using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AotForms
{
    internal static class Program
    {
        [UnmanagedCallersOnly(EntryPoint = "Load")]
        public static void Load(nint pVM)
        {
            if (pVM != 0)
            {
                InternalMemory.Initialize(pVM);
                var process = Process.GetCurrentProcess();
                ComWrappers.RegisterForMarshalling(WinFormsComInterop.WinFormsComWrappers.Instance);
                Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
                Application.EnableVisualStyles();
                Application.Run(new FormAh(process.MainWindowHandle));
            }
            else{
                MessageBox.Show("Please Restart Your Emulator And Try again.");
                Environment.Exit(0);
            }
          
        }

    }
}
