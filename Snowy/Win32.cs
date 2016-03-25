namespace Snowy
{
    using System;
    using System.Runtime.InteropServices;

    internal class Win32
    {
        public const byte AC_SRC_ALPHA = 1;
        public const byte AC_SRC_OVER = 0;
        public const int ULW_ALPHA = 2;

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern Bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern Bool DeleteObject(IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr handle);
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr handle, IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern Bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("user32.dll")]
        public static extern Bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern Bool SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        public enum Bool
        {
            False,
            True
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this = new Win32.Point();
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public int cx;
            public int cy;
            public Size(int cx, int cy)
            {
                this = new Win32.Size();
                this.cx = cx;
                this.cy = cy;
            }
        }
    }
}

