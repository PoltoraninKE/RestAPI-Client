using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DesktopAppChat.Additionals
{
    class DataConverter
    {
        public static string UnsecureString(SecureString password)
        {
            if (password == null)
            {
                return string.Empty;
            }
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
