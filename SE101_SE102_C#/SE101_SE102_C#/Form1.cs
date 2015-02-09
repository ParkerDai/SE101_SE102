using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // http://terence-mak.blogspot.tw/2012/06/netparametersexe.html
        // 如何接收外部傳入的 Parameters
        string[] Parameters;

        public Form1(string[] args)
        {
            InitializeComponent();
            Parameters = args;
        }

        //todo: C#取得主程式路徑(Application Path)
        string appPATH = System.Windows.Forms.Application.StartupPath;

        public const int UDPport = 55954;
        Process proc;
        UdpClient udpClient;
        Thread udpRcvThread;
        string targetIP;
        string displayIP, displayGateway, displayNetmask, displayHostname, displayMAC, displayModel, displayKernel, displayAP;
        string model_name;

        private int Shell(string FilePath, string FileName)
        {
            try
            {
                ////////////////////// like VB 【shell】 ///////////////////////
                //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                proc.EnableRaisingEvents = false;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = FilePath + "\\" + FileName;
                proc.Start();
                return proc.Id;
                ////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ' " + FileName + " ' ", "Shell error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void CloseShell(int pid)
        {
            //if (!Process.GetProcessById(pid).HasExited)
            //{
            //    // Close process by sending a close message to its main window.
            //    Process.GetProcessById(pid).CloseMainWindow();
            //    Process.GetProcessById(pid).WaitForExit(3000);
            //}
            if (!Process.GetProcessById(pid).HasExited)
            {
                Process.GetProcessById(pid).Kill();
                Process.GetProcessById(pid).WaitForExit(1000);
            }
        }

        private void CleanARP()
        {
            try
            {
                Shell(appPATH, "arp-d.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CleanARP error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Hold(long timeout)
        {
            bool tmp_Hold = true;
            long delay = 0;
            if (timeout > 0) { delay = timeout / 10; }
            while (true)
            {
                Application.DoEvents();
                Thread.Sleep(10);
                if (timeout > 0)
                {
                    if (delay > 0)
                    {
                        delay -= 1;
                    }
                    else
                    {
                        tmp_Hold = false;   // 時間等到底
                        break;
                    }
                }
            }
            return tmp_Hold;
        }

        /// <summary>
        /// 驗證網段(Network segment)
        /// </summary>
        /// <param name="source"></param>
        /// <returns>規則運算式尋找到符合項目，則為 true，否則為 false</returns>
        public static bool IsNetworkSegment(string source)
        {
            // Regex.IsMatch 方法 (String, String, RegexOptions)
            // 表示指定的規則運算式是否使用指定的比對選項，在指定的輸入字串中尋找相符項目
            return Regex.IsMatch(source, @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 驗證IP
        /// </summary>
        /// <param name="source"></param>
        /// <returns>規則運算式尋找到符合項目，則為 true，否則為 false</returns>
        public static bool IsIP(string source)
        {
            // Regex.IsMatch 方法 (String, String, RegexOptions)
            // 表示指定的規則運算式是否使用指定的比對選項，在指定的輸入字串中尋找相符項目
            return Regex.IsMatch(source, @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.IgnoreCase);
        }

        public static bool HasIP(string source)
        {
            return Regex.IsMatch(source, @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 驗證 Model name
        /// </summary>
        /// <param name="source"></param>
        /// <returns>規則運算式尋找到符合項目，則為 true，否則為 false</returns>
        public static bool IsModelName(string source)
        {
            return Regex.IsMatch(source, @"[A-Z]{1}[A-Z]{1}[0-9]{1}(0|3|4|5|6|7|8|9){1}[0-9]{1}", RegexOptions.None); // ex: SE1902、SW550X
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmdInvite_Click(null, null);
            if (Parameters.Length < 1)
            {
                cmdChgModel.Enabled = false;
                this.Text = "未接收到批次檔傳送的參數(model name)";
                model_name = null;
            }
            else
            {
                model_name = Parameters[0];
                cmdChgModel.Text = "To " + model_name;
                this.Text = model_name;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmdInvite_Click(object sender, EventArgs e)
        {
            lblModel.Text = "Model";
            lblMac.Text = "Mac";
            lblIP.Text = "IP";
            lblKernel.Text = "Kernel";
            lblAP.Text = "AP";
            lblNetmask.Text = "Netmask";
            lblGateway.Text = "Gateway";
            lblHostname.Text = "Hostname";
            Hold(1);

            CleanARP();

            try
            {
                byte[] bdata = new byte[300];
                bdata[0] = 2;
                bdata[1] = 1;
                bdata[2] = 6;
                bdata[4] = Convert.ToByte(Convert.ToUInt64("92", 16)); //將十六進制轉換為十進制
                bdata[5] = Convert.ToByte(Convert.ToUInt64("DA", 16));
                IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Broadcast, UDPport);   // 目標 port
                // 背景接收執行緒
                if (udpRcvThread == null || !udpRcvThread.IsAlive)
                {
                    udpRcvThread = new Thread(new ThreadStart(ReceiveBroadcast));
                    udpRcvThread.IsBackground = true;
                    udpRcvThread.Priority = ThreadPriority.Highest;
                    udpRcvThread.Start();
                }

                if (!PortInUse(UDPport))  // 判斷 local port 是否占用中
                {
                    udpClient = new UdpClient(UDPport); // 未使用就綁定 local port
                    udpClient.Send(bdata, bdata.Length, ipEndpoint);
                }
                else
                {
                    udpClient.Send(bdata, bdata.Length, ipEndpoint);
                }

                inviteTmr.Interval = 100;
                inviteTmr.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請關掉 Serial Manager、Monitor、Device Manager 之類的程式 !\n" + "\n" + ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// todo: 判斷指定的本機 Udp 端口（只判斷端口）是否被占用
        /// </summary>
        public bool PortInUse(int port)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveUdpListeners();
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    return true;    // 占用中
                }
            }
            return false;
        }

        public void ReceiveBroadcast()
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, UDPport);
                aLabel:
                while (true)
                {
                    byte[] bytes = udpClient.Receive(ref ip);
                    if ((bytes[0] == 1 || bytes[0] == 3) && bytes[4] == Convert.ToByte(Convert.ToUInt64("92", 16)) && bytes[5] == Convert.ToByte(Convert.ToUInt64("DA", 16)))
                    {
                        string tmpstr = string.Empty;
                        int i;

                        // get Model
                        displayModel = DecToChar(bytes, 44, 16);
                        // get MAC
                        displayMAC = TenToSixteen(bytes, 28, 6).ToUpper();
                        // get IP
                        targetIP = Convert.ToString(bytes[12] + "." + bytes[13] + "." + bytes[14] + "." + bytes[15]);
                        displayIP = targetIP;
                        for (i = targetIP.Length; i <= 15; i++)
                        {
                            displayIP = displayIP + " ";
                        }
                        // get Kernel
                        displayKernel = Convert.ToString(bytes[109] + "." + bytes[108]);
                        // get AP version
                        displayAP = DecToChar(bytes, 110, 125);
                        // get Netmask
                        displayNetmask = Convert.ToString(bytes[236] + "." + bytes[237] + "." + bytes[238] + "." + bytes[239]);
                        // get Gateway
                        displayGateway = Convert.ToString(bytes[24] + "." + bytes[25] + "." + bytes[26] + "." + bytes[27]);
                        // get Hostname
                        displayHostname = DecToChar(bytes, 90, 16);

                        //if (model_name != null)
                        //{
                        //    if (!displayModel.Contains(model_name))     // 指定 Model
                        //    {
                        //        goto aLabel;
                        //    }
                        //}

                        this.Invoke(new EventHandler(Lable_Display));
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Lable_Display(object sender, EventArgs e)
        {
            lblModel.Text = "Model: " + displayModel;
            lblMac.Text = "Mac: " + displayMAC;
            lblIP.Text = "IP: " + displayIP;
            lblKernel.Text = "Kernel: " + displayKernel;
            lblAP.Text = "AP: " + displayAP;
            lblGateway.Text = "Gateway: " + displayGateway;
            lblNetmask.Text = "Netmask: " + displayNetmask;
            lblHostname.Text = "Hostname: " + displayHostname;

            cmbCountry.Items.Clear();
            cmbCountry.Text = string.Empty;
            if (displayModel.Contains("SE101"))
            {
                txtAPname.Text = "SE50021M_v3572";
                cmbCountry.Items.Add("test_422_1M");
                cmbCountry.Items.Add("test_485_1M");
                cmbCountry.SelectedIndex = 1;
            }
            else if (displayModel.Contains("SE102"))
            {
                txtAPname.Text = "SE5002_v3572";
                cmbCountry.Items.Add("test_422");
                cmbCountry.Items.Add("test_485");
                cmbCountry.SelectedIndex = 1;
            }
            else
            {
                txtAPname.Text = string.Empty;
            }
        }

        // 1.委派delegate 宣告
        public delegate void myListBoxCallBack(string Str, ListBox ctl);

        // 2.設計delegate可供媒介的功能
        public void mylstDev(string Str, ListBox ctl)
        {
            if (this.InvokeRequired)
            {
                // 3.建構delegate型別的物件
                myListBoxCallBack myUpdate = new myListBoxCallBack(mylstDev);
                this.Invoke(myUpdate, Str, ctl);
            }
            else
            {
                ctl.Items.Add(Str);
            }
        }

        public delegate void myUICallBack(string Str, Control ctl);

        public void myText(string Str, Control ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack myUpdate = new myUICallBack(myText);
                this.Invoke(myUpdate, Str, ctl);
            }
            else
            {
                ctl.Text = Str;
            }
        }

        public string TenToSixteen(byte[] bdata, int Start, int Count)
        {
            int i;
            string op_str = string.Empty;
            string tmpstr = string.Empty;
            int EndNum = Start + Count;
            for (i = Start; i < EndNum; i++)
            {
                tmpstr = Convert.ToString(bdata[i], 16); //十進制轉十六進制,Convert.ToString(166, 16));
                if (tmpstr.Length < 2)
                {
                    tmpstr = "0" + tmpstr;
                }
                op_str = op_str + tmpstr;
            }
            return op_str;
        }

        public string DecToChar(byte[] bdata, int Start, int Count)
        {
            int i;
            string op_str = string.Empty;
            int EndNum = Start + Count;
            for (i = Start; i < EndNum; i++)
            {
                short ch = bdata[i];
                if (ch == 0)
                {
                    break;
                } // break for
                op_str = op_str + Convert.ToChar(ch); // vb6,ChrW() => c#,Convert.ToChar()
            }
            return op_str;
        }

        private void 內網環境建置_Click(object sender, EventArgs e)
        {
            Shell(appPATH, "LAN_setting.bat");
        }

        private void cmdCloseIn_Click(object sender, EventArgs e)
        {
            if (udpClient != null)
            {
                udpClient.Close();
            }
        }

        private void inviteTmr_Tick(object sender, EventArgs e)
        {
            byte[] bdata = new byte[300];
            bdata[0] = 2;
            bdata[1] = 1;
            bdata[2] = 6;
            bdata[4] = Convert.ToByte(Convert.ToUInt64("92", 16)); //將十六進制轉換為十進制
            bdata[5] = Convert.ToByte(Convert.ToUInt64("DA", 16));
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Broadcast, UDPport);   // 目標 port

            if (!PortInUse(UDPport))  // 判斷 local port 是否占用中
            {
                udpClient = new UdpClient(UDPport); // 未使用就綁定 local port
                udpClient.Send(bdata, bdata.Length, ipEndpoint);
            }
            else
            {
                udpClient.Send(bdata, bdata.Length, ipEndpoint);
            }
            // 背景接收執行緒
            if (udpRcvThread == null || !udpRcvThread.IsAlive)
            {
                udpRcvThread = new Thread(new ThreadStart(ReceiveBroadcast));
                udpRcvThread.IsBackground = true;
                udpRcvThread.Priority = ThreadPriority.Highest;
                udpRcvThread.Start();
            }

            inviteTmr.Enabled = false;
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(displayKernel) < 2.0)
            {
                MessageBox.Show("Please upgrade the kernel to 2.0 or later.     ", "warning");
                return;
            }

            RUN(cmbCountry.Text + ".HEX");
        }

        private void RUN(string fn)
        {
            if (File.Exists(appPATH + @"\download\" + fn))
            {
                string batFile = appPATH + @"\download\" + "run.bat";
                using (StreamWriter sw = new StreamWriter(batFile, false, Encoding.Default))
                {
                    sw.WriteLine("gwdl " + targetIP + " " + fn + " admin");
                }

                ProcessStartInfo Info2 = new ProcessStartInfo();
                // 執行的檔案名稱
                Info2.FileName = "run.bat";
                // 執行的檔案所在的目錄
                Info2.WorkingDirectory = appPATH + @"\download";
                Process.Start(Info2);
            }
            else
            {
                MessageBox.Show(appPATH + @"\download\" + fn + "\n\n指定的檔案在該路徑不存在。", "error");
            }
        }

        private void cmdChgModel_Click(object sender, EventArgs e)
        {
            RUN(model_name + ".HEX");
        }

        private void cmdRTCtest_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(displayKernel) < 2.0)
            {
                MessageBox.Show("Please upgrade the kernel to 2.0 or later.     ", "warning");
                return;
            }

            if (File.Exists(appPATH + @"\download\" + "se5002_rtc" + ".HEX"))
            {
                RUN("se5002_rtc" + ".HEX");
            }
            else
            {
                MessageBox.Show(appPATH + @"\download\" + "se5002_rtc" + ".HEX" + "\n\n指定的檔案在該路徑不存在。", "error");
                return;
            }

            Hold(12000);
            cmdInvite_Click(null, null);
            string t1 = displayAP.Substring(38);
            //Debug.Print(t1);
            Hold(5000);
            cmdInvite_Click(null, null);
            Hold(2000);
            string t2 = displayAP.Substring(38);
            //Debug.Print(t2);
            if (Convert.ToInt32(t2) - Convert.ToInt32(t1) >= 5)
            {
                txtRTCstatus.Text = "OK";
            }
            else
            {
                txtRTCstatus.Text = "Fail";
            }
        }

        private void cmdRestoreAP_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(displayKernel) < 2.0)
            {
                MessageBox.Show("Please upgrade the kernel to 2.0 or later.     ", "warning");
                return;
            }

            RUN(txtAPname.Text + ".HEX");
        }

        private void 開啟Monitor_Click(object sender, EventArgs e)
        {
            Shell(appPATH, "monitor2.5.exe");
        }

        private void 開啟網頁_Click(object sender, EventArgs e)
        {
            if (targetIP != null)
            {
                try
                {
                    System.Diagnostics.Process.Start("http://" + targetIP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "warning");
                }
            }
        }
    }
}