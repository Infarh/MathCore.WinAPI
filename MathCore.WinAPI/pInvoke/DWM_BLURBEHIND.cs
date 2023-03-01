﻿using System.Runtime.InteropServices;
using System;

namespace MathCore.WinAPI.pInvoke;

[StructLayout(LayoutKind.Sequential)]
public class DWM_BLURBEHIND
{
    public uint dwFlags;
    [MarshalAs(UnmanagedType.Bool)]
    public bool fEnable;
    public IntPtr hRegionBlur;
    [MarshalAs(UnmanagedType.Bool)]
    public bool fTransitionOnMaximized;

    public const uint DWM_BB_ENABLE = 0x00000001;
    public const uint DWM_BB_BLURREGION = 0x00000002;
    public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
}
