:start
%comspec% /c SE101SE102.exe SE102-MST
pause
%comspec% /c gwcfg
pause
%comspec% /c RemindMessage.exe
pause
goto start