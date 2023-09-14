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
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(419, 68);
            this.Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(56, 52);
            this.Exit.TabIndex = 14;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Error_context
            // 
            this.Error_context.AutoSize = true;
            this.Error_context.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Error_context.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Error_context.Location = new System.Drawing.Point(60, 86);
            this.Error_context.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_context.Name = "Error_context";
            this.Error_context.Size = new System.Drawing.Size(242, 34);
            this.Error_context.TabIndex = 13;
            this.Error_context.Text = "We don\'t know what happened either.\r\nPlease report the issue to us on GitHub.";
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Error_label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Error_label.ForeColor = System.Drawing.Color.White;
            this.Error_label.Location = new System.Drawing.Point(60, 47);
            this.Error_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(182, 30);
            this.Error_label.TabIndex = 12;
            this.Error_label.Text = "An Error Occurred!";
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(533, 188);
            this.ControlBox = false;
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Error_context);
            this.Controls.Add(this.Error_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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