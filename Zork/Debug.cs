using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zork
{
    public static class Debug
    {
        public static FileStream Debugstream = File.OpenWrite(@"../../Debug.txt");


        public static void Log(string text)
        {
            WriteToFile("DEBUG: " + text);
        }

        public static void Error(string text)
        {
            Console.WriteLine("ERROR: " + text.ToUpper());
            WriteToFile("ERROR: " + text.ToUpper());
        }

        private static void WriteToFile(string text)
        {
            if (text != "")
            {
                if (Debugstream.CanWrite)
                {

                    StreamWriter swriter = new StreamWriter(Debugstream);
                    swriter.WriteLineAsync(DateTime.Now.ToString() + " - " + text);
                }
                else
                {
                    Console.WriteLine("Debug file locked!/nDebug ERROR text: " + text);
                }
            }
            else
            {
                Console.WriteLine("Blank string passed to debug log");
            }
        }
    }
}