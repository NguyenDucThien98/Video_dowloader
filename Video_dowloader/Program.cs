using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Video_dowloader
{
    class Program
    {
        static void Main(string[] args)
        {
           


            while (true)
            {
                Console.WriteLine("Enter url(input exit to stop) :");
                string url = Console.ReadLine();
                if (url == "exit")
                {
                    return;
                }
                string folder = DateTime.Today.ToString("m", CultureInfo.CreateSpecificCulture("en-us"));
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("youtube-dl " + url + " -o \"/"+ folder + "/%(title)s.%(ext)s");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                while (cmd.StandardOutput.ReadLine() != null)
                {
                    Console.WriteLine(cmd.StandardOutput.ReadLine());
                }
                cmd.WaitForExit();
                cmd.Close();
            }

        }
    }
}
