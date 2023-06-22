/*
____________________________________________________________

    PASPAS   PASPAS   PASPAS   PASPAS   PASPAS   PASPAS
    PA  SP   P    A   P        PA  SP   P    A   P     
    PASPAS   PASPAS   PASPAS   PASPAS   PASPAS   PASPAS
    PA       P    A        P   PA       P    A        P
    PA       P    A   PASPAS   PA       P    A   PASPAS
____________________________________________________________
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PASPAS
{
    public partial class PASPAS_Main : Form
    {
        int CP_Move;
        int MX;
        int MY;

        int FileCount = 0;
        int Clipboard_Count = 0;
        int DNSCache_Count = 0;

        public readonly Dictionary<string, string> folders = new Dictionary<string, string>{
    { "WinTemp", "/Windows/TEMP" },
    { "WinTemp2", "/Users/" + Environment.UserName + "/AppData/Local/Temp" },
    { "DownloadedInstallations", "/Users/" + Environment.UserName + "/AppData/Roaming/Downloaded Installations" },
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

        int SelectedThread;
        readonly string SystemDirectory = Path.GetPathRoot(Environment.SystemDirectory);

        public PASPAS_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void PASPAS_Main_Load(object sender, EventArgs e)
        {
            SelectedThread = Properties.Settings.Default.SelectedThread;
            if (SelectedThread == 0)
            { }
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
                Error error = new Error();
                error.ShowDialog();
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

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void ControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            CP_Move = 1;
            MX = e.X;
            MY = e.Y;
        }
        private void ControlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            CP_Move = 0;
        }
        private void ControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (CP_Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MX, MousePosition.Y - MY);
            }
        }
        private void Home_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = Home_btn.Top;
            SidePanel.Height = Home_btn.Height;
            Home_panel.BringToFront();
        }
        private void Options_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = Options_btn.Top;
            SidePanel.Height = Options_btn.Height;
            Options_panel.BringToFront();
        }
        private void About_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Top = About_btn.Top;
            SidePanel.Height = About_btn.Height;
            About_panel.BringToFront();
        }

        private void Clipboard_select_CheckedChanged(object sender, EventArgs e)
        {
            if (Clipboard_select.Checked == true)
            {
                Properties.Settings.Default.Clipboard = Clipboard_select.Checked;
                Properties.Settings.Default.Save();
                Clipboard_select.Text = "✓";
                Clipboard_select.BackColor = Color.Lime;
                Clipboard_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.Clipboard = Clipboard_select.Checked;
                Properties.Settings.Default.Save();
                Clipboard_select.Text = "X";
                Clipboard_select.BackColor = Color.Red;
                Clipboard_select.ForeColor = Color.White;
            }
        }
        private void TemporaryFiles_select_CheckedChanged(object sender, EventArgs e)
        {
            if (TemporaryFiles_select.Checked == true)
            {
                Properties.Settings.Default.TemporaryFiles = TemporaryFiles_select.Checked;
                Properties.Settings.Default.Save();
                TemporaryFiles_select.Text = "✓";
                TemporaryFiles_select.BackColor = Color.Lime;
                TemporaryFiles_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.TemporaryFiles = TemporaryFiles_select.Checked;
                Properties.Settings.Default.Save();
                TemporaryFiles_select.Text = "X";
                TemporaryFiles_select.BackColor = Color.Red;
                TemporaryFiles_select.ForeColor = Color.White;
            }
        }
        private void DownloadedInstallations_select_CheckedChanged(object sender, EventArgs e)
        {
            if (DownloadedInstallations_select.Checked == true)
            {
                Properties.Settings.Default.DownloadedInstallations = DownloadedInstallations_select.Checked;
                Properties.Settings.Default.Save();
                DownloadedInstallations_select.Text = "✓";
                DownloadedInstallations_select.BackColor = Color.Lime;
                DownloadedInstallations_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.DownloadedInstallations = DownloadedInstallations_select.Checked;
                Properties.Settings.Default.Save();
                DownloadedInstallations_select.Text = "X";
                DownloadedInstallations_select.BackColor = Color.Red;
                DownloadedInstallations_select.ForeColor = Color.White;
            }
        }
        private void RecentlyUsed_select_CheckedChanged(object sender, EventArgs e)
        {
            if (RecentlyUsed_select.Checked == true)
            {
                Properties.Settings.Default.RecentlyUsed = RecentlyUsed_select.Checked;
                Properties.Settings.Default.Save();
                RecentlyUsed_select.Text = "✓";
                RecentlyUsed_select.BackColor = Color.Lime;
                RecentlyUsed_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.RecentlyUsed = RecentlyUsed_select.Checked;
                Properties.Settings.Default.Save();
                RecentlyUsed_select.Text = "X";
                RecentlyUsed_select.BackColor = Color.Red;
                RecentlyUsed_select.ForeColor = Color.White;
            }
        }
        private void PreviewCache_select_CheckedChanged(object sender, EventArgs e)
        {
            if (PreviewCache_select.Checked == true)
            {
                Properties.Settings.Default.PreviewCache = PreviewCache_select.Checked;
                Properties.Settings.Default.Save();
                PreviewCache_select.Text = "✓";
                PreviewCache_select.BackColor = Color.Lime;
                PreviewCache_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.PreviewCache = PreviewCache_select.Checked;
                Properties.Settings.Default.Save();
                PreviewCache_select.Text = "X";
                PreviewCache_select.BackColor = Color.Red;
                PreviewCache_select.ForeColor = Color.White;
            }
        }
        private void DNSCache_select_CheckedChanged(object sender, EventArgs e)
        {
            if (DNSCache_select.Checked == true)
            {
                Properties.Settings.Default.DNSCache = DNSCache_select.Checked;
                Properties.Settings.Default.Save();
                DNSCache_select.Text = "✓";
                DNSCache_select.BackColor = Color.Lime;
                DNSCache_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.DNSCache = DNSCache_select.Checked;
                Properties.Settings.Default.Save();
                DNSCache_select.Text = "X";
                DNSCache_select.BackColor = Color.Red;
                DNSCache_select.ForeColor = Color.White;
            }
        }
        private void Logs_select_CheckedChanged(object sender, EventArgs e)
        {
            if (Logs_select.Checked == true)
            {
                Properties.Settings.Default.Logs = Logs_select.Checked;
                Properties.Settings.Default.Save();
                Logs_select.Text = "✓";
                Logs_select.BackColor = Color.Lime;
                Logs_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.Logs = Logs_select.Checked;
                Properties.Settings.Default.Save();
                Logs_select.Text = "X";
                Logs_select.BackColor = Color.Red;
                Logs_select.ForeColor = Color.White;
            }
        }
        private void SystemCache_select_CheckedChanged(object sender, EventArgs e)
        {
            if (SystemCache_select.Checked == true)
            {
                Properties.Settings.Default.SystemCache = SystemCache_select.Checked;
                Properties.Settings.Default.Save();
                SystemCache_select.Text = "✓";
                SystemCache_select.BackColor = Color.Lime;
                SystemCache_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.SystemCache = SystemCache_select.Checked;
                Properties.Settings.Default.Save();
                SystemCache_select.Text = "X";
                SystemCache_select.BackColor = Color.Red;
                SystemCache_select.ForeColor = Color.White;
            }
        }
        private void MemoryDumps_select_CheckedChanged(object sender, EventArgs e)
        {
            if (MemoryDumps_select.Checked == true)
            {
                Properties.Settings.Default.MemoryDumps = MemoryDumps_select.Checked;
                Properties.Settings.Default.Save();
                MemoryDumps_select.Text = "✓";
                MemoryDumps_select.BackColor = Color.Lime;
                MemoryDumps_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.MemoryDumps = MemoryDumps_select.Checked;
                Properties.Settings.Default.Save();
                MemoryDumps_select.Text = "X";
                MemoryDumps_select.BackColor = Color.Red;
                MemoryDumps_select.ForeColor = Color.White;
            }
        }
        private void Prefetch_select_CheckedChanged(object sender, EventArgs e)
        {
            if (Prefetch_select.Checked == true)
            {
                Properties.Settings.Default.Prefetch = Prefetch_select.Checked;
                Properties.Settings.Default.Save();
                Prefetch_select.Text = "✓";
                Prefetch_select.BackColor = Color.Lime;
                Prefetch_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.Prefetch = Prefetch_select.Checked;
                Properties.Settings.Default.Save();
                Prefetch_select.Text = "X";
                Prefetch_select.BackColor = Color.Red;
                Prefetch_select.ForeColor = Color.White;
            }
        }
        private void FontCache_select_CheckedChanged(object sender, EventArgs e)
        {
            if (FontCache_select.Checked == true)
            {
                Properties.Settings.Default.FontCache = FontCache_select.Checked;
                Properties.Settings.Default.Save();
                FontCache_select.Text = "✓";
                FontCache_select.BackColor = Color.Lime;
                FontCache_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.FontCache = FontCache_select.Checked;
                Properties.Settings.Default.Save();
                FontCache_select.Text = "X";
                FontCache_select.BackColor = Color.Red;
                FontCache_select.ForeColor = Color.White;
            }
        }
        private void DownloadCache_select_CheckedChanged(object sender, EventArgs e)
        {
            if (DownloadCache_select.Checked == true)
            {
                Properties.Settings.Default.DownloadCache = DownloadCache_select.Checked;
                Properties.Settings.Default.Save();
                DownloadCache_select.Text = "✓";
                DownloadCache_select.BackColor = Color.Lime;
                DownloadCache_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.DownloadCache = DownloadCache_select.Checked;
                Properties.Settings.Default.Save();
                DownloadCache_select.Text = "X";
                DownloadCache_select.BackColor = Color.Red;
                DownloadCache_select.ForeColor = Color.White;
            }
        }
        private void OldWindows_select_CheckedChanged(object sender, EventArgs e)
        {
            if (OldWindows_select.Checked == true)
            {
                Properties.Settings.Default.OldWindows = OldWindows_select.Checked;
                Properties.Settings.Default.Save();
                OldWindows_select.Text = "✓";
                OldWindows_select.BackColor = Color.Lime;
                OldWindows_select.ForeColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.OldWindows = OldWindows_select.Checked;
                Properties.Settings.Default.Save();
                OldWindows_select.Text = "X";
                OldWindows_select.BackColor = Color.Red;
                OldWindows_select.ForeColor = Color.White;
            }
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
                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "cmd /c echo off | clip"
                };
                Clipboard_Count++;
                ProcessBox.Items.Add(Clipboard_Count + " - " + startinfo.Arguments);
                ProcessBox.Items.Add("");
                cmd.StartInfo = startinfo;
                cmd.Start();
            }
            catch { }
        }
        private void DNSCacheRefresh()
        {
            try
            {
                ProcessBox.Items.Add("");
                ProcessBox.Items.Add("--->cmd.exe");
                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C ipconfig /flushdns"
                };
                DNSCache_Count++;
                ProcessBox.Items.Add(DNSCache_Count + " - " + startinfo.Arguments);

                startinfo.Arguments = "/C ipconfig /release";
                DNSCache_Count++;
                ProcessBox.Items.Add(DNSCache_Count + " - " + startinfo.Arguments);

                startinfo.Arguments = "/C ipconfig /renew";
                DNSCache_Count++;
                ProcessBox.Items.Add(DNSCache_Count + " - " + startinfo.Arguments);

                cmd.StartInfo = startinfo;
                cmd.Start();
                ProcessBox.Items.Add("");
            }
            catch { }
        }
        private void DeleteFiles(string directory, string extension)
        {
            try
            {
                FileInfo fileinfo;
                foreach (string file in Directory.GetFiles(SystemDirectory + directory))
                {
                    fileinfo = new FileInfo(file);
                    if (fileinfo.Extension == extension.ToUpper() || fileinfo.Extension == extension.ToLower())
                    {
                        fileinfo.Delete();
                        if (fileinfo.Exists == false)
                        {
                            FileCount++;
                            ProcessBox.Items.Add(FileCount + " | " + fileinfo.ToString());
                        }
                    }
                }
            }
            catch { }
        }
        private void AnalyzeFiles(string directory, string extension)
        {
            try
            {
                FileInfo fileinfo;
                foreach (string file in Directory.GetFiles(SystemDirectory + directory))
                {
                    fileinfo = new FileInfo(file);
                    if (fileinfo.Extension == extension.ToUpper() || fileinfo.Extension == extension.ToLower())
                    {
                        if (fileinfo.Exists)
                        {
                            FileCount++;
                            ProcessBox.Items.Add(FileCount + " | " + fileinfo.ToString());
                        }
                    }
                }
            }
            catch { }
        }
        private void SingleDirectoryDeletion(string directory)
        {
            try
            {
                if (Directory.Exists(directory))
                {
                    Directory.Delete(SystemDirectory + directory);
                    if (Directory.Exists(directory) == false)
                    {
                        FileCount++;
                        ProcessBox.Items.Add(FileCount + " | " + directory);
                    }
                }
            }
            catch { }
        }
        private void SingleDirectoryAnalyze(string directory)
        {
            try
            {
                if (Directory.Exists(directory))
                {
                    FileCount++;
                    ProcessBox.Items.Add(FileCount + " | " + directory);
                }
            }
            catch { }
        }
        private void SingleFileDeletion(string directory, string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(SystemDirectory + directory + file);
                    if (File.Exists(file) == false)
                    {
                        FileCount++;
                        ProcessBox.Items.Add(FileCount + " | " + directory + file);
                    }
                }
            }
            catch { }
        }
        private void SingleFileAnalyze(string directory, string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    FileCount++;
                    ProcessBox.Items.Add(FileCount + " | " + directory + file);
                }
            }
            catch { }
        }

        private void ThreadBasic()
        {
            FileCount = 0;
            Clipboard_Count = 0;
            DNSCache_Count = 0;

            ClipboardClear();

            DeleteFiles(folders["WinTemp"], ".tmp");
            DeleteFiles(folders["WinTemp"], ".log");
            DeleteFiles(folders["WinTemp"], ".txt");
            DeleteFiles(folders["WinTemp"], ".dat");
            DeleteFiles(folders["WinTemp"], ".iss");
            DeleteFiles(folders["WinTemp"], ".exe");
            DeleteFiles(folders["WinTemp"], ".ini");
            DeleteFiles(folders["WinTemp"], ".vbs");
            DeleteFiles(folders["WinTemp"], ".cvr");
            DeleteFiles(folders["WinTemp"], ".od");
            DeleteFiles(folders["WinTemp"], ".lnk");
            DeleteFiles(folders["WinTemp"], ".js");
            DeleteFiles(folders["WinTemp"], ".5f2");
            DeleteFiles(folders["WinTemp"], ".jro");
            DeleteFiles(folders["WinTemp"], ".41u");
            DeleteFiles(folders["WinTemp"], ".w0y");
            DeleteFiles(folders["WinTemp"], ".vmo");
            DeleteFiles(folders["WinTemp2"], ".tmp");
            DeleteFiles(folders["WinTemp2"], ".log");
            DeleteFiles(folders["WinTemp2"], ".txt");
            DeleteFiles(folders["WinTemp2"], ".dat");
            DeleteFiles(folders["WinTemp2"], ".iss");
            DeleteFiles(folders["WinTemp2"], ".exe");
            DeleteFiles(folders["WinTemp2"], ".ini");
            DeleteFiles(folders["WinTemp2"], ".vbs");
            DeleteFiles(folders["WinTemp2"], ".cvr");
            DeleteFiles(folders["WinTemp2"], ".od");
            DeleteFiles(folders["WinTemp2"], ".lnk");
            DeleteFiles(folders["WinTemp2"], ".js");
            DeleteFiles(folders["WinTemp2"], ".5f2");
            DeleteFiles(folders["WinTemp2"], ".jro");
            DeleteFiles(folders["WinTemp2"], ".41u");
            DeleteFiles(folders["WinTemp2"], ".w0y");
            DeleteFiles(folders["WinTemp2"], ".diagsession");
            DeleteFiles(folders["WinTemp2"], ".png");
            DeleteFiles(folders["WinTemp2"], ".jpg");
            DeleteFiles(folders["WinTemp2"], ".jpeg");
            DeleteFiles(folders["WinTemp2"], ".q13");
            DeleteFiles(folders["WinTemp2"], ".2im");
            DeleteFiles(folders["WinTemp2"], ".html");
            DeleteFiles(folders["WinTemp2"], ".rcl");
            DeleteFiles(folders["WinTemp2"], ".5ar");
            DeleteFiles(folders["WinTemp2"], ".xml");
            DeleteFiles(folders["WinTemp2"], ".dll");
            DeleteFiles(folders["WinTemp2"], ".Mtx");
            DeleteFiles(folders["WinTemp2"], ".5f2");
            DeleteFiles(folders["WinTemp2"], ".jro");
            DeleteFiles(folders["WinTemp2"], ".41u");
            DeleteFiles(folders["WinTemp2"], ".w0y");
            Process_count.Text = FileCount.ToString();

            SingleDirectoryDeletion(folders["DownloadedInstallations"]);
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["RecentFiles"], ".lnk");
            DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
            DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["PreviewCache"], ".db");
            Process_count.Text = FileCount.ToString();

            DNSCacheRefresh();

            SingleDirectoryDeletion(folders["Logs"]);
            SingleDirectoryDeletion(folders["Logs2"]);
            Process_count.Text = FileCount.ToString();

            SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
            Process_count.Text = FileCount.ToString();

            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadAdvanced()
        {
            FileCount = 0;
            Clipboard_Count = 0;
            DNSCache_Count = 0;

            //Pano
            ClipboardClear();

            //Geçici Dosyalar
            DeleteFiles(folders["WinTemp"], ".tmp");
            DeleteFiles(folders["WinTemp"], ".log");
            DeleteFiles(folders["WinTemp"], ".txt");
            DeleteFiles(folders["WinTemp"], ".dat");
            DeleteFiles(folders["WinTemp"], ".iss");
            DeleteFiles(folders["WinTemp"], ".exe");
            DeleteFiles(folders["WinTemp"], ".ini");
            DeleteFiles(folders["WinTemp"], ".vbs");
            DeleteFiles(folders["WinTemp"], ".cvr");
            DeleteFiles(folders["WinTemp"], ".od");
            DeleteFiles(folders["WinTemp"], ".lnk");
            DeleteFiles(folders["WinTemp"], ".js");
            DeleteFiles(folders["WinTemp"], ".5f2");
            DeleteFiles(folders["WinTemp"], ".jro");
            DeleteFiles(folders["WinTemp"], ".41u");
            DeleteFiles(folders["WinTemp"], ".w0y");
            DeleteFiles(folders["WinTemp"], ".vmo");
            DeleteFiles(folders["WinTemp2"], ".tmp");
            DeleteFiles(folders["WinTemp2"], ".log");
            DeleteFiles(folders["WinTemp2"], ".txt");
            DeleteFiles(folders["WinTemp2"], ".dat");
            DeleteFiles(folders["WinTemp2"], ".iss");
            DeleteFiles(folders["WinTemp2"], ".exe");
            DeleteFiles(folders["WinTemp2"], ".ini");
            DeleteFiles(folders["WinTemp2"], ".vbs");
            DeleteFiles(folders["WinTemp2"], ".cvr");
            DeleteFiles(folders["WinTemp2"], ".od");
            DeleteFiles(folders["WinTemp2"], ".lnk");
            DeleteFiles(folders["WinTemp2"], ".js");
            DeleteFiles(folders["WinTemp2"], ".5f2");
            DeleteFiles(folders["WinTemp2"], ".jro");
            DeleteFiles(folders["WinTemp2"], ".41u");
            DeleteFiles(folders["WinTemp2"], ".w0y");
            DeleteFiles(folders["WinTemp2"], ".diagsession");
            DeleteFiles(folders["WinTemp2"], ".png");
            DeleteFiles(folders["WinTemp2"], ".jpg");
            DeleteFiles(folders["WinTemp2"], ".jpeg");
            DeleteFiles(folders["WinTemp2"], ".q13");
            DeleteFiles(folders["WinTemp2"], ".2im");
            DeleteFiles(folders["WinTemp2"], ".html");
            DeleteFiles(folders["WinTemp2"], ".rcl");
            DeleteFiles(folders["WinTemp2"], ".5ar");
            DeleteFiles(folders["WinTemp2"], ".xml");
            DeleteFiles(folders["WinTemp2"], ".dll");
            DeleteFiles(folders["WinTemp2"], ".Mtx");
            DeleteFiles(folders["WinTemp2"], ".5f2");
            DeleteFiles(folders["WinTemp2"], ".jro");
            DeleteFiles(folders["WinTemp2"], ".41u");
            DeleteFiles(folders["WinTemp2"], ".w0y");
            Process_count.Text = FileCount.ToString();

            SingleDirectoryDeletion(folders["DownloadedInstallations"]);
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["RecentFiles"], ".lnk");
            DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
            DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["PreviewCache"], ".db");
            Process_count.Text = FileCount.ToString();

            DNSCacheRefresh();

            SingleDirectoryDeletion(folders["Logs"]);
            SingleDirectoryDeletion(folders["Logs2"]);
            Process_count.Text = FileCount.ToString();

            SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["SystemCache"], ".db");
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["LiveKernelReports"], ".dmp");
            DeleteFiles(folders["LiveKernelNDIS"], ".dmp");
            DeleteFiles(folders["CrashDumps"], ".dmp");
            DeleteFiles(folders["MiniDumps"], ".dmp");
            Process_count.Text = FileCount.ToString();

            DeleteFiles(folders["Prefetch"], ".pf");
            Process_count.Text = FileCount.ToString();

            SingleFileDeletion(folders["FontCache"], "FNTCACHE.DAT");
            Process_count.Text = FileCount.ToString();

            SingleDirectoryDeletion(folders["DownloadCache"]);
            Process_count.Text = FileCount.ToString();

            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadSpecial()
        {
            FileCount = 0;
            Clipboard_Count = 0;
            DNSCache_Count = 0;

            if (Properties.Settings.Default.Clipboard == true)
            {
                ClipboardClear();
            }
            else { }

            if (Properties.Settings.Default.TemporaryFiles == true)
            {
                DeleteFiles(folders["WinTemp"], ".tmp");
                DeleteFiles(folders["WinTemp"], ".log");
                DeleteFiles(folders["WinTemp"], ".txt");
                DeleteFiles(folders["WinTemp"], ".dat");
                DeleteFiles(folders["WinTemp"], ".iss");
                DeleteFiles(folders["WinTemp"], ".exe");
                DeleteFiles(folders["WinTemp"], ".ini");
                DeleteFiles(folders["WinTemp"], ".vbs");
                DeleteFiles(folders["WinTemp"], ".cvr");
                DeleteFiles(folders["WinTemp"], ".od");
                DeleteFiles(folders["WinTemp"], ".lnk");
                DeleteFiles(folders["WinTemp"], ".js");
                DeleteFiles(folders["WinTemp"], ".5f2");
                DeleteFiles(folders["WinTemp"], ".jro");
                DeleteFiles(folders["WinTemp"], ".41u");
                DeleteFiles(folders["WinTemp"], ".w0y");
                DeleteFiles(folders["WinTemp"], ".vmo");
                DeleteFiles(folders["WinTemp2"], ".tmp");
                DeleteFiles(folders["WinTemp2"], ".log");
                DeleteFiles(folders["WinTemp2"], ".txt");
                DeleteFiles(folders["WinTemp2"], ".dat");
                DeleteFiles(folders["WinTemp2"], ".iss");
                DeleteFiles(folders["WinTemp2"], ".exe");
                DeleteFiles(folders["WinTemp2"], ".ini");
                DeleteFiles(folders["WinTemp2"], ".vbs");
                DeleteFiles(folders["WinTemp2"], ".cvr");
                DeleteFiles(folders["WinTemp2"], ".od");
                DeleteFiles(folders["WinTemp2"], ".lnk");
                DeleteFiles(folders["WinTemp2"], ".js");
                DeleteFiles(folders["WinTemp2"], ".5f2");
                DeleteFiles(folders["WinTemp2"], ".jro");
                DeleteFiles(folders["WinTemp2"], ".41u");
                DeleteFiles(folders["WinTemp2"], ".w0y");
                DeleteFiles(folders["WinTemp2"], ".diagsession");
                DeleteFiles(folders["WinTemp2"], ".png");
                DeleteFiles(folders["WinTemp2"], ".jpg");
                DeleteFiles(folders["WinTemp2"], ".jpeg");
                DeleteFiles(folders["WinTemp2"], ".q13");
                DeleteFiles(folders["WinTemp2"], ".2im");
                DeleteFiles(folders["WinTemp2"], ".html");
                DeleteFiles(folders["WinTemp2"], ".rcl");
                DeleteFiles(folders["WinTemp2"], ".5ar");
                DeleteFiles(folders["WinTemp2"], ".xml");
                DeleteFiles(folders["WinTemp2"], ".dll");
                DeleteFiles(folders["WinTemp2"], ".Mtx");
                DeleteFiles(folders["WinTemp2"], ".5f2");
                DeleteFiles(folders["WinTemp2"], ".jro");
                DeleteFiles(folders["WinTemp2"], ".41u");
                DeleteFiles(folders["WinTemp2"], ".w0y");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.DownloadedInstallations == true)
            {
                SingleDirectoryDeletion(folders["DownloadedInstallations"]);
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.RecentlyUsed == true)
            {
                DeleteFiles(folders["RecentFiles"], ".lnk");
                DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
                DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.PreviewCache == true)
            {
                DeleteFiles(folders["PreviewCache"], ".db");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.DNSCache == true)
            {
                DNSCacheRefresh();
            }
            else { }

            if (Properties.Settings.Default.Logs == true)
            {
                SingleDirectoryDeletion(folders["Logs"]);
                SingleDirectoryDeletion(folders["Logs2"]);

                SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.SystemCache == true)
            {
                DeleteFiles(folders["SystemCache"], ".db");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.MemoryDumps == true)
            {
                DeleteFiles(folders["LiveKernelReports"], ".dmp");
                DeleteFiles(folders["LiveKernelNDIS"], ".dmp");
                DeleteFiles(folders["CrashDumps"], ".dmp");
                DeleteFiles(folders["MiniDumps"], ".dmp");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.Prefetch == true)
            {
                DeleteFiles(folders["Prefetch"], ".pf");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.FontCache == true)
            {
                SingleFileDeletion(folders["FontCache"], "FNTCACHE.DAT");
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.DownloadCache == true)
            {
                SingleDirectoryDeletion(folders["DownloadCache"]);
                Process_count.Text = FileCount.ToString();
            }
            else { }

            if (Properties.Settings.Default.OldWindows == true)
            {
                SingleDirectoryDeletion(folders["OldWindows"]);
            }
            else { }

            Process_count.Text = FileCount.ToString();
            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadAnalysis()
        {
            FileCount = 0;
            if (SelectedThread == 1 || SelectedThread == 2 || SelectedThread == 3)
            {
                AnalyzeFiles(folders["WinTemp"], ".tmp");
                AnalyzeFiles(folders["WinTemp"], ".log");
                AnalyzeFiles(folders["WinTemp"], ".txt");
                AnalyzeFiles(folders["WinTemp"], ".dat");
                AnalyzeFiles(folders["WinTemp"], ".iss");
                AnalyzeFiles(folders["WinTemp"], ".exe");
                AnalyzeFiles(folders["WinTemp"], ".ini");
                AnalyzeFiles(folders["WinTemp"], ".vbs");
                AnalyzeFiles(folders["WinTemp"], ".cvr");
                AnalyzeFiles(folders["WinTemp"], ".od");
                AnalyzeFiles(folders["WinTemp"], ".lnk");
                AnalyzeFiles(folders["WinTemp"], ".js");
                AnalyzeFiles(folders["WinTemp"], ".5f2");
                AnalyzeFiles(folders["WinTemp"], ".jro");
                AnalyzeFiles(folders["WinTemp"], ".41u");
                AnalyzeFiles(folders["WinTemp"], ".w0y");
                AnalyzeFiles(folders["WinTemp"], ".vmo");
                AnalyzeFiles(folders["WinTemp2"], ".tmp");
                AnalyzeFiles(folders["WinTemp2"], ".log");
                AnalyzeFiles(folders["WinTemp2"], ".txt");
                AnalyzeFiles(folders["WinTemp2"], ".dat");
                AnalyzeFiles(folders["WinTemp2"], ".iss");
                AnalyzeFiles(folders["WinTemp2"], ".exe");
                AnalyzeFiles(folders["WinTemp2"], ".ini");
                AnalyzeFiles(folders["WinTemp2"], ".vbs");
                AnalyzeFiles(folders["WinTemp2"], ".cvr");
                AnalyzeFiles(folders["WinTemp2"], ".od");
                AnalyzeFiles(folders["WinTemp2"], ".lnk");
                AnalyzeFiles(folders["WinTemp2"], ".js");
                AnalyzeFiles(folders["WinTemp2"], ".5f2");
                AnalyzeFiles(folders["WinTemp2"], ".jro");
                AnalyzeFiles(folders["WinTemp2"], ".41u");
                AnalyzeFiles(folders["WinTemp2"], ".w0y");
                AnalyzeFiles(folders["WinTemp2"], ".diagsession");
                AnalyzeFiles(folders["WinTemp2"], ".png");
                AnalyzeFiles(folders["WinTemp2"], ".jpg");
                AnalyzeFiles(folders["WinTemp2"], ".jpeg");
                AnalyzeFiles(folders["WinTemp2"], ".q13");
                AnalyzeFiles(folders["WinTemp2"], ".2im");
                AnalyzeFiles(folders["WinTemp2"], ".html");
                AnalyzeFiles(folders["WinTemp2"], ".rcl");
                AnalyzeFiles(folders["WinTemp2"], ".5ar");
                AnalyzeFiles(folders["WinTemp2"], ".xml");
                AnalyzeFiles(folders["WinTemp2"], ".dll");
                AnalyzeFiles(folders["WinTemp2"], ".Mtx");
                AnalyzeFiles(folders["WinTemp2"], ".5f2");
                AnalyzeFiles(folders["WinTemp2"], ".jro");
                AnalyzeFiles(folders["WinTemp2"], ".41u");
                AnalyzeFiles(folders["WinTemp2"], ".w0y");

                SingleDirectoryAnalyze(folders["DownloadCache"]);

                AnalyzeFiles(folders["RecentFiles"], ".lnk");
                AnalyzeFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
                AnalyzeFiles(folders["RecentFiles3"], ".customDestinations-ms");

                AnalyzeFiles(folders["PreviewCache"], ".db");

                SingleDirectoryAnalyze(folders["Logs"]);
                SingleDirectoryAnalyze(folders["Logs2"]);

                SingleFileAnalyze(folders["UpdateReport"], "ReportingEvents.log");

                Process_count.Text = FileCount.ToString();
            }
            if (SelectedThread == 2 || SelectedThread == 3)
            {
                AnalyzeFiles(folders["SystemCache"], ".db");

                AnalyzeFiles(folders["LiveKernelReports"], ".dmp");
                AnalyzeFiles(folders["LiveKernelNDIS"], ".dmp");
                AnalyzeFiles(folders["CrashDumps"], ".dmp");
                AnalyzeFiles(folders["MiniDumps"], ".dmp");

                AnalyzeFiles(folders["Prefetch"], ".pf");

                SingleFileAnalyze(folders["FontCache"], "FNTCACHE.DAT");

                SingleDirectoryAnalyze(folders["DownloadCache"]);
            }

            if (SelectedThread == 3)
            {
                SingleDirectoryAnalyze(folders["OldWindows"]);
            }
            Process_count.Text = FileCount.ToString();
            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
            Analysis.Enabled = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (SelectedThread == 1)
            {
                Thread BasicThread = new Thread(ThreadBasic);
                BasicThread.Start();

            }
            else if (SelectedThread == 2)
            {
                Thread AdvancedThread = new Thread(ThreadAdvanced);
                AdvancedThread.Start();
            }
            else if (SelectedThread == 3)
            {
                Thread SpecialThread = new Thread(ThreadSpecial);
                SpecialThread.Start();
            }
            else
            {
                Error error = new Error();
                error.ShowDialog();
            }

            Process_panel.BringToFront();
            process_img.Visible = true;
            Finish.Visible = false;
            finish_img.Visible = false;
            Home_btn.Enabled = false;
            Options_btn.Enabled = false;
            About_btn.Enabled = false;
            Start.Enabled = false;
        }
        private void Analysis_Click(object sender, EventArgs e)
        {
            Thread analysis = new Thread(ThreadAnalysis);
            analysis.Start();
            Process_panel.BringToFront();
            process_img.Visible = true;
            Finish.Visible = false;
            finish_img.Visible = false;
            Home_btn.Enabled = false;
            Options_btn.Enabled = false;
            About_btn.Enabled = false;
            Start.Enabled = false;
            Analysis.Enabled = false;
        }
        private void Finish_Click(object sender, EventArgs e)
        {
            Home_btn.Enabled = true;
            Options_btn.Enabled = true;
            About_btn.Enabled = true;
            ProcessBox.Items.Clear();
            Process_count.Text = "0";
            Home_panel.BringToFront();
        }
        private void Github_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/berkaygediz");

        }
    }
}