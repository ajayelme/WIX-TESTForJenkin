using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIFileDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            //lblResult.Text = txtName.Text;
            //lblResult.ForeColor = System.Drawing.Color.Green;
            //string fileName = session.CustomActionData["FILENAME"];
            string subKey = "ErrorLog";
            string programDisplayName = "Error Log Track";
            string uninstallString = GetUninstallString(subKey, programDisplayName);

            if (!string.IsNullOrEmpty(uninstallString))
                txtName.Text = uninstallString;
          
     
        }

        private static string GetUninstallString(string subKey, string programDisplayName)
        {
            RegistryKey rgKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Services");

            ProcessStartInfo info = new ProcessStartInfo();
            foreach (var vsKey in rgKey.GetSubKeyNames().Where(n => n.ToUpper().Contains(subKey)))
            {
                RegistryKey productKey = rgKey.OpenSubKey(vsKey);
                string displayName = Convert.ToString(productKey.GetValue("DisplayName"));
                string InstallLocation = Convert.ToString(productKey.GetValue("InstallLocation"));
                if (displayName.Contains(programDisplayName))
                {
                    return Convert.ToString(productKey.GetValue("UninstallString"));
                }
            }
            return string.Empty;
        }
    }
}
