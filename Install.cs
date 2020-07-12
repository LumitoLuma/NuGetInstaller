using System;
using System.IO;
using System.Net;
using static System.Console;

namespace NugetInstaller
{
    public class Install
    {
        public static void DownloadInstall(string FileURL, string DestPath)
        {
            Write("- ");
            ForegroundColor = ConsoleColor.Magenta;
            Write("Attemping to download and install NuGet.exe...");
            ResetColor();
            try
            {
                /* Enables HTTPS connection */
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                /* Downloads and installs requested file */
                WebClient Client = new WebClient();
                Client.DownloadFile(FileURL, DestPath);
                ForegroundColor = ConsoleColor.Green;
                WriteLine(" Done!");
                ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                Write(" Error! " + ex.Message + "\n\nPlease check if you have the correct permissions. Full StackTrace at error.log");
                ResetColor();
                WriteLine();
                string time = DateTime.Now.TimeOfDay.ToString();
                string progpath = AppDomain.CurrentDomain.BaseDirectory; // Gets application directory
                TextWriter txtwrite = new StreamWriter(progpath + @"\error.log", true);
                txtwrite.WriteLine("[" + time + "] " + ex + "\n");
                txtwrite.Close();
                Beep(400, 350);
                System.Threading.Thread.Sleep(650);
            }
        }
    }
}