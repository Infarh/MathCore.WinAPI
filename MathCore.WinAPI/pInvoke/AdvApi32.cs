using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

public static class AdvApi32
{
    public const string FileName = "advapi32.dll";

    ///// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184(v=vs.85).aspx</remarks>
    //[DllImport(FileName, SetLastError = true, CharSet = CharSet.Unicode)]
    //public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, out SafeTokenHandle phToken);

}
