/**
 * NugetInstaller.cs is the main part of the NugetInstaller project.
 *
 * Lumito's NugetInstaller version 1.00
 * Copyright (C) 2020, Lumito. www.lumito.net
 * Licensed under the MIT license
 * GitHub repository: github.com/LumitoLuma/NugetInstaller
 */

using System;

namespace NugetInstaller
{
    public static class NugetInstaller
    {
        public static void Help()
        {
            /* Gets executable name */
            var progname = System.Diagnostics.Process.GetCurrentProcess();
            string programname = progname.ProcessName;

            /* Displays help message */
            Console.WriteLine("Usage: '" + programname + ".exe [install | uninstall] [/NOLOGO]'\n");
            Console.WriteLine("Options:");
            Console.WriteLine("  install   - Installs the latest version of NuGet into C:\\Windows folder");
            Console.WriteLine("  uninstall - Uninstalls NuGet only if it is installed\n");
            Console.WriteLine("Special flags:");
            Console.WriteLine("  /NOLOGO   - The program suppress the copyright logo. Only works if is specified as the second argument.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n =====================================================================");
            Console.WriteLine(" | If no arguments are specified, the program will install NuGet.exe |");
            Console.WriteLine(" =====================================================================");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }

        public static void Main(string[] args)
        {
            if (args.Length <= 1 || args[1].ToUpperInvariant() != "/NOLOGO")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Lumito's NugetInstaller version 1.00");
                Console.WriteLine("Copyright (C) 2020, Lumito. www.lumito.net");
                Console.ResetColor();
                Console.WriteLine();
            }
            if (args.Length > 0)
            {
                if (args[0].ToLowerInvariant().Equals("uninstall"))
                {
                    Uninstall.RemoveFile(@"C:\Windows\nuget.exe");
		}
                else if (args[0].ToLowerInvariant().Equals("install"))
                {
                    Install.DownloadInstall(@"https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", @"C:\Windows\nuget.exe");
                }
                else
                {
                    Help();
                }
            }
            else
            {
                Install.DownloadInstall(@"https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", @"C:\Windows\nuget.exe");
            }
            Console.ResetColor();
        }
    }
}
