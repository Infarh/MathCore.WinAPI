using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

[Serializable]
[return: MarshalAs(UnmanagedType.Bool)]
public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr lParam);
