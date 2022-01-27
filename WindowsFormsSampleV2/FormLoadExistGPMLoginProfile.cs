using GPMSharedLibrary.V2.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;

namespace WindowsFormsSampleV2
{
    public partial class FormLoadExistGPMLoginProfile : Form
    {
        public FormLoadExistGPMLoginProfile()
        {
            InitializeComponent();
        }

        private void btnOpenGPMLoginProfile_Click(object sender, EventArgs e)
        {
            // Load profile from GPM Login
            ProfileInfo profileInfo = ProfileInfo.LoadFromGPMLoginProfilePath(txtProfilePath.Text);
            profileInfo.ProfilePath = txtProfilePath.Text;

            // If need custom info => must save after custom info
            // profileInfo.ProxyAuth.RawProxy = "ip:port:user:pass";
            // profileInfo.Extensions.Add(@"D:\#CSharp\#Project\#OutSource\CodeThue_SeparateGithub\GPMSharedLibrary\GPMSharedLibrary.V2\ChromeExtension_PassGoogleLogin_Selenium");
            // profileInfo.SaveToGPMFile(); => Save after custom

            // Download gpm_browser.zip: https://drive.google.com/file/d/1XGEIuDs1dOOPsajBWZjJyjlpIuvmybje/view?usp=sharing
            ChromeDriver gpmDriver = profileInfo.GetDriverForRemote("gpm_browser", hideConsole: false);

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
    }
}
