/**
 * Uninstall.cs is a part of the NuGetInstaller project.
 *
 * Lumito's NuGetInstaller CLI version 2.00
 * Copyright (C) 2020, Lumito. www.lumito.net
 * Licensed under the MIT license
 * GitHub repository: github.com/LumitoLuma/NuGetInstaller
 */

using System;
using System.IO;

namespace CLI
{
    public static class Uninstall
    {
        public static void RemoveFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                Console.Write("- ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Attemping to uninstall NuGet.exe...");
                Console.ResetColor();
                try
                {
                    File.Delete(FilePath);
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
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Program uninstallation is not needed.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
