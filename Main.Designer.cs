namespace PASPAS
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));

            // Control Initialization
            this.aboutBtn = new System.Windows.Forms.Button();
            this.uninstallMenuBtn = new System.Windows.Forms.Button();
            this.registryBtn = new System.Windows.Forms.Button();
            this.optionsBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.versionCode = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.homePanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.processPanel = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.tweaksBtn = new System.Windows.Forms.Button();
            this.tweaksPanel = new System.Windows.Forms.Panel();
            this.programsPanel = new System.Windows.Forms.Panel();
            this.registryPanel = new System.Windows.Forms.Panel();
            this.languageSelector = new System.Windows.Forms.ComboBox();

            this.controlPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();

            // aboutBtn
            this.aboutBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.aboutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutBtn.FlatAppearance.BorderSize = 0;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.aboutBtn.Location = new System.Drawing.Point(25, 421);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(165, 40);
            this.aboutBtn.TabIndex = 6;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);

            // uninstallMenuBtn
            this.uninstallMenuBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.uninstallMenuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uninstallMenuBtn.FlatAppearance.BorderSize = 0;
            this.uninstallMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallMenuBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.uninstallMenuBtn.Location = new System.Drawing.Point(25, 365);
            this.uninstallMenuBtn.Name = "uninstallMenuBtn";
            this.uninstallMenuBtn.Size = new System.Drawing.Size(165, 40);
            this.uninstallMenuBtn.TabIndex = 5;
            this.uninstallMenuBtn.Text = "Programs";
            this.uninstallMenuBtn.UseVisualStyleBackColor = false;
            this.uninstallMenuBtn.Click += new System.EventHandler(this.uninstallMenuBtn_Click);

            // registryBtn
            this.registryBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.registryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registryBtn.FlatAppearance.BorderSize = 0;
            this.registryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registryBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.registryBtn.Location = new System.Drawing.Point(25, 309);
            this.registryBtn.Name = "registryBtn";
            this.registryBtn.Size = new System.Drawing.Size(165, 40);
            this.registryBtn.TabIndex = 4;
            this.registryBtn.Text = "Registry";
            this.registryBtn.UseVisualStyleBackColor = false;
            this.registryBtn.Click += new System.EventHandler(this.registryBtn_Click);

            // tweaksBtn
            this.tweaksBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tweaksBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tweaksBtn.FlatAppearance.BorderSize = 0;
            this.tweaksBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tweaksBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.tweaksBtn.Location = new System.Drawing.Point(25, 253);
            this.tweaksBtn.Name = "tweaksBtn";
            this.tweaksBtn.Size = new System.Drawing.Size(165, 40);
            this.tweaksBtn.TabIndex = 3;
            this.tweaksBtn.Text = "System";
            this.tweaksBtn.UseVisualStyleBackColor = false;
            this.tweaksBtn.Click += new System.EventHandler(this.tweaksBtn_Click);

            // optionsBtn
            this.optionsBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.optionsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsBtn.FlatAppearance.BorderSize = 0;
            this.optionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.optionsBtn.Location = new System.Drawing.Point(25, 197);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(165, 40);
            this.optionsBtn.TabIndex = 2;
            this.optionsBtn.Text = "Settings";
            this.optionsBtn.UseVisualStyleBackColor = false;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);

            // homeBtn
            this.homeBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.homeBtn.Location = new System.Drawing.Point(25, 141);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(165, 40);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);

            // sidePanel
            this.sidePanel.BackColor = System.Drawing.Color.Crimson;
            this.sidePanel.Location = new System.Drawing.Point(10, 141);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(15, 40);
            this.sidePanel.TabIndex = 0;

            // splitter
            this.splitter.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            this.splitter.Cursor = System.Windows.Forms.Cursors.No;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(190, 556);
            this.splitter.TabIndex = 7;
            this.splitter.TabStop = false;

            // controlPanel
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(252, 199, 55);
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.versionCode);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(871, 15);
            this.controlPanel.TabIndex = 8;
            this.controlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.controlPanel_MouseDown);
            this.controlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.controlPanel_MouseMove);
            this.controlPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.controlPanel_MouseUp);

            // versionCode
            this.versionCode.AutoSize = true;
            this.versionCode.BackColor = System.Drawing.Color.FromArgb(252, 199, 55);
            this.versionCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.versionCode.ForeColor = System.Drawing.Color.Maroon;
            this.versionCode.Location = new System.Drawing.Point(789, 0);
            this.versionCode.Name = "versionCode";
            this.versionCode.Size = new System.Drawing.Size(77, 13);
            this.versionCode.TabIndex = 0;
            this.versionCode.Text = "Omni 2026.07";

            // logoPanel
            this.logoPanel.BackColor = System.Drawing.Color.Yellow;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPanel.Controls.Add(this.logo);
            this.logoPanel.Controls.Add(this.title);
            this.logoPanel.Location = new System.Drawing.Point(220, 15);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(176, 76);
            this.logoPanel.TabIndex = 9;

            // logo
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logo.Image = global::PASPAS.Properties.Resources.paspas;
            this.logo.Location = new System.Drawing.Point(10, 6);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(60, 60);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;

            // title
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            this.title.Location = new System.Drawing.Point(76, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(91, 30);
            this.title.TabIndex = 1;
            this.title.Text = "PASPAS";

            // homePanel
            this.homePanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.homePanel.Location = new System.Drawing.Point(190, 124);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(680, 432);
            this.homePanel.TabIndex = 10;

            // optionsPanel
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.optionsPanel.Location = new System.Drawing.Point(190, 124);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(680, 432);
            this.optionsPanel.TabIndex = 11;

            // aboutPanel
            this.aboutPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.aboutPanel.Location = new System.Drawing.Point(190, 124);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(680, 432);
            this.aboutPanel.TabIndex = 12;

            // processPanel
            this.processPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.processPanel.Location = new System.Drawing.Point(190, 124);
            this.processPanel.Name = "processPanel";
            this.processPanel.Size = new System.Drawing.Size(680, 432);
            this.processPanel.TabIndex = 13;

            // tweaksPanel
            this.tweaksPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.tweaksPanel.Location = new System.Drawing.Point(190, 124);
            this.tweaksPanel.Name = "tweaksPanel";
            this.tweaksPanel.Size = new System.Drawing.Size(680, 432);
            this.tweaksPanel.TabIndex = 14;

            // programsPanel
            this.programsPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.programsPanel.Location = new System.Drawing.Point(190, 124);
            this.programsPanel.Name = "programsPanel";
            this.programsPanel.Size = new System.Drawing.Size(680, 432);
            this.programsPanel.TabIndex = 15;

            // registryPanel
            this.registryPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.registryPanel.Location = new System.Drawing.Point(190, 124);
            this.registryPanel.Name = "registryPanel";
            this.registryPanel.Size = new System.Drawing.Size(680, 432);
            this.registryPanel.TabIndex = 16;

            // exitBtn
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            this.exitBtn.Location = new System.Drawing.Point(827, 21);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(38, 38);
            this.exitBtn.TabIndex = 18;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);

            // minimizeBtn
            this.minimizeBtn.BackColor = System.Drawing.Color.Gold;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            this.minimizeBtn.Location = new System.Drawing.Point(783, 21);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(38, 38);
            this.minimizeBtn.TabIndex = 17;
            this.minimizeBtn.Text = "—";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);

            // languageSelector
            this.languageSelector.BackColor = System.Drawing.Color.WhiteSmoke;
            this.languageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.languageSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.languageSelector.FormattingEnabled = true;
            this.languageSelector.Items.AddRange(new object[] {
            "English",
            "Türkçe"});
            this.languageSelector.Location = new System.Drawing.Point(700, 28);
            this.languageSelector.Name = "languageSelector";
            this.languageSelector.Size = new System.Drawing.Size(75, 25);
            this.languageSelector.TabIndex = 19;

            // Main Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(870, 556);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PASPAS";
            this.Load += new System.EventHandler(this.PASPAS_Main_Load);
            this.Shown += new System.EventHandler(this.PASPAS_Main_Shown);

            // Z-Order Management (DO NOT CHANGE ORDER)
            this.Controls.Add(this.languageSelector);
            this.Controls.Add(this.uninstallMenuBtn);
            this.Controls.Add(this.registryBtn);
            this.Controls.Add(this.tweaksBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.logoPanel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.aboutPanel);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.tweaksPanel);
            this.Controls.Add(this.programsPanel);
            this.Controls.Add(this.registryPanel);
            this.Controls.Add(this.processPanel);

            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button optionsBtn;
        private System.Windows.Forms.Button registryBtn;
        private System.Windows.Forms.Button tweaksBtn;
        private System.Windows.Forms.Button uninstallMenuBtn;

        private System.Windows.Forms.Panel aboutPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel processPanel;
        private System.Windows.Forms.Panel programsPanel;
        private System.Windows.Forms.Panel registryPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel tweaksPanel;

        private System.Windows.Forms.ComboBox languageSelector;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label versionCode;
    }
}