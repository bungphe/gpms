using GPMSharedLibrary;
using GPMSharedLibrary.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace SampleGPMBrowserAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 0: download browser https://drive.google.com/drive/folders/1GTGsYsWPrDi0cAMXLo_esTgGZ-5jpc50?usp=sharing

            // Step 1: Create or load profile info
            ProfileInfo profileInfo = null;
            if (File.Exists("test-profile.json"))
            {
                // Load saved profile
                profileInfo = ProfileInfo.LoadFromFile("test-profile.json");
                profileInfo.GPMKey = "Enter key here";
            }
            else
            {
                // Create new and save profile
                profileInfo = ProfileInfo.CreateRandom(@"D:\Codes\chromium-test-file\test-auto-profiles\test-profile", "Enter key here");
                profileInfo.SaveToFile("test-profile.json");
            }

            // Step 2: Init profile folder, path to chrome.exe and port remote chrome
            string gpmBrowserPath = @"D:\Codes\chromium\src\out\Release\chrome.exe"; //https://drive.google.com/drive/folders/1GTGsYsWPrDi0cAMXLo_esTgGZ-5jpc50?usp=sharing

            /****************Use export cookie plugin (cookie will send to SimpleServer.cs). Guide: https://youtu.be/7zZjsfuZ7tQ ***********************/
            //GPMSimpleHttpServer simpleHttpServer = new GPMSimpleHttpServer(6699);
            //simpleHttpServer.StartAsync();

            //profileInfo.Id = "fixed id";
            //string extensionPath = profileInfo.CopyCookieExtension();
            //profileInfo.Extensions.Add(extensionPath);
            //var onlineStatus = ProfileConection.GetProfileStatus(profileInfo.Id);
            /**/

            // Step 3: Start browser and remote
            ChromeDriver driver = GPMStarter.StartProfile(gpmBrowserPath,  profileInfo,
                // custom config
                hideConsole: false
                );

            driver.Navigate().GoToUrl("http://codethuegiare.com/download");

            var input = driver.FindElement(By.XPath("//input[@id='activeKey']"));

            input.SendKeys("ABC");
            driver.FindElement(By.XPath("//*[@id='btnGetLink']")).Click();

            //Thread.Sleep(2000);
            //driver.Close();
            //driver.Quit();
            Console.ReadLine();// Keep simple server live
        }
    }
}
