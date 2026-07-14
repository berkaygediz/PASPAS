using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace PASPAS
{
    public static class Core
    {
        public static int FileCount = 0;
        public static int RejectCount = 0;
        public static int AccessError = 0;
        public static int SelectedThread = 0;

        private static HashSet<string> rejectedFiles = new HashSet<string>();

        public static Action<string[]> OnLogUpdate;
        public static Action<int, int, int> OnStatsUpdate;
        public static Action<bool> OnProcessFinished;
        public static Action<string> OnUninstallLog;
        public static Action<int, int, string> OnUninstallProgress;
        public static Action<List<ProgramItem>> OnProgramsLoaded;
        public static Action<string, int> OnRegistryCountUpdated;
        public static Action OnRegistryCleanFinished;

        private static List<string> _logBuffer = new List<string>();
        private static Stopwatch _uiStopwatch = Stopwatch.StartNew();

        private static void LogStats()
        {
            _logBuffer.Add($"{DateTime.Now:HH:mm:ss} -> {FileCount} / {RejectCount} / {AccessError}");
            _logBuffer.Add("");
            FlushLogs();
            OnStatsUpdate?.Invoke(FileCount, RejectCount, AccessError);
        }

        private static void AddLog(string log)
        {
            _logBuffer.Add(log);
            if (_uiStopwatch.ElapsedMilliseconds > 30)
            {
                FlushLogs();
                OnStatsUpdate?.Invoke(FileCount, RejectCount, AccessError);
                _uiStopwatch.Restart();
            }
        }

        private static void FlushLogs()
        {
            if (_logBuffer.Count > 0)
            {
                OnLogUpdate?.Invoke(_logBuffer.ToArray());
                _logBuffer.Clear();
            }
        }

        private static bool IsCancelled(CancellationToken token) => token.IsCancellationRequested;

        // cleaner/analysis

        public static void StartCleaning(CancellationToken token) => RunProcess(token, false);
        public static void StartAnalysis(CancellationToken token) => RunProcess(token, true);

        private static void RunProcess(CancellationToken token, bool isAnalysis)
        {
            FileCount = 0;
            RejectCount = 0;
            AccessError = 0;
            rejectedFiles.Clear();

            if (SelectedThread == 1) ThreadBasic(isAnalysis, token);
            else if (SelectedThread == 2) ThreadAdvanced(isAnalysis, token);
            else if (SelectedThread == 3) ThreadSpecial(isAnalysis, token);

            OnProcessFinished?.Invoke(true);
        }

        private static void ThreadBasic(bool isAnalysis, CancellationToken token)
        {
            foreach (string ext in Globals.TemporaryExtensions) ProcessFiles(Globals.FolderIndex["WinTemp"], ext, isAnalysis, token);
            foreach (string ext in Globals.TemporaryExtensions) ProcessFiles(Globals.FolderIndex["WinTemp2"], ext, isAnalysis, token);
            ProcessAllDirectories(Globals.FolderIndex["WinTemp2"], isAnalysis, token);
            LogStats();

            ProcessSingleDirectory(Globals.FolderIndex["DownloadedInstallations"], isAnalysis, token);
            LogStats();

            ProcessFiles(Globals.FolderIndex["RecentFiles"], ".lnk", isAnalysis, token);
            ProcessFiles(Globals.FolderIndex["RecentFiles2"], ".automaticDestinations-ms", isAnalysis, token);
            ProcessFiles(Globals.FolderIndex["RecentFiles3"], ".customDestinations-ms", isAnalysis, token);
            LogStats();

            ProcessFiles(Globals.FolderIndex["PreviewCache"], ".db", isAnalysis, token);
            LogStats();

            ProcessSingleDirectory(Globals.FolderIndex["Logs"], isAnalysis, token);
            ProcessSingleDirectory(Globals.FolderIndex["Logs2"], isAnalysis, token);
            LogStats();

            ProcessSingleFile(Globals.FolderIndex["UpdateReport"], "ReportingEvents.log", isAnalysis, token);
            LogStats();
        }

        private static void ThreadAdvanced(bool isAnalysis, CancellationToken token)
        {
            ThreadBasic(isAnalysis, token);

            ProcessFiles(Globals.FolderIndex["SystemCache"], ".db", isAnalysis, token);
            LogStats();

            ProcessFiles(Globals.FolderIndex["LiveKernelReports"], ".dmp", isAnalysis, token);
            ProcessFiles(Globals.FolderIndex["LiveKernelNDIS"], ".dmp", isAnalysis, token);
            ProcessFiles(Globals.FolderIndex["CrashDumps"], ".dmp", isAnalysis, token);
            ProcessFiles(Globals.FolderIndex["MiniDumps"], ".dmp", isAnalysis, token);
            LogStats();

            ProcessFiles(Globals.FolderIndex["Prefetch"], ".pf", isAnalysis, token);
            LogStats();

            ProcessSingleFile(Globals.FolderIndex["FontCache"], "FNTCACHE.DAT", isAnalysis, token);
            LogStats();

            ProcessSingleDirectory(Globals.FolderIndex["DownloadCache"], isAnalysis, token);
            LogStats();
        }

        private static void ThreadSpecial(bool isAnalysis, CancellationToken token)
        {
            if (!isAnalysis && Properties.Settings.Default.Clipboard)
            {
                ClipboardClear();
            }

            if (Properties.Settings.Default.TemporaryFiles)
            {
                foreach (string ext in Globals.TemporaryExtensions) ProcessFiles(Globals.FolderIndex["WinTemp"], ext, isAnalysis, token);
                foreach (string ext in Globals.TemporaryExtensions) ProcessFiles(Globals.FolderIndex["WinTemp2"], ext, isAnalysis, token);
                ProcessAllDirectories(Globals.FolderIndex["WinTemp2"], isAnalysis, token);
                LogStats();
            }
            if (Properties.Settings.Default.DownloadedInstallations) { ProcessSingleDirectory(Globals.FolderIndex["DownloadedInstallations"], isAnalysis, token); LogStats(); }
            if (Properties.Settings.Default.RecentlyUsed)
            {
                ProcessFiles(Globals.FolderIndex["RecentFiles"], ".lnk", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["RecentFiles2"], ".automaticDestinations-ms", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["RecentFiles3"], ".customDestinations-ms", isAnalysis, token);
                LogStats();
            }
            if (Properties.Settings.Default.PreviewCache) { ProcessFiles(Globals.FolderIndex["PreviewCache"], ".db", isAnalysis, token); LogStats(); }
            if (!isAnalysis && Properties.Settings.Default.DNSCache)
            {
                DNSCacheRefresh();
            }

            if (Properties.Settings.Default.Logs)
            {
                ProcessSingleDirectory(Globals.FolderIndex["Logs"], isAnalysis, token);
                ProcessSingleDirectory(Globals.FolderIndex["Logs2"], isAnalysis, token);
                ProcessSingleFile(Globals.FolderIndex["UpdateReport"], "ReportingEvents.log", isAnalysis, token);
                LogStats();
            }
            if (Properties.Settings.Default.SystemCache)
            {
                ProcessFiles(Globals.FolderIndex["SystemCache"], ".db", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["TokenBrokerCache"], null, isAnalysis, token);
                LogStats();
            }
            if (Properties.Settings.Default.MemoryDumps)
            {
                ProcessFiles(Globals.FolderIndex["LiveKernelReports"], ".dmp", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["LiveKernelNDIS"], ".dmp", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["CrashDumps"], ".dmp", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["MiniDumps"], ".dmp", isAnalysis, token);
                LogStats();
            }
            if (Properties.Settings.Default.Prefetch) { ProcessFiles(Globals.FolderIndex["Prefetch"], ".pf", isAnalysis, token); LogStats(); }
            if (Properties.Settings.Default.FontCache) { ProcessSingleFile(Globals.FolderIndex["FontCache"], "FNTCACHE.DAT", isAnalysis, token); LogStats(); }
            if (Properties.Settings.Default.DownloadCache) { ProcessSingleDirectory(Globals.FolderIndex["DownloadCache"], isAnalysis, token); LogStats(); }
            if (Properties.Settings.Default.OldWindows) { ProcessSingleDirectory(Globals.FolderIndex["OldWindows"], isAnalysis, token); LogStats(); }
            if (Properties.Settings.Default.SysLogErrorRep)
            {
                ProcessFiles(Globals.FolderIndex["CryptnetUrlCacheContent"], null, isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["CryptnetUrlCacheMetaData"], null, isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["NetworkServiceTemp"], null, isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["waasmedicLog"], ".etl", isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["NetSetupLog"], ".etl", isAnalysis, token);
                ProcessAllDirectories(Globals.FolderIndex["ReportArchive"], isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["ReportArchive"], null, isAnalysis, token);
                ProcessAllDirectories(Globals.FolderIndex["ReportQueue"], isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["ReportQueue"], null, isAnalysis, token);
                ProcessAllDirectories(Globals.FolderIndex["WERTemp"], isAnalysis, token);
                ProcessFiles(Globals.FolderIndex["WERTemp"], null, isAnalysis, token);
                LogStats();
            }
        }

        private static void ProcessFiles(string directory, string extension, bool isAnalysis, CancellationToken token)
        {
            try
            {
                string path = Path.Combine(Globals.SystemDirectory, directory);
                if (!Directory.Exists(path)) return;

                foreach (string file in Directory.EnumerateFiles(path))
                {
                    if (IsCancelled(token)) return;
                    if (rejectedFiles.Contains(file)) continue;

                    bool matchesExtension = string.IsNullOrEmpty(extension) ||
                        Path.GetExtension(file).Equals(extension, StringComparison.OrdinalIgnoreCase);
                    if (!matchesExtension) continue;

                    bool success = true;
                    if (!isAnalysis) { try { File.Delete(file); } catch { success = false; } }

                    if (success) { FileCount++; AddLog($"{FileCount} | {file}"); }
                    else { RejectCount++; rejectedFiles.Add(file); AddLog($"X | {file}"); }
                }
            }
            catch { AccessError++; }
        }

        private static void ProcessAllDirectories(string directory, bool isAnalysis, CancellationToken token)
        {
            try
            {
                string path = Path.Combine(Globals.SystemDirectory, directory);
                if (!Directory.Exists(path)) return;

                foreach (string dir in Directory.EnumerateDirectories(path))
                {
                    if (IsCancelled(token)) return;
                    if (rejectedFiles.Contains(dir)) continue;

                    bool success = true;
                    if (!isAnalysis) { try { Directory.Delete(dir, true); } catch { success = false; } }

                    if (success) { FileCount++; AddLog($"{FileCount} | {dir}"); }
                    else { RejectCount++; rejectedFiles.Add(dir); AddLog($"X | {dir}"); }
                }
            }
            catch { AccessError++; }
        }

        private static void ProcessSingleDirectory(string directory, bool isAnalysis, CancellationToken token)
        {
            string fullPath = Path.Combine(Globals.SystemDirectory, directory);
            try
            {
                if (!Directory.Exists(fullPath)) return;

                bool success = true;
                if (!isAnalysis) { try { Directory.Delete(fullPath, true); } catch { success = false; } }

                if (success) { FileCount++; AddLog($"{FileCount} | {directory}"); }
                else { RejectCount++; AddLog($"X | {directory}"); }
            }
            catch { AccessError++; }
        }

        private static void ProcessSingleFile(string directory, string file, bool isAnalysis, CancellationToken token)
        {
            string fullPath = Path.Combine(Globals.SystemDirectory, directory, file);
            try
            {
                if (!File.Exists(fullPath)) return;

                bool success = true;
                if (!isAnalysis) { try { File.Delete(fullPath); } catch { success = false; } }

                if (success) { FileCount++; AddLog($"{FileCount} | {fullPath}"); }
                else { RejectCount++; AddLog($"X | {fullPath}"); }
            }
            catch { AccessError++; }
        }

        private static void ClipboardClear()
        {
            try
            {
                AddLog("---> clip.exe");
                Process.Start(new ProcessStartInfo { FileName = "clip.exe", WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true, UseShellExecute = false });
            }
            catch { RejectCount++; }
        }

        private static void DNSCacheRefresh()
        {
            try
            {
                AddLog("---> ipconfig.exe");
                AddLog("- /flushdns");
                Process.Start(new ProcessStartInfo { FileName = "ipconfig.exe", Arguments = "/flushdns", WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true, UseShellExecute = false });
            }
            catch { RejectCount++; }
        }

        // tweaks

        public static bool ApplyServicesManual()
        {
            try
            {
                using RegistryKey servicesRoot = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services");
                if (servicesRoot == null) return false;

                string[] allServiceNames = servicesRoot.GetSubKeyNames();

                foreach (var cfg in Globals.ServiceConfigurations)
                {
                    int startVal = 3;
                    if (cfg.Value == "Automatic" || cfg.Value == "AutomaticDelayedStart") startVal = 2;
                    else if (cfg.Value == "Disabled") startVal = 4;

                    bool isDelayed = (cfg.Value == "AutomaticDelayedStart");
                    string targetName = cfg.Key;
                    bool isWildcard = targetName.EndsWith("*");

                    foreach (string actualServiceName in allServiceNames)
                    {
                        bool isMatch = isWildcard ? actualServiceName.StartsWith(targetName.TrimEnd('*'), StringComparison.OrdinalIgnoreCase)
                                                  : string.Equals(actualServiceName, targetName, StringComparison.OrdinalIgnoreCase);

                        if (isMatch)
                        {
                            try
                            {
                                using RegistryKey svcKey = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{actualServiceName}", true);
                                if (svcKey != null)
                                {
                                    svcKey.SetValue("Start", startVal, RegistryValueKind.DWord);
                                    if (isDelayed) svcKey.SetValue("DelayedAutostart", 1, RegistryValueKind.DWord);
                                    else svcKey.DeleteValue("DelayedAutostart", false);
                                }
                            }
                            catch { }
                        }
                    }
                }
                return true;
            }
            catch { return false; }
        }

        public static bool ApplyDisableTelemetry()
        {
            try
            {
                string autoLoggerDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Diagnosis\ETLLogs\AutoLogger");
                string etlFile = Path.Combine(autoLoggerDir, "AutoLogger-Diagtrack-Listener.etl");

                if (File.Exists(etlFile)) File.Delete(etlFile);
                Process.Start("icacls.exe", $"\"{autoLoggerDir}\" /deny SYSTEM:(OI)(CI)F")?.WaitForExit();

                using RegistryKey spynetKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Spynet", true);
                spynetKey.SetValue("SubmitSamplesConsent", 2, RegistryValueKind.DWord);

                return true;
            }
            catch { return false; }
        }

        public static bool ApplyDisableActivity()
        {
            try
            {
                using RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true);
                key.SetValue("EnableActivityFeed", 0, RegistryValueKind.DWord);
                key.SetValue("PublishUserActivities", 0, RegistryValueKind.DWord);
                key.SetValue("UploadUserActivities", 0, RegistryValueKind.DWord);
                return true;
            }
            catch { return false; }
        }

        // uninstaller

        public class ProgramItem
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string UninstallString { get; set; }
            public override string ToString() => $"{Name} - {Date:yyyy-MM-dd}";
        }

        public static void LoadPrograms()
        {
            List<ProgramItem> programs = new List<ProgramItem>();
            string[] paths = { @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall" };

            void ReadFromKey(RegistryKey root, string path)
            {
                using RegistryKey key = root.OpenSubKey(path);
                if (key == null) return;

                foreach (var subKeyName in key.GetSubKeyNames())
                {
                    using RegistryKey subKey = key.OpenSubKey(subKeyName);
                    if (subKey == null) continue;

                    string name = subKey.GetValue("DisplayName") as string;
                    string uninstallString = subKey.GetValue("UninstallString") as string;
                    string installDateStr = subKey.GetValue("InstallDate") as string;

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(uninstallString))
                    {
                        DateTime installDate = DateTime.MinValue;
                        if (DateTime.TryParseExact(installDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                            installDate = date;

                        programs.Add(new ProgramItem { Name = name, Date = installDate, UninstallString = uninstallString });
                    }
                }
            }

            foreach (var path in paths)
            {
                ReadFromKey(Registry.LocalMachine, path);
                ReadFromKey(Registry.CurrentUser, path);
            }

            programs.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase));

            OnProgramsLoaded?.Invoke(programs);
            OnUninstallProgress?.Invoke(programs.Count, programs.Count, "Refresh");
        }

        public static void UninstallPrograms(List<ProgramItem> selectedPrograms)
        {
            bool TryUninstall(string programName, string uninstallString)
            {
                try
                {
                    if (string.IsNullOrEmpty(uninstallString)) return false;

                    string fileName = uninstallString;
                    string arguments = "";

                    if (uninstallString.StartsWith('"'))
                    {
                        int endQuote = uninstallString.IndexOf('"', 1);
                        if (endQuote > 0) { fileName = uninstallString.Substring(1, endQuote - 1); arguments = uninstallString.Substring(endQuote + 1).Trim(); }
                    }
                    else
                    {
                        int spaceIndex = uninstallString.IndexOf(' ');
                        if (spaceIndex > 0) { fileName = uninstallString.Substring(0, spaceIndex); arguments = uninstallString.Substring(spaceIndex + 1).Trim(); }
                    }

                    using Process uninstallProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = fileName,
                            Arguments = arguments,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            UseShellExecute = false
                        }
                    };
                    uninstallProcess.Start();
                    uninstallProcess.WaitForExit();
                    return true;
                }
                catch (Exception ex)
                {
                    OnUninstallLog?.Invoke($"ERROR | {programName} : {ex.Message}");
                    return false;
                }
            }

            foreach (var program in selectedPrograms)
            {
                OnUninstallLog?.Invoke($"STARTED: {program.Name}");

                if (TryUninstall(program.Name, program.UninstallString))
                    OnUninstallLog?.Invoke($"UNINSTALLED: {program.Name}");
                else
                    OnUninstallLog?.Invoke($"FAILED: {program.Name}");

                Thread.Sleep(500);
            }
        }

        // registry

        public static Dictionary<string, List<RegistryItem>> RegistryResults = new();

        public static void ScanRegistry(List<string> categoriesToScan)
        {
            foreach (var categoryName in categoriesToScan)
            {
                if (!Globals.RegistryCategories.ContainsKey(categoryName)) continue;

                var category = Globals.RegistryCategories[categoryName];
                var foundItems = new List<RegistryItem>();

                foreach (var path in category.Paths)
                {
                    using RegistryKey key = category.Root.OpenSubKey(path, false);
                    if (key == null) continue;

                    string[] entries = category.ScanSubKeys ? key.GetSubKeyNames() : key.GetValueNames();

                    foreach (var entry in entries)
                    {
                        string name = entry;

                        if (category.Suffixes != null)
                        {
                            bool matched = false;
                            foreach (var suffix in category.Suffixes)
                            {
                                if (name.EndsWith(suffix)) { name = name.Substring(0, name.Length - suffix.Length); matched = true; break; }
                            }
                            if (!matched) continue;
                        }

                        bool isExcluded = false;
                        if (category.Excludes != null && category.Excludes.Length > 0)
                        {
                            foreach (var item in category.Excludes)
                            {
                                if (name.StartsWith(item, StringComparison.OrdinalIgnoreCase) || name.Equals(item, StringComparison.OrdinalIgnoreCase))
                                {
                                    isExcluded = true;
                                    break;
                                }
                            }
                        }
                        if (isExcluded) continue;

                        bool isJunk = false;
                        bool skipItem = false;

                        if (category.CheckPids && name.StartsWith("*PID", StringComparison.OrdinalIgnoreCase))
                            isJunk = true;

                        else if (category.CheckNotifyIcons && name.StartsWith("NotifyIconGeneratedAumid_", StringComparison.OrdinalIgnoreCase))
                            isJunk = true;

                        else if (category.CheckFiles && (name.StartsWith("C:\\", StringComparison.OrdinalIgnoreCase) || name.StartsWith('{')) && (name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || name.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)))
                        {
                            string filePath = name.Replace('/', '\\');

                            foreach (var kvp in Globals.KnownFolders)
                            {
                                if (filePath.StartsWith(kvp.Key + "\\")) { filePath = Path.Combine(kvp.Value, filePath.Substring(kvp.Key.Length + 1)); break; }
                            }

                            string lowerPath = filePath.ToLowerInvariant();
                            bool pathExcluded = false;
                            foreach (var p in Globals.SystemPaths) if (lowerPath.Contains(p)) pathExcluded = true;
                            if (!pathExcluded) { foreach (var v in Globals.VendorKeywords) if (lowerPath.Contains(v)) pathExcluded = true; }

                            if (pathExcluded) skipItem = true;
                            else isJunk = !File.Exists(filePath);
                        }

                        else if (category.CheckProgIds)
                        {
                            int lastUnderscore = entry.LastIndexOf('_');
                            if (lastUnderscore > 0)
                            {
                                string progId = entry.Substring(0, lastUnderscore);
                                using RegistryKey progKey = Registry.ClassesRoot.OpenSubKey(progId, false);

                                if (progKey == null) isJunk = true;
                                else
                                {
                                    using RegistryKey cmdKey = progKey.OpenSubKey(@"shell\open\command", false);
                                    string cmd = cmdKey?.GetValue("") as string;

                                    if (!string.IsNullOrEmpty(cmd))
                                    {
                                        string exePath = cmd.Trim();
                                        if (exePath.StartsWith('"')) { int endQ = exePath.IndexOf('"', 1); if (endQ > 0) exePath = exePath.Substring(1, endQ - 1); }
                                        else { int spc = exePath.IndexOf(' '); if (spc > 0) exePath = exePath.Substring(0, spc); }

                                        exePath = Environment.ExpandEnvironmentVariables(exePath);
                                        string lowerExe = exePath.ToLowerInvariant();

                                        bool pathExcluded = false;
                                        foreach (var p in Globals.SystemPaths) if (lowerExe.Contains(p)) pathExcluded = true;
                                        if (!pathExcluded) { foreach (var v in Globals.VendorKeywords) if (lowerExe.Contains(v)) pathExcluded = true; }

                                        if (pathExcluded) skipItem = true;
                                        else isJunk = !File.Exists(exePath);
                                    }
                                }
                            }
                        }

                        else if (category.UnknownIsJunk)
                            isJunk = true;

                        if (skipItem) continue;
                        if (isJunk) foundItems.Add(new RegistryItem { Root = category.Root, Path = path, Name = entry, IsSubKey = category.ScanSubKeys });
                    }
                }

                RegistryResults[categoryName] = foundItems;
                OnRegistryCountUpdated?.Invoke(categoryName, foundItems.Count);
            }
        }

        public static void CleanRegistryItems(string categoryName, List<RegistryItem> itemsToDelete)
        {
            if (!RegistryResults.ContainsKey(categoryName)) return;

            foreach (var item in itemsToDelete)
            {
                try
                {
                    using RegistryKey key = item.Root.OpenSubKey(item.Path, true);
                    if (key != null)
                    {
                        if (item.IsSubKey) key.DeleteSubKey(item.Name, false);
                        else key.DeleteValue(item.Name, false);
                    }
                }
                catch { }
            }

            var resultList = RegistryResults[categoryName];
            for (int i = resultList.Count - 1; i >= 0; i--)
            {
                if (itemsToDelete.Contains(resultList[i])) resultList.RemoveAt(i);
            }

            OnRegistryCountUpdated?.Invoke(categoryName, resultList.Count);
            OnRegistryCleanFinished?.Invoke();
        }
    }
}