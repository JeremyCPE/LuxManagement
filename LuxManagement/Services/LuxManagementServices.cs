using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LuxManagement.Controller;

namespace LuxManagement.Services
{
    internal static class LuxManagementServices
    {

        public static void SetBrightness(int brightess)
        {
            NativeMethods.SetMonitorBrightness(brightess);
        }
    }
}
