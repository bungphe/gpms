
namespace WindowsFormsSampleV2
{
    partial class FormCreateNewProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGPMKey = new System.Windows.Forms.TextBox();
            this.txtProfilePath = new System.Windows.Forms.TextBox();
            this.btnLoadOrCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.btnShowFormGPMLogin = new System.Windows.Forms.Button();
            this.btnLoadOrCreate_DebugPort = new System.Windows.Forms.Button();
            this.btnStartNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GPM Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profile path:";
            // 
            // txtGPMKey
            // 
            this.txtGPMKey.Location = new System.Drawing.Point(83, 24);
            this.txtGPMKey.Name = "txtGPMKey";
            this.txtGPMKey.Size = new System.Drawing.Size(345, 20);
            this.txtGPMKey.TabIndex = 2;
            this.txtGPMKey.UseSystemPasswordChar = true;
            // 
            // txtProfilePath
            // 
            this.txtProfilePath.Location = new System.Drawing.Point(83, 56);
            this.txtProfilePath.Name = "txtProfilePath";
            this.txtProfilePath.Size = new System.Drawing.Size(345, 20);
            this.txtProfilePath.TabIndex = 3;
            this.txtProfilePath.Text = "D:\\GPMProfiles\\Proflie 1";
            // 
            // btnLoadOrCreate
            // 
            this.btnLoadOrCreate.Location = new System.Drawing.Point(83, 127);
            this.btnLoadOrCreate.Name = "btnLoadOrCreate";
            this.btnLoadOrCreate.Size = new System.Drawing.Size(151, 29);
            this.btnLoadOrCreate.TabIndex = 4;
            this.btnLoadOrCreate.Text = "Load or create if not exists";
            this.btnLoadOrCreate.UseVisualStyleBackColor = true;
            this.btnLoadOrCreate.Click += new System.EventHandler(this.btnLoadOrCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Profile name:";
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(83, 90);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(345, 20);
            this.txtProfileName.TabIndex = 6;
            this.txtProfileName.Text = "uid 123456";
            // 
            // btnShowFormGPMLogin
            // 
            this.btnShowFormGPMLogin.Location = new System.Drawing.Point(257, 130);
            this.btnShowFormGPMLogin.Name = "btnShowFormGPMLogin";
            this.btnShowFormGPMLogin.Size = new System.Drawing.Size(143, 23);
            this.btnShowFormGPMLogin.TabIndex = 8;
            this.btnShowFormGPMLogin.Text = "Use GPM Login profile";
            this.btnShowFormGPMLogin.UseVisualStyleBackColor = true;
            this.btnShowFormGPMLogin.Click += new System.EventHandler(this.btnShowFormGPMLogin_Click);
            // 
            // btnLoadOrCreate_DebugPort
            // 
            this.btnLoadOrCreate_DebugPort.Location = new System.Drawing.Point(83, 162);
            this.btnLoadOrCreate_DebugPort.Name = "btnLoadOrCreate_DebugPort";
            this.btnLoadOrCreate_DebugPort.Size = new System.Drawing.Size(317, 23);
            this.btnLoadOrCreate_DebugPort.TabIndex = 9;
            this.btnLoadOrCreate_DebugPort.Text = "Load or create if not exists (use debug port)";
            this.btnLoadOrCreate_DebugPort.UseVisualStyleBackColor = true;
            this.btnLoadOrCreate_DebugPort.Click += new System.EventHandler(this.btnLoadOrCreate_DebugPort_Click);
            // 
            // btnStartNormal
            // 
            this.btnStartNormal.Location = new System.Drawing.Point(83, 191);
            this.btnStartNormal.Name = "btnStartNormal";
            this.btnStartNormal.Size = new System.Drawing.Size(317, 23);
            this.btnStartNormal.TabIndex = 10;
            this.btnStartNormal.Text = "Start normal";
            this.btnStartNormal.UseVisualStyleBackColor = true;
            this.btnStartNormal.Click += new System.EventHandler(this.btnStartNormal_Click);
            // 
            // FormCreateNewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 228);
            this.Controls.Add(this.btnStartNormal);
            this.Controls.Add(this.btnLoadOrCreate_DebugPort);
            this.Controls.Add(this.btnShowFormGPMLogin);
            this.Controls.Add(this.txtProfileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadOrCreate);
            this.Controls.Add(this.txtProfilePath);
            this.Controls.Add(this.txtGPMKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateNewProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WindowsFormsSampleV2 - Create or Load Exists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGPMKey;
        private System.Windows.Forms.TextBox txtProfilePath;
        private System.Windows.Forms.Button btnLoadOrCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Button btnShowFormGPMLogin;
        private System.Windows.Forms.Button btnLoadOrCreate_DebugPort;
        private System.Windows.Forms.Button btnStartNormal;
    }
}

