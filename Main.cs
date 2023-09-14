using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PASPAS
{
    public partial class Main : Form
    {
        int MoveCP;
        int MapX;
        int MapY;
        int FileCount = 0;
        int RejectCount = 0;
        int SelectedThread;
        readonly string SystemDirectory = Path.GetPathRoot(Environment.SystemDirectory);
        private readonly Dictionary<string, string> folders = new Dictionary<string, string>{
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
        private readonly string[] temporaryextensions = { ".tmp", ".log", ".txt", ".dat", ".iss", ".exe", ".ini", ".vbs", ".cvr", ".od", ".lnk", ".js", ".5f2", ".jro", ".41u", ".w0y", ".vmo", ".tmp", ".log", ".txt", ".dat", ".iss", ".exe", ".ini", ".vbs", ".cvr", ".od", ".lnk", ".js", ".5f2", ".jro", ".41u", ".w0y", ".diagsession", ".png", ".jpg", ".jpeg", ".q13", ".2im", ".html", ".rcl", ".5ar", ".xml", ".dll", ".Mtx", ".5f2", ".jro", ".41u", ".w0y" };

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void PASPAS_Main_Shown(object sender, EventArgs e)
        {
            DarkModeSwitch();
        }
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
            MoveCP = 1;
            MapX = e.X;
            MapY = e.Y;
        }
        private void ControlPanel_MouseUp(object sender, MouseEventArgs e)
        {
            MoveCP = 0;
        }
        private void ControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveCP == 1)
            {
                SetDesktopLocation(MousePosition.X - MapX, MousePosition.Y - MapY);
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
        private void CheckboxPropertySave(CheckBox checkbox, bool status, string property)
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
                ProcessStartInfo startinfo = new ProcessStartInfo
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
                ProcessStartInfo startinfo = new ProcessStartInfo
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
                        else { RejectCount++; }
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
                        else { RejectCount++; }
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
                    else { RejectCount++; }
                }
            }
            catch { }
        }
        private void SingleDirectoryAnalyze(string directory)
        {
            if (Directory.Exists(directory))
            {
                FileCount++;
                ProcessBox.Items.Add(FileCount + " | " + directory);
            }
            else { RejectCount++; }
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
                    else { RejectCount++; }
                }
            }
            catch { }
        }
        private void SingleFileAnalyze(string directory, string file)
        {
            if (File.Exists(file))
            {
                FileCount++;
                ProcessBox.Items.Add(FileCount + " | " + directory + file);
            }
            else { RejectCount++; }
        }
        private void ThreadBasic()
        {
            ClipboardClear();
            foreach (string extensions in temporaryextensions)
            {
                DeleteFiles(folders["WinTemp"], extensions.ToString());
            }
            foreach (string extensions in temporaryextensions)
            {
                DeleteFiles(folders["WinTemp2"], extensions.ToString());
            }
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleDirectoryDeletion(folders["DownloadedInstallations"]);
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["RecentFiles"], ".lnk");
            DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
            DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["PreviewCache"], ".db");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DNSCacheRefresh();

            SingleDirectoryDeletion(folders["Logs"]);
            SingleDirectoryDeletion(folders["Logs2"]);
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadAdvanced()
        {
            ClipboardClear();
            foreach (string extensions in temporaryextensions)
            {
                DeleteFiles(folders["WinTemp"], extensions.ToString());
            }
            foreach (string extensions in temporaryextensions)
            {
                DeleteFiles(folders["WinTemp2"], extensions.ToString());
            }
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleDirectoryDeletion(folders["DownloadedInstallations"]);
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["RecentFiles"], ".lnk");
            DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
            DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["PreviewCache"], ".db");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DNSCacheRefresh();

            SingleDirectoryDeletion(folders["Logs"]);
            SingleDirectoryDeletion(folders["Logs2"]);
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["SystemCache"], ".db");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["LiveKernelReports"], ".dmp");
            DeleteFiles(folders["LiveKernelNDIS"], ".dmp");
            DeleteFiles(folders["CrashDumps"], ".dmp");
            DeleteFiles(folders["MiniDumps"], ".dmp");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            DeleteFiles(folders["Prefetch"], ".pf");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleFileDeletion(folders["FontCache"], "FNTCACHE.DAT");
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            SingleDirectoryDeletion(folders["DownloadCache"]);
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();

            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadSpecial()
        {
            if (Properties.Settings.Default.Clipboard == true)
            {
                ClipboardClear();
            }
            if (Properties.Settings.Default.TemporaryFiles == true)
            {
                foreach (string extensions in temporaryextensions)
                {
                    DeleteFiles(folders["WinTemp"], extensions.ToString());
                }
                foreach (string extensions in temporaryextensions)
                {
                    DeleteFiles(folders["WinTemp2"], extensions.ToString());
                }

                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.DownloadedInstallations == true)
            {
                SingleDirectoryDeletion(folders["DownloadedInstallations"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.RecentlyUsed == true)
            {
                DeleteFiles(folders["RecentFiles"], ".lnk");
                DeleteFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
                DeleteFiles(folders["RecentFiles3"], ".customDestinations-ms");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.PreviewCache == true)
            {
                DeleteFiles(folders["PreviewCache"], ".db");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.DNSCache == true)
            {
                DNSCacheRefresh();
            }
            if (Properties.Settings.Default.Logs == true)
            {
                SingleDirectoryDeletion(folders["Logs"]);
                SingleDirectoryDeletion(folders["Logs2"]);

                SingleFileDeletion(folders["UpdateReport"], "ReportingEvents.log");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.SystemCache == true)
            {
                DeleteFiles(folders["SystemCache"], ".db");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.MemoryDumps == true)
            {
                DeleteFiles(folders["LiveKernelReports"], ".dmp");
                DeleteFiles(folders["LiveKernelNDIS"], ".dmp");
                DeleteFiles(folders["CrashDumps"], ".dmp");
                DeleteFiles(folders["MiniDumps"], ".dmp");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.Prefetch == true)
            {
                DeleteFiles(folders["Prefetch"], ".pf");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.FontCache == true)
            {
                SingleFileDeletion(folders["FontCache"], "FNTCACHE.DAT");
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.DownloadCache == true)
            {
                SingleDirectoryDeletion(folders["DownloadCache"]);
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (Properties.Settings.Default.OldWindows == true)
            {
                SingleDirectoryDeletion(folders["OldWindows"]);
            }
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
        }
        private void ThreadAnalysis()
        {
            FileCount = 0;
            RejectCount = 0;
            if (SelectedThread == 1 || SelectedThread == 2 || SelectedThread == 3)
            {
                if (Properties.Settings.Default.TemporaryFiles == true || SelectedThread == 1 || SelectedThread == 2)
                {
                    foreach (string extensions in temporaryextensions)
                    {
                        AnalyzeFiles(folders["WinTemp"], extensions.ToString());
                    }
                    foreach (string extensions in temporaryextensions)
                    {
                        AnalyzeFiles(folders["WinTemp2"], extensions.ToString());
                    }
                }
                if (Properties.Settings.Default.DownloadCache == true || SelectedThread == 1 || SelectedThread == 2)
                {
                    SingleDirectoryAnalyze(folders["DownloadCache"]);
                }
                if (Properties.Settings.Default.RecentlyUsed == true || SelectedThread == 1 || SelectedThread == 2)
                {
                    AnalyzeFiles(folders["RecentFiles"], ".lnk");
                    AnalyzeFiles(folders["RecentFiles2"], ".automaticDestinations-ms");
                    AnalyzeFiles(folders["RecentFiles3"], ".customDestinations-ms");
                }
                if (Properties.Settings.Default.PreviewCache == true || SelectedThread == 1 || SelectedThread == 2)
                {
                    AnalyzeFiles(folders["PreviewCache"], ".db");
                }
                if (Properties.Settings.Default.Logs == true || SelectedThread == 1 || SelectedThread == 2)
                {
                    SingleDirectoryAnalyze(folders["Logs"]);
                    SingleDirectoryAnalyze(folders["Logs2"]);
                    SingleFileAnalyze(folders["UpdateReport"], "ReportingEvents.log");
                }
                Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            }
            if (SelectedThread == 2 || SelectedThread == 3)
            {
                if (Properties.Settings.Default.SystemCache == true || SelectedThread == 2)
                {
                    AnalyzeFiles(folders["SystemCache"], ".db");
                }
                if (Properties.Settings.Default.MemoryDumps == true || SelectedThread == 2)
                {
                    AnalyzeFiles(folders["LiveKernelReports"], ".dmp");
                    AnalyzeFiles(folders["LiveKernelNDIS"], ".dmp");
                    AnalyzeFiles(folders["CrashDumps"], ".dmp");
                    AnalyzeFiles(folders["MiniDumps"], ".dmp");
                }
                if (Properties.Settings.Default.Prefetch == true || SelectedThread == 2)
                {
                    AnalyzeFiles(folders["Prefetch"], ".pf");
                }
                if (Properties.Settings.Default.FontCache == true || SelectedThread == 2)
                {
                    SingleFileAnalyze(folders["FontCache"], "FNTCACHE.DAT");
                }
                if (Properties.Settings.Default.DownloadCache == true || SelectedThread == 2)
                {
                    SingleDirectoryAnalyze(folders["DownloadCache"]);
                }
            }
            if (SelectedThread == 3)
            {
                if (Properties.Settings.Default.OldWindows == true)
                {
                    SingleDirectoryAnalyze(folders["OldWindows"]);
                }
            }
            Process_count.Text = FileCount.ToString() + " / " + RejectCount.ToString();
            process_img.Visible = false;
            Finish.Visible = true;
            finish_img.Visible = true;
            Start.Enabled = true;
            Analysis.Enabled = true;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            FileCount = 0;
            RejectCount = 0;
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
            Process_count.Text = "0 / 0";
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
                    if (c is Panel && (c.Name != "ControlPanel" && c.Name != "SidePanel" && c.Name != "LogoPanel" && c.Name != "ProcessTitlePanel" && c.Name != "DarkModeButton"))
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
        private void Github_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/berkaygediz");
        }
    }
}