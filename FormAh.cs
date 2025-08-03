using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reborn;

namespace AotForms
{
    public partial class FormAh : Form
    {
        public static api KeyAuthApp = new api(
            name: "DJ X CHEATS",
            ownerid: "3vvAAyPCvq",
            secret: "7a4746a6278c2d7c4cf31e6d6a1d56dc38d7d2e826d5f8215144b3730ed22790",
            version: "1.0");

        IntPtr mainHandle;

        public FormAh(IntPtr handle)
        {
            InitializeComponent();
            mainHandle = handle;
            KeyAuthApp.init();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(user.Text, pass.Text);

            if (KeyAuthApp.response.success)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show(KeyAuthApp.response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void adbConnectBtn_Click(object sender, EventArgs e)
        {
            
            adbConnectBtn.FillColor = Color.Yellow;
            var processes = Process.GetProcessesByName("HD-Player");

            if (processes.Length != 1)
            {
                adbConnectBtn.FillColor = Color.Red;
                return;
            }

            var process = processes[0];
            var mainModulePath = Path.GetDirectoryName(process.MainModule.FileName);
            var adbPath = Path.Combine(mainModulePath, "HD-Adb.exe");

            if (!File.Exists(adbPath))
            {
                adbConnectBtn.FillColor = Color.Red;
                return;
            }

            var adb = new Adb(adbPath);
            await adb.Kill();

            var started = await adb.Start();
            if (!started)
            {
                adbConnectBtn.FillColor = Color.Red;
                return;
            }

            string pkg = "com.dts.freefireth";
            string lib = "libil2cpp.so";

            bool isFreeFireMax = false;
            if (isFreeFireMax)
            {
                pkg = "com.dts.freefiremax";
            }

            var moduleAddr = await adb.FindModule(pkg, lib);
            if (moduleAddr == 0)
            {
                adbConnectBtn.FillColor = Color.Red;
                return;
            }

            Offsets.Il2Cpp = (uint)moduleAddr;
            Core.Handle = FindRenderWindow(mainHandle);

            var esp = new ESP();
            await esp.Start();

            new Thread(Data.Work) { IsBackground = true }.Start();
            new Thread(Aimbot.Work) { IsBackground = true }.Start();
           

            adbConnectBtn.FillColor = Color.LimeGreen;
            Console.Beep(2000, 400);
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            KillProcess("HD-Adb");
            Task.Delay(2000);
            KillProcess("HD-Player");
            Task.Delay(1000);
            Environment.Exit(0);
        }

        public void KillProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
        }

        static IntPtr FindRenderWindow(IntPtr parent)
        {
            IntPtr renderWindow = IntPtr.Zero;
            WinAPI.EnumChildWindows(parent, (hWnd, lParam) =>
            {
                StringBuilder sb = new StringBuilder(256);
                WinAPI.GetWindowText(hWnd, sb, sb.Capacity);
                string windowName = sb.ToString();
                if (!string.IsNullOrEmpty(windowName) && windowName != "HD-Player")
                {
                    renderWindow = hWnd;
                }
                return true;
            }, IntPtr.Zero);

            return renderWindow;
        }
    }
}
