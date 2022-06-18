using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BackOffice
{
    public static class OS
    {
        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static string GetProcesses() 
        {
            string result = "";
            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                result += $"{process.ProcessName}\n";
            }
            
            return result;
        }
    }
}