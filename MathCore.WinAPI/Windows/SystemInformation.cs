using System.Drawing;

using MathCore.WinAPI.pInvoke;

namespace MathCore.WinAPI.Windows;

internal static class SystemInformation
{
    private static bool _CheckMultiMonitorSupport;
    private static bool _MultiMonitorSupport;

    public static Rectangle VirtualScreen
    {
        get
        {
            if (MultiMonitorSupport)
                return new(
                    User32.GetSystemMetrics(User32.SystemMetric.SM_XVIRTUALSCREEN),
                    User32.GetSystemMetrics(User32.SystemMetric.SM_YVIRTUALSCREEN),
                    User32.GetSystemMetrics(User32.SystemMetric.SM_CXVIRTUALSCREEN),
                    User32.GetSystemMetrics(User32.SystemMetric.SM_CYVIRTUALSCREEN));

            var size = PrimaryMonitorSize;
            return new(0, 0, size.Width, size.Height);
        }
    }

    public static Size PrimaryMonitorSize => new(User32.GetSystemMetrics(User32.SystemMetric.SM_CXSCREEN), User32.GetSystemMetrics(User32.SystemMetric.SM_CYSCREEN));

    private static bool MultiMonitorSupport
    {
        get
        {
            if (_CheckMultiMonitorSupport)
                return _MultiMonitorSupport;

            _MultiMonitorSupport = User32.GetSystemMetrics(User32.SystemMetric.SM_CMONITORS) != 0;
            _CheckMultiMonitorSupport = true;

            return _MultiMonitorSupport;
        }
    }

    public static Rectangle WorkingArea
    {
        get
        {
            var working_area = new RECT();
            User32.SystemParametersInfo(User32.SPI.GETWORKAREA, 0U, ref working_area, 0U);
            return working_area;
        }
    }
}
