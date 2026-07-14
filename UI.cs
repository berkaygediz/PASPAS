using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PASPAS
{
    public static class UI
    {
        public class EcoProject
        {
            public string Name { get; set; }
            public string Desc { get; set; }
            public string Url { get; set; }
            public string ColorHex { get; set; }
        }

        public static void BuildAboutPanel(Panel parentPanel)
        {
            parentPanel.Controls.Clear();
            bool isDark = Properties.Settings.Default.DarkMode;

            LinkLabel titleLabel = new LinkLabel
            {
                Text = Language.Get("About_EcoTitle"),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20),
                Name = "EcoTitleLabel",
                LinkArea = new LinkArea(0, 12),
                UseMnemonic = false,
                Tag = "About_EcoTitle"
            };
            titleLabel.LinkClicked += (s, e) => Process.Start(new ProcessStartInfo("https://github.com/berkaygediz") { UseShellExecute = true });

            Label subtitleLabel = new Label
            {
                Text = Language.Get("About_EcoSub"),
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                AutoSize = true,
                Location = new Point(20, 55),
                Name = "EcoSubLabel",
                UseMnemonic = false,
                Tag = "About_EcoSub"
            };

            FlowLayoutPanel ecoScrollPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 90),
                Size = new Size(parentPanel.Width - 40, 162),
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                BorderStyle = BorderStyle.FixedSingle,
                Name = "EcoScrollPanel"
            };

            ecoScrollPanel.MouseWheel += (s, e) =>
            {
                if (e.Delta > 0)
                    ecoScrollPanel.HorizontalScroll.Value = Math.Max(0, ecoScrollPanel.HorizontalScroll.Value - 50);
                else
                    ecoScrollPanel.HorizontalScroll.Value = Math.Min(ecoScrollPanel.HorizontalScroll.Maximum, ecoScrollPanel.HorizontalScroll.Value + 50);
            };

            var projects = new List<EcoProject>
            {
                new EcoProject { Name = "OpenLapis Connect", Desc = "Cross-platform data bridge linking browser extensions, desktop & mobile apps.", Url = "https://github.com/berkaygediz/openlapis-connect", ColorHex = "#40e0d0" },
                new EcoProject { Name = "SolidWriting", Desc = "A modern word processor with AI integration, supporting real-time computing and advanced formatting.", Url = "https://github.com/berkaygediz/SolidWriting", ColorHex = "#3f5ebd" },
                new EcoProject { Name = "SolidSheets", Desc = "A modern spreadsheet editor with ML integration, supporting real-time graphs and formulas.", Url = "https://github.com/berkaygediz/SolidSheets", ColorHex = "#419c62" },
                new EcoProject { Name = "PASPAS", Desc = "All-in-one system utility to clean temporary files, review registry entries, uninstall programs, and tweak Windows performance.", Url = "https://github.com/berkaygediz/PASPAS", ColorHex = "#9e9e24" },
                new EcoProject { Name = "uKick", Desc = "All-in-one extension to block, boost and tweak everything on Kick.", Url = "https://github.com/berkaygediz/uKick", ColorHex = "#1a7e4c" },
                new EcoProject { Name = "uDittor", Desc = "All-in-one extension to block and tweak everything on Reddit.", Url = "https://github.com/berkaygediz/uDittor", ColorHex = "#c4502a" },
                new EcoProject { Name = "uSozluk", Desc = "All-in-one extension to block and tweak everything on Ekşi Sözlük.", Url = "https://github.com/berkaygediz/uSozluk", ColorHex = "#d4a90a" },
                new EcoProject { Name = "Universal Blocklist", Desc = "Global blocklist for YouTube, Reddit & more.", Url = "https://github.com/berkaygediz/universal-blocklist", ColorHex = "#666666" },
                new EcoProject { Name = "LocalModerationMatrix", Desc = "CLI tool for bulk message deletion, media cleanup, and public room moderation in Matrix.", Url = "https://github.com/berkaygediz/LocalModerationMatrix", ColorHex = "#cccccc" },
                new EcoProject { Name = "LocalModerationLemmy", Desc = "Full-featured, cross-instance moderation panel for Lemmy communities.", Url = "https://github.com/berkaygediz/LocalModerationLemmy", ColorHex = "#cccccc" }
            };

            foreach (var proj in projects)
            {
                ecoScrollPanel.Controls.Add(CreateEcoCard(proj));
            }

            Button buyCoffeeButton = new Button
            {
                Name = "BuyCoffeeButton",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(490, 380),
                Size = new Size(170, 38),
                Text = "Buy Me a Coffee",
                FlatAppearance = { BorderSize = 1 }
            };
            buyCoffeeButton.Click += (s, e) => Process.Start(new ProcessStartInfo("https://buymeacoffee.com/berkaygediz") { UseShellExecute = true });

            parentPanel.Controls.Add(titleLabel);
            parentPanel.Controls.Add(subtitleLabel);
            parentPanel.Controls.Add(ecoScrollPanel);
            parentPanel.Controls.Add(buyCoffeeButton);
        }

        private static Panel CreateEcoCard(EcoProject proj)
        {
            bool isDark = Properties.Settings.Default.DarkMode;
            Panel card = new Panel
            {
                Width = 200,
                Height = 120,
                Margin = new Padding(10),
                BackColor = isDark ? ColorTranslator.FromHtml("#262626") : Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            Panel topBorder = new Panel
            {
                Dock = DockStyle.Top,
                Height = 4,
                BackColor = ColorTranslator.FromHtml(proj.ColorHex)
            };

            Label titleLabel = new Label
            {
                Text = proj.Name,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml(proj.ColorHex),
                AutoSize = false,
                Width = 180,
                Height = 25,
                Top = 10,
                Left = 10,
                UseMnemonic = false,
                Cursor = Cursors.Hand
            };

            Label descLabel = new Label
            {
                Text = proj.Desc,
                Font = new Font("Segoe UI", 8F),
                ForeColor = isDark ? Color.White : Color.Black,
                AutoSize = false,
                Width = 180,
                Height = 75,
                Top = 35,
                Left = 10,
                UseMnemonic = false,
                Cursor = Cursors.Hand
            };

            card.Controls.Add(topBorder);
            card.Controls.Add(descLabel);
            card.Controls.Add(titleLabel);

            EventHandler openUrl = (s, e) => Process.Start(new ProcessStartInfo(proj.Url) { UseShellExecute = true });
            card.Click += openUrl;
            titleLabel.Click += openUrl;
            descLabel.Click += openUrl;

            return card;
        }

        private static Panel CreateCard(string title, string desc, string titleKey, string descKey, int y, int height, object tag, out Panel inner, out Label titleLabel, out Label descLabel)
        {
            Panel card = new Panel { Location = new Point(20, y), Size = new Size(640, height), Cursor = Cursors.Hand, Tag = tag };
            inner = new Panel { Location = new Point(1, 1), Size = new Size(638, height - 2), Cursor = Cursors.Hand };

            titleLabel = new Label { Text = title, Tag = titleKey, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(15, 4), Size = new Size(510, 16), Cursor = Cursors.Hand, UseMnemonic = false, Name = "titleLabel" };
            descLabel = new Label { Text = desc, Tag = descKey, Font = new Font("Segoe UI", 8F), Location = new Point(15, 21), Size = new Size(608, 15), Cursor = Cursors.Hand, UseMnemonic = false, Name = "descLabel" };

            inner.Controls.Add(descLabel);
            inner.Controls.Add(titleLabel);
            card.Controls.Add(inner);

            return card;
        }

        private static void WireCardClick(Panel card, Panel inner, Label titleLabel, Label descLabel, EventHandler action)
        {
            card.Click += action;
            inner.Click += action;
            titleLabel.Click += action;
            descLabel.Click += action;
        }

        public class HomeControls
        {
            public RadioButton Basic_select;
            public RadioButton Advanced_select;
            public RadioButton Special_select;
            public Button Start;
            public Button Analysis;
        }

        public static HomeControls BuildHomePanel(Panel parentPanel)
        {
            HomeControls controls = new HomeControls();
            parentPanel.Controls.Clear();

            void BuildModeCard(string title, string desc, string titleKey, string descKey, int y, string radioName)
            {
                RadioButton radio = new RadioButton { Name = radioName, Visible = false, Location = new Point(0, 0), Size = new Size(0, 0) };
                parentPanel.Controls.Add(radio);

                if (radioName == "Basic_select") controls.Basic_select = radio;
                else if (radioName == "Advanced_select") controls.Advanced_select = radio;
                else if (radioName == "Special_select") controls.Special_select = radio;

                Panel card = CreateCard(title, desc, titleKey, descKey, y, 80, radio, out Panel inner, out Label titleLabel, out Label descLabel);
                titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                titleLabel.Size = new Size(608, 25);
                descLabel.Font = new Font("Segoe UI", 9F);
                descLabel.Size = new Size(608, 35);
                descLabel.Location = new Point(15, 35);

                parentPanel.Controls.Add(card);
                WireCardClick(card, inner, titleLabel, descLabel, (s, e) => radio.Checked = true);

                radio.CheckedChanged += (s, e) => ApplyCardTheme(card, Properties.Settings.Default.DarkMode);
            }

            BuildModeCard(Language.Get("Home_Basic_Title"), Language.Get("Home_Basic_Desc"), "Home_Basic_Title", "Home_Basic_Desc", 60, "Basic_select");
            BuildModeCard(Language.Get("Home_Advanced_Title"), Language.Get("Home_Advanced_Desc"), "Home_Advanced_Title", "Home_Advanced_Desc", 150, "Advanced_select");
            BuildModeCard(Language.Get("Home_Custom_Title"), Language.Get("Home_Custom_Desc"), "Home_Custom_Title", "Home_Custom_Desc", 240, "Special_select");

            controls.Start = new Button { Name = "StartBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Location = new Point(20, 365), Size = new Size(310, 44), Text = Language.Get("Button_Run"), Tag = "Button_Run", FlatAppearance = { BorderSize = 0 } };
            controls.Analysis = new Button { Name = "AnalysisBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Location = new Point(350, 365), Size = new Size(310, 44), Text = Language.Get("Button_Analyze"), Tag = "Button_Analyze", FlatAppearance = { BorderSize = 1 } };

            parentPanel.Controls.Add(controls.Start);
            parentPanel.Controls.Add(controls.Analysis);

            return controls;
        }

        public class OptionItem
        {
            public string Key { get; set; }
            public string TitleKey { get; set; }
            public string DescKey { get; set; }
            public string Title { get; set; }
            public string Desc { get; set; }
        }

        public class OptionsControls
        {
            public Dictionary<string, CheckBox> OptionCheckBoxes = new Dictionary<string, CheckBox>();
            public Button DarkModeButton;
            public Button ResetButton;
        }

        public static OptionsControls BuildOptionsPanel(Panel parentPanel)
        {
            OptionsControls controls = new OptionsControls();
            parentPanel.Controls.Clear();

            List<OptionItem> options = new List<OptionItem>
            {
                new OptionItem { Key = "Clipboard", TitleKey = "Options_Clipboard_Title", DescKey = "Options_Clipboard_Desc", Title = Language.Get("Options_Clipboard_Title"), Desc = Language.Get("Options_Clipboard_Desc") },
                new OptionItem { Key = "TemporaryFiles", TitleKey = "Options_TempFiles_Title", DescKey = "Options_TempFiles_Desc", Title = Language.Get("Options_TempFiles_Title"), Desc = Language.Get("Options_TempFiles_Desc") },
                new OptionItem { Key = "DownloadedInstallations", TitleKey = "Options_DownloadedInst_Title", DescKey = "Options_DownloadedInst_Desc", Title = Language.Get("Options_DownloadedInst_Title"), Desc = Language.Get("Options_DownloadedInst_Desc") },
                new OptionItem { Key = "RecentlyUsed", TitleKey = "Options_Recent_Title", DescKey = "Options_Recent_Desc", Title = Language.Get("Options_Recent_Title"), Desc = Language.Get("Options_Recent_Desc") },
                new OptionItem { Key = "PreviewCache", TitleKey = "Options_Preview_Title", DescKey = "Options_Preview_Desc", Title = Language.Get("Options_Preview_Title"), Desc = Language.Get("Options_Preview_Desc") },
                new OptionItem { Key = "DNSCache", TitleKey = "Options_DNS_Title", DescKey = "Options_DNS_Desc", Title = Language.Get("Options_DNS_Title"), Desc = Language.Get("Options_DNS_Desc") },
                new OptionItem { Key = "Logs", TitleKey = "Options_Logs_Title", DescKey = "Options_Logs_Desc", Title = Language.Get("Options_Logs_Title"), Desc = Language.Get("Options_Logs_Desc") },
                new OptionItem { Key = "SystemCache", TitleKey = "Options_SysCache_Title", DescKey = "Options_SysCache_Desc", Title = Language.Get("Options_SysCache_Title"), Desc = Language.Get("Options_SysCache_Desc") },
                new OptionItem { Key = "MemoryDumps", TitleKey = "Options_MemDumps_Title", DescKey = "Options_MemDumps_Desc", Title = Language.Get("Options_MemDumps_Title"), Desc = Language.Get("Options_MemDumps_Desc") },
                new OptionItem { Key = "Prefetch", TitleKey = "Options_Prefetch_Title", DescKey = "Options_Prefetch_Desc", Title = Language.Get("Options_Prefetch_Title"), Desc = Language.Get("Options_Prefetch_Desc") },
                new OptionItem { Key = "FontCache", TitleKey = "Options_FontCache_Title", DescKey = "Options_FontCache_Desc", Title = Language.Get("Options_FontCache_Title"), Desc = Language.Get("Options_FontCache_Desc") },
                new OptionItem { Key = "DownloadCache", TitleKey = "Options_DownCache_Title", DescKey = "Options_DownCache_Desc", Title = Language.Get("Options_DownCache_Title"), Desc = Language.Get("Options_DownCache_Desc") },
                new OptionItem { Key = "OldWindows", TitleKey = "Options_OldWin_Title", DescKey = "Options_OldWin_Desc", Title = Language.Get("Options_OldWin_Title"), Desc = Language.Get("Options_OldWin_Desc") },
                new OptionItem { Key = "SysLogErrorRep", TitleKey = "Options_SysLogErr_Title", DescKey = "Options_SysLogErr_Desc", Title = Language.Get("Options_SysLogErr_Title"), Desc = Language.Get("Options_SysLogErr_Desc") }
            };

            int yPos = 55;
            int cardHeight = 40;
            int gap = 4;

            foreach (var opt in options)
            {
                CheckBox checkBox = new CheckBox { Name = opt.Key + "_checkbox", Visible = false, Location = new Point(0, 0), Size = new Size(0, 0) };
                parentPanel.Controls.Add(checkBox);
                controls.OptionCheckBoxes[opt.Key] = checkBox;

                Panel card = CreateCard(opt.Title, opt.Desc, opt.TitleKey, opt.DescKey, yPos, cardHeight, checkBox, out Panel inner, out Label titleLabel, out Label descLabel);
                parentPanel.Controls.Add(card);

                WireCardClick(card, inner, titleLabel, descLabel, (s, e) => checkBox.Checked = !checkBox.Checked);
                checkBox.CheckedChanged += (s, e) => ApplyCardTheme(card, Properties.Settings.Default.DarkMode);
                yPos += cardHeight + gap;
            }

            parentPanel.Controls.Add(new Panel { Location = new Point(0, yPos), Size = new Size(1, 20) });

            controls.DarkModeButton = new Button { Name = "DarkModeBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(460, 7), Size = new Size(100, 34), Text = Language.Get("Button_DarkMode"), Tag = "Button_DarkMode", FlatAppearance = { BorderSize = 1 } };
            controls.ResetButton = new Button { Name = "ResetBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(570, 7), Size = new Size(86, 34), Text = Language.Get("Button_Reset"), Tag = "Button_Reset", FlatAppearance = { BorderSize = 1 } };

            parentPanel.Controls.Add(controls.DarkModeButton);
            parentPanel.Controls.Add(controls.ResetButton);

            return controls;
        }

        public class TweaksControls
        {
            public Button SetServicesManual_btn;
            public Button DisableTelemetry_btn;
            public Button DisableActivity_btn;
        }

        public static TweaksControls BuildTweaksPanel(Panel parentPanel)
        {
            TweaksControls controls = new TweaksControls();
            parentPanel.Controls.Clear();

            Panel disclaimerPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 20),
                Size = new Size(640, 40),
                Name = "TweaksDisclaimer"
            };

            Label disclaimerLabel = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Location = new Point(15, 0),
                Size = new Size(610, 40),
                Text = Language.Get("Tweaks_Disclaimer"),
                UseMnemonic = false,
                Name = "DisclaimerText",
                Tag = "Tweaks_Disclaimer",
                TextAlign = ContentAlignment.MiddleCenter
            };
            disclaimerPanel.Controls.Add(disclaimerLabel);
            parentPanel.Controls.Add(disclaimerPanel);

            void BuildTweakCard(string title, string desc, string titleKey, string descKey, int y, string buttonName, ref Button targetButton)
            {
                Panel card = new Panel { Location = new Point(20, y), Size = new Size(640, 44), Name = "TweakCard", Tag = null };
                Panel inner = new Panel { Location = new Point(1, 1), Size = new Size(638, 42) };

                Label titleLabel = new Label { Text = title, Tag = titleKey, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(15, 5), Size = new Size(500, 18), UseMnemonic = false, Name = "titleLabel" };
                Label descLabel = new Label { Text = desc, Tag = descKey, Font = new Font("Segoe UI", 8F), Location = new Point(15, 23), Size = new Size(500, 15), UseMnemonic = false, Name = "descLabel" };

                Button actionButton = new Button
                {
                    Name = buttonName,
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(525, 5),
                    Size = new Size(100, 34),
                    Text = Language.Get("Button_Apply"),
                    Tag = "Button_Apply",
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatAppearance = { BorderSize = 1 }
                };

                inner.Controls.Add(descLabel);
                inner.Controls.Add(titleLabel);
                inner.Controls.Add(actionButton);
                card.Controls.Add(inner);
                parentPanel.Controls.Add(card);
                targetButton = actionButton;
            }

            BuildTweakCard(Language.Get("Tweaks_Services_Title"), Language.Get("Tweaks_Services_Desc"), "Tweaks_Services_Title", "Tweaks_Services_Desc", 70, "SetServicesManual_btn", ref controls.SetServicesManual_btn);
            BuildTweakCard(Language.Get("Tweaks_Telemetry_Title"), Language.Get("Tweaks_Telemetry_Desc"), "Tweaks_Telemetry_Title", "Tweaks_Telemetry_Desc", 118, "DisableTelemetry_btn", ref controls.DisableTelemetry_btn);
            BuildTweakCard(Language.Get("Tweaks_Activity_Title"), Language.Get("Tweaks_Activity_Desc"), "Tweaks_Activity_Title", "Tweaks_Activity_Desc", 166, "DisableActivity_btn", ref controls.DisableActivity_btn);

            return controls;
        }

        public class ProgramsControls
        {
            public CheckedListBox Programs_CheckedList;
            public ListBox UninstallLog_List;
            public Button Uninstall_btn;
            public Button Refresh_btn;
        }

        public static ProgramsControls BuildProgramsPanel(Panel parentPanel)
        {
            ProgramsControls controls = new ProgramsControls();
            parentPanel.Controls.Clear();

            Panel riskPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 20),
                Size = new Size(640, 40),
                Name = "ProgramsRisk"
            };

            Label riskLabel = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Location = new Point(15, 0),
                Size = new Size(610, 40),
                Text = Language.Get("Programs_Risk"),
                UseMnemonic = false,
                Name = "RiskText",
                Tag = "Programs_Risk",
                TextAlign = ContentAlignment.MiddleCenter
            };
            riskPanel.Controls.Add(riskLabel);
            parentPanel.Controls.Add(riskPanel);

            controls.Programs_CheckedList = new CheckedListBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 8.25F),
                FormattingEnabled = true,
                Location = new Point(20, 70),
                Size = new Size(395, 285)
            };
            AttachSmoothScroll(controls.Programs_CheckedList);

            controls.UninstallLog_List = new ListBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                FormattingEnabled = true,
                Location = new Point(425, 70),
                Size = new Size(235, 285)
            };

            controls.Refresh_btn = new Button { Name = "RefreshBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(20, 365), Size = new Size(310, 44), Text = Language.Get("Button_Refresh"), Tag = "Button_Refresh", FlatAppearance = { BorderSize = 1 } };
            controls.Uninstall_btn = new Button { Name = "UninstallBtn", Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(350, 365), Size = new Size(310, 44), Text = Language.Get("Button_Uninstall"), Tag = "Button_Uninstall", FlatAppearance = { BorderSize = 0 } };

            parentPanel.Controls.Add(controls.Refresh_btn);
            parentPanel.Controls.Add(controls.UninstallLog_List);
            parentPanel.Controls.Add(controls.Programs_CheckedList);
            parentPanel.Controls.Add(controls.Uninstall_btn);

            return controls;
        }

        public class ProcessControls
        {
            public Button Finish;
            public Label StatusLabel;
            public Label Process_count;
            public ListBox ProcessBox;
        }

        public static ProcessControls BuildProcessPanel(Panel parentPanel)
        {
            ProcessControls controls = new ProcessControls();
            parentPanel.Controls.Clear();

            Panel titlePanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 19),
                Size = new Size(640, 90),
                Name = "ProcessTitlePanel"
            };

            controls.StatusLabel = new Label
            {
                Text = Language.Get("Status_Ready"),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 5),
                Size = new Size(640, 25),
                UseMnemonic = false,
                Name = "StatusLabel"
            };

            controls.Process_count = new Label
            {
                Text = "0 / 0 / 0",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 30),
                Size = new Size(640, 35),
                AutoSize = false,
                Name = "ProcessCount"
            };

            Label subtextLabel = new Label
            {
                Text = Language.Get("Label_StatsSubtext"),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 65),
                Size = new Size(640, 20),
                UseMnemonic = false,
                Name = "ProcessSubtext",
                Tag = "Label_StatsSubtext"
            };

            titlePanel.Controls.Add(subtextLabel);
            titlePanel.Controls.Add(controls.Process_count);
            titlePanel.Controls.Add(controls.StatusLabel);

            controls.ProcessBox = new ListBox
            {
                FormattingEnabled = true,
                Location = new Point(20, 115),
                Size = new Size(640, 235),
                BorderStyle = BorderStyle.FixedSingle
            };
            AttachSmoothScroll(controls.ProcessBox);

            controls.Finish = new Button
            {
                Name = "FinishBtn",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 365),
                Size = new Size(640, 44),
                Text = Language.Get("Button_Finish"),
                Visible = false,
                Tag = "Button_Finish",
                FlatAppearance = { BorderSize = 0 }
            };

            parentPanel.Controls.Add(controls.Finish);
            parentPanel.Controls.Add(titlePanel);
            parentPanel.Controls.Add(controls.ProcessBox);

            return controls;
        }

        public class RegistryControls
        {
            public CheckBox SelectAllCategoriesChk;
            public Dictionary<string, CheckBox> SelectCheckBoxes = new();
            public Dictionary<string, Button> DetailButtons = new();
            public Dictionary<string, Label> CountLabels = new();
            public Dictionary<string, Panel> CategoryCards = new();

            public Panel DetailPanel;
            public Button BackBtn;
            public Label DetTitle;
            public Label DetDesc;
            public CheckBox SelectAllChk;
            public CheckedListBox ItemsList;
            public Button DeleteBtn;

            public Button ScanSelectedBtn;
            public Button ScanAllBtn;

            public string CurrentDetailCategory = "";

            public void ShowDetail(string categoryName)
            {
                CurrentDetailCategory = categoryName;
                DetTitle.Text = Globals.RegistryCategories[categoryName].Title;
                DetDesc.Text = Globals.RegistryCategories[categoryName].Desc;
                SelectAllChk.Checked = false;
                PopulateList(categoryName);
                DetailPanel.Visible = true;
                DetailPanel.BringToFront();
            }

            public void PopulateList(string categoryName)
            {
                ItemsList.BeginUpdate();
                ItemsList.Items.Clear();
                if (Core.RegistryResults.ContainsKey(categoryName))
                {
                    foreach (var item in Core.RegistryResults[categoryName])
                        ItemsList.Items.Add(item, false);
                }
                ItemsList.EndUpdate();
            }
        }

        public static RegistryControls BuildRegistryPanel(Panel parentPanel)
        {
            RegistryControls controls = new RegistryControls();
            parentPanel.Controls.Clear();

            Panel disclaimerPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 20),
                Size = new Size(640, 40),
                Name = "RegistryDisclaimer"
            };
            Label disclaimerLabel = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Location = new Point(15, 0),
                Size = new Size(610, 40),
                Text = Language.Get("Registry_Disclaimer"),
                ForeColor = Color.Gray,
                UseMnemonic = false,
                Name = "DisclaimerText",
                Tag = "Registry_Disclaimer",
                TextAlign = ContentAlignment.MiddleCenter
            };
            disclaimerPanel.Controls.Add(disclaimerLabel);
            parentPanel.Controls.Add(disclaimerPanel);

            controls.SelectAllCategoriesChk = new CheckBox
            {
                Text = Language.Get("Button_SelectAll"),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(20, 65),
                Size = new Size(150, 25),
                Checked = false,
                Tag = "Button_SelectAll"
            };
            parentPanel.Controls.Add(controls.SelectAllCategoriesChk);

            Panel cardsContainer = new Panel
            {
                Location = new Point(20, 95),
                Size = new Size(640, 260),
                AutoScroll = true,
                BorderStyle = BorderStyle.None,
                Name = "RegCardsContainer"
            };
            parentPanel.Controls.Add(cardsContainer);

            int yPos = 0;
            int cardHeight = 44;
            int gap = 4;

            foreach (var kvp in Globals.RegistryCategories)
            {
                string categoryName = kvp.Key;
                var category = kvp.Value;

                Panel card = new Panel { Location = new Point(0, yPos), Size = new Size(620, cardHeight), Name = "RegCard", Tag = null };
                Panel inner = new Panel { Location = new Point(1, 1), Size = new Size(618, cardHeight - 2), Name = "RegCardInner" };

                CheckBox checkBox = new CheckBox { Location = new Point(10, 14), Size = new Size(15, 15), Checked = false };
                controls.SelectCheckBoxes[categoryName] = checkBox;

                Label titleLabel = new Label { Text = category.Title, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(35, 5), Size = new Size(400, 18), Name = "titleLabel" };
                Label descLabel = new Label { Text = category.Desc, Font = new Font("Segoe UI", 8F), Location = new Point(35, 23), Size = new Size(400, 15), ForeColor = Color.Gray, Name = "descLabel" };

                Label countLabel = new Label
                {
                    Text = "0",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(50, 34),
                    Location = new Point(515, 4),
                    Name = "countLabel",
                    TextAlign = ContentAlignment.MiddleRight
                };
                controls.CountLabels[categoryName] = countLabel;

                Button detailButton = new Button
                {
                    Text = ">",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(34, 34),
                    Location = new Point(572, 4),
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatAppearance = { BorderSize = 0 }
                };
                controls.DetailButtons[categoryName] = detailButton;

                inner.Controls.Add(checkBox);
                inner.Controls.Add(titleLabel);
                inner.Controls.Add(descLabel);
                inner.Controls.Add(countLabel);
                inner.Controls.Add(detailButton);

                card.Controls.Add(inner);
                cardsContainer.Controls.Add(card);
                controls.CategoryCards[categoryName] = card;
                yPos += cardHeight + gap;
            }

            controls.ScanSelectedBtn = new Button { Name = "ScanSelBtn", Text = Language.Get("Button_ScanSelected"), Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(20, 365), Size = new Size(310, 44), Tag = "Button_ScanSelected", FlatAppearance = { BorderSize = 0 } };
            controls.ScanAllBtn = new Button { Name = "ScanAllBtn", Text = Language.Get("Button_ScanAll"), Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(350, 365), Size = new Size(310, 44), Tag = "Button_ScanAll", FlatAppearance = { BorderSize = 1 } };
            parentPanel.Controls.Add(controls.ScanSelectedBtn);
            parentPanel.Controls.Add(controls.ScanAllBtn);

            controls.DetailPanel = new Panel { Location = new Point(20, 20), Size = new Size(640, 432), Visible = false, Name = "RegDetailPanel" };

            Panel detailHeader = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(0, 0),
                Size = new Size(640, 60),
                Name = "RegDetailHeader"
            };

            controls.BackBtn = new Button { Text = "<", Font = new Font("Segoe UI", 12F, FontStyle.Bold), FlatStyle = FlatStyle.Flat, Size = new Size(34, 34), Location = new Point(10, 13), Cursor = Cursors.Hand, FlatAppearance = { BorderSize = 0 } };

            controls.DetTitle = new Label { Font = new Font("Segoe UI", 11F, FontStyle.Bold), AutoSize = false, Size = new Size(580, 25), Location = new Point(54, 8), TextAlign = ContentAlignment.MiddleLeft, Name = "titleLabel" };
            controls.DetDesc = new Label { Font = new Font("Segoe UI", 8F), AutoSize = false, Size = new Size(580, 20), Location = new Point(54, 30), TextAlign = ContentAlignment.MiddleLeft, ForeColor = Color.Gray, Name = "descLabel" };

            detailHeader.Controls.Add(controls.BackBtn);
            detailHeader.Controls.Add(controls.DetTitle);
            detailHeader.Controls.Add(controls.DetDesc);
            controls.DetailPanel.Controls.Add(detailHeader);

            controls.SelectAllChk = new CheckBox { Text = Language.Get("Button_SelectAll"), Font = new Font("Segoe UI", 9F), Location = new Point(10, 70), Size = new Size(150, 25), Tag = "Button_SelectAll" };

            controls.ItemsList = new CheckedListBox { BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 8.25F), FormattingEnabled = true, Location = new Point(10, 100), Size = new Size(620, 250), CheckOnClick = true };
            AttachSmoothScroll(controls.ItemsList);

            controls.DeleteBtn = new Button { Name = "RegDeleteBtn", Text = Language.Get("Button_Delete"), Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, 365), Size = new Size(620, 44), Tag = "Button_Delete", FlatAppearance = { BorderSize = 0 } };

            controls.DetailPanel.Controls.Add(controls.SelectAllChk);
            controls.DetailPanel.Controls.Add(controls.ItemsList);
            controls.DetailPanel.Controls.Add(controls.DeleteBtn);

            parentPanel.Controls.Add(controls.DetailPanel);

            return controls;
        }

        private static void AttachSmoothScroll(ListBox listBox)
        {
            listBox.MouseWheel += (s, e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
                int scrollAmount = 3;
                if (e.Delta > 0)
                    listBox.TopIndex = Math.Max(0, listBox.TopIndex - scrollAmount);
                else
                    listBox.TopIndex = Math.Min(listBox.Items.Count - 1, listBox.TopIndex + scrollAmount);
            };
        }

        public static void ApplyTheme(Control parent, bool isDark)
        {
            Color bgPanel = isDark ? Color.FromArgb(68, 68, 73) : Color.FromArgb(230, 230, 230);
            Color bgInput = isDark ? Color.FromArgb(30, 30, 30) : Color.White;
            Color bgButton = isDark ? Color.FromArgb(45, 45, 45) : Color.White;
            Color fgText = isDark ? Color.White : Color.FromArgb(30, 30, 30);
            Color borderButton = isDark ? Color.FromArgb(100, 100, 100) : Color.FromArgb(200, 200, 200);

            if (parent is Panel mainPanel) mainPanel.BackColor = bgPanel;

            foreach (Control c in parent.Controls)
            {
                if (c is Panel card && (card.Tag is RadioButton || card.Tag is CheckBox || card.Name == "TweakCard" || card.Name == "RegCard"))
                {
                    ApplyCardTheme(card, isDark);
                }
                else if (c is Panel detPanel && detPanel.Name == "RegDetailPanel")
                {
                    detPanel.BackColor = bgPanel;
                    foreach (Control detCtrl in detPanel.Controls)
                    {
                        if (detCtrl is Panel detHeader && detHeader.Name == "RegDetailHeader")
                        {
                            detHeader.BackColor = isDark ? Color.FromArgb(45, 45, 48) : Color.FromArgb(240, 240, 240);
                            foreach (Control hdrCtrl in detHeader.Controls)
                            {
                                if (hdrCtrl is Label hdrLbl)
                                    hdrLbl.ForeColor = hdrLbl.Name == "descLabel" ? (isDark ? Color.LightGray : Color.FromArgb(80, 80, 80)) : fgText;
                                else if (hdrCtrl is Button backBtn)
                                {
                                    backBtn.BackColor = detHeader.BackColor;
                                    backBtn.ForeColor = fgText;
                                }
                            }
                        }
                        else if (detCtrl is Label dl) dl.ForeColor = fgText;
                        else if (detCtrl is Button db)
                        {
                            db.BackColor = db.Name == "RegDeleteBtn" ? (isDark ? Color.FromArgb(146, 43, 33) : Color.FromArgb(192, 57, 43)) : bgButton;
                            db.ForeColor = Color.White;
                            db.FlatAppearance.BorderColor = borderButton;
                        }
                        else if (detCtrl is CheckedListBox clb) { clb.BackColor = bgInput; clb.ForeColor = fgText; }
                        else if (detCtrl is CheckBox chk) chk.ForeColor = fgText;
                    }
                }
                else if (c is Panel banner && (banner.Name == "TweaksDisclaimer" || banner.Name == "ProgramsRisk" || banner.Name == "RegistryDisclaimer"))
                {
                    banner.BackColor = isDark ? Color.FromArgb(60, 40, 40) : Color.FromArgb(250, 230, 230);
                    foreach (Control inner in banner.Controls)
                        if (inner is Label lbl) lbl.ForeColor = fgText;
                }
                else if (c is Panel procPanel && procPanel.Name == "ProcessTitlePanel")
                {
                    procPanel.BackColor = isDark ? Color.FromArgb(45, 45, 48) : Color.FromArgb(240, 240, 240);
                    foreach (Control inner in procPanel.Controls)
                        if (inner is Label lbl) lbl.ForeColor = lbl.Name == "ProcessSubtext" ? (isDark ? Color.LightGray : Color.FromArgb(80, 80, 80)) : fgText;
                }
                else if (c is FlowLayoutPanel ecoScroll && ecoScroll.Name == "EcoScrollPanel")
                {
                    ecoScroll.BackColor = bgPanel;
                    foreach (Panel ecoCard in ecoScroll.Controls)
                    {
                        ecoCard.BackColor = isDark ? ColorTranslator.FromHtml("#262626") : Color.White;
                        foreach (Control inner in ecoCard.Controls)
                            if (inner is Label lblDesc) lblDesc.ForeColor = fgText;
                    }
                }
                else if (c is Panel p) { ApplyTheme(p, isDark); }
                else if (c is Button btn)
                {
                    // color
                    if (btn.Name == "StartBtn" || btn.Name == "ScanSelBtn")
                    {
                        btn.BackColor = Color.FromArgb(252, 199, 55);
                        btn.ForeColor = Color.Black;
                        btn.FlatAppearance.BorderColor = btn.BackColor;
                    }
                    else if (btn.Name == "UninstallBtn" || btn.Name == "RegDeleteBtn")
                    {
                        btn.BackColor = isDark ? Color.FromArgb(146, 43, 33) : Color.FromArgb(192, 57, 43);
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = btn.BackColor;
                    }
                    else if (btn.Name == "FinishBtn")
                    {
                        btn.BackColor = isDark ? Color.FromArgb(56, 142, 60) : Color.FromArgb(46, 139, 87);
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = btn.BackColor;
                    }
                    else if (btn.Name == "StopButton")
                    {
                        btn.BackColor = isDark ? Color.FromArgb(146, 43, 33) : Color.FromArgb(192, 57, 43);
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = btn.BackColor;
                    }
                    else
                    {
                        btn.BackColor = bgButton;
                        btn.ForeColor = fgText;
                        btn.FlatAppearance.BorderColor = borderButton;
                        if (btn.Name == "DarkModeBtn") btn.Text = isDark ? Language.Get("Button_LightMode") : Language.Get("Button_DarkMode");
                    }
                }
                else if (c is ListBox lb) { lb.BackColor = bgInput; lb.ForeColor = fgText; }
                else if (c is CheckedListBox clb) { clb.BackColor = bgInput; clb.ForeColor = fgText; }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = fgText;
                    if (lbl is LinkLabel linkLbl)
                    {
                        linkLbl.LinkColor = isDark ? ColorTranslator.FromHtml("#58a6ff") : ColorTranslator.FromHtml("#0969da");
                        linkLbl.VisitedLinkColor = linkLbl.LinkColor;
                    }
                }
            }
        }

        private static void ApplyCardTheme(Panel card, bool isDark)
        {
            bool isChecked = false;
            if (card.Tag is RadioButton radio) isChecked = radio.Checked;
            else if (card.Tag is CheckBox chk) isChecked = chk.Checked;

            Panel inner = card.Controls.Count > 0 ? (Panel)card.Controls[0] : null;
            if (inner == null) return;

            Color borderDefault = isDark ? Color.FromArgb(100, 100, 100) : Color.FromArgb(210, 210, 210);
            Color bgDefault = isDark ? Color.FromArgb(45, 45, 45) : Color.White;
            Color titleColor = isDark ? Color.White : Color.FromArgb(30, 30, 30);
            Color descColor = isDark ? Color.LightGray : Color.FromArgb(80, 80, 80);

            if (card.Tag is CheckBox)
            {
                borderDefault = isDark ? Color.FromArgb(100, 60, 60) : Color.FromArgb(230, 200, 200);
                Color borderSelected = isDark ? Color.FromArgb(80, 200, 120) : Color.FromArgb(80, 180, 100);
                Color bgSelected = isDark ? Color.FromArgb(30, 50, 35) : Color.FromArgb(230, 245, 230);

                card.BackColor = isChecked ? borderSelected : borderDefault;
                inner.BackColor = isChecked ? bgSelected : bgDefault;
            }
            else if (card.Tag is RadioButton)
            {
                Color borderSelected = isDark ? Color.White : Color.Black;
                Color bgSelected = isDark ? Color.FromArgb(25, 25, 25) : Color.FromArgb(240, 240, 240);

                card.BackColor = isChecked ? borderSelected : borderDefault;
                inner.BackColor = isChecked ? bgSelected : bgDefault;
            }
            else
            {
                card.BackColor = borderDefault;
                inner.BackColor = bgDefault;
            }

            foreach (Control c in inner.Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Name == "countLabel")
                        lbl.ForeColor = isDark ? Color.FromArgb(252, 199, 55) : Color.FromArgb(204, 128, 0);
                    else
                        lbl.ForeColor = (lbl.Name == "titleLabel") ? titleColor : descColor;
                }
                else if (c is Button btn)
                {
                    btn.BackColor = isDark ? Color.FromArgb(45, 45, 45) : Color.White;
                    btn.ForeColor = isDark ? Color.White : Color.FromArgb(30, 30, 30);
                    btn.FlatAppearance.BorderColor = isDark ? Color.FromArgb(100, 100, 100) : Color.FromArgb(200, 200, 200);
                }
            }
        }
    }
}