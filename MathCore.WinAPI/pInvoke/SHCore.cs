using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathCore.WinAPI.pInvoke;

public static class SHCore
{
    public const string FileName = "SHCore.dll";

    [DllImport(FileName, EntryPoint = "GetScaleFactorForMonitor")]
    public static extern nint GetScalePercentForMonitor(nint MonitorHandle, out int Scale);

    [DllImport(FileName)]
    public static extern nint GetScaleFactorForMonitor(nint MonitorHandle, out DeviceScaleFactor Scale);

    public enum DeviceScaleFactor
    {
        DEVICE_SCALE_FACTOR_INVALID = 0,
        SCALE_100_PERCENT = 100,
        SCALE_120_PERCENT = 120,
        SCALE_125_PERCENT = 125,
        SCALE_140_PERCENT = 140,
        SCALE_150_PERCENT = 150,
        SCALE_160_PERCENT = 160,
        SCALE_175_PERCENT = 175,
        SCALE_180_PERCENT = 180,
        SCALE_200_PERCENT = 200,
        SCALE_225_PERCENT = 225,
        SCALE_250_PERCENT = 250,
        SCALE_300_PERCENT = 300,
        SCALE_350_PERCENT = 350,
        SCALE_400_PERCENT = 400,
        SCALE_450_PERCENT = 450,
        SCALE_500_PERCENT = 500
    }
}
