using System;
using System.IO;
using static System.Console;

namespace NugetInstaller
{
    public class Uninstall
    {
        public static void RemoveFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                Write("- ");
                ForegroundColor = ConsoleColor.Magenta;
                Write("Attemping to uninstall NuGet.exe...");
                ResetColor();
                try
                {
                    File.Delete(FilePath);
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
            else
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Program uninstallation is not needed.");
                ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}