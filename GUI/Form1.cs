/**
 * Form1.cs is the main part of the NuGetInstaller GUI project.
 *
 * Lumito's NuGetInstaller GUI version 2.00
 * Copyright (C) 2020, Lumito. www.lumito.net
 * Licensed under the MIT license
 * GitHub repository: github.com/LumitoLuma/NugetInstaller
 */

using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        readonly WebClient client = new WebClient();
        readonly string FileName = Path.GetTempPath() + "\\NuGetVersions.txt";
        const int BufferSize = 128;

        public Form1()
        {
            InitializeComponent();
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                client.DownloadFile(new Uri("https://dl.lumito.net/public/repos/NuGetInstaller/.data/NuGetVersions.txt"), Path.GetTempPath() + "\\NuGetVersions.txt");
                using (var fileStream = File.OpenRead(FileName))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            comboBox1.Items.Add(line);
                        }
                    }
                }
                comboBox1.SelectedItem = "latest";
            }
            catch (Exception e)
            {
                string time = DateTime.Now.TimeOfDay.ToString();
                string progpath = AppDomain.CurrentDomain.BaseDirectory; // Gets application directory
                TextWriter txtwrite = new StreamWriter(progpath + @"\error.log", true);
                txtwrite.WriteLine("[" + time + "] " + e + "\n");
                txtwrite.Close();
                MessageBox.Show("Cannot download NuGetVersions.txt file. Please check your internet connection.\n\n" +
                    "If you are sure that you can download files, please open an issue at:\n\n" +
                    "https://github.com/LumitoLuma/NugetInstaller/issues\n\n" +
                    "More information about the problem at error.log.", "NuGet Installer GUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DownInst();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://lumito.net");
        }

        private void DownloadInstall(Uri FileURL, string DestPath)
        {
            richTextBox1.AppendText("\n- Attemping to download and install NuGet.exe...");
            if (textBox1.Text.Contains("\\"))
            {
                if (!Directory.Exists(textBox1.Text))
                    Directory.CreateDirectory(textBox1.Text);
            }
            try
            {
                client.DownloadFile(FileURL, DestPath);
                richTextBox1.AppendText(" Done!");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(" Error! " + ex.Message + "\n\nPlease check if you have the correct permissions. Full StackTrace at error.log");
                string time = DateTime.Now.TimeOfDay.ToString();
                string progpath = AppDomain.CurrentDomain.BaseDirectory; // Gets application directory
                TextWriter txtwrite = new StreamWriter(progpath + @"\error.log", true);
                txtwrite.WriteLine("[" + time + "] " + ex + "\n");
                txtwrite.Close();
                Console.Beep(400, 350);
                System.Threading.Thread.Sleep(650);
            }
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void Cmd(string command)
        {
            if (command.ToLowerInvariant().Equals("nugetinstaller install") || command.ToLowerInvariant().Equals("nugetinstaller.exe install") || command.ToLowerInvariant().Equals("nugetinstaller") || command.ToLowerInvariant().Equals("nugetinstaller.exe"))
            {
                DownloadInstall(new Uri("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"), @"C:\Windows\nuget.exe");
            }
            else if (command.ToLowerInvariant().Equals("nugetinstaller uninstall") || command.ToLowerInvariant().Equals("nugetinstaller.exe uninstall"))
            {
                RemoveFile(@"C:\Windows\nuget.exe");
            }
            else
            {
                richTextBox1.AppendText("\nUsage: 'NuGetInstaller.exe [install | uninstall]'\n\n");
                richTextBox1.AppendText("Options:\n");
                richTextBox1.AppendText("  install   - Installs the latest version of NuGet into C:\\Windows folder\n\n");
                richTextBox1.AppendText("  uninstall - Uninstalls NuGet only if it is installed\n\n");
                richTextBox1.AppendText(" If no arguments are specified, the program will install NuGet.exe");
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void RemoveFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                richTextBox1.AppendText("\n- Attemping to uninstall NuGet.exe...");
                try
                {
                    File.Delete(FilePath);
                    richTextBox1.AppendText(" Done!");
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText(" Error! " + ex.Message + "\n\nPlease check if you have the correct permissions. Full StackTrace at error.log");
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
                richTextBox1.AppendText("\nProgram uninstallation is not needed.");
            }
        }
        
        private void DownInst()
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("Lumito's NuGet Installer GUI version 2.00\n");
            richTextBox1.AppendText("Copyright (C) 2020, Lumito. www.lumito.net\n");
            System.Threading.Thread.Sleep(500);
            if (!textBox1.Text.Contains("\\"))
            {
                Cmd(textBox1.Text);
            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
                comboBox1.Enabled = false;
                button2.Enabled = false;
                DownloadInstall(new Uri("https://dist.nuget.org/win-x86-commandline/" + comboBox1.Text + "/nuget.exe"), textBox1.Text + "\\nuget.exe");
                textBox1.Enabled = true;
                button1.Enabled = true;
                comboBox1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DownInst();
                e.SuppressKeyPress = true;
            }
        }
    }
}
