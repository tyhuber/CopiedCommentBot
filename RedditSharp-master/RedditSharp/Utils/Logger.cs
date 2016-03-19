using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace RedditSharp.Utils
{
    public static class Logger
    {
        private static string LogPath  {get;set;}
        private static string ErrorLogPath { get; set; }
        private static StreamWriter Writer { get; set; }

        private static StreamWriter ErrorWriter { get; set; }

        public static bool Initiated;


        public static void Init(string file, string errorFile)
        {
            LogPath = file;
            ErrorLogPath = errorFile;
            Writer = new StreamWriter(LogPath);
            Initiated = true;
        }

        public static void WriteLine(string s, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            string append = $"[{DateTime.Now}] [{name}] [ln {ln}] - ";
            if (Writer != null)
            {
                Writer.WriteLine($"{append}{s}");
                Writer.Flush();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(LogPath))
                {
                    Writer=new StreamWriter(LogPath);
                    Writer.WriteLine($"{append}{s}");
                }
                else
                {
                    LogPath = Path.Combine(Environment.CurrentDirectory, "BackupLog.txt");
                    Writer = new StreamWriter(LogPath);
                    Writer.WriteLine($"{append}{s}");
                }
                
            }
            Console.WriteLine(s);
        }

        public static void Error(string s, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            string append = $"ERROR - [{DateTime.Now}] [{name}] [ln {ln}] - ";
            if(ErrorWriter==null)ErrorWriter=new StreamWriter(ErrorLogPath);
            ErrorWriter.WriteLine($"{append}{s}");
            ErrorWriter.Flush();
            Writer.WriteLine($"{append}{s}");
            Writer.Flush();
            Console.WriteLine($"{append}{s}");
        }
        public static void Error(Exception e, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            string append = $"EXCEPTION CAUGHT - [{DateTime.Now}] [{name}] [ln {ln}] - ";
            if (ErrorWriter == null) ErrorWriter = new StreamWriter(ErrorLogPath);
            ErrorWriter.WriteLine($"{append}{e.Message}");
            ErrorWriter.WriteLine($"Stack trace - {e.StackTrace}");
            ErrorWriter.Flush();
            Writer.WriteLine($"{append}{e.Message}");
            Writer.WriteLine($"Stack trace - {e.StackTrace}");
            Writer.Flush();
            Console.WriteLine($"{append}{e.Message}");
            Console.WriteLine($"Stack trace - {e.StackTrace}");
        }

        public static void TearDown()
        {
            Writer?.Flush();
            Writer?.Close();
            Writer?.Dispose();
        }
    }
}