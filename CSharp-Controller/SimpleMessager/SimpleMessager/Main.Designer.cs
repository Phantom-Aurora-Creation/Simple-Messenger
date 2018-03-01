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
            this.NotificAPI = new System.Windows.Forms.LinkLabel();
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
            // NotificAPI
            // 
            this.NotificAPI.AutoSize = true;
            this.NotificAPI.Location = new System.Drawing.Point(457, 340);
            this.NotificAPI.Name = "NotificAPI";
            this.NotificAPI.Size = new System.Drawing.Size(65, 12);
            this.NotificAPI.TabIndex = 1;
            this.NotificAPI.TabStop = true;
            this.NotificAPI.Text = "NotificAPI";
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
            this.Controls.Add(this.NotificAPI);
            this.Controls.Add(this.ListBoxLog);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel NotificAPI;
        private System.Windows.Forms.TextBox TestBoxInput;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonSettings;
        private System.Windows.Forms.ListBox ListBoxLog;
    }
}