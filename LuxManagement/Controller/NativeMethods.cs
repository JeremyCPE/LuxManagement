using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuxManagement.Controller
{
    internal static class NativeMethods
    {
        #region "User32.dll"
        // Define necessary constants and structs
        public const int PHYSICAL_MONITOR_DESCRIPTION_SIZE = 128;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PHYSICAL_MONITOR
        {
            public IntPtr hPhysicalMonitor;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = PHYSICAL_MONITOR_DESCRIPTION_SIZE)]
            public string szPhysicalMonitorDescription;
        }

        // Import the necessary methods from dxva2.dll
        [DllImport("dxva2.dll", SetLastError = true)]
        public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);

        [DllImport("dxva2.dll", SetLastError = true)]
        public static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        [DllImport("dxva2.dll", SetLastError = true)]
        public static extern bool DestroyPhysicalMonitor(IntPtr hMonitor);

        [DllImport("dxva2.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMonitorBrightness(IntPtr hMonitor, uint dwNewBrightness);

        [DllImport("dxva2.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool GetMonitorBrightness(IntPtr hMonitor, out uint pdwMinimumBrightness, out uint pdwCurrentBrightness, out uint pdwMaximumBrightness);

        // Import necessary methods from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        #endregion


        #region "WMI"

        public static void SetMonitorBrightness(int brightness)
        {
            // Create a management class object
            ManagementClass mclass = new ManagementClass("WmiMonitorBrightnessMethods");
            mclass.Scope = new ManagementScope(@"\\.\root\wmi");

            // Get all instances of the class
            ManagementObjectCollection instances = mclass.GetInstances();

            foreach (ManagementObject instance in instances)
            {
                // Use the WmiSetBrightness method to set the brightness
                instance.InvokeMethod("WmiSetBrightness", new object[] { UInt32.MaxValue, brightness });
                Console.WriteLine("Brightness set to " + brightness);
            }
        }
    }
}
