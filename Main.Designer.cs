﻿namespace PASPAS
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.About_btn = new System.Windows.Forms.Button();
            this.Options_btn = new System.Windows.Forms.Button();
            this.Home_btn = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.Home_panel = new System.Windows.Forms.Panel();
            this.Analysis = new System.Windows.Forms.Button();
            this.BasicPanel = new System.Windows.Forms.Panel();
            this.BasicDesc = new System.Windows.Forms.Label();
            this.Basic = new System.Windows.Forms.Label();
            this.AdvancedPanel = new System.Windows.Forms.Panel();
            this.AdvancedDesc = new System.Windows.Forms.Label();
            this.Advanced = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.SpecialPanel = new System.Windows.Forms.Panel();
            this.SpecialDesc = new System.Windows.Forms.Label();
            this.Special = new System.Windows.Forms.Label();
            this.Advanced_select = new System.Windows.Forms.RadioButton();
            this.Special_select = new System.Windows.Forms.RadioButton();
            this.Basic_select = new System.Windows.Forms.RadioButton();
            this.Options_panel = new System.Windows.Forms.Panel();
            this.DarkModeButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.OldWindows_select = new System.Windows.Forms.CheckBox();
            this.OldWindows_title = new System.Windows.Forms.Label();
            this.DownloadCache_select = new System.Windows.Forms.CheckBox();
            this.DownloadCache_title = new System.Windows.Forms.Label();
            this.FontCache_select = new System.Windows.Forms.CheckBox();
            this.FontCache_title = new System.Windows.Forms.Label();
            this.Prefetch_select = new System.Windows.Forms.CheckBox();
            this.Prefetch_title = new System.Windows.Forms.Label();
            this.MemoryDumps_select = new System.Windows.Forms.CheckBox();
            this.MemoryDumps_title = new System.Windows.Forms.Label();
            this.SystemCache_select = new System.Windows.Forms.CheckBox();
            this.SystemCache_title = new System.Windows.Forms.Label();
            this.Logs_select = new System.Windows.Forms.CheckBox();
            this.Logs_title = new System.Windows.Forms.Label();
            this.DNSCache_select = new System.Windows.Forms.CheckBox();
            this.DNSCache_title = new System.Windows.Forms.Label();
            this.PreviewCache_select = new System.Windows.Forms.CheckBox();
            this.PreviewCache_title = new System.Windows.Forms.Label();
            this.RecentlyUsed_select = new System.Windows.Forms.CheckBox();
            this.RecentlyUsed_title = new System.Windows.Forms.Label();
            this.DownloadedInstallations_select = new System.Windows.Forms.CheckBox();
            this.DownloadedInstallations_title = new System.Windows.Forms.Label();
            this.TemporaryFiles_select = new System.Windows.Forms.CheckBox();
            this.TemporaryFiles_title = new System.Windows.Forms.Label();
            this.Clipboard_select = new System.Windows.Forms.CheckBox();
            this.Clipboard_title = new System.Windows.Forms.Label();
            this.About_panel = new System.Windows.Forms.Panel();
            this.Github_label = new System.Windows.Forms.LinkLabel();
            this.Author_subtext = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.ProcessPanel = new System.Windows.Forms.Panel();
            this.Finish = new System.Windows.Forms.Button();
            this.ProcessTitlePanel = new System.Windows.Forms.Panel();
            this.Process_count_subtext = new System.Windows.Forms.Label();
            this.Process_count = new System.Windows.Forms.Label();
            this.process_img = new System.Windows.Forms.PictureBox();
            this.finish_img = new System.Windows.Forms.PictureBox();
            this.ProcessBox = new System.Windows.Forms.ListBox();
            this.Exit = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.Home_panel.SuspendLayout();
            this.BasicPanel.SuspendLayout();
            this.AdvancedPanel.SuspendLayout();
            this.SpecialPanel.SuspendLayout();
            this.Options_panel.SuspendLayout();
            this.About_panel.SuspendLayout();
            this.ProcessPanel.SuspendLayout();
            this.ProcessTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.process_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finish_img)).BeginInit();
            this.SuspendLayout();
            // 
            // About_btn
            // 
            this.About_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.About_btn.FlatAppearance.BorderSize = 0;
            this.About_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About_btn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.About_btn.Location = new System.Drawing.Point(31, 351);
            this.About_btn.Margin = new System.Windows.Forms.Padding(4);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(206, 50);
            this.About_btn.TabIndex = 22;
            this.About_btn.Text = "About";
            this.About_btn.UseVisualStyleBackColor = false;
            this.About_btn.Click += new System.EventHandler(this.About_btn_Click);
            // 
            // Options_btn
            // 
            this.Options_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Options_btn.FlatAppearance.BorderSize = 0;
            this.Options_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Options_btn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Options_btn.Location = new System.Drawing.Point(31, 282);
            this.Options_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Options_btn.Name = "Options_btn";
            this.Options_btn.Size = new System.Drawing.Size(206, 50);
            this.Options_btn.TabIndex = 21;
            this.Options_btn.Text = "Options";
            this.Options_btn.UseVisualStyleBackColor = false;
            this.Options_btn.Click += new System.EventHandler(this.Options_btn_Click);
            // 
            // Home_btn
            // 
            this.Home_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Home_btn.FlatAppearance.BorderSize = 0;
            this.Home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home_btn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Home_btn.Location = new System.Drawing.Point(31, 212);
            this.Home_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Home_btn.Name = "Home_btn";
            this.Home_btn.Size = new System.Drawing.Size(206, 50);
            this.Home_btn.TabIndex = 20;
            this.Home_btn.Text = "Home";
            this.Home_btn.UseVisualStyleBackColor = false;
            this.Home_btn.Click += new System.EventHandler(this.Home_btn_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.Red;
            this.SidePanel.Location = new System.Drawing.Point(12, 212);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(19, 50);
            this.SidePanel.TabIndex = 19;
            // 
            // Splitter
            // 
            this.Splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Splitter.Cursor = System.Windows.Forms.Cursors.Default;
            this.Splitter.Location = new System.Drawing.Point(0, 0);
            this.Splitter.Margin = new System.Windows.Forms.Padding(4);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(238, 650);
            this.Splitter.TabIndex = 16;
            this.Splitter.TabStop = false;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.Yellow;
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1088, 18);
            this.ControlPanel.TabIndex = 15;
            this.ControlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseDown);
            this.ControlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseMove);
            this.ControlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlPanel_MouseUp);
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.Yellow;
            this.LogoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogoPanel.Controls.Add(this.Logo);
            this.LogoPanel.Controls.Add(this.Title);
            this.LogoPanel.Location = new System.Drawing.Point(275, 19);
            this.LogoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(175, 188);
            this.LogoPanel.TabIndex = 17;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Logo.Image = global::PASPAS.Properties.Resources.paspas;
            this.Logo.Location = new System.Drawing.Point(12, 8);
            this.Logo.Margin = new System.Windows.Forms.Padding(4);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(150, 150);
            this.Logo.TabIndex = 5;
            this.Logo.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Title.Location = new System.Drawing.Point(22, 149);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(126, 41);
            this.Title.TabIndex = 11;
            this.Title.Text = "PASPAS";
            // 
            // Home_panel
            // 
            this.Home_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Home_panel.Controls.Add(this.Analysis);
            this.Home_panel.Controls.Add(this.BasicPanel);
            this.Home_panel.Controls.Add(this.AdvancedPanel);
            this.Home_panel.Controls.Add(this.Start);
            this.Home_panel.Controls.Add(this.SpecialPanel);
            this.Home_panel.Controls.Add(this.Advanced_select);
            this.Home_panel.Controls.Add(this.Special_select);
            this.Home_panel.Controls.Add(this.Basic_select);
            this.Home_panel.Location = new System.Drawing.Point(238, 210);
            this.Home_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Home_panel.Name = "Home_panel";
            this.Home_panel.Size = new System.Drawing.Size(850, 438);
            this.Home_panel.TabIndex = 23;
            // 
            // Analysis
            // 
            this.Analysis.BackColor = System.Drawing.Color.Red;
            this.Analysis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Analysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Analysis.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Analysis.ForeColor = System.Drawing.Color.White;
            this.Analysis.Location = new System.Drawing.Point(595, 345);
            this.Analysis.Margin = new System.Windows.Forms.Padding(4);
            this.Analysis.Name = "Analysis";
            this.Analysis.Size = new System.Drawing.Size(225, 44);
            this.Analysis.TabIndex = 20;
            this.Analysis.Text = "Analysis";
            this.Analysis.UseVisualStyleBackColor = false;
            this.Analysis.Click += new System.EventHandler(this.Analysis_Click);
            // 
            // BasicPanel
            // 
            this.BasicPanel.BackColor = System.Drawing.Color.MediumPurple;
            this.BasicPanel.Controls.Add(this.BasicDesc);
            this.BasicPanel.Controls.Add(this.Basic);
            this.BasicPanel.Location = new System.Drawing.Point(19, 72);
            this.BasicPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BasicPanel.Name = "BasicPanel";
            this.BasicPanel.Size = new System.Drawing.Size(225, 162);
            this.BasicPanel.TabIndex = 13;
            // 
            // BasicDesc
            // 
            this.BasicDesc.AutoSize = true;
            this.BasicDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BasicDesc.ForeColor = System.Drawing.Color.White;
            this.BasicDesc.Location = new System.Drawing.Point(4, 51);
            this.BasicDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BasicDesc.Name = "BasicDesc";
            this.BasicDesc.Size = new System.Drawing.Size(231, 76);
            this.BasicDesc.TabIndex = 9;
            this.BasicDesc.Text = "Permanently deletes clipboard, \r\ntemporary files, temporary \r\ninstallation files," +
    " recents, preview\r\ncache, DNS Cache and logs.";
            // 
            // Basic
            // 
            this.Basic.AutoSize = true;
            this.Basic.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Basic.ForeColor = System.Drawing.Color.Goldenrod;
            this.Basic.Location = new System.Drawing.Point(72, 0);
            this.Basic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Basic.Name = "Basic";
            this.Basic.Size = new System.Drawing.Size(82, 37);
            this.Basic.TabIndex = 5;
            this.Basic.Text = "Basic";
            // 
            // AdvancedPanel
            // 
            this.AdvancedPanel.BackColor = System.Drawing.Color.MediumPurple;
            this.AdvancedPanel.Controls.Add(this.AdvancedDesc);
            this.AdvancedPanel.Controls.Add(this.Advanced);
            this.AdvancedPanel.Location = new System.Drawing.Point(276, 72);
            this.AdvancedPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AdvancedPanel.Name = "AdvancedPanel";
            this.AdvancedPanel.Size = new System.Drawing.Size(288, 162);
            this.AdvancedPanel.TabIndex = 14;
            // 
            // AdvancedDesc
            // 
            this.AdvancedDesc.AutoSize = true;
            this.AdvancedDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AdvancedDesc.ForeColor = System.Drawing.Color.White;
            this.AdvancedDesc.Location = new System.Drawing.Point(11, 51);
            this.AdvancedDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AdvancedDesc.Name = "AdvancedDesc";
            this.AdvancedDesc.Size = new System.Drawing.Size(285, 95);
            this.AdvancedDesc.TabIndex = 9;
            this.AdvancedDesc.Text = "It is a more advanced version of the \r\nbasic option. Permanently deletes the\r\nsys" +
    "tem cache, memory dumps, prefetch\r\n data, cached fonts, and download cache,\r\nin " +
    "addition to the basic option.";
            // 
            // Advanced
            // 
            this.Advanced.AutoSize = true;
            this.Advanced.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Advanced.ForeColor = System.Drawing.Color.Goldenrod;
            this.Advanced.Location = new System.Drawing.Point(72, 0);
            this.Advanced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Advanced.Name = "Advanced";
            this.Advanced.Size = new System.Drawing.Size(144, 37);
            this.Advanced.TabIndex = 6;
            this.Advanced.Text = "Advanced";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Orange;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(19, 345);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(545, 44);
            this.Start.TabIndex = 16;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // SpecialPanel
            // 
            this.SpecialPanel.BackColor = System.Drawing.Color.MediumPurple;
            this.SpecialPanel.Controls.Add(this.SpecialDesc);
            this.SpecialPanel.Controls.Add(this.Special);
            this.SpecialPanel.Location = new System.Drawing.Point(595, 74);
            this.SpecialPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SpecialPanel.Name = "SpecialPanel";
            this.SpecialPanel.Size = new System.Drawing.Size(225, 162);
            this.SpecialPanel.TabIndex = 15;
            // 
            // SpecialDesc
            // 
            this.SpecialDesc.AutoSize = true;
            this.SpecialDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SpecialDesc.ForeColor = System.Drawing.Color.White;
            this.SpecialDesc.Location = new System.Drawing.Point(11, 50);
            this.SpecialDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SpecialDesc.Name = "SpecialDesc";
            this.SpecialDesc.Size = new System.Drawing.Size(207, 38);
            this.SpecialDesc.TabIndex = 10;
            this.SpecialDesc.Text = "Cleans according to the user\'s\r\nselection.";
            // 
            // Special
            // 
            this.Special.AutoSize = true;
            this.Special.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Special.ForeColor = System.Drawing.Color.Goldenrod;
            this.Special.Location = new System.Drawing.Point(59, 0);
            this.Special.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Special.Name = "Special";
            this.Special.Size = new System.Drawing.Size(108, 37);
            this.Special.TabIndex = 7;
            this.Special.Text = "Special";
            // 
            // Advanced_select
            // 
            this.Advanced_select.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Advanced_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Advanced_select.ForeColor = System.Drawing.Color.Black;
            this.Advanced_select.Location = new System.Drawing.Point(276, 72);
            this.Advanced_select.Margin = new System.Windows.Forms.Padding(4);
            this.Advanced_select.Name = "Advanced_select";
            this.Advanced_select.Size = new System.Drawing.Size(288, 204);
            this.Advanced_select.TabIndex = 18;
            this.Advanced_select.UseVisualStyleBackColor = true;
            this.Advanced_select.CheckedChanged += new System.EventHandler(this.Advanced_select_CheckedChanged);
            // 
            // Special_select
            // 
            this.Special_select.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Special_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Special_select.ForeColor = System.Drawing.Color.Black;
            this.Special_select.Location = new System.Drawing.Point(595, 74);
            this.Special_select.Margin = new System.Windows.Forms.Padding(4);
            this.Special_select.Name = "Special_select";
            this.Special_select.Size = new System.Drawing.Size(225, 202);
            this.Special_select.TabIndex = 19;
            this.Special_select.UseVisualStyleBackColor = true;
            this.Special_select.CheckedChanged += new System.EventHandler(this.Special_select_CheckedChanged);
            // 
            // Basic_select
            // 
            this.Basic_select.BackColor = System.Drawing.Color.Transparent;
            this.Basic_select.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Basic_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Basic_select.ForeColor = System.Drawing.Color.Black;
            this.Basic_select.Location = new System.Drawing.Point(19, 72);
            this.Basic_select.Margin = new System.Windows.Forms.Padding(4);
            this.Basic_select.Name = "Basic_select";
            this.Basic_select.Size = new System.Drawing.Size(225, 204);
            this.Basic_select.TabIndex = 17;
            this.Basic_select.UseVisualStyleBackColor = false;
            this.Basic_select.CheckedChanged += new System.EventHandler(this.Basic_select_CheckedChanged);
            // 
            // Options_panel
            // 
            this.Options_panel.AutoScroll = true;
            this.Options_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Options_panel.Controls.Add(this.DarkModeButton);
            this.Options_panel.Controls.Add(this.ResetButton);
            this.Options_panel.Controls.Add(this.OldWindows_select);
            this.Options_panel.Controls.Add(this.OldWindows_title);
            this.Options_panel.Controls.Add(this.DownloadCache_select);
            this.Options_panel.Controls.Add(this.DownloadCache_title);
            this.Options_panel.Controls.Add(this.FontCache_select);
            this.Options_panel.Controls.Add(this.FontCache_title);
            this.Options_panel.Controls.Add(this.Prefetch_select);
            this.Options_panel.Controls.Add(this.Prefetch_title);
            this.Options_panel.Controls.Add(this.MemoryDumps_select);
            this.Options_panel.Controls.Add(this.MemoryDumps_title);
            this.Options_panel.Controls.Add(this.SystemCache_select);
            this.Options_panel.Controls.Add(this.SystemCache_title);
            this.Options_panel.Controls.Add(this.Logs_select);
            this.Options_panel.Controls.Add(this.Logs_title);
            this.Options_panel.Controls.Add(this.DNSCache_select);
            this.Options_panel.Controls.Add(this.DNSCache_title);
            this.Options_panel.Controls.Add(this.PreviewCache_select);
            this.Options_panel.Controls.Add(this.PreviewCache_title);
            this.Options_panel.Controls.Add(this.RecentlyUsed_select);
            this.Options_panel.Controls.Add(this.RecentlyUsed_title);
            this.Options_panel.Controls.Add(this.DownloadedInstallations_select);
            this.Options_panel.Controls.Add(this.DownloadedInstallations_title);
            this.Options_panel.Controls.Add(this.TemporaryFiles_select);
            this.Options_panel.Controls.Add(this.TemporaryFiles_title);
            this.Options_panel.Controls.Add(this.Clipboard_select);
            this.Options_panel.Controls.Add(this.Clipboard_title);
            this.Options_panel.Location = new System.Drawing.Point(238, 210);
            this.Options_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Options_panel.Name = "Options_panel";
            this.Options_panel.Size = new System.Drawing.Size(850, 438);
            this.Options_panel.TabIndex = 24;
            // 
            // DarkModeButton
            // 
            this.DarkModeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.DarkModeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DarkModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkModeButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DarkModeButton.ForeColor = System.Drawing.Color.White;
            this.DarkModeButton.Location = new System.Drawing.Point(560, 9);
            this.DarkModeButton.Margin = new System.Windows.Forms.Padding(4);
            this.DarkModeButton.Name = "DarkModeButton";
            this.DarkModeButton.Size = new System.Drawing.Size(160, 48);
            this.DarkModeButton.TabIndex = 27;
            this.DarkModeButton.Text = "Dark Mode";
            this.DarkModeButton.UseVisualStyleBackColor = false;
            this.DarkModeButton.Click += new System.EventHandler(this.DarkModeButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Gold;
            this.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ResetButton.Location = new System.Drawing.Point(728, 9);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(92, 48);
            this.ResetButton.TabIndex = 26;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // OldWindows_select
            // 
            this.OldWindows_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.OldWindows_select.AutoSize = true;
            this.OldWindows_select.BackColor = System.Drawing.Color.Red;
            this.OldWindows_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OldWindows_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OldWindows_select.ForeColor = System.Drawing.Color.White;
            this.OldWindows_select.Location = new System.Drawing.Point(36, 1058);
            this.OldWindows_select.Margin = new System.Windows.Forms.Padding(4);
            this.OldWindows_select.Name = "OldWindows_select";
            this.OldWindows_select.Size = new System.Drawing.Size(35, 38);
            this.OldWindows_select.TabIndex = 25;
            this.OldWindows_select.Text = "X";
            this.OldWindows_select.UseVisualStyleBackColor = false;
            this.OldWindows_select.CheckedChanged += new System.EventHandler(this.OldWindows_select_CheckedChanged);
            // 
            // OldWindows_title
            // 
            this.OldWindows_title.AutoSize = true;
            this.OldWindows_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OldWindows_title.Location = new System.Drawing.Point(31, 1028);
            this.OldWindows_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OldWindows_title.Name = "OldWindows_title";
            this.OldWindows_title.Size = new System.Drawing.Size(312, 28);
            this.OldWindows_title.TabIndex = 24;
            this.OldWindows_title.Text = "OLD WINDOWS INSTALLATION:";
            // 
            // DownloadCache_select
            // 
            this.DownloadCache_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.DownloadCache_select.AutoSize = true;
            this.DownloadCache_select.BackColor = System.Drawing.Color.Red;
            this.DownloadCache_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadCache_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DownloadCache_select.ForeColor = System.Drawing.Color.White;
            this.DownloadCache_select.Location = new System.Drawing.Point(36, 969);
            this.DownloadCache_select.Margin = new System.Windows.Forms.Padding(4);
            this.DownloadCache_select.Name = "DownloadCache_select";
            this.DownloadCache_select.Size = new System.Drawing.Size(35, 38);
            this.DownloadCache_select.TabIndex = 23;
            this.DownloadCache_select.Text = "X";
            this.DownloadCache_select.UseVisualStyleBackColor = false;
            this.DownloadCache_select.CheckedChanged += new System.EventHandler(this.DownloadCache_select_CheckedChanged);
            // 
            // DownloadCache_title
            // 
            this.DownloadCache_title.AutoSize = true;
            this.DownloadCache_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DownloadCache_title.Location = new System.Drawing.Point(31, 939);
            this.DownloadCache_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DownloadCache_title.Name = "DownloadCache_title";
            this.DownloadCache_title.Size = new System.Drawing.Size(207, 28);
            this.DownloadCache_title.TabIndex = 22;
            this.DownloadCache_title.Text = "DOWNLOAD CACHE:";
            // 
            // FontCache_select
            // 
            this.FontCache_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.FontCache_select.AutoSize = true;
            this.FontCache_select.BackColor = System.Drawing.Color.Red;
            this.FontCache_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontCache_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FontCache_select.ForeColor = System.Drawing.Color.White;
            this.FontCache_select.Location = new System.Drawing.Point(36, 885);
            this.FontCache_select.Margin = new System.Windows.Forms.Padding(4);
            this.FontCache_select.Name = "FontCache_select";
            this.FontCache_select.Size = new System.Drawing.Size(35, 38);
            this.FontCache_select.TabIndex = 21;
            this.FontCache_select.Text = "X";
            this.FontCache_select.UseVisualStyleBackColor = false;
            this.FontCache_select.CheckedChanged += new System.EventHandler(this.FontCache_select_CheckedChanged);
            // 
            // FontCache_title
            // 
            this.FontCache_title.AutoSize = true;
            this.FontCache_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FontCache_title.Location = new System.Drawing.Point(31, 855);
            this.FontCache_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FontCache_title.Name = "FontCache_title";
            this.FontCache_title.Size = new System.Drawing.Size(140, 28);
            this.FontCache_title.TabIndex = 20;
            this.FontCache_title.Text = "FONT CACHE:";
            // 
            // Prefetch_select
            // 
            this.Prefetch_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.Prefetch_select.AutoSize = true;
            this.Prefetch_select.BackColor = System.Drawing.Color.Red;
            this.Prefetch_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Prefetch_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Prefetch_select.ForeColor = System.Drawing.Color.White;
            this.Prefetch_select.Location = new System.Drawing.Point(36, 801);
            this.Prefetch_select.Margin = new System.Windows.Forms.Padding(4);
            this.Prefetch_select.Name = "Prefetch_select";
            this.Prefetch_select.Size = new System.Drawing.Size(35, 38);
            this.Prefetch_select.TabIndex = 19;
            this.Prefetch_select.Text = "X";
            this.Prefetch_select.UseVisualStyleBackColor = false;
            this.Prefetch_select.CheckedChanged += new System.EventHandler(this.Prefetch_select_CheckedChanged);
            // 
            // Prefetch_title
            // 
            this.Prefetch_title.AutoSize = true;
            this.Prefetch_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Prefetch_title.Location = new System.Drawing.Point(31, 771);
            this.Prefetch_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prefetch_title.Name = "Prefetch_title";
            this.Prefetch_title.Size = new System.Drawing.Size(112, 28);
            this.Prefetch_title.TabIndex = 18;
            this.Prefetch_title.Text = "PREFETCH:";
            // 
            // MemoryDumps_select
            // 
            this.MemoryDumps_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.MemoryDumps_select.AutoSize = true;
            this.MemoryDumps_select.BackColor = System.Drawing.Color.Red;
            this.MemoryDumps_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MemoryDumps_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MemoryDumps_select.ForeColor = System.Drawing.Color.White;
            this.MemoryDumps_select.Location = new System.Drawing.Point(36, 711);
            this.MemoryDumps_select.Margin = new System.Windows.Forms.Padding(4);
            this.MemoryDumps_select.Name = "MemoryDumps_select";
            this.MemoryDumps_select.Size = new System.Drawing.Size(35, 38);
            this.MemoryDumps_select.TabIndex = 17;
            this.MemoryDumps_select.Text = "X";
            this.MemoryDumps_select.UseVisualStyleBackColor = false;
            this.MemoryDumps_select.CheckedChanged += new System.EventHandler(this.MemoryDumps_select_CheckedChanged);
            // 
            // MemoryDumps_title
            // 
            this.MemoryDumps_title.AutoSize = true;
            this.MemoryDumps_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MemoryDumps_title.Location = new System.Drawing.Point(31, 681);
            this.MemoryDumps_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MemoryDumps_title.Name = "MemoryDumps_title";
            this.MemoryDumps_title.Size = new System.Drawing.Size(183, 28);
            this.MemoryDumps_title.TabIndex = 16;
            this.MemoryDumps_title.Text = "MEMORY DUMPS:";
            // 
            // SystemCache_select
            // 
            this.SystemCache_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.SystemCache_select.AutoSize = true;
            this.SystemCache_select.BackColor = System.Drawing.Color.Red;
            this.SystemCache_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemCache_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SystemCache_select.ForeColor = System.Drawing.Color.White;
            this.SystemCache_select.Location = new System.Drawing.Point(36, 626);
            this.SystemCache_select.Margin = new System.Windows.Forms.Padding(4);
            this.SystemCache_select.Name = "SystemCache_select";
            this.SystemCache_select.Size = new System.Drawing.Size(35, 38);
            this.SystemCache_select.TabIndex = 15;
            this.SystemCache_select.Text = "X";
            this.SystemCache_select.UseVisualStyleBackColor = false;
            this.SystemCache_select.CheckedChanged += new System.EventHandler(this.SystemCache_select_CheckedChanged);
            // 
            // SystemCache_title
            // 
            this.SystemCache_title.AutoSize = true;
            this.SystemCache_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SystemCache_title.Location = new System.Drawing.Point(31, 596);
            this.SystemCache_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SystemCache_title.Name = "SystemCache_title";
            this.SystemCache_title.Size = new System.Drawing.Size(163, 28);
            this.SystemCache_title.TabIndex = 14;
            this.SystemCache_title.Text = "SYSTEM CACHE:";
            // 
            // Logs_select
            // 
            this.Logs_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.Logs_select.AutoSize = true;
            this.Logs_select.BackColor = System.Drawing.Color.Red;
            this.Logs_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logs_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Logs_select.ForeColor = System.Drawing.Color.White;
            this.Logs_select.Location = new System.Drawing.Point(36, 542);
            this.Logs_select.Margin = new System.Windows.Forms.Padding(4);
            this.Logs_select.Name = "Logs_select";
            this.Logs_select.Size = new System.Drawing.Size(35, 38);
            this.Logs_select.TabIndex = 13;
            this.Logs_select.Text = "X";
            this.Logs_select.UseVisualStyleBackColor = false;
            this.Logs_select.CheckedChanged += new System.EventHandler(this.Logs_select_CheckedChanged);
            // 
            // Logs_title
            // 
            this.Logs_title.AutoSize = true;
            this.Logs_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Logs_title.Location = new System.Drawing.Point(31, 512);
            this.Logs_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Logs_title.Name = "Logs_title";
            this.Logs_title.Size = new System.Drawing.Size(67, 28);
            this.Logs_title.TabIndex = 12;
            this.Logs_title.Text = "LOGS:";
            // 
            // DNSCache_select
            // 
            this.DNSCache_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.DNSCache_select.AutoSize = true;
            this.DNSCache_select.BackColor = System.Drawing.Color.Red;
            this.DNSCache_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DNSCache_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DNSCache_select.ForeColor = System.Drawing.Color.White;
            this.DNSCache_select.Location = new System.Drawing.Point(36, 459);
            this.DNSCache_select.Margin = new System.Windows.Forms.Padding(4);
            this.DNSCache_select.Name = "DNSCache_select";
            this.DNSCache_select.Size = new System.Drawing.Size(35, 38);
            this.DNSCache_select.TabIndex = 11;
            this.DNSCache_select.Text = "X";
            this.DNSCache_select.UseVisualStyleBackColor = false;
            this.DNSCache_select.CheckedChanged += new System.EventHandler(this.DNSCache_select_CheckedChanged);
            // 
            // DNSCache_title
            // 
            this.DNSCache_title.AutoSize = true;
            this.DNSCache_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DNSCache_title.Location = new System.Drawing.Point(31, 429);
            this.DNSCache_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DNSCache_title.Name = "DNSCache_title";
            this.DNSCache_title.Size = new System.Drawing.Size(129, 28);
            this.DNSCache_title.TabIndex = 10;
            this.DNSCache_title.Text = "DNS CACHE:";
            // 
            // PreviewCache_select
            // 
            this.PreviewCache_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.PreviewCache_select.AutoSize = true;
            this.PreviewCache_select.BackColor = System.Drawing.Color.Red;
            this.PreviewCache_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewCache_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PreviewCache_select.ForeColor = System.Drawing.Color.White;
            this.PreviewCache_select.Location = new System.Drawing.Point(36, 375);
            this.PreviewCache_select.Margin = new System.Windows.Forms.Padding(4);
            this.PreviewCache_select.Name = "PreviewCache_select";
            this.PreviewCache_select.Size = new System.Drawing.Size(35, 38);
            this.PreviewCache_select.TabIndex = 9;
            this.PreviewCache_select.Text = "X";
            this.PreviewCache_select.UseVisualStyleBackColor = false;
            this.PreviewCache_select.CheckedChanged += new System.EventHandler(this.PreviewCache_select_CheckedChanged);
            // 
            // PreviewCache_title
            // 
            this.PreviewCache_title.AutoSize = true;
            this.PreviewCache_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PreviewCache_title.Location = new System.Drawing.Point(31, 345);
            this.PreviewCache_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreviewCache_title.Name = "PreviewCache_title";
            this.PreviewCache_title.Size = new System.Drawing.Size(173, 28);
            this.PreviewCache_title.TabIndex = 8;
            this.PreviewCache_title.Text = "PREVIEW CACHE:";
            // 
            // RecentlyUsed_select
            // 
            this.RecentlyUsed_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.RecentlyUsed_select.AutoSize = true;
            this.RecentlyUsed_select.BackColor = System.Drawing.Color.Red;
            this.RecentlyUsed_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecentlyUsed_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RecentlyUsed_select.ForeColor = System.Drawing.Color.White;
            this.RecentlyUsed_select.Location = new System.Drawing.Point(36, 295);
            this.RecentlyUsed_select.Margin = new System.Windows.Forms.Padding(4);
            this.RecentlyUsed_select.Name = "RecentlyUsed_select";
            this.RecentlyUsed_select.Size = new System.Drawing.Size(35, 38);
            this.RecentlyUsed_select.TabIndex = 7;
            this.RecentlyUsed_select.Text = "X";
            this.RecentlyUsed_select.UseVisualStyleBackColor = false;
            this.RecentlyUsed_select.CheckedChanged += new System.EventHandler(this.RecentlyUsed_select_CheckedChanged);
            // 
            // RecentlyUsed_title
            // 
            this.RecentlyUsed_title.AutoSize = true;
            this.RecentlyUsed_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RecentlyUsed_title.Location = new System.Drawing.Point(31, 265);
            this.RecentlyUsed_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RecentlyUsed_title.Name = "RecentlyUsed_title";
            this.RecentlyUsed_title.Size = new System.Drawing.Size(170, 28);
            this.RecentlyUsed_title.TabIndex = 6;
            this.RecentlyUsed_title.Text = "RECENTLY USED:";
            // 
            // DownloadedInstallations_select
            // 
            this.DownloadedInstallations_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.DownloadedInstallations_select.AutoSize = true;
            this.DownloadedInstallations_select.BackColor = System.Drawing.Color.Red;
            this.DownloadedInstallations_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadedInstallations_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DownloadedInstallations_select.ForeColor = System.Drawing.Color.White;
            this.DownloadedInstallations_select.Location = new System.Drawing.Point(36, 211);
            this.DownloadedInstallations_select.Margin = new System.Windows.Forms.Padding(4);
            this.DownloadedInstallations_select.Name = "DownloadedInstallations_select";
            this.DownloadedInstallations_select.Size = new System.Drawing.Size(35, 38);
            this.DownloadedInstallations_select.TabIndex = 5;
            this.DownloadedInstallations_select.Text = "X";
            this.DownloadedInstallations_select.UseVisualStyleBackColor = false;
            this.DownloadedInstallations_select.CheckedChanged += new System.EventHandler(this.DownloadedInstallations_select_CheckedChanged);
            // 
            // DownloadedInstallations_title
            // 
            this.DownloadedInstallations_title.AutoSize = true;
            this.DownloadedInstallations_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DownloadedInstallations_title.Location = new System.Drawing.Point(31, 181);
            this.DownloadedInstallations_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DownloadedInstallations_title.Name = "DownloadedInstallations_title";
            this.DownloadedInstallations_title.Size = new System.Drawing.Size(338, 28);
            this.DownloadedInstallations_title.TabIndex = 4;
            this.DownloadedInstallations_title.Text = "TEMPORARY INSTALLATION FILES:";
            // 
            // TemporaryFiles_select
            // 
            this.TemporaryFiles_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.TemporaryFiles_select.AutoSize = true;
            this.TemporaryFiles_select.BackColor = System.Drawing.Color.Red;
            this.TemporaryFiles_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TemporaryFiles_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TemporaryFiles_select.ForeColor = System.Drawing.Color.White;
            this.TemporaryFiles_select.Location = new System.Drawing.Point(36, 128);
            this.TemporaryFiles_select.Margin = new System.Windows.Forms.Padding(4);
            this.TemporaryFiles_select.Name = "TemporaryFiles_select";
            this.TemporaryFiles_select.Size = new System.Drawing.Size(35, 38);
            this.TemporaryFiles_select.TabIndex = 3;
            this.TemporaryFiles_select.Text = "X";
            this.TemporaryFiles_select.UseVisualStyleBackColor = false;
            this.TemporaryFiles_select.CheckedChanged += new System.EventHandler(this.TemporaryFiles_select_CheckedChanged);
            // 
            // TemporaryFiles_title
            // 
            this.TemporaryFiles_title.AutoSize = true;
            this.TemporaryFiles_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TemporaryFiles_title.Location = new System.Drawing.Point(31, 98);
            this.TemporaryFiles_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TemporaryFiles_title.Name = "TemporaryFiles_title";
            this.TemporaryFiles_title.Size = new System.Drawing.Size(192, 28);
            this.TemporaryFiles_title.TabIndex = 2;
            this.TemporaryFiles_title.Text = "TEMPORARY FILES:";
            // 
            // Clipboard_select
            // 
            this.Clipboard_select.Appearance = System.Windows.Forms.Appearance.Button;
            this.Clipboard_select.AutoSize = true;
            this.Clipboard_select.BackColor = System.Drawing.Color.Red;
            this.Clipboard_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clipboard_select.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Clipboard_select.ForeColor = System.Drawing.Color.White;
            this.Clipboard_select.Location = new System.Drawing.Point(36, 44);
            this.Clipboard_select.Margin = new System.Windows.Forms.Padding(4);
            this.Clipboard_select.Name = "Clipboard_select";
            this.Clipboard_select.Size = new System.Drawing.Size(35, 38);
            this.Clipboard_select.TabIndex = 1;
            this.Clipboard_select.Text = "X";
            this.Clipboard_select.UseVisualStyleBackColor = false;
            this.Clipboard_select.CheckedChanged += new System.EventHandler(this.Clipboard_select_CheckedChanged);
            // 
            // Clipboard_title
            // 
            this.Clipboard_title.AutoSize = true;
            this.Clipboard_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Clipboard_title.Location = new System.Drawing.Point(31, 14);
            this.Clipboard_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Clipboard_title.Name = "Clipboard_title";
            this.Clipboard_title.Size = new System.Drawing.Size(127, 28);
            this.Clipboard_title.TabIndex = 0;
            this.Clipboard_title.Text = "CLIPBOARD:";
            // 
            // About_panel
            // 
            this.About_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.About_panel.Controls.Add(this.Github_label);
            this.About_panel.Controls.Add(this.Author_subtext);
            this.About_panel.Controls.Add(this.Author);
            this.About_panel.Location = new System.Drawing.Point(238, 210);
            this.About_panel.Margin = new System.Windows.Forms.Padding(4);
            this.About_panel.Name = "About_panel";
            this.About_panel.Size = new System.Drawing.Size(850, 438);
            this.About_panel.TabIndex = 24;
            // 
            // Github_label
            // 
            this.Github_label.ActiveLinkColor = System.Drawing.Color.Red;
            this.Github_label.AutoSize = true;
            this.Github_label.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Github_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Github_label.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Github_label.Location = new System.Drawing.Point(45, 98);
            this.Github_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Github_label.Name = "Github_label";
            this.Github_label.Size = new System.Drawing.Size(156, 19);
            this.Github_label.TabIndex = 2;
            this.Github_label.TabStop = true;
            this.Github_label.Text = "github.com/berkaygediz";
            this.Github_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Github_label_LinkClicked);
            // 
            // Author_subtext
            // 
            this.Author_subtext.AutoSize = true;
            this.Author_subtext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Author_subtext.ForeColor = System.Drawing.Color.MediumPurple;
            this.Author_subtext.Location = new System.Drawing.Point(44, 56);
            this.Author_subtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Author_subtext.Name = "Author_subtext";
            this.Author_subtext.Size = new System.Drawing.Size(136, 28);
            this.Author_subtext.TabIndex = 1;
            this.Author_subtext.Text = "Berkay Gediz";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Author.Location = new System.Drawing.Point(42, 19);
            this.Author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(115, 37);
            this.Author.TabIndex = 0;
            this.Author.Text = "Author:";
            // 
            // ProcessPanel
            // 
            this.ProcessPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ProcessPanel.Controls.Add(this.Finish);
            this.ProcessPanel.Controls.Add(this.ProcessTitlePanel);
            this.ProcessPanel.Controls.Add(this.process_img);
            this.ProcessPanel.Controls.Add(this.finish_img);
            this.ProcessPanel.Controls.Add(this.ProcessBox);
            this.ProcessPanel.Location = new System.Drawing.Point(238, 210);
            this.ProcessPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ProcessPanel.Name = "ProcessPanel";
            this.ProcessPanel.Size = new System.Drawing.Size(850, 438);
            this.ProcessPanel.TabIndex = 24;
            // 
            // Finish
            // 
            this.Finish.BackColor = System.Drawing.Color.Lime;
            this.Finish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Finish.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Finish.ForeColor = System.Drawing.Color.Black;
            this.Finish.Location = new System.Drawing.Point(64, 358);
            this.Finish.Margin = new System.Windows.Forms.Padding(4);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(725, 55);
            this.Finish.TabIndex = 7;
            this.Finish.Text = "Finish";
            this.Finish.UseVisualStyleBackColor = false;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // ProcessTitlePanel
            // 
            this.ProcessTitlePanel.BackColor = System.Drawing.Color.MediumPurple;
            this.ProcessTitlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessTitlePanel.Controls.Add(this.Process_count_subtext);
            this.ProcessTitlePanel.Controls.Add(this.Process_count);
            this.ProcessTitlePanel.Location = new System.Drawing.Point(205, 35);
            this.ProcessTitlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.ProcessTitlePanel.Name = "ProcessTitlePanel";
            this.ProcessTitlePanel.Size = new System.Drawing.Size(583, 101);
            this.ProcessTitlePanel.TabIndex = 6;
            // 
            // Process_count_subtext
            // 
            this.Process_count_subtext.AutoSize = true;
            this.Process_count_subtext.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Process_count_subtext.ForeColor = System.Drawing.Color.White;
            this.Process_count_subtext.Location = new System.Drawing.Point(21, 65);
            this.Process_count_subtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Process_count_subtext.Name = "Process_count_subtext";
            this.Process_count_subtext.Size = new System.Drawing.Size(128, 23);
            this.Process_count_subtext.TabIndex = 5;
            this.Process_count_subtext.Text = "Item / Rejected";
            // 
            // Process_count
            // 
            this.Process_count.AutoSize = true;
            this.Process_count.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Process_count.ForeColor = System.Drawing.Color.White;
            this.Process_count.Location = new System.Drawing.Point(12, 1);
            this.Process_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Process_count.Name = "Process_count";
            this.Process_count.Size = new System.Drawing.Size(119, 60);
            this.Process_count.TabIndex = 4;
            this.Process_count.Text = "0 / 0";
            // 
            // process_img
            // 
            this.process_img.BackColor = System.Drawing.Color.Transparent;
            this.process_img.Image = global::PASPAS.Properties.Resources.process;
            this.process_img.Location = new System.Drawing.Point(64, 24);
            this.process_img.Margin = new System.Windows.Forms.Padding(4);
            this.process_img.Name = "process_img";
            this.process_img.Size = new System.Drawing.Size(125, 125);
            this.process_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.process_img.TabIndex = 2;
            this.process_img.TabStop = false;
            // 
            // finish_img
            // 
            this.finish_img.BackColor = System.Drawing.Color.Transparent;
            this.finish_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.finish_img.Image = global::PASPAS.Properties.Resources.finish;
            this.finish_img.Location = new System.Drawing.Point(64, 24);
            this.finish_img.Margin = new System.Windows.Forms.Padding(4);
            this.finish_img.Name = "finish_img";
            this.finish_img.Size = new System.Drawing.Size(125, 125);
            this.finish_img.TabIndex = 3;
            this.finish_img.TabStop = false;
            // 
            // ProcessBox
            // 
            this.ProcessBox.FormattingEnabled = true;
            this.ProcessBox.ItemHeight = 19;
            this.ProcessBox.Location = new System.Drawing.Point(64, 156);
            this.ProcessBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProcessBox.Name = "ProcessBox";
            this.ProcessBox.Size = new System.Drawing.Size(724, 175);
            this.ProcessBox.TabIndex = 5;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Exit.Location = new System.Drawing.Point(1034, 26);
            this.Exit.Margin = new System.Windows.Forms.Padding(4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(48, 48);
            this.Exit.TabIndex = 18;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Gold;
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Minimize.Location = new System.Drawing.Point(979, 26);
            this.Minimize.Margin = new System.Windows.Forms.Padding(4);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(48, 48);
            this.Minimize.TabIndex = 25;
            this.Minimize.Text = "—";
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1088, 650);
            this.ControlBox = false;
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Home_panel);
            this.Controls.Add(this.About_btn);
            this.Controls.Add(this.Options_btn);
            this.Controls.Add(this.Home_btn);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.LogoPanel);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Options_panel);
            this.Controls.Add(this.About_panel);
            this.Controls.Add(this.ProcessPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PASPAS";
            this.Load += new System.EventHandler(this.PASPAS_Main_Load);
            this.Shown += new System.EventHandler(this.PASPAS_Main_Shown);
            this.LogoPanel.ResumeLayout(false);
            this.LogoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.Home_panel.ResumeLayout(false);
            this.BasicPanel.ResumeLayout(false);
            this.BasicPanel.PerformLayout();
            this.AdvancedPanel.ResumeLayout(false);
            this.AdvancedPanel.PerformLayout();
            this.SpecialPanel.ResumeLayout(false);
            this.SpecialPanel.PerformLayout();
            this.Options_panel.ResumeLayout(false);
            this.Options_panel.PerformLayout();
            this.About_panel.ResumeLayout(false);
            this.About_panel.PerformLayout();
            this.ProcessPanel.ResumeLayout(false);
            this.ProcessTitlePanel.ResumeLayout(false);
            this.ProcessTitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.process_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finish_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button About_btn;
        private System.Windows.Forms.Button Options_btn;
        private System.Windows.Forms.Button Home_btn;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Splitter Splitter;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel Home_panel;
        private System.Windows.Forms.Panel Options_panel;
        private System.Windows.Forms.Panel About_panel;
        private System.Windows.Forms.Panel ProcessPanel;
        private System.Windows.Forms.RadioButton Special_select;
        private System.Windows.Forms.RadioButton Advanced_select;
        private System.Windows.Forms.RadioButton Basic_select;
        private System.Windows.Forms.Panel BasicPanel;
        private System.Windows.Forms.Label BasicDesc;
        private System.Windows.Forms.Label Basic;
        private System.Windows.Forms.Panel AdvancedPanel;
        private System.Windows.Forms.Label AdvancedDesc;
        private System.Windows.Forms.Label Advanced;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel SpecialPanel;
        private System.Windows.Forms.Label SpecialDesc;
        private System.Windows.Forms.Label Special;
        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Panel ProcessTitlePanel;
        private System.Windows.Forms.PictureBox finish_img;
        private System.Windows.Forms.PictureBox process_img;
        private System.Windows.Forms.ListBox ProcessBox;
        private System.Windows.Forms.Label Clipboard_title;
        private System.Windows.Forms.CheckBox DownloadCache_select;
        private System.Windows.Forms.Label DownloadCache_title;
        private System.Windows.Forms.CheckBox FontCache_select;
        private System.Windows.Forms.Label FontCache_title;
        private System.Windows.Forms.CheckBox Prefetch_select;
        private System.Windows.Forms.Label Prefetch_title;
        private System.Windows.Forms.CheckBox MemoryDumps_select;
        private System.Windows.Forms.Label MemoryDumps_title;
        private System.Windows.Forms.CheckBox SystemCache_select;
        private System.Windows.Forms.Label SystemCache_title;
        private System.Windows.Forms.CheckBox Logs_select;
        private System.Windows.Forms.Label Logs_title;
        private System.Windows.Forms.CheckBox DNSCache_select;
        private System.Windows.Forms.Label DNSCache_title;
        private System.Windows.Forms.CheckBox PreviewCache_select;
        private System.Windows.Forms.Label PreviewCache_title;
        private System.Windows.Forms.CheckBox RecentlyUsed_select;
        private System.Windows.Forms.Label RecentlyUsed_title;
        private System.Windows.Forms.CheckBox DownloadedInstallations_select;
        private System.Windows.Forms.Label DownloadedInstallations_title;
        private System.Windows.Forms.CheckBox TemporaryFiles_select;
        private System.Windows.Forms.Label TemporaryFiles_title;
        private System.Windows.Forms.CheckBox Clipboard_select;
        private System.Windows.Forms.CheckBox OldWindows_select;
        private System.Windows.Forms.Label OldWindows_title;
        private System.Windows.Forms.Button Analysis;
        private System.Windows.Forms.Label Author_subtext;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label Process_count_subtext;
        private System.Windows.Forms.Label Process_count;
        private System.Windows.Forms.LinkLabel Github_label;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button DarkModeButton;
    }
}

