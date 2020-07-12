using System;
using static System.Console;

namespace NugetInstaller
{
    public class NugetInstaller
    {
        public static void Help()
        {
            /* Gets executable name */
            var progname = System.Diagnostics.Process.GetCurrentProcess();
            string programname = progname.ProcessName;

            /* Displays help message */
            WriteLine("Usage: '" + programname + ".exe [install | uninstall] [/NOLOGO]'\n");
            WriteLine("Options:");
            WriteLine("  install   - Installs the latest version of NuGet into C:\\Windows folder");
            WriteLine("  uninstall - Uninstalls NuGet only if it is installed\n");
            WriteLine("Special flags:");
            WriteLine("  /NOLOGO   - The program suppress the copyright logo. Only works if is specified as the second argument.");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\n =====================================================================");
            WriteLine(" | If no arguments are specified, the program will install NuGet.exe |");
            WriteLine(" =====================================================================");
            ResetColor();
        }

        public static void Main(string[] args)
        {
            if (args.Length <= 1 || args[1].ToUpper() != "/NOLOGO")
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("Lumito's NugetInstaller version 1.00");
                WriteLine("© 2020, Lumito. www.lumito.net");
                ResetColor();
                WriteLine();
            }
            if (args.Length > 0)
            {
                if (args[0].ToLower().Equals("uninstall"))
                {
                    Uninstall.RemoveFile(@"C:\Windows\nuget.exe");
                }
                else if (args[0].ToLower().Equals("install"))
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
            ResetColor(); // Resets console default color
        }
    }
}