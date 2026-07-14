using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASPAS
{
    public partial class Main : Form
    {
        private UI.HomeControls homeControls;
        private UI.OptionsControls optionsControls;
        private UI.TweaksControls tweaksControls;
        private UI.ProgramsControls programsControls;
        private UI.ProcessControls processControls;
        private UI.RegistryControls registryControls;

        private bool isProcessing = false;
        private bool isAnalysisMode = false;

        private bool isUpdatingItemList = false;
        private bool isUpdatingCategoryList = false;

        private CancellationTokenSource _cancellationTokenSource;
        private Button stopButton;
        private Panel activePanel;

        private bool _isDragging = false;
        private Point _dragStartCursor;
        private Point _dragStartFormLocation;

        public Main()
        {
            InitializeComponent();
        }

        // Force WS_MINIMIZEBOX
        protected override CreateParams CreateParams
        {
            get
            {
                var param = base.CreateParams;
                param.Style |= 0x20000;
                return param;
            }
        }

        private void PASPAS_Main_Shown(object sender, EventArgs e) => DarkModeSwitch();

        private void PASPAS_Main_Load(object sender, EventArgs e)
        {
            Language.Current = string.IsNullOrEmpty(Properties.Settings.Default.Language) ? "en" : Properties.Settings.Default.Language;
            languageSelector.SelectedIndex = Language.Current == "tr" ? 1 : 0;

            BuildAllPanels();
            SignalUICoreEvents();
            WireUpEvents();

            Core.SelectedThread = Properties.Settings.Default.SelectedThread;
            if (Core.SelectedThread == 0) Core.SelectedThread = 1;

            if (Core.SelectedThread == 1) homeControls.Basic_select.Checked = true;
            else if (Core.SelectedThread == 2) homeControls.Advanced_select.Checked = true;
            else if (Core.SelectedThread == 3) homeControls.Special_select.Checked = true;

            foreach (var kvp in optionsControls.OptionCheckBoxes)
                kvp.Value.Checked = (bool)Properties.Settings.Default[kvp.Key];

            NavigateToPanel(homePanel, homeBtn);
        }

        private void BuildAllPanels()
        {
            homeBtn.Text = Language.Get("Menu_Home");
            optionsBtn.Text = Language.Get("Menu_Options");
            tweaksBtn.Text = Language.Get("Menu_Tweaks");
            registryBtn.Text = Language.Get("Menu_Registry");
            uninstallMenuBtn.Text = Language.Get("Menu_Uninstall");
            aboutBtn.Text = Language.Get("Menu_About");

            homeControls = UI.BuildHomePanel(homePanel);
            optionsControls = UI.BuildOptionsPanel(optionsPanel);
            tweaksControls = UI.BuildTweaksPanel(tweaksPanel);
            programsControls = UI.BuildProgramsPanel(programsPanel);
            processControls = UI.BuildProcessPanel(processPanel);
            registryControls = UI.BuildRegistryPanel(registryPanel);
            UI.BuildAboutPanel(aboutPanel);

            InitializeStopButton();
        }

        private void InitializeStopButton()
        {
            if (stopButton != null)
            {
                stopButton.Click -= StopButton_Click;
                stopButton.Parent?.Controls.Remove(stopButton);
                stopButton.Dispose();
            }

            bool isDark = Properties.Settings.Default.DarkMode;
            stopButton = new Button
            {
                Name = "StopButton",
                Text = Language.Get("Button_Stop"),
                BackColor = isDark ? Color.FromArgb(146, 43, 33) : Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = processControls.Finish.Size,
                Location = processControls.Finish.Location,
                Font = processControls.Finish.Font,
                Cursor = Cursors.Hand,
                Visible = false
            };
            stopButton.FlatAppearance.BorderSize = 0;
            stopButton.Click += StopButton_Click;
            processControls.Finish.Parent.Controls.Add(stopButton);
            stopButton.BringToFront();
        }

        private void WireUpEvents()
        {
            languageSelector.SelectedIndexChanged += (s, e) =>
            {
                string newLang = languageSelector.SelectedIndex == 1 ? "tr" : "en";
                if (newLang != Properties.Settings.Default.Language)
                {
                    Properties.Settings.Default.Language = newLang;
                    Properties.Settings.Default.Save();
                    ApplyLanguage();
                }
            };

            homeControls.Basic_select.CheckedChanged += (s, e) => SelectThread(1, homePanel, homeBtn);
            homeControls.Advanced_select.CheckedChanged += (s, e) => SelectThread(2, homePanel, homeBtn);
            homeControls.Special_select.CheckedChanged += (s, e) => SelectThread(3, optionsPanel, optionsBtn);

            homeControls.Start.Click += (s, e) => StartProcess(false);
            homeControls.Analysis.Click += (s, e) => StartProcess(true);

            foreach (var kvp in optionsControls.OptionCheckBoxes)
            {
                string key = kvp.Key;
                kvp.Value.CheckedChanged += (s, e) =>
                {
                    Properties.Settings.Default[key] = kvp.Value.Checked;
                    Properties.Settings.Default.Save();
                };
            }

            optionsControls.DarkModeButton.Click += DarkModeButton_Click;
            optionsControls.ResetButton.Click += ResetButton_Click;

            tweaksControls.SetServicesManual_btn.Click += (s, e) => ExecuteTweak(Core.ApplyServicesManual, Language.Get("Msg_ServicesSuccess"), Language.Get("Msg_ServicesFail"));
            tweaksControls.DisableTelemetry_btn.Click += (s, e) => ExecuteTweak(Core.ApplyDisableTelemetry, Language.Get("Msg_TelemetrySuccess"), Language.Get("Msg_TelemetryFail"));
            tweaksControls.DisableActivity_btn.Click += (s, e) => ExecuteTweak(Core.ApplyDisableActivity, Language.Get("Msg_ActivitySuccess"), Language.Get("Msg_ActivityFail"));

            programsControls.Uninstall_btn.Click += uninstallBtn_Click;
            programsControls.Refresh_btn.Click += refreshBtn_Click;
            processControls.Finish.Click += Finish_Click;

            registryControls.ScanSelectedBtn.Click += (s, e) => StartRegistryScan(false);
            registryControls.ScanAllBtn.Click += (s, e) => StartRegistryScan(true);

            registryControls.SelectAllCategoriesChk.CheckedChanged += (s, e) =>
            {
                if (isUpdatingCategoryList) return;
                isUpdatingCategoryList = true;
                foreach (var kvp in registryControls.SelectCheckBoxes)
                    kvp.Value.Checked = registryControls.SelectAllCategoriesChk.Checked;
                isUpdatingCategoryList = false;
            };

            foreach (var kvp in registryControls.SelectCheckBoxes)
            {
                kvp.Value.CheckedChanged += (s, e) =>
                {
                    if (isUpdatingCategoryList) return;
                    isUpdatingCategoryList = true;

                    bool allChecked = true;
                    foreach (var pair in registryControls.SelectCheckBoxes)
                    {
                        if (!pair.Value.Checked)
                        {
                            allChecked = false;
                            break;
                        }
                    }
                    registryControls.SelectAllCategoriesChk.Checked = allChecked;

                    isUpdatingCategoryList = false;
                };
            }

            foreach (var kvp in registryControls.DetailButtons)
            {
                string categoryName = kvp.Key;
                kvp.Value.Click += (s, e) => registryControls.ShowDetail(categoryName);
            }

            registryControls.BackBtn.Click += (s, e) => registryControls.DetailPanel.Visible = false;

            registryControls.SelectAllChk.CheckedChanged += (s, e) =>
            {
                if (isUpdatingItemList) return;
                isUpdatingItemList = true;
                for (int i = 0; i < registryControls.ItemsList.Items.Count; i++)
                    registryControls.ItemsList.SetItemChecked(i, registryControls.SelectAllChk.Checked);
                isUpdatingItemList = false;
            };

            registryControls.ItemsList.ItemCheck += (s, e) =>
            {
                if (isUpdatingItemList) return;

                if (e.NewValue != CheckState.Checked)
                {
                    isUpdatingItemList = true;
                    registryControls.SelectAllChk.Checked = false;
                    isUpdatingItemList = false;
                }
                else
                {
                    int checkedCount = 0;
                    for (int i = 0; i < registryControls.ItemsList.Items.Count; i++)
                    {
                        if (i == e.Index) checkedCount++;
                        else if (registryControls.ItemsList.GetItemChecked(i)) checkedCount++;
                    }
                    if (checkedCount == registryControls.ItemsList.Items.Count)
                    {
                        isUpdatingItemList = true;
                        registryControls.SelectAllChk.Checked = true;
                        isUpdatingItemList = false;
                    }
                }
            };

            registryControls.DeleteBtn.Click += RegistryDeleteBtn_Click;
        }

        private async void RegistryDeleteBtn_Click(object sender, EventArgs e)
        {
            string categoryName = registryControls.CurrentDetailCategory;
            if (string.IsNullOrEmpty(categoryName)) return;

            List<RegistryItem> itemsToDelete = new List<RegistryItem>();
            foreach (var item in registryControls.ItemsList.CheckedItems)
                if (item is RegistryItem regItem) itemsToDelete.Add(regItem);

            if (itemsToDelete.Count == 0) return;

            registryControls.DeleteBtn.Enabled = false;
            registryControls.BackBtn.Enabled = false;

            await Task.Run(() => Core.CleanRegistryItems(categoryName, itemsToDelete));

            registryControls.DeleteBtn.Enabled = true;
            registryControls.BackBtn.Enabled = true;
            registryControls.PopulateList(categoryName);
        }

        private async void StartRegistryScan(bool scanAll)
        {
            List<string> categoriesToScan = new List<string>();
            foreach (var kvp in registryControls.SelectCheckBoxes)
            {
                if (scanAll || kvp.Value.Checked)
                {
                    categoriesToScan.Add(kvp.Key);
                }
            }

            if (categoriesToScan.Count == 0) return;

            registryControls.ScanSelectedBtn.Enabled = false;
            registryControls.ScanAllBtn.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            await Task.Run(() => Core.ScanRegistry(categoriesToScan));

            registryControls.ScanSelectedBtn.Enabled = true;
            registryControls.ScanAllBtn.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void ApplyLanguage()
        {
            Language.Current = Properties.Settings.Default.Language;

            homeBtn.Text = Language.Get("Menu_Home");
            optionsBtn.Text = Language.Get("Menu_Options");
            tweaksBtn.Text = Language.Get("Menu_Tweaks");
            registryBtn.Text = Language.Get("Menu_Registry");
            uninstallMenuBtn.Text = Language.Get("Menu_Uninstall");
            aboutBtn.Text = Language.Get("Menu_About");

            UpdateTexts(homePanel);
            UpdateTexts(optionsPanel);
            UpdateTexts(tweaksPanel);
            UpdateTexts(programsPanel);
            UpdateTexts(processPanel);
            UpdateTexts(registryPanel);
            UpdateTexts(aboutPanel);

            if (isProcessing)
            {
                processControls.StatusLabel.Text = isAnalysisMode ? Language.Get("Status_Analyzing") : Language.Get("Status_Cleaning");
            }
            else
            {
                processControls.StatusLabel.Text = Language.Get("Status_Ready");
            }

            DarkModeSwitch();
            activePanel.BringToFront();
        }

        private void UpdateTexts(Control parent)
        {
            if (parent == null) return;
            foreach (Control c in parent.Controls)
            {
                if (c.Tag is string key)
                {
                    c.Text = Language.Get(key);
                }
                if (c.HasChildren)
                {
                    UpdateTexts(c);
                }
            }
        }

        private void SignalUICoreEvents()
        {
            Core.OnLogUpdate = (logs) => BeginInvoke((MethodInvoker)delegate
            {
                processControls.ProcessBox.BeginUpdate();
                processControls.ProcessBox.Items.AddRange(logs);

                if (processControls.ProcessBox.Items.Count > 5000)
                {
                    int removeCount = processControls.ProcessBox.Items.Count - 5000;
                    while (removeCount > 0)
                    {
                        processControls.ProcessBox.Items.RemoveAt(0);
                        removeCount--;
                    }
                }

                processControls.ProcessBox.TopIndex = processControls.ProcessBox.Items.Count - 1;
                processControls.ProcessBox.EndUpdate();
            });

            Core.OnStatsUpdate = (fileCount, rejectCount, accessError) => BeginInvoke((MethodInvoker)delegate
            {
                processControls.Process_count.Text = $"{fileCount} / {rejectCount} / {accessError}";
            });

            Core.OnProcessFinished = (isFinished) => BeginInvoke((MethodInvoker)delegate
            {
                if (isFinished)
                {
                    processControls.StatusLabel.Text = Language.Get("Status_Completed");
                    processControls.Finish.Visible = true;
                    homeControls.Start.Enabled = true;
                    homeControls.Analysis.Enabled = true;
                    isProcessing = false;
                    stopButton.Visible = false;
                }
            });

            Core.OnUninstallLog = (log) => BeginInvoke((MethodInvoker)delegate
            {
                programsControls.UninstallLog_List.Items.Add(log);
                programsControls.UninstallLog_List.TopIndex = programsControls.UninstallLog_List.Items.Count - 1;
            });

            Core.OnUninstallProgress = (processed, total, text) => BeginInvoke((MethodInvoker)delegate
            {
                programsControls.Refresh_btn.Text = text;
            });

            Core.OnProgramsLoaded = (programs) => BeginInvoke((MethodInvoker)delegate
            {
                programsControls.Programs_CheckedList.Items.Clear();
                programsControls.Programs_CheckedList.BeginUpdate();
                foreach (var prog in programs) programsControls.Programs_CheckedList.Items.Add(prog);
                programsControls.Programs_CheckedList.EndUpdate();
                programsControls.Refresh_btn.Text = Language.Get("Button_Refresh");
                programsControls.Uninstall_btn.Enabled = true;
                programsControls.Refresh_btn.Enabled = true;
            });

            Core.OnRegistryCountUpdated = (categoryName, count) => BeginInvoke((MethodInvoker)delegate
            {
                if (registryControls.CountLabels.ContainsKey(categoryName))
                    registryControls.CountLabels[categoryName].Text = count.ToString();
            });
        }

        private void exitBtn_Click(object sender, EventArgs e) => Application.Exit();
        private void minimizeBtn_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void controlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _dragStartCursor = Cursor.Position;
            _dragStartFormLocation = Location;
        }

        private void controlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging) return;
            Point difference = Point.Subtract(Cursor.Position, new Size(_dragStartCursor));
            Location = Point.Add(_dragStartFormLocation, new Size(difference));
        }

        private void controlPanel_MouseUp(object sender, MouseEventArgs e) => _isDragging = false;

        private void homeBtn_Click(object sender, EventArgs e)
        {
            if (isProcessing) NavigateToPanel(processPanel, homeBtn);
            else NavigateToPanel(homePanel, homeBtn);
        }
        private void optionsBtn_Click(object sender, EventArgs e) => NavigateToPanel(optionsPanel, optionsBtn);
        private void tweaksBtn_Click(object sender, EventArgs e) => NavigateToPanel(tweaksPanel, tweaksBtn);
        private void registryBtn_Click(object sender, EventArgs e) => NavigateToPanel(registryPanel, registryBtn);
        private void uninstallMenuBtn_Click(object sender, EventArgs e) => NavigateToPanel(programsPanel, uninstallMenuBtn);
        private void aboutBtn_Click(object sender, EventArgs e) => NavigateToPanel(aboutPanel, aboutBtn);

        private void NavigateToPanel(Panel targetPanel, Button navButton)
        {
            activePanel = targetPanel;
            sidePanel.Top = navButton.Top;
            sidePanel.Height = navButton.Height;
            targetPanel.BringToFront();
        }

        private void SelectThread(int threadId, Panel targetPanel, Button navButton)
        {
            Core.SelectedThread = threadId;
            Properties.Settings.Default.SelectedThread = threadId;
            Properties.Settings.Default.Save();
            NavigateToPanel(targetPanel, navButton);
        }

        private async void StartProcess(bool isAnalysis)
        {
            this.isAnalysisMode = isAnalysis;
            processControls.ProcessBox.Items.Clear();
            processControls.Process_count.Text = "0 / 0 / 0";
            processControls.StatusLabel.Text = isAnalysis ? Language.Get("Status_Analyzing") : Language.Get("Status_Cleaning");
            processPanel.BringToFront();
            activePanel = processPanel;
            processControls.Finish.Visible = false;
            homeControls.Start.Enabled = false;
            homeControls.Analysis.Enabled = false;

            isProcessing = true;
            stopButton.Visible = true;
            stopButton.Enabled = true;
            stopButton.BringToFront();

            await Task.Delay(100);

            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            await Task.Run(() =>
            {
                if (isAnalysis) Core.StartAnalysis(token);
                else Core.StartCleaning(token);
            });
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                isProcessing = false;
                processControls.StatusLabel.Text = Language.Get("Status_Stopped");
                processControls.Finish.Visible = true;
                homeControls.Start.Enabled = true;
                homeControls.Analysis.Enabled = true;
                stopButton.Visible = false;
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            processControls.ProcessBox.Items.Clear();
            processControls.Process_count.Text = "0 / 0 / 0";
            processControls.StatusLabel.Text = Language.Get("Status_Ready");
            homePanel.BringToFront();
            activePanel = homePanel;
        }

        private void DarkModeSwitch()
        {
            bool isDark = Properties.Settings.Default.DarkMode;
            Color bg = isDark ? ColorTranslator.FromHtml("#444449") : Color.FromArgb(230, 230, 230);
            Color fg = isDark ? Color.White : Color.Black;

            this.BackColor = bg;
            foreach (Control c in Controls)
            {
                if (c is Panel && c.Name != "controlPanel" && c.Name != "sidePanel" && c.Name != "logoPanel")
                {
                    c.BackColor = bg;
                    c.ForeColor = fg;
                }
            }

            UI.ApplyTheme(homePanel, isDark);
            UI.ApplyTheme(optionsPanel, isDark);
            UI.ApplyTheme(tweaksPanel, isDark);
            UI.ApplyTheme(programsPanel, isDark);
            UI.ApplyTheme(processPanel, isDark);
            UI.ApplyTheme(registryPanel, isDark);
            UI.ApplyTheme(aboutPanel, isDark);
        }

        private void DarkModeButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DarkMode = !Properties.Settings.Default.DarkMode;
            Properties.Settings.Default.Save();
            DarkModeSwitch();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            DarkModeSwitch();
        }

        private void ExecuteTweak(Func<bool> tweakAction, string successMsg, string failMsg)
        {
            try
            {
                MessageBox.Show(tweakAction() ? successMsg : failMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void uninstallBtn_Click(object sender, EventArgs e)
        {
            programsControls.Uninstall_btn.Enabled = false;
            programsControls.Refresh_btn.Enabled = false;
            programsControls.UninstallLog_List.Items.Clear();

            List<Core.ProgramItem> selectedPrograms = new List<Core.ProgramItem>();
            foreach (var item in programsControls.Programs_CheckedList.CheckedItems)
            {
                if (item is Core.ProgramItem prog) selectedPrograms.Add(prog);
            }

            await Task.Run(() => Core.UninstallPrograms(selectedPrograms));

            programsControls.Uninstall_btn.Enabled = true;
            programsControls.Refresh_btn.Enabled = true;
            await Task.Run(() => Core.LoadPrograms());
        }

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            programsControls.Programs_CheckedList.Items.Clear();
            programsControls.UninstallLog_List.Items.Clear();
            programsControls.Uninstall_btn.Enabled = false;
            programsControls.Refresh_btn.Enabled = false;
            programsControls.Refresh_btn.Text = Language.Get("Status_Loading");

            await Task.Run(() => Core.LoadPrograms());
        }
    }
}