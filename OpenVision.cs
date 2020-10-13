using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WinApplication
{
    class OpenVision
    {
        [DllImport("D:\\Development\\WinApplication\\WinApplication\\bin\\x64\\Debug\\openvision.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr CreateOpenVision(string title, string rtsp, 
            string VideoPath, double fps, string HaarCascadePath);

        [DllImport("D:\\Development\\WinApplication\\WinApplication\\bin\\x64\\Debug\\openvision.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void DisplayImageFrame(IntPtr obj);


        [DllImport("D:\\Development\\WinApplication\\WinApplication\\bin\\x64\\Debug\\openvision.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void RecordImageFrame(IntPtr obj);


        [DllImport("D:\\Development\\WinApplication\\WinApplication\\bin\\x64\\Debug\\openvision.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void PrepareImageTo(IntPtr obj);

        [DllImport("D:\\Development\\WinApplication\\WinApplication\\bin\\x64\\Debug\\openvision.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void RecognizePlate(IntPtr obj, byte[] buff);
    }
}
