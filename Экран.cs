using System;
using System.Runtime.InteropServices;

class Class_Screen
{
    private const int MONITOR_ON = -1;
    private const int MONITOR_OFF = 2;
    private const int WM_SYSCOMMAND = 0x0112;
    private const int SC_MONITORPOWER = 0xF170;
    private const int HWND_BROADCAST = 0xffff;
    [DllImport("user32.dll")]
    
   
    private static extern IntPtr SendMessage(IntPtr hWnd,
                                             uint Msg,
                                             IntPtr wParam,
                                             IntPtr lParam);
   
    [DllImport("user32.dll")]
    
    
    private static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
    public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;

    [DllImport("User32.dll")]
    
    static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);
    [Flags]
    
    enum MouseFlags
    {
        Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
        RightUp = 0x0010, Absolute = 0x8000
    };

    public void MonitorOff()
    {
        IntPtr foregroundWindow = GetForegroundWindow();
        if (foregroundWindow == IntPtr.Zero)
            foregroundWindow = (IntPtr)HWND_BROADCAST;
        SendMessage(foregroundWindow, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MONITOR_OFF);

    }
    public void MonitorOn()
    {
        IntPtr foregroundWindow = GetForegroundWindow();
        if (foregroundWindow == IntPtr.Zero)
            foregroundWindow = (IntPtr)HWND_BROADCAST;
        SendMessage(foregroundWindow, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MONITOR_ON);
        const int x = 32000;
        const int y = 32000;
        mouse_event(MouseFlags.Absolute | MouseFlags.Move, x, y, 0, UIntPtr.Zero);
    }
}