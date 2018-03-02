namespace SimpleMessager
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.ListBoxLog = new System.Windows.Forms.ListBox();
            this.MorepushAPI = new System.Windows.Forms.LinkLabel();
            this.TestBoxInput = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxLog
            // 
            this.ListBoxLog.FormattingEnabled = true;
            this.ListBoxLog.ItemHeight = 12;
            this.ListBoxLog.Location = new System.Drawing.Point(12, 12);
            this.ListBoxLog.Name = "ListBoxLog";
            this.ListBoxLog.Size = new System.Drawing.Size(429, 292);
            this.ListBoxLog.TabIndex = 0;
            // 
            // MorepushAPI
            // 
            this.MorepushAPI.AutoSize = true;
            this.MorepushAPI.Location = new System.Drawing.Point(12, 340);
            this.MorepushAPI.Name = "MorepushAPI";
            this.MorepushAPI.Size = new System.Drawing.Size(71, 12);
            this.MorepushAPI.TabIndex = 1;
            this.MorepushAPI.TabStop = true;
            this.MorepushAPI.Text = "MorepushAPI";
            // 
            // TestBoxInput
            // 
            this.TestBoxInput.Location = new System.Drawing.Point(12, 316);
            this.TestBoxInput.Name = "TestBoxInput";
            this.TestBoxInput.Size = new System.Drawing.Size(429, 21);
            this.TestBoxInput.TabIndex = 2;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(447, 314);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 3;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Location = new System.Drawing.Point(447, 281);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(75, 23);
            this.ButtonSettings.TabIndex = 4;
            this.ButtonSettings.Text = "Settings";
            this.ButtonSettings.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.ButtonSettings);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.TestBoxInput);
            this.Controls.Add(this.MorepushAPI);
            this.Controls.Add(this.ListBoxLog);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel MorepushAPI;
        private System.Windows.Forms.TextBox TestBoxInput;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonSettings;
        public System.Windows.Forms.ListBox ListBoxLog;
    }
}