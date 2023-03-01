using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

[StructLayout(LayoutKind.Sequential)]
public class MARGINS
{
    public int cxLeftWidth, cxRightWidth,
               cyTopHeight, cyBottomHeight;

    public MARGINS(int left, int top, int right, int bottom)
    {
        cxLeftWidth = left; cyTopHeight = top;
        cxRightWidth = right; cyBottomHeight = bottom;
    }
}
