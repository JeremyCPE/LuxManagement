﻿using System;
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
        public static int _currentBrightness = 0;
        public static void SetBrightness(int brightness)
        {
            NativeMethods.SetMonitorBrightness(brightness);
            _currentBrightness = brightness;
        }

        public static void ReduceBlueLight(int blueReduction)
        {

            if (blueReduction < 0 || blueReduction > 100)
                throw new ArgumentOutOfRangeException("Blue reduction must be between 0 and 100.");

            NativeMethods.RAMP ramp = new NativeMethods.RAMP
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            // Calculate the ramp values
            for (int i = 0; i < 256; i++)
            {
                int value = i * (_currentBrightness + 128);
                if (value > 65535) value = 65535;

                ramp.Red[i] = ramp.Green[i] = (ushort)value;

                // Reduce blue light
                int blueValue = (int)(value * (1.0 - blueReduction / 100.0));
                if (blueValue > 65535) blueValue = 65535;
                ramp.Blue[i] = (ushort)blueValue;
            }

            IntPtr hdc = NativeMethods.GetDC(IntPtr.Zero);
            bool result = NativeMethods.SetDeviceGammaRamp(hdc, ref ramp);
            if(!result)
            { 
                    int errorCode = Marshal.GetLastWin32Error();
                    Console.WriteLine($"Failed to set gamma ramp. Error code: {errorCode}");
            }
            NativeMethods.ReleaseDC(IntPtr.Zero, hdc);

        }
    }
}
