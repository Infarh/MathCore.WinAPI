using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

[StructLayout(LayoutKind.Sequential)]
public struct CursorInfo
{
    public int Size { get; set; } = Marshal.SizeOf(typeof(CursorInfo));

    public CursorInfoFlags Flags { get; set; }

    public nint CursorHandle { get; set; }

    public POINT Location { get; set; }

    public CursorInfo() { }
}
