using System.Drawing;
using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

public static class DwmApi
{
    public const string FileName = "dwmapi.dll";

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmEnableBlurBehindWindow(nint hWnd, DWM_BLURBEHIND pBlurBehind);

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmExtendFrameIntoClientArea(nint hWnd, MARGINS pMargins);

    [DllImport(FileName, PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmEnableComposition(bool bEnable);

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmGetColorizationColor(out int pcrColorization, [MarshalAs(UnmanagedType.Bool)] out bool pfOpaqueBlend);

    [DllImport(FileName, PreserveSig = false)]
    public static extern nint DwmRegisterThumbnail(nint dest, nint source);

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmUnregisterThumbnail(nint hThumbnail);

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmUpdateThumbnailProperties(nint hThumbnail, DWM_THUMBNAIL_PROPERTIES props);

    [DllImport(FileName, PreserveSig = false)]
    public static extern void DwmQueryThumbnailSourceSize(nint hThumbnail, out Size size);
}
