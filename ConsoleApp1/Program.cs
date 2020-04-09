using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        string uninstallString =    GetUninstallString("ZZZZ", "DELIVERY CENTER V6");


        }

        private static string GetUninstallString(string subKey, string programDisplayName)
        {
            Trace.WriteLine("In GetUninstallString ");
            RegistryKey rgKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            ProcessStartInfo info = new ProcessStartInfo();
            Process uninstallProcess = new Process();
            foreach (var vsKey in rgKey.GetSubKeyNames().Where(n => n.ToUpper().Contains(subKey)))
            {
                RegistryKey productKey = rgKey.OpenSubKey(vsKey);
                string displayName = Convert.ToString(productKey.GetValue("DisplayName"));
                string InstallLocation = Convert.ToString(productKey.GetValue("InstallLocation"));
                if (displayName.Equals(programDisplayName, StringComparison.OrdinalIgnoreCase))
                {
                    return Convert.ToString(productKey.GetValue("UninstallString"));
                    
                }
            }
            return string.Empty;
        }
    }
}
