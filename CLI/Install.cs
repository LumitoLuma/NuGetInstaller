/**
 * Install.cs is a part of the NuGetInstaller project.
 *
 * Lumito's NuGetInstaller CLI version 2.00
 * Copyright (C) 2020, Lumito. www.lumito.net
 * Licensed under the MIT license
 * GitHub repository: github.com/LumitoLuma/NugetInstaller
 */

using System;
using System.IO;
using System.Net;

namespace CLI
{
    public static class Install
    {
        public static void DownloadInstall(string FileURL, string DestPath)
        {
            Console.Write("- ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Attemping to download and install NuGet.exe...");
            Console.ResetColor();
            try
            {
                /* Enables HTTPS connection */
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                /* Downloads and installs requested file */
                WebClient Client = new WebClient();
                Client.DownloadFile(FileURL, DestPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Done!");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error! " + ex.Message + "\n\nPlease check if you have the correct permissions. Full StackTrace at error.log");
                Console.ResetColor();
                Console.WriteLine();
                string time = DateTime.Now.TimeOfDay.ToString();
                string progpath = AppDomain.CurrentDomain.BaseDirectory; // Gets application directory
                TextWriter txtwrite = new StreamWriter(progpath + @"\error.log", true);
                txtwrite.WriteLine("[" + time + "] " + ex + "\n");
                txtwrite.Close();
                Console.Beep(400, 350);
                System.Threading.Thread.Sleep(650);
            }
        }
    }
}
