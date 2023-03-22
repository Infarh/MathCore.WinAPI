namespace MathCore.WinAPI.pInvoke;

public static class Shell32
{
    public const string FileName = "shell32.dll";

    ///// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/bb776391(v=vs.85).aspx</remarks>
    //[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    //public static extern SafeLocalAllocWStrArray CommandLineToArgvW(string lpCmdLine, out int pNumArgs);
}

///// <summary>
///// Wraps a handle to a user token.
///// </summary>
//public class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
//{
//    /// <summary>
//    /// Creates a new SafeTokenHandle. This constructor should only be called by P/Invoke.
//    /// </summary>
//    private SafeTokenHandle() : base(true) { }

//    /// <summary>
//    /// Creates a new SafeTokenHandle to wrap the specified user token.
//    /// </summary>
//    /// <param name="arrayPointer">The user token to wrap.</param>
//    /// <param name="ownHandle"><c>true</c> to close the token when this object is disposed or finalized,
//    /// <c>false</c> otherwise.</param>
//    public SafeTokenHandle(IntPtr handle, bool ownHandle) : base(ownHandle) => SetHandle(handle);

//    /// <summary>
//    /// Provides a <see cref="WindowsIdentity" /> object created from this user token. Depending
//    /// on the type of token, this can be used to impersonate the user. The WindowsIdentity
//    /// class will duplicate the token, so it is safe to use the WindowsIdentity object created by
//    /// this method after disposing this object.
//    /// </summary>
//    /// <returns>a <see cref="WindowsIdentity" /> for the user that this token represents.</returns>
//    /// <exception cref="InvalidOperationException">This object does not contain a valid handle.</exception>
//    /// <exception cref="ObjectDisposedException">This object has been disposed and its token has
//    /// been released.</exception>

//  <PackageReference Include = "System.Security.Principal.Windows" Version="5.0.0" />
//    public WindowsIdentity GetWindowsIdentity()
//    {
//        if (IsClosed)
//            throw new ObjectDisposedException("The user token has been released.");
//        if (IsInvalid)
//            throw new InvalidOperationException("The user token is invalid.");

//        return new WindowsIdentity(handle);
//    }

//    /// <summary>
//    /// Calls <see cref="NativeMethods.CloseHandle" /> to release this user token.
//    /// </summary>
//    /// <returns><c>true</c> if the function succeeds, <c>false otherwise</c>. To get extended
//    /// error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
//    protected override bool ReleaseHandle() => Kernel32.CloseHandle(handle);
//}

