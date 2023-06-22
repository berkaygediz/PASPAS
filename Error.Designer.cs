namespace PASPAS
{
    partial class Error
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
            this.Exit = new System.Windows.Forms.Button();
            this.Error_context = new System.Windows.Forms.Label();
            this.Error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.Transparent;
            this.Exit.Image = global::PASPAS.Properties.Resources.exit;
            this.Exit.Location = new System.Drawing.Point(314, 55);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(42, 42);
            this.Exit.TabIndex = 14;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Error_context
            // 
            this.Error_context.AutoSize = true;
            this.Error_context.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Error_context.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Error_context.Location = new System.Drawing.Point(45, 70);
            this.Error_context.Name = "Error_context";
            this.Error_context.Size = new System.Drawing.Size(196, 28);
            this.Error_context.TabIndex = 13;
            this.Error_context.Text = "We don\'t know what happened either.\r\nPlease report the issue to us on GitHub.";
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Error_label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Error_label.ForeColor = System.Drawing.Color.White;
            this.Error_label.Location = new System.Drawing.Point(45, 38);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(149, 23);
            this.Error_label.TabIndex = 12;
            this.Error_label.Text = "An Error Occurred!";
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 153);
            this.ControlBox = false;
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Error_context);
            this.Controls.Add(this.Error_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Error";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PASPAS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label Error_context;
        private System.Windows.Forms.Label Error_label;
    }
}