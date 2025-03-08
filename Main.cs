using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASPAS
{
    public partial class Main : Form
    {
        private int MoveCP;
        private int MapX;
        private int MapY;
        private int FileCount = 0;
        private int RejectCount = 0;
        private int AccessError = 0;
        private int SelectedThread;
        private readonly string SystemDirectory = Path.GetPathRoot(Environment.SystemDirectory);
        private readonly Dictionary<string, string> folderIndex = new()
        {
            { "WinTemp", "/Windows/TEMP" },
            { "WinTemp2", "/Users/" + Environment.UserName + "/AppData/Local/Temp" },
            { "DownloadedInstallations", "/Users/" + Environment.UserName + "/AppData/Roaming/Downloaded Installations" },
            { "CryptnetUrlCacheContent", "/Windows/System32/config/systemprofile/AppData/LocalLow/Microsoft/CryptnetUrlCache/Content"},
            { "CryptnetUrlCacheMetaData", "/Windows/System32/config/systemprofile/AppData/LocalLow/Microsoft/CryptnetUrlCache/MetaData"},
            { "NetworkServiceTemp", "/Windows/ServiceProfiles/NetworkService/AppData/Local/Temp"},
            { "TokenBrokerCache", "/Users/" + Environment.UserName + "/AppData/Local/Microsoft/TokenBroker/Cache"},
            { "waasmedicLog", "/Windows/Logs/waasmedic"},
            { "NetSetupLog", "/Windows/Logs/NetSetup"},
            { "ReportArchive", "/ProgramData/Microsoft/Windows/WER/ReportArchive"},
            { "ReportQueue", "/ProgramData/Microsoft/Windows/WER/ReportQueue"},
            { "WERTemp", "/ProgramData/Microsoft/Windows/WER/Temp"},
            { "RecentFiles", "/Users/" + Environment.UserName + "/AppData/Roaming/Microsoft/Windows/Recent" },
            { "RecentFiles2", "/Users/" + Environment.UserName + "/AppData/Roaming/Microsoft/Windows/Recent/AutomaticDestinations" },
            { "RecentFiles3", "/Users/" + Environment.UserName + "/AppData/Roaming/Microsoft/Windows/Recent/CustomDestinations" },
            { "PreviewCache", "/Users/" + Environment.UserName + "/AppData/Local/Microsoft/Windows/Explorer" },
            { "Logs", "/Windows/SoftwareDistribution/DataStore/Logs" },
            { "Logs2", "/Windows/System32/wbem/Logs" },
            { "UpdateReport", "/Windows/SoftwareDistribution/" },
            { "SystemCache", "/Users/" + Environment.UserName + "/AppData/Local/Microsoft/Windows/Explorer" },
            { "LiveKernelReports", "/Windows/LiveKernelReports" },
            { "LiveKernelNDIS", "/Windows/LiveKernelReports/NDIS" },
            { "CrashDumps", "/Users/" + Environment.UserName + "/AppData/Local/CrashDumps" },
            { "MiniDumps", "/Windows/Minidump" },
            { "Prefetch", "/Windows/Prefetch" },
            { "DownloadCache", "/Windows/SoftwareDistribution/Download" },
            { "FontCache", "/Windows/System32" },
            { "OldWindows", "/$Windows.old" }
        };
        private readonly string[] temporaryExtensions = [".tmp", ".log", ".txt", ".dat", ".iss", ".exe", ".ini", ".vbs", ".cvr", ".od", ".lnk", ".js", ".5f2", ".jro", ".41u", ".w0y", ".vmo", ".tmp", ".log", ".txt", ".dat", ".iss", ".exe", ".ini", ".vbs", ".cvr", ".od", ".lnk", ".js", ".5f2", ".jro", ".41u", ".w0y", ".diagsession", ".png", ".jpg", ".jpeg", ".q13", ".2im", ".html", ".rcl", ".5ar", ".xml", ".dll", ".Mtx", ".5f2", ".jro", ".41u", ".w0y"];
        private readonly Dictionary<string, string> serviceConfigurations = new()
        {
            { "InstallService", "Manual" },
            { "InventorySvc", "Manual" },
            { "IpxlatCfgSvc", "Manual" },
            { "KeyIso", "Automatic" },
            { "KtmRm", "Manual" },
            { "LSM", "Automatic" },
            { "LanmanServer", "Automatic" },
            { "LanmanWorkstation", "Automatic" },
            { "LicenseManager", "Manual" },
            { "LxpSvc", "Manual" },
            { "MSDTC", "Manual" },
            { "MSiSCSI", "Manual" },
            { "MapsBroker", "AutomaticDelayedStart" },
            { "McpManagementService", "Manual" },
            { "MessagingService_*", "Manual" },
            { "MicrosoftEdgeElevationService", "Manual" },
            { "MixedRealityOpenXRSvc", "Manual" },
            { "MpsSvc", "Automatic" },
            { "MsKeyboardFilter", "Manual" },
            { "NPSMSvc_*", "Manual" },
            { "NaturalAuthentication", "Manual" },
            { "NcaSvc", "Manual" },
            { "NcbService", "Manual" },
            { "NcdAutoSetup", "Manual" },
            { "NetSetupSvc", "Manual" },
            { "NetTcpPortSharing", "Disabled" },
            { "Netlogon", "Automatic" },
            { "Netman", "Manual" },
            { "NgcCtnrSvc", "Manual" },
            { "NgcSvc", "Manual" },
            { "NlaSvc", "Manual" },
            { "OneSyncSvc_*", "Automatic" },
            { "P9RdrService_*", "Manual" },
            { "PNRPAutoReg", "Manual" },
            { "PNRPsvc", "Manual" },
            { "PcaSvc", "Manual" },
            { "PeerDistSvc", "Manual" },
            { "PenService_*", "Manual" },
            { "PerfHost", "Manual" },
            { "PhoneSvc", "Manual" },
            { "PimIndexMaintenanceSvc_*", "Manual" },
            { "PlugPlay", "Manual" },
            { "PolicyAgent", "Manual" },
            { "Power", "Automatic" },
            { "PrintNotify", "Manual" },
            { "PrintWorkflowUserSvc_*", "Manual" },
            { "ProfSvc", "Automatic" },
            { "PushToInstall", "Manual" },
            { "QWAVE", "Manual" },
            { "RasAuto", "Manual" },
            { "RasMan", "Manual" },
            { "RemoteAccess", "Disabled" },
            { "RemoteRegistry", "Disabled" },
            { "RetailDemo", "Manual" },
            { "RmSvc", "Manual" },
            { "RpcEptMapper", "Automatic" },
            { "RpcLocator", "Manual" },
            { "RpcSs", "Automatic" },
            { "SCPolicySvc", "Manual" },
            { "SCardSvr", "Manual" },
            { "SDRSVC", "Manual" },
            { "SEMgrSvc", "Manual" },
            { "SENS", "Automatic" },
            { "SNMPTRAP", "Manual" },
            { "SNMPTrap", "Manual" },
            { "SSDPSRV", "Manual" },
            { "SamSs", "Automatic" },
            { "ScDeviceEnum", "Manual" },
            { "Schedule", "Automatic" },
            { "SecurityHealthService", "Manual" },
            { "Sense", "Manual" },
            { "SensorDataService", "Manual" },
            { "SensorService", "Manual" },
            { "SensrSvc", "Manual" },
            { "SessionEnv", "Manual" },
            { "SgrmBroker", "Automatic" },
            { "SharedAccess", "Manual" },
            { "SharedRealitySvc", "Manual" },
            { "ShellHWDetection", "Automatic" },
            { "SmsRouter", "Manual" },
            { "Spooler", "Automatic" },
            { "SstpSvc", "Manual" },
            { "StateRepository", "Manual" },
            { "StiSvc", "Manual" },
            { "StorSvc", "Manual" },
            { "SysMain", "Automatic" },
            { "SystemEventsBroker", "Automatic" },
            { "TabletInputService", "Manual" },
            { "TapiSrv", "Manual" },
            { "TermService", "Automatic" },
            { "TextInputManagementService", "Manual" },
            { "Themes", "Automatic" },
            { "TieringEngineService", "Manual" },
            { "TimeBroker", "Manual" },
            { "TimeBrokerSvc", "Manual" },
            { "TokenBroker", "Manual" },
            { "TrkWks", "Automatic" },
            { "TroubleshootingSvc", "Manual" },
            { "TrustedInstaller", "Manual" },
            { "UI0Detect", "Manual" },
            { "UdkUserSvc_*", "Manual" },
            { "UevAgentService", "Disabled" },
            { "UmRdpService", "Manual" },
            { "UnistoreSvc_*", "Manual" },
            { "UserDataSvc_*", "Manual" },
            { "UserManager", "Automatic" },
            { "UsoSvc", "Manual" },
            { "VGAuthService", "Automatic" },
            { "VMTools", "Automatic" },
            { "VSS", "Manual" },
            { "VacSvc", "Manual" },
            { "VaultSvc", "Automatic" },
            { "W32Time", "Manual" },
            { "WEPHOSTSVC", "Manual" },
            { "WFDSConMgrSvc", "Manual" },
            { "WMPNetworkSvc", "Manual" },
            { "WManSvc", "Manual" },
            { "WPDBusEnum", "Manual" },
            { "WSService", "Manual" },
            { "WSearch", "AutomaticDelayedStart" },
            { "WaaSMedicSvc", "Manual" },
            { "WalletService", "Manual" },
            { "WarpJITSvc", "Manual" },
            { "WbioSrvc", "Manual" },
            { "Wcmsvc", "Automatic" },
            { "WcsPlugInService", "Manual" },
            { "WdNisSvc", "Manual" },
            { "WdiServiceHost", "Manual" },
            { "WdiSystemHost", "Manual" },
            { "WebClient", "Manual" },
            { "Wecsvc", "Manual" },
            { "WerSvc", "Manual" },
            { "WiaRpc", "Manual" },
            { "WinDefend", "Automatic" },
            { "WinHttpAutoProxySvc", "Manual" },
            { "WinRM", "Manual" },
            { "Winmgmt", "Automatic" },
            { "WlanSvc", "Automatic" },
            { "WpcMonSvc", "Manual" },
            { "WpnService", "Manual" },
            { "WpnUserService_*", "Automatic" },
            { "XblAuthManager", "Manual" },
            { "XblGameSave", "Manual" },
            { "XboxGipSvc", "Manual" },
            { "XboxNetApiSvc", "Manual" },
            { "autotimesvc", "Manual" },
            { "bthserv", "Manual" },
            { "camsvc", "Manual" },
            { "cbdhsvc_*", "Manual" },
            { "cloudidsvc", "Manual" },
            { "dcsvc", "Manual" },
            { "defragsvc", "Manual" },
            { "diagnosticshub.standardcollector.service", "Manual" },
            { "diagsvc", "Manual" },
            { "dmwappushservice", "Manual" },
            { "dot3svc", "Manual" },
            { "edgeupdate", "Manual" },
            { "edgeupdatem", "Manual" },
            { "embeddedmode", "Manual" },
            { "fdPHost", "Manual" },
            { "fhsvc", "Manual" },
            { "gpsvc", "Automatic" },
            { "hidserv", "Manual" },
            { "icssvc", "Manual" },
            { "iphlpsvc", "Automatic" },
            { "lfsvc", "Manual" },
            { "lltdsvc", "Manual" },
            { "lmhosts", "Manual" },
            { "mpssvc", "Automatic" },
            { "msiserver", "Manual" },
            { "netprofm", "Manual" },
            { "nsi", "Automatic" },
            { "p2pimsvc", "Manual" },
            { "p2psvc", "Manual" },
            { "perceptionsimulation", "Manual" },
            { "pla", "Manual" },
            { "seclogon", "Manual" },
            { "shpamsvc", "Disabled" },
            { "smphost", "Manual" },
            { "spectrum", "Manual" },
            { "sppsvc", "AutomaticDelayedStart" },
            { "ssh-agent", "Disabled" },
            { "svsvc", "Manual" },
            { "swprv", "Manual" },
            { "tiledatamodelsvc", "Automatic" },
            { "tzautoupdate", "Disabled" },
            { "uhssvc", "Disabled" },
            { "upnphost", "Manual" },
            { "vds", "Manual" },
            { "vm3dservice", "Manual" },
            { "vmicguestinterface", "Manual" },
            { "vmicheartbeat", "Manual" },
            { "vmickvpexchange", "Manual" },
            { "vmicrdv", "Manual" },
            { "vmicshutdown", "Manual" },
            { "vmictimesync", "Manual" },
            { "vmicvmsession", "Manual" },
            { "vmicvss", "Manual" },
            { "vmvss", "Manual" },
            { "wbengine", "Manual" },
            { "wcncsvc", "Manual" },
            { "webthreatdefsvc", "Manual" },
            { "webthreatdefusersvc_*", "Automatic" },
            { "wercplsupport", "Manual" },
            { "wisvc", "Manual" },
            { "wlidsvc", "Manual" },
            { "wlpasvc", "Manual" },
            { "wmiApSrv", "Manual" },
            { "workfolderssvc", "Manual" },
            { "wscsvc", "AutomaticDelayedStart" },
            { "wuauserv", "Manual" },
            { "wudfsvc", "Manual" }
        };
        private readonly string[] telemetryCommands =
            [
                "bcdedit /set {current} bootmenupolicy Legacy | Out-Null",
                "If ((get-ItemProperty -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion' -Name CurrentBuild).CurrentBuild -lt 22557) { $taskmgr = Start-Process -WindowStyle Hidden -FilePath taskmgr.exe -PassThru; Do { Start-Sleep -Milliseconds 100; $preferences = Get-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\TaskManager' -Name 'Preferences' -ErrorAction SilentlyContinue; } Until ($preferences); Stop-Process $taskmgr; $preferences.Preferences[28] = 0; Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\TaskManager' -Name 'Preferences' -Type Binary -Value $preferences.Preferences }",
                "Remove-Item -Path 'HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}' -Recurse -ErrorAction SilentlyContinue",
                "If (Test-Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Edge') { Remove-Item -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Edge' -Recurse -ErrorAction SilentlyContinue }",
                "$ram = (Get-CimInstance -ClassName Win32_PhysicalMemory | Measure-Object -Property Capacity -Sum).Sum / 1kb",
                "Set-ItemProperty -Path 'HKLM:\\SYSTEM\\CurrentControlSet\\Control' -Name 'SvcHostSplitThresholdInKB' -Type DWord -Value $ram -Force",
                "$autoLoggerDir = '$env:PROGRAMDATA\\Microsoft\\Diagnosis\\ETLLogs\\AutoLogger'",
                "If (Test-Path '$autoLoggerDir\\AutoLogger-Diagtrack-Listener.etl') { Remove-Item '$autoLoggerDir\\AutoLogger-Diagtrack-Listener.etl' }",
                "icacls $autoLoggerDir /deny SYSTEM:(OI)(CI)F | Out-Null",
                "Set-MpPreference -SubmitSamplesConsent 2 -ErrorAction SilentlyContinue | Out-Null"
            ];
        private readonly string[] activityHistoryCommands =
        [
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'EnableActivityFeed' -Value 0 -Type DWord -Force",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'PublishUserActivities' -Value 0 -Type DWord -Force",
                "Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System' -Name 'UploadUserActivities' -Value 0 -Type DWord -Force"
        ];
        public Main()
        {
            InitializeComponent();
        }

        private void PASPAS_Main_Shown(object sender, EventArgs e) => DarkModeSwitch();
        private void PASPAS_Main_Load(object sender, EventArgs e)
        {
            SelectedThread = Properties.Settings.Default.SelectedThread;
            if (SelectedThread == 0) { }
            else if (SelectedThread == 1)
            {
                Basic_select.Checked = true;
            }
            else if (SelectedThread == 2)
            {
                Advanced_select.Checked = true;
            }
            else if (SelectedThread == 3)
            {
                Special_select.Checked = true;
                SidePanel.Top = Home_btn.Top;
                SidePanel.Height = Home_btn.Height;
                Home_panel.BringToFront();
            }
            else
            {
                new Error().ShowDialog();
            }
            Clipboard_select.Checked = Properties.Settings.Default.Clipboard;
            TemporaryFiles_select.Checked = Properties.Settings.Default.TemporaryFiles;
            DownloadedInstallations_select.Checked = Properties.Settings.Default.DownloadedInstallations;
            RecentlyUsed_select.Checked = Properties.Settings.Default.RecentlyUsed;
            PreviewCache_select.Checked = Properties.Settings.Default.PreviewCache;
            DNSCache_select.Checked = Properties.Settings.Default.DNSCache;
            Logs_select.Checked = Properties.Settings.Default.Logs;
            SystemCache_select.Checked = Properties.Settings.Default.SystemCache;
            MemoryDumps_select.Checked = Properties.Settings.Default.MemoryDumps;
            Prefetch_select.Checked = Properties.Settings.Default.Prefetch;
            FontCache_select.Checked = Properties.Settings.Default.FontCache;
            DownloadCache_select.Checked = Properties.Settings.Default.DownloadCache;
            OldWindows_select.Checked = Properties.Settings.Default.OldWindows;
            SysLogErrorRep_select.Checked = Properties.Settings.Default.SysLogErrorRep;
        }
        private void Exit_Click(object sender, EventArgs e) => Application.Exit();
        private void Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void ControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MoveCP = 1;
            MapX = e.X;
            MapY = e.Y;
        }
        private void ControlPanel_MouseUp(object sender, MouseEventArgs e) => MoveCP = 0;
        private void ControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveCP == 1)
            {
                SetDesktopLocation(MousePosition.X - MapX, MousePosition.Y - MapY);
            }
        }
        private void Home_btn_Click(object sender, EventArgs e)
        {
            int top = Home_btn.Top;
            SidePanel.Top = top;
            SidePanel.Height = Home_btn.Height;
            Home_panel.BringToFront();
        }

        private void Options_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = Options_btn.Top;
            SidePanel.Height = Options_btn.Height;
            Options_panel.BringToFront();
        }

        private void Tweaks_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = Tweaks_btn.Top;
            SidePanel.Height = Tweaks_btn.Height;
            Tweaks_panel.BringToFront();
        }
        private void UninstallMenu_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = UninstallMenu_btn.Top;
            SidePanel.Height = UninstallMenu_btn.Height;
            Programs_panel.BringToFront();
        }
        private void About_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = About_btn.Top;
            SidePanel.Height = About_btn.Height;
            About_panel.BringToFront();
        }


        private static void CheckboxPropertySave(CheckBox checkbox, bool status, string property)
        {
            try
            {
                checkbox.Checked = status;
                Properties.Settings.Default[property] = status;
                Properties.Settings.Default.Save();

                if (status)
                {
                    checkbox.Text = "✓";
                    checkbox.BackColor = Color.Lime;
                    checkbox.ForeColor = Color.Black;
                }
                else
                {
                    checkbox.Text = "X";
                    checkbox.BackColor = Color.Red;
                    checkbox.ForeColor = Color.White;
                }
            }
            catch { }
        }
        private void Clipboard_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = Clipboard_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "Clipboard");
        }
        private void TemporaryFiles_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = TemporaryFiles_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "TemporaryFiles");
        }
        private void DownloadedInstallations_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = DownloadedInstallations_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "DownloadedInstallations");
        }
        private void RecentlyUsed_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = RecentlyUsed_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "RecentlyUsed");
        }
        private void PreviewCache_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = PreviewCache_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "PreviewCache");
        }
        private void DNSCache_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = DNSCache_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "DNSCache");
        }
        private void Logs_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = Logs_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "Logs");
        }
        private void SystemCache_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = SystemCache_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "SystemCache");
        }
        private void MemoryDumps_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = MemoryDumps_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "MemoryDumps");
        }
        private void Prefetch_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = Prefetch_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "Prefetch");
        }
        private void FontCache_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = FontCache_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "FontCache");
        }
        private void DownloadCache_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = DownloadCache_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "DownloadCache");
        }
        private void OldWindows_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = OldWindows_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "OldWindows");
        }
        private void SysLogErrorRep_select_CheckedChanged(object sender, EventArgs e)
        {
            bool status = SysLogErrorRep_select.Checked;
            CheckboxPropertySave((CheckBox)sender, status, "SysLogErrorRep");
        }
        private void Basic_select_CheckedChanged(object sender, EventArgs e)
        {
            SelectedThread = 1;
            Properties.Settings.Default.SelectedThread = SelectedThread;
            Properties.Settings.Default.Save();
            SidePanel.Top = Home_btn.Top;
            SidePanel.Height = Home_btn.Height;
            Home_panel.BringToFront();
        }
        private void Advanced_select_CheckedChanged(object sender, EventArgs e)
        {
            SelectedThread = 2;
            Properties.Settings.Default.SelectedThread = SelectedThread;
            Properties.Settings.Default.Save();
            SidePanel.Top = Home_btn.Top;
            SidePanel.Height = Home_btn.Height;
            Home_panel.BringToFront();
        }
        private void Special_select_CheckedChanged(object sender, EventArgs e)
        {
            SelectedThread = 3;
            Properties.Settings.Default.SelectedThread = SelectedThread;
            Properties.Settings.Default.Save();
            SidePanel.Top = Options_btn.Top;
            SidePanel.Height = Options_btn.Height;
            Options_panel.BringToFront();
        }

        private void ClipboardClear()
        {
            try
            {
                ProcessBox.Items.Add("");
                ProcessBox.Items.Add("--->cmd.exe");
                ProcessStartInfo startinfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "cmd /c echo off | clip"
                };
                ProcessBox.Items.Add("- " + startinfo.Arguments);
                ProcessBox.Items.Add("");
                new Process().StartInfo = startinfo;
                new Process().Start();
            }
            catch { RejectCount++; }
        }
        private void DNSCacheRefresh()
        {
            try
            {
                ProcessBox.Items.Add("");
                ProcessBox.Items.Add("--->cmd.exe");
                ProcessStartInfo startinfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c ipconfig /flushdns && ipconfig /release && ipconfig /renew"
                };
                ProcessBox.Items.Add("- " + startinfo.Arguments);
                ProcessBox.Items.Add("");
                new Process().StartInfo = startinfo;
                new Process().Start();
            }
            catch { RejectCount++; }
        }

        private void DeleteFiles(string directory, string extension)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Path.Combine(SystemDirectory, directory)))
                {
                    FileInfo fileinfo = new(file);
                    if (fileinfo.Extension.Equals(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        fileinfo.Delete();
                        if (!fileinfo.Exists)
                        {
                            FileCount++;
                            ProcessBox.Items.Add($"{FileCount} | {fileinfo.FullName}");
                        }
                        else
                        {
                            RejectCount++;
                        }
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void DeleteAllFiles(string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Path.Combine(SystemDirectory, directory)))
                {
                    FileInfo fileinfo = new(file);
                    fileinfo.Delete();
                    if (!fileinfo.Exists)
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {fileinfo.FullName}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void DeleteAllDirectories(string directory)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(Path.Combine(SystemDirectory, directory)))
                {
                    DirectoryInfo dirinfo = new(dir);
                    dirinfo.Delete(true);
                    if (!dirinfo.Exists)
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {dirinfo.FullName}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void AnalyzeFiles(string directory, string extension)
        {
            try
            {
                foreach (string file in Directory.GetFiles(Path.Combine(SystemDirectory, directory)))
                {
                    FileInfo fileinfo = new(file);
                    if (fileinfo.Extension.Equals(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        if (fileinfo.Exists)
                        {
                            FileCount++;
                            ProcessBox.Items.Add($"{FileCount} | {fileinfo.FullName}");
                        }
                        else
                        {
                            RejectCount++;
                        }
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void AnalyzeAllFiles(string directory)
        {
            try
            {
                FileInfo fileinfo;
                foreach (string file in Directory.GetFiles(Path.Combine(SystemDirectory, directory)))
                {
                    fileinfo = new FileInfo(file);
                    if (fileinfo.Exists)
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {fileinfo.FullName}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void AnalyzeAllDirectories(string directory)
        {
            try
            {
                DirectoryInfo dirinfo;
                foreach (string dir in Directory.GetDirectories(Path.Combine(SystemDirectory, directory)))
                {
                    dirinfo = new DirectoryInfo(dir);
                    if (dirinfo.Exists)
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {dirinfo.FullName}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void SingleDirectoryDeletion(string directory)
        {
            try
            {
                string fullPath = Path.Combine(SystemDirectory, directory);
                if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                    if (!Directory.Exists(fullPath))
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {directory}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void SingleDirectoryAnalyze(string directory)
        {
            try
            {
                string fullPath = Path.Combine(SystemDirectory, directory);
                if (Directory.Exists(fullPath))
                {
                    FileCount++;
                    ProcessBox.Items.Add($"{FileCount} | {directory}");
                }
                else
                {
                    RejectCount++;
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void SingleFileDeletion(string directory, string file)
        {
            try
            {
                string fullPath = Path.Combine(SystemDirectory, directory, file);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    if (!File.Exists(fullPath))
                    {
                        FileCount++;
                        ProcessBox.Items.Add($"{FileCount} | {fullPath}");
                    }
                    else
                    {
                        RejectCount++;
                    }
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void SingleFileAnalyze(string directory, string file)
        {
            try
            {
                string fullPath = Path.Combine(SystemDirectory, directory, file);
                if (File.Exists(fullPath))
                {
                    FileCount++;
                    ProcessBox.Items.Add($"{FileCount} | {fullPath}");
                }
                else
                {
                    RejectCount++;
                }
            }
            catch
            {
                AccessError++;
            }
        }

        private void ThreadBasic()
        {
            void value()
            {
                ClipboardClear();
                foreach (string extensions in temporaryExtensions)
                {
                    DeleteFiles(folderIndex["WinTemp"], extensions.ToString());
                }
                foreach (string extensions in temporaryExtensions)
                {
                    DeleteFiles(folderIndex["WinTemp2"], extensions.ToString());
                    DeleteAllDirectories(folderIndex["WinTemp2"]);
                }
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleDirectoryDeletion(folderIndex["DownloadedInstallations"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["RecentFiles"], ".lnk");
                DeleteFiles(folderIndex["RecentFiles2"], ".automaticDestinations-ms");
                DeleteFiles(folderIndex["RecentFiles3"], ".customDestinations-ms");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["PreviewCache"], ".db");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DNSCacheRefresh();

                SingleDirectoryDeletion(folderIndex["Logs"]);
                SingleDirectoryDeletion(folderIndex["Logs2"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleFileDeletion(folderIndex["UpdateReport"], "ReportingEvents.log");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                process_img.Visible = false;
                Finish.Visible = true;
                finish_img.Visible = true;
                Start.Enabled = true;
            }
            Invoke(new Action(value));
        }
        private void ThreadAdvanced()
        {
            void value()
            {
                ClipboardClear();
                foreach (string extensions in temporaryExtensions)
                {
                    DeleteFiles(folderIndex["WinTemp"], extensions.ToString());
                }
                foreach (string extensions in temporaryExtensions)
                {
                    DeleteFiles(folderIndex["WinTemp2"], extensions.ToString());
                    DeleteAllDirectories(folderIndex["WinTemp2"]);
                }
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleDirectoryDeletion(folderIndex["DownloadedInstallations"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["RecentFiles"], ".lnk");
                DeleteFiles(folderIndex["RecentFiles2"], ".automaticDestinations-ms");
                DeleteFiles(folderIndex["RecentFiles3"], ".customDestinations-ms");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["PreviewCache"], ".db");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DNSCacheRefresh();

                SingleDirectoryDeletion(folderIndex["Logs"]);
                SingleDirectoryDeletion(folderIndex["Logs2"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleFileDeletion(folderIndex["UpdateReport"], "ReportingEvents.log");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["SystemCache"], ".db");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["LiveKernelReports"], ".dmp");
                DeleteFiles(folderIndex["LiveKernelNDIS"], ".dmp");
                DeleteFiles(folderIndex["CrashDumps"], ".dmp");
                DeleteFiles(folderIndex["MiniDumps"], ".dmp");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                DeleteFiles(folderIndex["Prefetch"], ".pf");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleFileDeletion(folderIndex["FontCache"], "FNTCACHE.DAT");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                SingleDirectoryDeletion(folderIndex["DownloadCache"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                process_img.Visible = false;
                Finish.Visible = true;
                finish_img.Visible = true;
                Start.Enabled = true;
            }
            Invoke(new Action(value));
        }
        private void ThreadSpecial()
        {
            void value()
            {
                if (Properties.Settings.Default.Clipboard == true)
                {
                    ClipboardClear();
                }
                if (Properties.Settings.Default.TemporaryFiles == true)
                {
                    foreach (string extensions in temporaryExtensions)
                    {
                        DeleteFiles(folderIndex["WinTemp"], extensions.ToString());
                    }
                    foreach (string extensions in temporaryExtensions)
                    {
                        DeleteFiles(folderIndex["WinTemp2"], extensions.ToString());
                        DeleteAllDirectories(folderIndex["WinTemp2"]);
                    }

                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.DownloadedInstallations == true)
                {
                    SingleDirectoryDeletion(folderIndex["DownloadedInstallations"]);
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.RecentlyUsed == true)
                {
                    DeleteFiles(folderIndex["RecentFiles"], ".lnk");
                    DeleteFiles(folderIndex["RecentFiles2"], ".automaticDestinations-ms");
                    DeleteFiles(folderIndex["RecentFiles3"], ".customDestinations-ms");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.PreviewCache == true)
                {
                    DeleteFiles(folderIndex["PreviewCache"], ".db");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                }
                if (Properties.Settings.Default.DNSCache == true)
                {
                    DNSCacheRefresh();
                }
                if (Properties.Settings.Default.Logs == true)
                {
                    SingleDirectoryDeletion(folderIndex["Logs"]);
                    SingleDirectoryDeletion(folderIndex["Logs2"]);

                    SingleFileDeletion(folderIndex["UpdateReport"], "ReportingEvents.log");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                }
                if (Properties.Settings.Default.SystemCache == true)
                {
                    DeleteFiles(folderIndex["SystemCache"], ".db");
                    DeleteAllFiles(folderIndex["TokenBrokerCache"]);
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();

                }
                if (Properties.Settings.Default.MemoryDumps == true)
                {
                    DeleteFiles(folderIndex["LiveKernelReports"], ".dmp");
                    DeleteFiles(folderIndex["LiveKernelNDIS"], ".dmp");
                    DeleteFiles(folderIndex["CrashDumps"], ".dmp");
                    DeleteFiles(folderIndex["MiniDumps"], ".dmp");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.Prefetch == true)
                {
                    DeleteFiles(folderIndex["Prefetch"], ".pf");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.FontCache == true)
                {
                    SingleFileDeletion(folderIndex["FontCache"], "FNTCACHE.DAT");
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.DownloadCache == true)
                {
                    SingleDirectoryDeletion(folderIndex["DownloadCache"]);
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (Properties.Settings.Default.OldWindows == true)
                {
                    SingleDirectoryDeletion(folderIndex["OldWindows"]);
                }
                if (Properties.Settings.Default.SysLogErrorRep == true)
                {
                    DeleteAllFiles(folderIndex["CryptnetUrlCacheContent"]);
                    DeleteAllFiles(folderIndex["CryptnetUrlCacheMetaData"]);
                    DeleteAllFiles(folderIndex["NetworkServiceTemp"]);
                    DeleteFiles(folderIndex["waasmedicLog"], ".etl");
                    DeleteFiles(folderIndex["NetSetupLog"], ".etl");
                    DeleteAllDirectories(folderIndex["ReportArchive"]);
                    DeleteAllFiles(folderIndex["ReportArchive"]);
                    DeleteAllDirectories(folderIndex["ReportQueue"]);
                    DeleteAllFiles(folderIndex["ReportQueue"]);
                    DeleteAllDirectories(folderIndex["WERTemp"]);
                    DeleteAllFiles(folderIndex["WERTemp"]);
                }

                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                process_img.Visible = false;
                Finish.Visible = true;
                finish_img.Visible = true;
                Start.Enabled = true;
            }
            Invoke(new Action(value));
        }
        private void ThreadAnalysis()
        {
            void value()
            {
                FileCount = 0;
                RejectCount = 0;
                AccessError = 0;
                if (SelectedThread == 1 || SelectedThread == 2 || SelectedThread == 3)
                {
                    if (Properties.Settings.Default.TemporaryFiles == true || SelectedThread == 1 || SelectedThread == 2)
                    {
                        foreach (string extensions in temporaryExtensions)
                        {
                            AnalyzeFiles(folderIndex["WinTemp"], extensions.ToString());
                        }
                        foreach (string extensions in temporaryExtensions)
                        {
                            AnalyzeFiles(folderIndex["WinTemp2"], extensions.ToString());
                        }
                    }
                    if (Properties.Settings.Default.DownloadCache == true || SelectedThread == 1 || SelectedThread == 2)
                    {
                        SingleDirectoryAnalyze(folderIndex["DownloadCache"]);
                    }
                    if (Properties.Settings.Default.RecentlyUsed == true || SelectedThread == 1 || SelectedThread == 2)
                    {
                        AnalyzeFiles(folderIndex["RecentFiles"], ".lnk");
                        AnalyzeFiles(folderIndex["RecentFiles2"], ".automaticDestinations-ms");
                        AnalyzeFiles(folderIndex["RecentFiles3"], ".customDestinations-ms");
                    }
                    if (Properties.Settings.Default.PreviewCache == true || SelectedThread == 1 || SelectedThread == 2)
                    {
                        AnalyzeFiles(folderIndex["PreviewCache"], ".db");
                    }
                    if (Properties.Settings.Default.Logs == true || SelectedThread == 1 || SelectedThread == 2)
                    {
                        SingleDirectoryAnalyze(folderIndex["Logs"]);
                        SingleDirectoryAnalyze(folderIndex["Logs2"]);
                        SingleFileAnalyze(folderIndex["UpdateReport"], "ReportingEvents.log");
                    }
                    Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                }
                if (SelectedThread == 2 || SelectedThread == 3)
                {
                    if (Properties.Settings.Default.SystemCache == true || SelectedThread == 2)
                    {
                        AnalyzeFiles(folderIndex["SystemCache"], ".db");
                        AnalyzeAllFiles(folderIndex["TokenBrokerCache"]);

                    }
                    if (Properties.Settings.Default.MemoryDumps == true || SelectedThread == 2)
                    {
                        AnalyzeFiles(folderIndex["LiveKernelReports"], ".dmp");
                        AnalyzeFiles(folderIndex["LiveKernelNDIS"], ".dmp");
                        AnalyzeFiles(folderIndex["CrashDumps"], ".dmp");
                        AnalyzeFiles(folderIndex["MiniDumps"], ".dmp");
                    }
                    if (Properties.Settings.Default.Prefetch == true || SelectedThread == 2)
                    {
                        AnalyzeFiles(folderIndex["Prefetch"], ".pf");
                    }
                    if (Properties.Settings.Default.FontCache == true || SelectedThread == 2)
                    {
                        SingleFileAnalyze(folderIndex["FontCache"], "FNTCACHE.DAT");
                    }
                    if (Properties.Settings.Default.DownloadCache == true || SelectedThread == 2)
                    {
                        SingleDirectoryAnalyze(folderIndex["DownloadCache"]);
                    }
                }
                if (SelectedThread == 3)
                {
                    if (Properties.Settings.Default.OldWindows == true)
                    {
                        SingleDirectoryAnalyze(folderIndex["OldWindows"]);
                    }
                    if (Properties.Settings.Default.SysLogErrorRep == true)
                    {
                        AnalyzeAllFiles(folderIndex["CryptnetUrlCacheContent"]);
                        AnalyzeAllFiles(folderIndex["CryptnetUrlCacheMetaData"]);
                        AnalyzeAllFiles(folderIndex["NetworkServiceTemp"]);
                        AnalyzeFiles(folderIndex["waasmedicLog"], ".etl");
                        AnalyzeFiles(folderIndex["NetSetupLog"], ".etl");
                        AnalyzeAllDirectories(folderIndex["ReportArchive"]);
                        AnalyzeAllFiles(folderIndex["ReportArchive"]);
                        AnalyzeAllDirectories(folderIndex["ReportQueue"]);
                        AnalyzeAllFiles(folderIndex["ReportQueue"]);
                        AnalyzeAllDirectories(folderIndex["WERTemp"]);
                        AnalyzeAllFiles(folderIndex["WERTemp"]);
                    }
                }
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString() + " / " + AccessError.ToString();
                process_img.Visible = false;
                Finish.Visible = true;
                finish_img.Visible = true;
                Start.Enabled = true;
                Analysis.Enabled = true;
            }
            Invoke(new Action(value));
        }
        private void Start_Click(object sender, EventArgs e)
        {
            FileCount = 0;
            RejectCount = 0;
            AccessError = 0;
            if (SelectedThread == 1)
            {
                new Thread(ThreadBasic).Start();
            }
            else if (SelectedThread == 2)
            {
                new Thread(ThreadAdvanced).Start();
            }
            else if (SelectedThread == 3)
            {
                new Thread(ThreadSpecial).Start();
            }
            else
            {
                new Error().ShowDialog();
            }
            ProcessPanel.BringToFront();
            process_img.Visible = true;
            Finish.Visible = false;
            finish_img.Visible = false;
            Start.Enabled = false;
        }
        private void Analysis_Click(object sender, EventArgs e)
        {
            new Thread(ThreadAnalysis).Start();
            ProcessPanel.BringToFront();
            process_img.Visible = true;
            Finish.Visible = false;
            finish_img.Visible = false;
            Start.Enabled = false;
            Analysis.Enabled = false;
        }
        private void Finish_Click(object sender, EventArgs e)
        {
            ProcessBox.Items.Clear();
            Process_count.Text = "0 / 0 / 0";
            Home_panel.BringToFront();
        }
        private void DarkModeSwitch()
        {
            if (Properties.Settings.Default.DarkMode)
            {
                foreach (Control c in Controls)
                {
                    if (c is Panel && (c.Name != "ControlPanel" && c.Name != "SidePanel" && c.Name != "LogoPanel" && c.Name != "ProcessTitlePanel" && c.Name != "DarkModeButton"))
                    {
                        c.BackColor = ColorTranslator.FromHtml("#444449");
                        c.ForeColor = Color.White;
                        BackColor = c.BackColor;
                    }
                }
            }
            else if (!Properties.Settings.Default.DarkMode)
            {
                foreach (Control c in Controls)
                {
                    if (c is Panel && c.Name != "ControlPanel" && c.Name != "SidePanel" && c.Name != "LogoPanel" && c.Name != "ProcessTitlePanel" && c.Name != "DarkModeButton")
                    {
                        c.BackColor = Color.WhiteSmoke;
                        c.ForeColor = Color.Black;
                        BackColor = c.BackColor;
                    }
                }
            }
        }
        private void DarkModeButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                new Thread(DarkModeSwitch).Start();
                Properties.Settings.Default.DarkMode = false;
                Properties.Settings.Default.Save();
            }
            else if (!Properties.Settings.Default.DarkMode)
            {
                new Thread(DarkModeSwitch).Start();
                Properties.Settings.Default.DarkMode = true;
                Properties.Settings.Default.Save();
            }
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            foreach (Control control in Options_panel.Controls)
            {
                if (control is CheckBox checkbox)
                {
                    checkbox.Checked = false;
                }
            }
            DarkModeSwitch();
        }

        private static string RunPowerShellCommand(string command)
        {
            using PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(command);
            var results = powerShell.Invoke();

            return string.Join(Environment.NewLine, results);
        }
        private void SetServicesManual_btn_Click(object sender, EventArgs e) => Invoke((MethodInvoker)delegate
                                                                                         {
                                                                                             try
                                                                                             {
                                                                                                 foreach (var serviceConfig in serviceConfigurations)
                                                                                                 {
                                                                                                     string serviceName = serviceConfig.Key;
                                                                                                     string startupType = serviceConfig.Value;

                                                                                                     RunPowerShellCommand($"Set-Service -Name \"{serviceName}\" -StartupType {startupType}");
                                                                                                 }

                                                                                                 MessageBox.Show("OK");
                                                                                             }
                                                                                             catch (Exception ex)
                                                                                             {
                                                                                                 MessageBox.Show("ERROR: " + ex.Message);
                                                                                             }
                                                                                         });

        private void DisableTelemetry_btn_Click(object sender, EventArgs e) => Invoke((MethodInvoker)delegate
                                                                                        {
                                                                                            try
                                                                                            {
                                                                                                foreach (var command in telemetryCommands)
                                                                                                {
                                                                                                    RunPowerShellCommand(command);
                                                                                                }

                                                                                                MessageBox.Show("OK");
                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                MessageBox.Show("ERROR: " + ex.Message);
                                                                                            }
                                                                                        });

        private void DisableActivity_btn_Click(object sender, EventArgs e) => Invoke((MethodInvoker)delegate
                                                                                       {
                                                                                           try
                                                                                           {
                                                                                               foreach (var command in activityHistoryCommands)
                                                                                               {
                                                                                                   RunPowerShellCommand(command);
                                                                                               }

                                                                                               MessageBox.Show("OK");
                                                                                           }
                                                                                           catch (Exception ex)
                                                                                           {
                                                                                               MessageBox.Show("ERROR: " + ex.Message);
                                                                                           }
                                                                                       });

        private async void Uninstall_btn_Click(object sender, EventArgs e)
        {
            Uninstall_btn.Enabled = false;
            Refresh_btn.Enabled = false;

            UninstallLog_List.Items.Clear();
            var selectedPrograms = Programs_CheckedList.CheckedItems.Cast<string>().ToList();
            await Task.Run(() => UninstallProgram(selectedPrograms));

            Uninstall_btn.Enabled = true;
            Refresh_btn.Enabled = true;
        }

        private void UninstallProgram(List<string> selectedPrograms)
        {
            foreach (var programInfo in selectedPrograms)
            {
                string programName = programInfo.Split(" - ")[0];

                Invoke(() =>
                {
                    UninstallLog_List.Items.Add($"STARTED: {programName}");
                    UninstallLog_List.SelectedIndex = UninstallLog_List.Items.Count - 1;
                });

                if (TryUninstallProgram(programName))
                {
                    Invoke(() =>
                    {
                        UninstallLog_List.Items.Add($"UNINSTALLED: {programName}");
                        UninstallLog_List.SelectedIndex = UninstallLog_List.Items.Count - 1;
                    });
                }
                else
                {
                    Invoke(() =>
                    {
                        UninstallLog_List.Items.Add($"FAILED: {programName}");
                        UninstallLog_List.SelectedIndex = UninstallLog_List.Items.Count - 1;
                    });
                }

                Thread.Sleep(500);
            }
        }

        private bool TryUninstallProgram(string programName)
        {
            try
            {
                ManagementObjectSearcher searcher = new(
                    $"SELECT * FROM Win32_Product WHERE Name = '{programName}'");

                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject obj in queryCollection.Cast<ManagementObject>())
                {
                    string uninstallString = obj["UninstallString"]?.ToString();

                    if (!string.IsNullOrEmpty(uninstallString))
                    {
                        Process uninstallProcess = new()
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = uninstallString,
                            }
                        };
                        uninstallProcess.Start();
                        uninstallProcess.WaitForExit();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Invoke(() =>
                {
                    UninstallLog_List.Items.Add($"ERROR | {programName} : {ex.Message}");
                    UninstallLog_List.SelectedIndex = UninstallLog_List.Items.Count - 1;
                });
                return false;
            }
        }

        private async void Refresh_btn_Click(object sender, EventArgs e)
        {
            Programs_CheckedList.Items.Clear();
            UninstallLog_List.Items.Clear();
            Uninstall_btn.Enabled = false;
            Refresh_btn.Enabled = false;
            Refresh_btn.Text = "...";

            await Task.Run(LoadPrograms);
        }
        public record ProgramInfo(string Name, DateTime InstallDate);
        private void LoadPrograms()
        {
            ManagementObjectSearcher searcher = new(@"SELECT * FROM Win32_Product");
            ManagementObjectCollection queryCollection = searcher.Get();

            List<ProgramInfo> programs = [];

            foreach (ManagementObject obj in queryCollection.Cast<ManagementObject>())
            {
                string programName = obj["Name"]?.ToString();
                string installDateStr = obj["InstallDate"]?.ToString();

                if (!string.IsNullOrEmpty(programName) && !string.IsNullOrEmpty(installDateStr))
                {
                    if (DateTime.TryParseExact(installDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime installDate))
                    {
                        programs.Add(new ProgramInfo(programName, installDate));
                    }
                }
            }

            var sortedPrograms = programs.OrderByDescending(p => p.InstallDate).ToList();

            Invoke(() =>
            {
                Programs_CheckedList.Items.Clear();
            });

            int totalCount = sortedPrograms.Count;
            int processedCount = 0;

            foreach (var program in sortedPrograms)
            {
                Invoke(() =>
                {
                    Programs_CheckedList.Items.Add($"{program.Name} - {program.InstallDate:yyyy-MM-dd}");
                });

                processedCount++;
                string progressText = $"{processedCount} / {totalCount}";
                Invoke(() =>
                {
                    Refresh_btn.Text = progressText;
                });
            }

            Invoke(() =>
            {
                Refresh_btn.Text = $"{processedCount} / {totalCount}";
                Uninstall_btn.Enabled = true;
                Refresh_btn.Enabled = true;
            });
        }
    }
}