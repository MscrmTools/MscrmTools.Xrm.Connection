using McTools.Xrm.Connection.WinForms.AppCode;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class BrowserSelectionDialog : Form
    {
        public BrowserSelectionDialog(BrowserEnum browser, string profile)
        {
            InitializeComponent();

            LoadBrowsers();
            SetControls(browser, profile);

            CustomTheme.Instance.ApplyTheme(this);
        }

        public BrowserEnum Browser { get; private set; }

        public string Profile { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetBrowser();

            Profile = ((BrowserProfile)comboBox1.SelectedItem).Path;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var process = new Process();
            SetBrowser();
            switch (Browser)
            {
                case BrowserEnum.Chrome:
                    process.StartInfo = new ProcessStartInfo("chrome.exe");
                    process.StartInfo.Arguments = $"https://www.xrmtoolbox.com";

                    if (comboBox1.SelectedItem != null) process.StartInfo.Arguments += $" --profile-directory=\"{((BrowserProfile)comboBox1.SelectedItem).Path}\"";
                    break;

                case BrowserEnum.Edge:
                    process.StartInfo = new ProcessStartInfo("msedge.exe");
                    process.StartInfo.Arguments = $"https://www.xrmtoolbox.com";

                    if (comboBox1.SelectedItem != null) process.StartInfo.Arguments += $" --profile-directory=\"{((BrowserProfile)comboBox1.SelectedItem).Path}\"";
                    break;

                case BrowserEnum.Firefox:
                    process.StartInfo = new ProcessStartInfo("firefox.exe");
                    process.StartInfo.Arguments = $"https://www.xrmtoolbox.com";

                    if (comboBox1.SelectedItem != null) process.StartInfo.Arguments += $" -P \"{((BrowserProfile)comboBox1.SelectedItem).Path}\"";
                    break;
            }

            process.Start();
        }

        private void cbbBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetBrowser();
                LoadBrowsers();
            }
            catch (Exception error)
            {
                MessageBox.Show(this, $"An error occured when searching for profiles: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetChromeProfileName(string folder)
        {
            JObject jo;
            using (var reader = new StreamReader(Path.Combine(folder, "Preferences")))
            {
                jo = JObject.Parse(reader.ReadToEnd());
            }

            return ((JValue)((JObject)jo["profile"])["name"]).Value.ToString();
        }

        private void LoadBrowsers()
        {
            comboBox1.Items.Clear();
            switch (Browser)
            {
                case BrowserEnum.Chrome:
                case BrowserEnum.Edge:
                    var path = Browser == BrowserEnum.Chrome ? "Google\\Chrome\\User Data" : "Microsoft\\Edge\\User Data";

                    try
                    {
                        // New way to find profiles
                        JObject jo;
                        using (var reader = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path, "Local State")))
                        {
                            jo = JObject.Parse(reader.ReadToEnd());
                        }

                        jo["profile"]["info_cache"].Children().ToList().ForEach(x =>
                        {
                            if (((JProperty)x).Name.StartsWith("Profile"))
                            {
                                comboBox1.Items.Add(new BrowserProfile { Name = x.Values<JObject>().First()["name"].ToString(), Path = ((JProperty)x).Name.ToString() });
                            }
                        });
                    }
                    catch
                    {
                        // Fallback to old way
                        foreach (var folder in Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path), "Profile *"))
                        {
                            comboBox1.Items.Add(new BrowserProfile { Name = GetChromeProfileName(folder), Path = Path.GetFileName(folder) });
                        }

                        var defaultFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path, "Default");
                        comboBox1.Items.Add(new BrowserProfile { Name = GetChromeProfileName(defaultFolder), Path = Path.GetFileName(defaultFolder) });
                    }

                    break;

                case BrowserEnum.Firefox:
                    foreach (var folder in Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mozilla\\Firefox\\Profiles")))
                    {
                        comboBox1.Items.Add(new BrowserProfile { Name = folder.Split('.')[1], Path = Path.GetFileName(folder).Split('.')[1] });
                    }
                    break;
            }
        }

        private void SetBrowser()
        {
            switch (cbbBrowser.SelectedItem?.ToString())
            {
                case "Chrome":
                    Browser = BrowserEnum.Chrome;
                    break;

                case "Edge":
                    Browser = BrowserEnum.Edge;
                    break;

                case "Firefox":
                    Browser = BrowserEnum.Firefox;
                    break;

                default:
                    Browser = BrowserEnum.None;
                    break;
            }
        }

        private void SetControls(BrowserEnum browser, string profile)
        {
            if (browser != BrowserEnum.None)
            {
                switch (browser)
                {
                    case BrowserEnum.Chrome:
                        cbbBrowser.SelectedItem = "Chrome";
                        break;

                    case BrowserEnum.Edge:
                        cbbBrowser.SelectedItem = "Edge";
                        break;

                    case BrowserEnum.Firefox:
                        cbbBrowser.SelectedItem = "Firefox";
                        break;
                }

                cbbBrowser_SelectedIndexChanged(cbbBrowser, new EventArgs());

                foreach (BrowserProfile item in comboBox1.Items)
                {
                    if (item.Path == profile)
                    {
                        comboBox1.SelectedItem = item;
                    }
                }
            }
        }
    }
}