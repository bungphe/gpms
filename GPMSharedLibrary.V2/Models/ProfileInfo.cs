using GPMSharedLibrary.V2.Models.GPMConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;

namespace GPMSharedLibrary.V2.Models
{
    public class ProfileInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Custom file Config name and property name in file config. Default is "gpm"
        /// </summary>
        [JsonProperty("configName")]
        public string ConfigName { get; set; } = "gpm";

        [JsonProperty("profilePath")]
        public string ProfilePath { get; set; }

        [JsonProperty("license")]
        public License License { get; set; } = new License();

        // Browser info
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
        /// <summary>
        /// Suggest: 93.xx.xxxx.xx, 94.x.xxxx.xxx, 95.xxx.xxxx.xxx
        /// </summary>
        [JsonProperty("acceptLanguage")]
        public string AcceptLanguage { get; set; }
        [JsonProperty("proxyAuth")]
        public ProxyAuth ProxyAuth { get; set; } = new ProxyAuth();
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("fonts_exclude")]
        public List<string> Fonts_Exclude { get; set; }
        [JsonProperty("fonts")]
        public List<string> Fonts { get; set; }

        [JsonProperty("screen")]
        public Screen Screen { get; set; } = new Screen();

        // Hardware

        [JsonProperty("navigator")]
        public Navigator Navigator { get; set; } = new Navigator();

        [JsonProperty("webgl")]
        public Webgl Webgl { get; set; } = new Webgl();

        [JsonProperty("audio")]
        public Audio Audio { get; set; } = new Audio();

        [JsonProperty("brand")]
        public Brand Brand { get; set; } = new Brand();

        [JsonProperty("advance")]
        public Advance Advance { get; set; } = new Advance();

        // Other setting
        [JsonProperty("customFlags")]
        public List<string> CustomFlags { get; set; }
        [JsonProperty("extensions")]
        public List<string> Extensions { get; set; }

        [JsonProperty("webRTC")]
        public WebRTC WebRTC { get; set; } = new WebRTC();

        public ProfileInfo()
        {
            // Default data
            this.Fonts_Exclude = new List<string>();
            this.Fonts = new List<string>();
            this.AcceptLanguage = "en-US";
            this.Timezone = "Asia/Bangkok";
            this.CustomFlags = new List<string>();
            this.Extensions = new List<string>();
        }

        public void SaveToFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();
            dynamic dynTemp = new ExpandoObject();
            dynTemp.gpm = this;
            string json = JsonConvert.SerializeObject(dynTemp, Formatting.Indented, new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver() });
            File.WriteAllText(path, json);
        }

        public void SaveToGPMFile()
        {
            SaveToFile(Path.Combine(this.ProfilePath, "Default", "gpm"));
        }

        public static ProfileInfo CreateIfNotExists(string profilePath, string gpmKey = null)
        {
            string fileGPM = Path.Combine(profilePath, "Default", "gpm");
            if (File.Exists(fileGPM))
            {
                var profileInfpo = LoadFromGPMLoginProfilePath(profilePath);
                profileInfpo.License.Key = gpmKey;
                return profileInfpo;
            }
            else
            {
                return CreateRandom(profilePath, gpmKey);
            }
        }

        public static ProfileInfo LoadFromGPMLoginProfilePath(string profilePath)
        {
            ProfileInfo res = null;
            string fileGPM = Path.Combine(profilePath, "Default", "gpm");
            string fileGPM_Define = Path.Combine(profilePath, "Default", "gpm_define");
            if (File.Exists(fileGPM))
            {
                string jsonGPM = File.ReadAllText(fileGPM);
                dynamic dynTemp = JsonConvert.DeserializeObject<dynamic>(jsonGPM);
                res = JsonConvert.DeserializeObject<ProfileInfo>(Convert.ToString(dynTemp.gpm ?? ""));
                if (res != null && File.Exists(fileGPM_Define))
                {
                    string jsonGPM_Define = File.ReadAllText(fileGPM_Define);
                    dynamic dynTemp_Define = JsonConvert.DeserializeObject<dynamic>(jsonGPM_Define);
                    string jsonGPM_Define_jsonData = Convert.ToString(Convert.ToString(dynTemp_Define.JsonData));
                    dynamic dynTemp_Define_jsonData = JsonConvert.DeserializeObject<dynamic>(jsonGPM_Define_jsonData);
                    res.Webgl.Vendor = dynTemp_Define_jsonData.WebGLVendor;
                    res.Webgl.Render = dynTemp_Define_jsonData.WebGLRenderer;
                    res.ProxyAuth.RawProxy = dynTemp_Define_jsonData.Proxy;
                }
            }
            return res;
        }

        public static ProfileInfo CreateRandom(string profilePath, string keyGPM)
        {
            // Step 1: Init fake hardware info
            Random _rand = new Random();
            ProfileInfo profileInfo = new ProfileInfo();

            profileInfo.ProfilePath = profilePath;

            profileInfo.Name = Guid.NewGuid().ToString();
            profileInfo.ConfigName = "gpm";

            profileInfo.Brand.Version = "96.0.4664.45";
            profileInfo.UserAgent = $"Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{profileInfo.Brand.Version} Safari/537.36";
            profileInfo.Timezone = "Asia/Bangkok";

            profileInfo.Screen.Width = _rand.Next(720, 1080);
            profileInfo.Screen.Height = _rand.Next(720, 1080);
            profileInfo.Screen.AvailWidth = _rand.Next(720, 1080);
            profileInfo.Screen.AvailHeight = _rand.Next(720, 1080);

            profileInfo.Navigator.ProcessorCount = 12;

            profileInfo.Webgl.CanvasNoise= _rand.NextDouble();
            profileInfo.Webgl.ClientRectNoise = _rand.NextDouble();
            //profileInfo.Webgl.Vendor = "Custom vendor";
            //profileInfo.Webgl.Render = "Custom render";
            profileInfo.Webgl.Uniform2fNoise = _rand.NextDouble() * (0.001 - 0) + 0;
            profileInfo.Audio.Noise = _rand.NextDouble();
            profileInfo.Advance.MaxVertexUniform = _rand.Next(3000, 4500);
            profileInfo.Advance.MaxFragmentUniform = _rand.Next(900, 1500);

            profileInfo.CustomFlags.Add("--enabled");

            profileInfo.WebRTC.Mode = "real";
            // profileInfo.Proxy = "socks5://1.2.3.4:567"; //"103.155.217.247:32865"; // 

            // Step 2: Set key GPM
            profileInfo.License.Key = keyGPM;
            return profileInfo;
        }

        public ChromeDriver GetDriverForRemote(string chromeExePath, string fileNameDriver="gpmdriver.exe", bool hideConsole = true)
        {
            string browserExePath = Path.Combine(chromeExePath, "chrome.exe");// Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gpm_browser", "chrome.exe");

            // Check params
            if (string.IsNullOrEmpty(this.License.Key))
                throw new Exception("Lincense key null or empty");
            if (string.IsNullOrEmpty(this.ProfilePath))
                throw new Exception("Must be set profile path");

            //Step 1: Create folder profile
            if (!Directory.Exists(this.ProfilePath))
                Directory.CreateDirectory(this.ProfilePath);

            //Step 2: Override file gpm
            if (!Directory.Exists(Path.Combine(this.ProfilePath, "Default")))
                Directory.CreateDirectory(Path.Combine(this.ProfilePath, "Default"));

            this.SaveToFile(Path.Combine(this.ProfilePath, "Default", "gpm"));

            if (!File.Exists(this.ProfilePath + $"\\Default\\{this.ConfigName}"))
                throw new Exception($"{this.ProfilePath}\\Default\\{this.ConfigName} file not found.");

            //Step 3: set params to gpm browser
            List<string> parmas = new List<string>();
            parmas.Add($"--user-data-dir={this.ProfilePath}");
            parmas.Add($"--disable-encryption");
            parmas.Add($"--user-agent={this.UserAgent}");
            parmas.Add($"--uniform2f-noise={this.Webgl.Uniform2fNoise}");
            parmas.Add($"--max-vertex-uniform={this.Advance.MaxVertexUniform}");
            parmas.Add($"--max-fragment-uniform={this.Advance.MaxFragmentUniform}");
            parmas.Add($"--no-default-browser-check");
            parmas.Add($"--turn-off-whats-new");
            parmas.Add($"--disable-blink-features");
            parmas.Add($"--disable-blink-features=AutomationControlled");
            //parmas.Add("--incognito");

            if (!string.IsNullOrEmpty(this.AcceptLanguage))
                parmas.Add($"--lang={this.AcceptLanguage}");
            if (!string.IsNullOrEmpty(this.ConfigName))
                parmas.Add($"--config-name={this.ConfigName}");
            if (!string.IsNullOrEmpty(this.Webgl.Vendor))
                parmas.Add($"--webgl-vendor={this.Webgl.Vendor}");
            if (!string.IsNullOrEmpty(this.Webgl.Render))
                parmas.Add($"--webgl-renderer={this.Webgl.Render}");

            if (this.Extensions != null && this.Extensions.Count > 0)
                parmas.Add($"--load-extension={string.Join(",", this.Extensions)}");
            if (!string.IsNullOrEmpty(this.ProxyAuth.ProxyConnection))
            {
                ProxyInfo proxyInfo = new ProxyInfo(this.ProxyAuth.ProxyConnection);
                string proxyParam = $"--proxy-server={proxyInfo.Host}:{proxyInfo.Port}";
                if (proxyInfo.Type == ProxyType.Socks5) proxyParam = $"--proxy-server=socks5://{proxyInfo.Host}:{proxyInfo.Port}";
                else if (proxyInfo.Type == ProxyType.Socks4) proxyParam = $"--proxy-server=socks://{proxyInfo.Host}:{proxyInfo.Port}";

                parmas.Add(proxyParam);
            }

            if (this.CustomFlags != null && this.CustomFlags.Count > 0)
                parmas.AddRange(this.CustomFlags);

            // Remote by driver
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, fileNameDriver);
            service.HideCommandPromptWindow = hideConsole;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(parmas);
            options.BinaryLocation = browserExePath; //@"C:\Users\LEGION\.gologin\browser\orbita-browser\chrome.exe";//
            //ChromiumMobileEmulationDeviceSettings deviceSettings = new ChromiumMobileEmulationDeviceSettings
            //{
            //    EnableTouchEvents = true,
            //    Width = 480,
            //    Height = 720,
            //    UserAgent = this.UserAgent,
            //    PixelRatio = 1
            //};
            //options.EnableMobileEmulation(deviceSettings);

            ChromeDriver driver = new ChromeDriver(service, options, new TimeSpan(0, 0, 300));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);

            return driver;
        }

        public ChromeDriver GetDriverForRemote_UseDebugPort(string chromeExePath, int remotePort, string fileNameDriver = "gpmdriver.exe", bool hideConsole = true)
        {
            string browserExePath = Path.Combine(chromeExePath, "chrome.exe");// Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gpm_browser", "chrome.exe");

            // Check params
            if (string.IsNullOrEmpty(this.License.Key))
                throw new Exception("Lincense key null or empty");
            if (string.IsNullOrEmpty(this.ProfilePath))
                throw new Exception("Must be set profile path");

            //Step 1: Create folder profile
            if (!Directory.Exists(this.ProfilePath))
                Directory.CreateDirectory(this.ProfilePath);

            //Step 2: Override file gpm
            if (!Directory.Exists(Path.Combine(this.ProfilePath, "Default")))
                Directory.CreateDirectory(Path.Combine(this.ProfilePath, "Default"));

            this.SaveToFile(Path.Combine(this.ProfilePath, "Default", "gpm"));

            if (!File.Exists(this.ProfilePath + $"\\Default\\{this.ConfigName}"))
                throw new Exception($"{this.ProfilePath}\\Default\\{this.ConfigName} file not found.");

            //Step 3: set params to gpm browser
            List<string> parmas = new List<string>();
            parmas.Add($"--user-data-dir=\"{this.ProfilePath}\"");
            parmas.Add($"--disable-encryption");
            parmas.Add($"--user-agent=\"{this.UserAgent}\"");
            parmas.Add($"--uniform2f-noise=\"{this.Webgl.Uniform2fNoise}\"");
            parmas.Add($"--max-vertex-uniform=\"{this.Advance.MaxVertexUniform}\"");
            parmas.Add($"--max-fragment-uniform=\"{this.Advance.MaxFragmentUniform}\"");
            parmas.Add($"--no-default-browser-check");
            parmas.Add($"--turn-off-whats-new");
            parmas.Add($"--disable-blink-features");
            parmas.Add($"--disable-blink-features=AutomationControlled");
            //parmas.Add("--incognito");

            if (!string.IsNullOrEmpty(this.AcceptLanguage))
                parmas.Add($"--lang=\"{this.AcceptLanguage}\"");
            if (!string.IsNullOrEmpty(this.ConfigName))
                parmas.Add($"--config-name=\"{this.ConfigName}\"");
            if (!string.IsNullOrEmpty(this.Webgl.Vendor))
                parmas.Add($"--webgl-vendor=\"{this.Webgl.Vendor}\"");
            if (!string.IsNullOrEmpty(this.Webgl.Render))
                parmas.Add($"--webgl-renderer=\"{this.Webgl.Render}\"");

            if (this.Extensions != null && this.Extensions.Count > 0)
                parmas.Add($"--load-extension={string.Join(",", this.Extensions)}");
            if (!string.IsNullOrEmpty(this.ProxyAuth.ProxyConnection))
            {
                ProxyInfo proxyInfo = new ProxyInfo(this.ProxyAuth.ProxyConnection);
                string proxyParam = $"--proxy-server=\"{proxyInfo.Host}:{proxyInfo.Port}\"";
                if (proxyInfo.Type == ProxyType.Socks5) proxyParam = $"--proxy-server=\"socks5://{proxyInfo.Host}:{proxyInfo.Port}\"";
                else if (proxyInfo.Type == ProxyType.Socks4) proxyParam = $"--proxy-server=\"socks://{proxyInfo.Host}:{proxyInfo.Port}\"";

                parmas.Add(proxyParam);
            }
            parmas.Add($"--remote-debugging-port={remotePort}");

            if (this.CustomFlags != null && this.CustomFlags.Count > 0)
                parmas.AddRange(this.CustomFlags);

            string param = string.Join(" ", parmas);
            Process.Start(browserExePath, param);

            // Remote by driver
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, fileNameDriver);
            service.HideCommandPromptWindow = hideConsole;
            ChromeOptions options = new ChromeOptions();
            options.DebuggerAddress = "127.0.0.1:" + remotePort;

            // Remote by driver
            ChromeDriver driver = new ChromeDriver(service, options);

            return driver;
        }

        public void StartNormal(string chromeExePath, string fileNameDriver = "gpmdriver.exe", bool hideConsole = true)
        {
            string browserExePath = Path.Combine(chromeExePath, "chrome.exe");// Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gpm_browser", "chrome.exe");

            // Check params
            if (string.IsNullOrEmpty(this.License.Key))
                throw new Exception("Lincense key null or empty");
            if (string.IsNullOrEmpty(this.ProfilePath))
                throw new Exception("Must be set profile path");

            //Step 1: Create folder profile
            if (!Directory.Exists(this.ProfilePath))
                Directory.CreateDirectory(this.ProfilePath);

            //Step 2: Override file gpm
            if (!Directory.Exists(Path.Combine(this.ProfilePath, "Default")))
                Directory.CreateDirectory(Path.Combine(this.ProfilePath, "Default"));

            this.SaveToFile(Path.Combine(this.ProfilePath, "Default", "gpm"));

            if (!File.Exists(this.ProfilePath + $"\\Default\\{this.ConfigName}"))
                throw new Exception($"{this.ProfilePath}\\Default\\{this.ConfigName} file not found.");

            //Step 3: set params to gpm browser
            List<string> parmas = new List<string>();
            parmas.Add($"--user-data-dir=\"{this.ProfilePath}\"");
            parmas.Add($"--disable-encryption");
            parmas.Add($"--user-agent=\"{this.UserAgent}\"");
            parmas.Add($"--uniform2f-noise=\"{this.Webgl.Uniform2fNoise}\"");
            parmas.Add($"--max-vertex-uniform=\"{this.Advance.MaxVertexUniform}\"");
            parmas.Add($"--max-fragment-uniform=\"{this.Advance.MaxFragmentUniform}\"");
            parmas.Add($"--no-default-browser-check");
            parmas.Add($"--turn-off-whats-new");
            parmas.Add($"--disable-blink-features");
            parmas.Add($"--disable-blink-features=AutomationControlled");
            //parmas.Add("--incognito");

            if (!string.IsNullOrEmpty(this.AcceptLanguage))
                parmas.Add($"--lang=\"{this.AcceptLanguage}\"");
            if (!string.IsNullOrEmpty(this.ConfigName))
                parmas.Add($"--config-name=\"{this.ConfigName}\"");
            if (!string.IsNullOrEmpty(this.Webgl.Vendor))
                parmas.Add($"--webgl-vendor=\"{this.Webgl.Vendor}\"");
            if (!string.IsNullOrEmpty(this.Webgl.Render))
                parmas.Add($"--webgl-renderer=\"{this.Webgl.Render}\"");

            if (this.Extensions != null && this.Extensions.Count > 0)
                parmas.Add($"--load-extension={string.Join(",", this.Extensions)}");
            if (!string.IsNullOrEmpty(this.ProxyAuth.ProxyConnection))
            {
                ProxyInfo proxyInfo = new ProxyInfo(this.ProxyAuth.ProxyConnection);
                string proxyParam = $"--proxy-server=\"{proxyInfo.Host}:{proxyInfo.Port}\"";
                if (proxyInfo.Type == ProxyType.Socks5) proxyParam = $"--proxy-server=\"socks5://{proxyInfo.Host}:{proxyInfo.Port}\"";
                else if (proxyInfo.Type == ProxyType.Socks4) proxyParam = $"--proxy-server=\"socks://{proxyInfo.Host}:{proxyInfo.Port}\"";

                parmas.Add(proxyParam);
            }

            if (this.CustomFlags != null && this.CustomFlags.Count > 0)
                parmas.AddRange(this.CustomFlags);

            string param = string.Join(" ", parmas);
            Process.Start(browserExePath, param);
        }

    }
}
