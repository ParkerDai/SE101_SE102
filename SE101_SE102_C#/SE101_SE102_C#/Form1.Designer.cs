namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblNetmask = new System.Windows.Forms.Label();
            this.lblGateway = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.lblAP = new System.Windows.Forms.Label();
            this.lblKernel = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定 = new System.Windows.Forms.ToolStripMenuItem();
            this.內網環境建置 = new System.Windows.Forms.ToolStripMenuItem();
            this.檢視 = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟Monitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtAPname = new System.Windows.Forms.TextBox();
            this.inviteTmr = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdRestoreAP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRTCstatus = new System.Windows.Forms.TextBox();
            this.cmdRTCtest = new System.Windows.Forms.Button();
            this.cmdChgModel = new System.Windows.Forms.Button();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.cmdCloseIn = new System.Windows.Forms.Button();
            this.cmdInvite = new System.Windows.Forms.Button();
            this.開啟網頁 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHostname);
            this.groupBox1.Controls.Add(this.lblNetmask);
            this.groupBox1.Controls.Add(this.lblGateway);
            this.groupBox1.Controls.Add(this.lblIP);
            this.groupBox1.Controls.Add(this.lblMac);
            this.groupBox1.Controls.Add(this.lblAP);
            this.groupBox1.Controls.Add(this.lblKernel);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 165);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblHostname.Location = new System.Drawing.Point(273, 112);
            this.lblHostname.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(71, 16);
            this.lblHostname.TabIndex = 7;
            this.lblHostname.Text = "Hostname";
            // 
            // lblNetmask
            // 
            this.lblNetmask.AutoSize = true;
            this.lblNetmask.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNetmask.Location = new System.Drawing.Point(273, 60);
            this.lblNetmask.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblNetmask.Name = "lblNetmask";
            this.lblNetmask.Size = new System.Drawing.Size(63, 16);
            this.lblNetmask.TabIndex = 6;
            this.lblNetmask.Text = "Netmask";
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblGateway.Location = new System.Drawing.Point(273, 86);
            this.lblGateway.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(63, 16);
            this.lblGateway.TabIndex = 5;
            this.lblGateway.Text = "Gateway";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblIP.Location = new System.Drawing.Point(9, 86);
            this.lblIP.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(21, 16);
            this.lblIP.TabIndex = 4;
            this.lblIP.Text = "IP";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMac.Location = new System.Drawing.Point(9, 60);
            this.lblMac.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(35, 16);
            this.lblMac.TabIndex = 3;
            this.lblMac.Text = "Mac";
            // 
            // lblAP
            // 
            this.lblAP.AutoSize = true;
            this.lblAP.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAP.Location = new System.Drawing.Point(9, 138);
            this.lblAP.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(27, 16);
            this.lblAP.TabIndex = 2;
            this.lblAP.Text = "AP";
            // 
            // lblKernel
            // 
            this.lblKernel.AutoSize = true;
            this.lblKernel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblKernel.Location = new System.Drawing.Point(9, 112);
            this.lblKernel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblKernel.Name = "lblKernel";
            this.lblKernel.Size = new System.Drawing.Size(50, 16);
            this.lblKernel.TabIndex = 1;
            this.lblKernel.Text = "Kernel";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblModel.Location = new System.Drawing.Point(6, 18);
            this.lblModel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(98, 32);
            this.lblModel.TabIndex = 0;
            this.lblModel.Text = "Model";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定,
            this.檢視});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定
            // 
            this.設定.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.內網環境建置});
            this.設定.Name = "設定";
            this.設定.Size = new System.Drawing.Size(43, 20);
            this.設定.Text = "設定";
            // 
            // 內網環境建置
            // 
            this.內網環境建置.Name = "內網環境建置";
            this.內網環境建置.Size = new System.Drawing.Size(146, 22);
            this.內網環境建置.Text = "內網環境建置";
            this.內網環境建置.Click += new System.EventHandler(this.內網環境建置_Click);
            // 
            // 檢視
            // 
            this.檢視.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟Monitor,
            this.開啟網頁});
            this.檢視.Name = "檢視";
            this.檢視.Size = new System.Drawing.Size(43, 20);
            this.檢視.Text = "檢視";
            // 
            // 開啟Monitor
            // 
            this.開啟Monitor.Name = "開啟Monitor";
            this.開啟Monitor.Size = new System.Drawing.Size(152, 22);
            this.開啟Monitor.Text = "開啟 Monitor";
            this.開啟Monitor.Click += new System.EventHandler(this.開啟Monitor_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ShowAlways = true;
            // 
            // txtAPname
            // 
            this.txtAPname.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAPname.Location = new System.Drawing.Point(232, 21);
            this.txtAPname.Name = "txtAPname";
            this.txtAPname.Size = new System.Drawing.Size(140, 23);
            this.txtAPname.TabIndex = 29;
            this.toolTip1.SetToolTip(this.txtAPname, "Firmware檔名(不含副檔名)");
            // 
            // inviteTmr
            // 
            this.inviteTmr.Interval = 1000;
            this.inviteTmr.Tick += new System.EventHandler(this.inviteTmr_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.cmdChgModel);
            this.groupBox2.Controls.Add(this.cmbCountry);
            this.groupBox2.Controls.Add(this.cmdGo);
            this.groupBox2.Controls.Add(this.cmdCloseIn);
            this.groupBox2.Controls.Add(this.cmdInvite);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 154);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdRestoreAP);
            this.groupBox3.Controls.Add(this.txtAPname);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtRTCstatus);
            this.groupBox3.Controls.Add(this.cmdRTCtest);
            this.groupBox3.Location = new System.Drawing.Point(6, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 56);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RTC test";
            // 
            // cmdRestoreAP
            // 
            this.cmdRestoreAP.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRestoreAP.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdRestoreAP.Location = new System.Drawing.Point(378, 18);
            this.cmdRestoreAP.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmdRestoreAP.Name = "cmdRestoreAP";
            this.cmdRestoreAP.Size = new System.Drawing.Size(75, 30);
            this.cmdRestoreAP.TabIndex = 30;
            this.cmdRestoreAP.Text = "Restore";
            this.cmdRestoreAP.UseVisualStyleBackColor = true;
            this.cmdRestoreAP.Click += new System.EventHandler(this.cmdRestoreAP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "AP firmware:";
            // 
            // txtRTCstatus
            // 
            this.txtRTCstatus.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRTCstatus.Location = new System.Drawing.Point(87, 18);
            this.txtRTCstatus.Multiline = true;
            this.txtRTCstatus.Name = "txtRTCstatus";
            this.txtRTCstatus.ReadOnly = true;
            this.txtRTCstatus.Size = new System.Drawing.Size(45, 30);
            this.txtRTCstatus.TabIndex = 27;
            this.txtRTCstatus.TabStop = false;
            this.txtRTCstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdRTCtest
            // 
            this.cmdRTCtest.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRTCtest.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdRTCtest.Location = new System.Drawing.Point(6, 18);
            this.cmdRTCtest.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmdRTCtest.Name = "cmdRTCtest";
            this.cmdRTCtest.Size = new System.Drawing.Size(75, 30);
            this.cmdRTCtest.TabIndex = 26;
            this.cmdRTCtest.Text = "RTC Test";
            this.cmdRTCtest.UseVisualStyleBackColor = true;
            this.cmdRTCtest.Click += new System.EventHandler(this.cmdRTCtest_Click);
            // 
            // cmdChgModel
            // 
            this.cmdChgModel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdChgModel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdChgModel.Location = new System.Drawing.Point(93, 19);
            this.cmdChgModel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmdChgModel.Name = "cmdChgModel";
            this.cmdChgModel.Size = new System.Drawing.Size(142, 30);
            this.cmdChgModel.TabIndex = 29;
            this.cmdChgModel.Text = "To new model";
            this.cmdChgModel.UseVisualStyleBackColor = true;
            this.cmdChgModel.Click += new System.EventHandler(this.cmdChgModel_Click);
            // 
            // cmbCountry
            // 
            this.cmbCountry.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(241, 20);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(183, 27);
            this.cmbCountry.TabIndex = 28;
            // 
            // cmdGo
            // 
            this.cmdGo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGo.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdGo.Location = new System.Drawing.Point(430, 19);
            this.cmdGo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(45, 30);
            this.cmdGo.TabIndex = 27;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // cmdCloseIn
            // 
            this.cmdCloseIn.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCloseIn.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdCloseIn.Location = new System.Drawing.Point(12, 55);
            this.cmdCloseIn.Name = "cmdCloseIn";
            this.cmdCloseIn.Size = new System.Drawing.Size(75, 30);
            this.cmdCloseIn.TabIndex = 26;
            this.cmdCloseIn.Text = "Close invite";
            this.cmdCloseIn.UseVisualStyleBackColor = true;
            this.cmdCloseIn.Click += new System.EventHandler(this.cmdCloseIn_Click);
            // 
            // cmdInvite
            // 
            this.cmdInvite.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInvite.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmdInvite.Location = new System.Drawing.Point(12, 19);
            this.cmdInvite.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.cmdInvite.Name = "cmdInvite";
            this.cmdInvite.Size = new System.Drawing.Size(75, 30);
            this.cmdInvite.TabIndex = 25;
            this.cmdInvite.Text = "&Invite";
            this.cmdInvite.UseVisualStyleBackColor = true;
            this.cmdInvite.Click += new System.EventHandler(this.cmdInvite_Click);
            // 
            // 開啟網頁
            // 
            this.開啟網頁.Name = "開啟網頁";
            this.開啟網頁.Size = new System.Drawing.Size(152, 22);
            this.開啟網頁.Text = "開啟 網頁";
            this.開啟網頁.Click += new System.EventHandler(this.開啟網頁_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 360);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檢視;
        private System.Windows.Forms.ToolStripMenuItem 設定;
        private System.Windows.Forms.ToolStripMenuItem 內網環境建置;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblNetmask;
        private System.Windows.Forms.Label lblGateway;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.Label lblAP;
        private System.Windows.Forms.Label lblKernel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Timer inviteTmr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.Button cmdCloseIn;
        private System.Windows.Forms.Button cmdInvite;
        private System.Windows.Forms.Button cmdChgModel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdRTCtest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRTCstatus;
        private System.Windows.Forms.Button cmdRestoreAP;
        private System.Windows.Forms.TextBox txtAPname;
        private System.Windows.Forms.ToolStripMenuItem 開啟Monitor;
        private System.Windows.Forms.ToolStripMenuItem 開啟網頁;
    }
}

