/**
 * NuGetInstaller.cs is the main part of the NuGetInstaller project.
 *
 * Lumito's NuGetInstaller CLI version 2.00
 * Copyright (C) 2020, Lumito. www.lumito.net
 * Licensed under the MIT license
 * GitHub repository: github.com/LumitoLuma/NuGetInstaller
 */

using System;

namespace CLI
{
    public static class NuGetInstaller
    {
        public static void Help()
        {
            /* Gets executable name */
            var progname = System.Diagnostics.Process.GetCurrentProcess();
            string programname = progname.ProcessName;

            /* Displays help message */
            Console.WriteLine("Usage: '" + programname + ".exe [install | uninstall] [/NOLOGO] [/version]'\n");
            Console.WriteLine("Options:");
            Console.WriteLine("  install   - Installs the latest version of NuGet into C:\\Windows folder");
            Console.WriteLine("  uninstall - Uninstalls NuGet only if it is installed\n");
            Console.WriteLine("Special flags:");
            Console.WriteLine("  /NOLOGO   - The program suppress the copyright logo.");
            Console.WriteLine("  /version  - Displays program version information and license.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n =====================================================================");
            Console.WriteLine(" | If no arguments are specified, the program will install NuGet.exe |");
            Console.WriteLine(" =====================================================================");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }

        public static void Main(string[] args)
        {
            bool showVer = false;
            bool showLogo = true;
            bool extraArgs = false;

            foreach (string argument in args)
            {
                string arg = argument.ToLowerInvariant();
                if (arg.Equals("--version") || arg.Equals("-version") || arg.Equals("/version"))
                {
                    showVer = true;
                    extraArgs = true;
                }
                else if (arg.Equals("/nologo") || arg.Equals("-nologo") || arg.Equals("--nologo"))
                {
                    showLogo = false;
                }
            }

            if (showLogo)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Lumito's NuGetInstaller CLI version 2.00");
                Console.WriteLine("Copyright (C) 2020, Lumito. www.lumito.net");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (showVer)
            {
                Console.WriteLine("NuGet Installer CLI version 2.00\nCoded by Lumito - www.lumito.net\nHosted on GitHub: github.com/LumitoLuma\n");
                Console.WriteLine("Licensed under the MIT license\n");
                Console.WriteLine("Copyright (c) 2020 Lumito Luma\n\n" +
                "Permission is hereby granted, free of charge, to any person obtaining a copy\n" +
                "of this software and associated documentation files(the \"Software\"), to deal\n" +
                "in the Software without restriction, including without limitation the rights\n" +
                "to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell\n" +
                "copies of the Software, and to permit persons to whom the Software is\n" +
                "furnished to do so, subject to the following conditions:\n\n" +
                "The above copyright notice and this permission notice shall be included in all\n" +
                "copies or substantial portions of the Software.\n\n" +
                "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\n" +
                "IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\n" +
                "FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE\n" +
                "AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\n" +
                "LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\n" +
                "OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\n" +
                "SOFTWARE.");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }

            if (args.Length > 0 && !extraArgs)
            {
                if (args[0].ToLowerInvariant().Equals("uninstall"))
                {
                    Uninstall.RemoveFile(@"C:\Windows\nuget.exe");
                }
                else if (args[0].ToLowerInvariant().Equals("install"))
                {
                    Install.DownloadInstall(@"https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", @"C:\Windows\nuget.exe");
                }
                else if (args[0].ToLowerInvariant().Equals("/nologo") || args[0].ToLowerInvariant().Equals("-nologo") || args[0].ToLowerInvariant().Equals("--nologo"))
                {
                    Install.DownloadInstall(@"https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", @"C:\Windows\nuget.exe");
                }
                else
                {
                    Help();
                }
            }
            else if (!extraArgs)
            {
                Install.DownloadInstall(@"https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", @"C:\Windows\nuget.exe");
            }
            Console.ResetColor();
        }
    }
}