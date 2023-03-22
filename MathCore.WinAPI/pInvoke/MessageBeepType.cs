namespace MathCore.WinAPI.pInvoke;

/// <summary>
/// Types of sounds that can be emitted by the <see cref="MessageBeep(MessageBeepType)"/> method.
/// </summary>
public enum MessageBeepType : uint
{
    /// <summary>
    /// A simple beep. If the sound card is not available, the sound is generated using the speaker.
    /// </summary>
    SimpleBeep = 0xFFFFFFFF,

    /// <summary>
    /// See <see cref="MB_ICONINFORMATION"/>.
    /// </summary>
    MB_ICONASTERISK = MB_ICONINFORMATION,

    /// <summary>
    /// See <see cref="MB_ICONWARNING"/>.
    /// </summary>
    MB_ICONEXCLAMATION = MB_ICONWARNING,

    /// <summary>
    /// The sound specified as the Windows Critical Stop sound.
    /// </summary>
    MB_ICONERROR = 0x10,

    /// <summary>
    /// See <see cref="MB_ICONERROR"/>.
    /// </summary>
    MB_ICONHAND = MB_ICONERROR,

    /// <summary>
    /// The sound specified as the Windows Asterisk sound.
    /// </summary>
    MB_ICONINFORMATION = 0x40,

    /// <summary>
    /// The sound specified as the Windows Question sound.
    /// </summary>
    MB_ICONQUESTION = 0x20,

    /// <summary>
    /// See <see cref="MB_ICONERROR"/>.
    /// </summary>
    MB_ICONSTOP = MB_ICONERROR,

    /// <summary>
    /// The sound specified as the Windows Exclamation sound.
    /// </summary>
    MB_ICONWARNING = 0x30,

    /// <summary>
    /// The sound specified as the Windows Default Beep sound.
    /// </summary>
    MB_OK = 0x0,
}
