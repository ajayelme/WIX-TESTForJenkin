using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Web.Administration;

namespace CustomActionUtility
{
    public class CustomActions
    {
        static string sourcePath = string.Empty;
        static string destinationPath = string.Empty;

        #region ErrorLog

        [CustomAction]
        public static ActionResult StopErrorLog()
        {
                PowerShell PowerShell1 = PowerShell.Create();
                PowerShell1.AddScript("Stop-Service ErrorLog");
                PowerShell1.Invoke();
                return ActionResult.Success;
        }

        #endregion
    }
}
