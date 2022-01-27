using GPMSharedLibrary.V2.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSampleV2
{
    public partial class FormCreateNewProfile : Form
    {
        public FormCreateNewProfile()
        {
            InitializeComponent();
        }

        void TestRemote(ChromeDriver gpmDriver)
        {
            try
            {
                gpmDriver.Navigate().GoToUrl("http://codethuegiare.com/download");

                var input = gpmDriver.FindElement(By.XPath("//input[@id='activeKey']"));

                input.SendKeys("Test success");
                gpmDriver.FindElement(By.XPath("//*[@id='btnGetLink']")).Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadOrCreate_Click(object sender, EventArgs e)
        {
            // Create profile fake info
            ProfileInfo profileInfo = ProfileInfo.CreateIfNotExists(txtProfilePath.Text, txtGPMKey.Text);
            profileInfo.Name = txtProfileName.Text;
            // profileInfo.ProxyAuth.RawProxy = "ip:port:user:pass";
            // profileInfo.Extensions.Add(@"D:\#CSharp\#Project\#OutSource\CodeThue_SeparateGithub\GPMSharedLibrary\GPMSharedLibrary.V2\ChromeExtension_PassGoogleLogin_Selenium");
            profileInfo.SaveToGPMFile();

            // Download gpm_browser.zip: https://drive.google.com/file/d/1Pst-bupcN3sijH4mbJlX6yWj2lEcKHJL/view?usp=sharing
            ChromeDriver gpmDriver = profileInfo.GetDriverForRemote("gpm_browser", hideConsole: false);

            this.TestRemote(gpmDriver);
        }

        private void btnShowFormGPMLogin_Click(object sender, EventArgs e)
        {
            new FormLoadExistGPMLoginProfile().Show();
        }

        private void btnLoadOrCreate_DebugPort_Click(object sender, EventArgs e)
        {
            // Create profile fake info
            ProfileInfo profileInfo = ProfileInfo.CreateIfNotExists(txtProfilePath.Text, txtGPMKey.Text);
            profileInfo.Name = txtProfileName.Text;
            // profileInfo.ProxyAuth.RawProxy = "ip:port:user:pass";
            // profileInfo.Extensions.Add(@"D:\#CSharp\#Project\#OutSource\CodeThue_SeparateGithub\GPMSharedLibrary\GPMSharedLibrary.V2\ChromeExtension_PassGoogleLogin_Selenium");
            profileInfo.SaveToGPMFile();

            // Download gpm_browser.zip: https://drive.google.com/file/d/1Pst-bupcN3sijH4mbJlX6yWj2lEcKHJL/view?usp=sharing
            ChromeDriver gpmDriver = profileInfo.GetDriverForRemote_UseDebugPort("gpm_browser", 9966, hideConsole: false);

            this.TestRemote(gpmDriver);
        }

        private void btnStartNormal_Click(object sender, EventArgs e)
        {
            // Create profile fake info
            ProfileInfo profileInfo = ProfileInfo.CreateIfNotExists(txtProfilePath.Text, txtGPMKey.Text);
            profileInfo.Name = txtProfileName.Text;
            // profileInfo.ProxyAuth.RawProxy = "ip:port:user:pass";
            // profileInfo.Extensions.Add(@"D:\#CSharp\#Project\#OutSource\CodeThue_SeparateGithub\GPMSharedLibrary\GPMSharedLibrary.V2\ChromeExtension_PassGoogleLogin_Selenium");
            profileInfo.SaveToGPMFile();

            // Download gpm_browser.zip: https://drive.google.com/file/d/1Pst-bupcN3sijH4mbJlX6yWj2lEcKHJL/view?usp=sharing
            profileInfo.StartNormal("gpm_browser", hideConsole: false);
        }
    }
}
