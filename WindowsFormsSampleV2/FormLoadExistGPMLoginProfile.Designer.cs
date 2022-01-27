
namespace WindowsFormsSampleV2
{
    partial class FormLoadExistGPMLoginProfile
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtProfilePath = new System.Windows.Forms.TextBox();
            this.btnOpenGPMLoginProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GPM Login Profile path:";
            // 
            // txtProfilePath
            // 
            this.txtProfilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfilePath.Location = new System.Drawing.Point(140, 12);
            this.txtProfilePath.Name = "txtProfilePath";
            this.txtProfilePath.Size = new System.Drawing.Size(561, 20);
            this.txtProfilePath.TabIndex = 3;
            this.txtProfilePath.Text = "D:\\Codes\\chromium-test-file\\profiles\\HYoll48vpoCD5ddNtxU6_11122021";
            // 
            // btnOpenGPMLoginProfile
            // 
            this.btnOpenGPMLoginProfile.Location = new System.Drawing.Point(140, 38);
            this.btnOpenGPMLoginProfile.Name = "btnOpenGPMLoginProfile";
            this.btnOpenGPMLoginProfile.Size = new System.Drawing.Size(87, 29);
            this.btnOpenGPMLoginProfile.TabIndex = 4;
            this.btnOpenGPMLoginProfile.Text = "Open";
            this.btnOpenGPMLoginProfile.UseVisualStyleBackColor = true;
            this.btnOpenGPMLoginProfile.Click += new System.EventHandler(this.btnOpenGPMLoginProfile_Click);
            // 
            // FormLoadExistGPMLoginProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 69);
            this.Controls.Add(this.btnOpenGPMLoginProfile);
            this.Controls.Add(this.txtProfilePath);
            this.Controls.Add(this.label2);
            this.Name = "FormLoadExistGPMLoginProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WindowsFormsSampleV2 - Load GPM Login Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProfilePath;
        private System.Windows.Forms.Button btnOpenGPMLoginProfile;
    }
}

