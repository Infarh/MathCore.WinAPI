using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MathCore.WinAPI.pInvoke
{
    public static class User32
    {
        public const string FileName = "user32.dll";

        #region SendMessage

        /// <summary>Отправка сообщения окну</summary>
        /// <param name="hWnd">Дескриптор окна</param>
        /// <param name="Msg">Сообщение</param>
        /// <param name="wParam">Старший параметр</param>
        /// <param name="lParam">Младший параметр</param>
        /// <returns></returns>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        #endregion

        #region PostMessage

        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        #endregion

        /// <summary>Число символов текста окна</summary>
        /// <param name="hWnd">Дескриптор окна</param>
        /// <returns>Число символов текста окна</returns>
        [DllImport(FileName, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>Получить текст окна</summary>
        /// <param name="hWnd">Дескриптор окна</param>
        /// <param name="lpString">Текст</param>
        /// <param name="nMaxCount">Число символов</param>
        /// <returns>Текст окна</returns>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, uint nMaxCount);

        [DllImport(FileName, SetLastError = true)]
        public static extern int EnumWindows(EnumWindowProc hWnd, IntPtr lParam);

        /// <summary>Установить текст окна</summary>
        /// <param name="hWnd">Дескриптор окна</param>
        /// <param name="lpString">Текст окна</param>
        /// <returns>Истина, если удалось</returns>
        [DllImport(FileName, SetLastError = true)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport(FileName, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// Функция MoveWindow изменяет позицию и габариты определяемого окна. Для окна верх-него уровня, позиция и 
        /// габариты - относительно левого верхнего угла экрана. Для дочернего окна, они - относительно левого верхнего 
        /// угла рабочей области родительского окна.
        /// </summary>
        /// <param name="hWnd">Идентификатор окна</param>
        /// <param name="X">Положение левого верхнего угла окна по оси X</param>
        /// <param name="Y">Положение левого верхнего угла окна по оси Y</param>
        /// <param name="nWidth">Ширина окна</param>
        /// <param name="nHeight">Высота окна</param>
        /// <param name="bRepaint">Определяет, должно ли окно быть перекрашено. Если этот параметр - ИСТИНА (TRUE), 
        /// окно принимает сообщение WM_PAINT. Если параметр - ЛОЖЬ(FALSE), никакого перекрашивания какого-либо сорта 
        /// не происходит. Это применяется к рабочей области, нерабочей области (включая строку заголовка и линейки 
        /// прокрутки) и любой части родительского окна, раскрытого в результате перемещения дочернего окна. 
        /// Если этот параметр - ЛОЖЬ(FALSE), прикладная программа должна явно аннулировать или перерисовать любые 
        /// части окна и родительского окна, которые нуждаются в перерисовке.</param>
        /// <returns>Если функция завершилась успешно, возвращается значение отличное от нуля. Если функция потерпела 
        /// неудачу, возвращаемое значение - ноль</returns>
        /// <remarks>Если параметр bRepaint - ИСТИНА (TRUE), Windows посылает сообщение WM_PAINT оконной процедуре 
        /// немедленно после перемещения окна (то есть функция MoveWindow вызывает функцию UpdateWindow). 
        /// Если bRepaint - ЛОЖЬ(FALSE), Windows помещает сообщение WM_PAINT в очередь сообщений, связанную с окном. 
        /// Цикл сообщений посылает сообщение WM_PAINT только после диспетчеризации всех других сообщений в очереди. 
        /// Функция MoveWindow посылает в окно сообщения WM_WINDOWPOSCHANGING, WM_WINDOWPOSCHANGED, 
        /// WM_MOVE, WM_SIZE и WM_NCCALCSIZE.</remarks>

        [DllImport(FileName, SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport(FileName, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
    }
}
