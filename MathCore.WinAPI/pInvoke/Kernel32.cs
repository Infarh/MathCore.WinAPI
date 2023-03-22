using System.Runtime.InteropServices;

namespace MathCore.WinAPI.pInvoke;

public static class Kernel32
{
    public const string FileName = "kernel32.dll";

    /// <summary>
    /// Получает кодовую страницу ввода, используемую консолью, связанной с вызывающим процессом.
    /// Консоль использует страницу входного кода для преобразования ввода
    /// с клавиатуры в соответствующее символьное значение.
    /// </summary>
    /// <returns>Возвращаемое значение — это код, идентифицирующий кодовую страницу. </returns>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/console/GetConsoleCP</remarks>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/win32/intl/code-page-identifiers</remarks>
    [DllImport(FileName)] public static extern uint GetConsoleCP();

    /// <summary>
    /// Задает кодовую страницу ввода, используемую консолью, связанной с вызывающим процессом.
    /// Консоль использует страницу входного кода для преобразования ввода
    /// с клавиатуры в соответствующее символьное значение.
    /// </summary>
    /// <param name="CodePage">Идентификатор устанавливаемой кодовой страницы</param>
    /// <returns>
    /// Если функция выполняется успешно, возвращается true.
    /// Если функция выполняется неудачно, возвращается false.
    /// Дополнительные сведения об ошибке можно получить, вызвав GetLastError.
    /// </returns>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/console/SetConsoleCP</remarks>
    [DllImport(FileName)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetConsoleCP(uint CodePage);

    /// <summary>
    /// Извлекает выходную кодовую страницу, используемую консолью, связанной с вызывающим процессом.
    /// Консоль использует свою кодовую страницу вывода для преобразования символьных значений,
    /// записанных различными функциями вывода, в изображения, отображаемые в окне консоли.
    /// </summary>
    /// <returns>Возвращаемое значение — это код, идентифицирующий кодовую страницу</returns>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/console/GetConsoleOutputCP</remarks>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/win32/intl/code-page-identifiers</remarks>
    [DllImport(FileName)] public static extern uint GetConsoleOutputCP();

    /// <summary>
    /// Задает выходную кодовую страницу, используемую консолью, связанной с вызывающим процессом.
    /// Консоль использует свою кодовую страницу вывода для преобразования символьных значений,
    /// записанных различными функциями вывода, в изображения, отображаемые в окне консоли.
    /// </summary>
    /// <param name="CodePage">Идентификатор заданной кодовой страницы</param>
    /// <returns>Если функция выполняется успешно, возвращается ненулевое значение</returns>
    /// <remarks>https://docs.microsoft.com/ru-ru/windows/console/SetConsoleOutputCP</remarks>
    [DllImport(FileName)] public static extern bool SetConsoleOutputCP(uint CodePage);

    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms724211(v=vs.85).aspx</remarks>
    [DllImport(FileName, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(nint handle);

    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa366730(v=vs.85).aspx</remarks>
    [DllImport(FileName, SetLastError = true)]
    public static extern nint LocalFree(nint hLocal);

    [DllImport(FileName, CharSet = CharSet.Auto)]
    public static extern nint GetModuleHandle(string lpModuleName);

    [DllImport(FileName, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    public static extern nint GetProcAddress(nint hModule, string procName);

    public static TDelegate GetFunction<TDelegate>(string lpModuleName, string procName) where TDelegate : MulticastDelegate
    {
        var module_handle = GetModuleHandle(lpModuleName);
        var method_handle = GetProcAddress(module_handle, procName);
        var result = Marshal.GetDelegateForFunctionPointer<TDelegate>(method_handle);
        return result;
    }
}
