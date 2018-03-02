namespace SimpleMessager
{
    partial class ConfigGuide
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
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.RadioButtonHost = new System.Windows.Forms.RadioButton();
            this.RadioButtonIP = new System.Windows.Forms.RadioButton();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextServer = new System.Windows.Forms.Label();
            this.TextPort = new System.Windows.Forms.Label();
            this.TextPassword = new System.Windows.Forms.Label();
            this.TextServerType = new System.Windows.Forms.Label();
            this.ButtonTestConnect = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Location = new System.Drawing.Point(95, 6);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(100, 21);
            this.TextBoxServer.TabIndex = 0;
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(95, 65);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(100, 21);
            this.TextBoxPort.TabIndex = 1;
            // 
            // RadioButtonHost
            // 
            this.RadioButtonHost.AutoSize = true;
            this.RadioButtonHost.Location = new System.Drawing.Point(95, 38);
            this.RadioButtonHost.Name = "RadioButtonHost";
            this.RadioButtonHost.Size = new System.Drawing.Size(47, 16);
            this.RadioButtonHost.TabIndex = 2;
            this.RadioButtonHost.TabStop = true;
            this.RadioButtonHost.Text = "Host";
            this.RadioButtonHost.UseVisualStyleBackColor = true;
            // 
            // RadioButtonIP
            // 
            this.RadioButtonIP.AutoSize = true;
            this.RadioButtonIP.Location = new System.Drawing.Point(148, 38);
            this.RadioButtonIP.Name = "RadioButtonIP";
            this.RadioButtonIP.Size = new System.Drawing.Size(35, 16);
            this.RadioButtonIP.TabIndex = 3;
            this.RadioButtonIP.TabStop = true;
            this.RadioButtonIP.Text = "IP";
            this.RadioButtonIP.UseVisualStyleBackColor = true;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(95, 97);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(100, 21);
            this.TextBoxPassword.TabIndex = 4;
            // 
            // TextServer
            // 
            this.TextServer.AutoSize = true;
            this.TextServer.Location = new System.Drawing.Point(12, 9);
            this.TextServer.Name = "TextServer";
            this.TextServer.Size = new System.Drawing.Size(77, 12);
            this.TextServer.TabIndex = 5;
            this.TextServer.Text = "服务器地址：";
            // 
            // TextPort
            // 
            this.TextPort.AutoSize = true;
            this.TextPort.Location = new System.Drawing.Point(12, 68);
            this.TextPort.Name = "TextPort";
            this.TextPort.Size = new System.Drawing.Size(77, 12);
            this.TextPort.TabIndex = 6;
            this.TextPort.Text = "服务器端口：";
            // 
            // TextPassword
            // 
            this.TextPassword.AutoSize = true;
            this.TextPassword.Location = new System.Drawing.Point(12, 100);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(53, 12);
            this.TextPassword.TabIndex = 7;
            this.TextPassword.Text = "授权码：";
            // 
            // TextServerType
            // 
            this.TextServerType.AutoSize = true;
            this.TextServerType.Location = new System.Drawing.Point(12, 40);
            this.TextServerType.Name = "TextServerType";
            this.TextServerType.Size = new System.Drawing.Size(77, 12);
            this.TextServerType.TabIndex = 8;
            this.TextServerType.Text = "服务器类型：";
            // 
            // ButtonTestConnect
            // 
            this.ButtonTestConnect.Location = new System.Drawing.Point(116, 126);
            this.ButtonTestConnect.Name = "ButtonTestConnect";
            this.ButtonTestConnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonTestConnect.TabIndex = 9;
            this.ButtonTestConnect.Text = "Test";
            this.ButtonTestConnect.UseVisualStyleBackColor = true;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(197, 126);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 10;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ConfigGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonTestConnect);
            this.Controls.Add(this.TextServerType);
            this.Controls.Add(this.TextPassword);
            this.Controls.Add(this.TextPort);
            this.Controls.Add(this.TextServer);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.RadioButtonIP);
            this.Controls.Add(this.RadioButtonHost);
            this.Controls.Add(this.TextBoxPort);
            this.Controls.Add(this.TextBoxServer);
            this.Name = "ConfigGuide";
            this.Text = "ConfigGuide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.RadioButton RadioButtonHost;
        private System.Windows.Forms.RadioButton RadioButtonIP;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label TextServer;
        private System.Windows.Forms.Label TextPort;
        private System.Windows.Forms.Label TextPassword;
        private System.Windows.Forms.Label TextServerType;
        private System.Windows.Forms.Button ButtonTestConnect;
        private System.Windows.Forms.Button ButtonSave;
    }
}