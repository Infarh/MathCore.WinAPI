namespace MathCore.WinAPI.pInvoke
{
    /// <summary>Сообщение Windows</summary>
    public enum WM : uint
    {
        ACTIVATE = 0x6,
        ACTIVATEAPP = 0x1C,
        AFXFIRST = 0x360,
        AFXLAST = 0x37F,
        APP = 0x8000,
        ASKCBFORMATNAME = 0x30C,
        CANCELJOURNAL = 0x4B,
        CANCELMODE = 0x1F,
        CAPTURECHANGED = 0x215,
        CHANGECBCHAIN = 0x30D,
        CHAR = 0x102,
        CHARTOITEM = 0x2F,
        CHILDACTIVATE = 0x22,
        CLEAR = 0x303,
        CLOSE = 0x10,
        COMMAND = 0x111,
        COMPACTING = 0x41,
        COMPAREITEM = 0x39,
        CONTEXTMENU = 0x7B,
        COPY = 0x301,
        COPYDATA = 0x4A,
        CREATE = 0x1,
        CTLCOLORBTN = 0x135,
        CTLCOLORDLG = 0x136,
        CTLCOLOREDIT = 0x133,
        CTLCOLORLISTBOX = 0x134,
        CTLCOLORMSGBOX = 0x132,
        CTLCOLORSCROLLBAR = 0x137,
        CTLCOLORSTATIC = 0x138,
        CUT = 0x300,
        DEADCHAR = 0x103,
        DELETEITEM = 0x2D,
        DESTROY = 0x2,
        DESTROYCLIPBOARD = 0x307,
        /// <summary>WParam = DBT</summary>
        DEVICECHANGE = 0x219,
        DEVMODECHANGE = 0x1B,
        DISPLAYCHANGE = 0x7E,
        DRAWCLIPBOARD = 0x308,
        DRAWITEM = 0x2B,
        DROPFILES = 0x233,
        ENABLE = 0xA,
        ENDSESSION = 0x16,
        ENTERIDLE = 0x121,
        ENTERMENULOOP = 0x211,
        ENTERSIZEMOVE = 0x231,
        ERASEBKGND = 0x14,
        EXITMENULOOP = 0x212,
        EXITSIZEMOVE = 0x232,
        FONTCHANGE = 0x1D,
        GETDLGCODE = 0x87,
        GETFONT = 0x31,
        GETHOTKEY = 0x33,
        /// <summary>Сообщение <b>WM_GETICON</b> отправляется окну, чтобы извлечь дескриптор большой  или маленькой пиктограммы, связанной с окном
        /// 
        /// <b>wParam</b> - Устанавливает тип извлекаемой пиктограммы:
        ///     <b>ICON_SMALL</b> = 0  - Извлечь маленькую пиктограмму для окна
        ///     <b>ICON_BIG</b> = 1    - Извлечь большую пиктограмму для окна
        ///     <b>ICON_SMALL2</b> = ? - <b>Windows XP</b>: Извлечь маленькую пиктограмму, предусмотренную приложением. 
        ///         Если прикладная программа не предусматривает ее, 
        ///         система использует генерируемую системой пиктограмму для этого окна
        ///         
        /// <b>lParam</b> - Этот параметр не используется
        /// 
        /// <b>Возвращаемые значения</b> - дескриптор большой или маленькой пиктограммы, в зависимости от значения <b>wParam</b>
        /// </summary>
        GETICON = 0x7F,
        GETMINMAXINFO = 0x24,
        GETOBJECT = 0x3D,
        GETSYSMENU = 0x313,
        GETTEXT = 0xD,
        GETTEXTLENGTH = 0xE,
        HANDHELDFIRST = 0x358,
        HANDHELDLAST = 0x35F,
        HELP = 0x53,
        HOTKEY = 0x312,
        HSCROLL = 0x114,
        HSCROLLCLIPBOARD = 0x30E,
        ICONERASEBKGND = 0x27,
        IME_CHAR = 0x286,
        IME_COMPOSITION = 0x10F,
        IME_COMPOSITIONFULL = 0x284,
        IME_CONTROL = 0x283,
        IME_ENDCOMPOSITION = 0x10E,
        IME_KEYDOWN = 0x290,
        IME_KEYLAST = 0x10F,
        IME_KEYUP = 0x291,
        IME_NOTIFY = 0x282,
        IME_REQUEST = 0x288,
        IME_SELECT = 0x285,
        IME_SETCONTEXT = 0x281,
        IME_STARTCOMPOSITION = 0x10D,
        INITDIALOG = 0x110,
        INITMENU = 0x116,
        INITMENUPOPUP = 0x117,
        INPUTLANGCHANGE = 0x51,
        INPUTLANGCHANGEREQUEST = 0x50,
        /// <summary>Нажата клавиша</summary>
        KEYDOWN = 0x100,
        KEYFIRST = 0x100,
        KEYLAST = 0x108,
        /// <summary>Отпущена клавиша</summary>
        KEYUP = 0x101,
        KILLFOCUS = 0x8,
        LBUTTONDBLCLK = 0x203,
        LBUTTONDOWN = 0x201,
        LBUTTONUP = 0x202,
        MBUTTONDBLCLK = 0x209,
        MBUTTONDOWN = 0x207,
        MBUTTONUP = 0x208,
        MDIACTIVATE = 0x222,
        MDICASCADE = 0x227,
        MDICREATE = 0x220,
        MDIDESTROY = 0x221,
        MDIGETACTIVE = 0x229,
        MDIICONARRANGE = 0x228,
        MDIMAXIMIZE = 0x225,
        MDINEXT = 0x224,
        MDIREFRESHMENU = 0x234,
        MDIRESTORE = 0x223,
        MDISETMENU = 0x230,
        MDITILE = 0x226,
        MEASUREITEM = 0x2C,
        MENUCHAR = 0x120,
        MENUCOMMAND = 0x126,
        MENUDRAG = 0x123,
        MENUGETOBJECT = 0x124,
        MENURBUTTONUP = 0x122,
        MENUSELECT = 0x11F,
        MOUSEACTIVATE = 0x21,
        MOUSEFIRST = 0x200,
        MOUSEHOVER = 0x2A1,
        MOUSELAST = 0x20A,
        MOUSELEAVE = 0x2A3,
        MOUSEMOVE = 0x200,
        MOUSEWHEEL = 0x20A,
        MOUSEHWHEEL = 0x20E,
        MOVE = 0x3,
        MOVING = 0x216,
        NCACTIVATE = 0x86,
        NCCALCSIZE = 0x83,
        NCCREATE = 0x81,
        NCDESTROY = 0x82,
        NCHITTEST = 0x84,
        NCLBUTTONDBLCLK = 0xA3,
        NCLBUTTONDOWN = 0xA1,
        NCLBUTTONUP = 0xA2,
        NCMBUTTONDBLCLK = 0xA9,
        NCMBUTTONDOWN = 0xA7,
        NCMBUTTONUP = 0xA8,
        NCMOUSEHOVER = 0x2A0,
        NCMOUSELEAVE = 0x2A2,
        NCMOUSEMOVE = 0xA0,
        NCPAINT = 0x85,
        NCRBUTTONDBLCLK = 0xA6,
        NCRBUTTONDOWN = 0xA4,
        NCRBUTTONUP = 0xA5,
        NEXTDLGCTL = 0x28,
        NEXTMENU = 0x213,
        NOTIFY = 0x4E,
        NOTIFYFORMAT = 0x55,
        NULL = 0x0,
        PAINT = 0xF,
        PAINTCLIPBOARD = 0x309,
        PAINTICON = 0x26,
        PALETTECHANGED = 0x311,
        PALETTEISCHANGING = 0x310,
        PARENTNOTIFY = 0x210,
        PASTE = 0x302,
        PENWINFIRST = 0x380,
        PENWINLAST = 0x38F,
        POWER = 0x48,
        PRINT = 0x317,
        PRINTCLIENT = 0x318,
        QUERYDRAGICON = 0x37,
        QUERYENDSESSION = 0x11,
        QUERYNEWPALETTE = 0x30F,
        /// <summary>Разворачивает окно из иконки</summary>
        QUERYOPEN = 0x13,
        QUERYUISTATE = 0x129,
        QUEUESYNC = 0x23,
        QUIT = 0x12,
        RBUTTONDBLCLK = 0x206,
        RBUTTONDOWN = 0x204,
        RBUTTONUP = 0x205,
        RENDERALLFORMATS = 0x306,
        RENDERFORMAT = 0x305,
        SETCURSOR = 0x20,
        SETFOCUS = 0x7,
        SETFONT = 0x30,
        SETHOTKEY = 0x32,
        /// <summary>Прикладная программа отправляет сообщение <b>WM_SETICON</b>, чтобы сопоставить новую большую или маленькую пиктограмму с окном
        /// 
        /// <b>wParam</b> - Устанавливает тип извлекаемой пиктограммы:
        ///     <b>ICON_SMALL</b> = 0  - Установить маленькую пиктограмму для окна
        ///     <b>ICON_BIG</b> = ?    - Установить большую пиктограмму для окна
        ///         
        /// <b>lParam</b> - Дескриптор новой большой или маленькой пиктограммы. 
        ///     Если этот параметр - ПУСТО (NULL), пиктограмма, обозначенная в параметре wParam, удаляется
        /// 
        /// <b>Возвращаемое значение</b> - дескриптор большой или маленькой предыдущей пиктограммы, в зависимости от значения <b>wParam</b>. 
        /// Оно имеет значение ПУСТО (NULL), если окно предварительно не имело никакой пиктограммы типа, обозначенного в параметре <b>wParam</b>.
        /// </summary>
        SETICON = 0x80,
        SETREDRAW = 0xB,
        SETTEXT = 0xC,
        SETTINGCHANGE = 0x1A,
        SHNOTIFY = 0x0401,
        SHOWWINDOW = 0x18,
        SIZE = 0x5,
        SIZECLIPBOARD = 0x30B,
        SIZING = 0x214,
        SPOOLERSTATUS = 0x2A,
        STYLECHANGED = 0x7D,
        STYLECHANGING = 0x7C,
        SYNCPAINT = 0x88,
        SYSCHAR = 0x106,
        SYSCOLORCHANGE = 0x15,
        SYSCOMMAND = 0x112,
        SYSDEADCHAR = 0x107,
        /// <summary>Системная клавиша нажата</summary>
        SYSKEYDOWN = 0x104,
        /// <summary>Системная клавиша отпущена</summary>
        SYSKEYUP = 0x105,
        SYSTIMER = 0x118,  // undocumented, see http://support.microsoft.com/?id=108938
        TCARD = 0x52,
        TIMECHANGE = 0x1E,
        TIMER = 0x113,
        UNDO = 0x304,
        UNINITMENUPOPUP = 0x125,
        USER = 0x400,
        USERCHANGED = 0x54,
        VKEYTOITEM = 0x2E,
        VSCROLL = 0x115,
        VSCROLLCLIPBOARD = 0x30A,
        WINDOWPOSCHANGED = 0x47,
        WINDOWPOSCHANGING = 0x46,
        WININICHANGE = 0x1A,
        XBUTTONDBLCLK = 0x20D,
        XBUTTONDOWN = 0x20B,
        XBUTTONUP = 0x20C,

        /// <summary>Пользовательское сообщение</summary>
        CAP = 0x400,
        /// <summary>соединение с драйвером устройства видеозахвата</summary>
        CAP_DRIVER_CONNECT = 0x40a,
        /// <summary>разрыв связи с драйвером видеозахвата</summary>
        CAP_DRIVER_DISCONNECT = 0x40b,
        /// <summary>Сохранение кадра с камеры в файл</summary>
        CAP_SAVEDIB = 0x419,
        /// <summary>копирование кадра в буффер обмена</summary>
        CAP_COPY = 0x41e,
        /// <summary>копирование кадра в буффер обмена</summary>
        CAP_EDIT_COPY = CAP_COPY,
        /// <summary></summary>
        CAP_START = 0x400,
        /// <summary></summary>
        CAP_GET_VIDEOFORMAT = 0x42c,
        /// <summary>Получение одиночного фрейма с драйвера видеозахвата</summary>
        CAP_GET_FRAME = 0x43c,
        /// <summary>Получение одиночного фрейма с драйвера видеозахвата</summary>
        CAP_GRAB_FRAME = CAP_GET_FRAME,
        /// <summary></summary>
        CAP_DLG_VIDEOFORMAT = 0x429,
        /// <summary></summary>
        CAP_DLG_VIDEOSOURCE = 0x42a,
        /// <summary></summary>
        CAP_DLG_VIDEODISPLAY = 0x42b,
        /// <summary></summary>
        CAP_DLG_VIDEOCOMPRESSION = 0x42e,
        /// <summary></summary>
        CAP_SET_VIDEOFORMAT = 0x42d,
        /// <summary>вклбчение/отключение режима предпосмотра</summary>
        CAP_SET_PREVIEW = 0x432,
        /// <summary>включение/отключение режима оверлей</summary>
        CAP_SET_OVERLAY = 0x433,
        /// <summary>Скорость previewrate</summary>
        CAP_SET_PREVIEWRATE = 0x434,
        /// <summary>Включение/отключение масштабирования</summary>
        CAP_SET_SCALE = 0x435,
        /// <summary>Установка callback функции  для preview</summary>
        CAP_SET_CALLBACK_FRAME = 0x405,

    }
}
