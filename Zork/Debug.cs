using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public static class Debug
    {
        public static void Log(string text)
        {
            if (text != null)
            {
                file = new System.IO.StreamWriter(@"../../Debug.txt");
                file.WriteLine("Log: " + Text);
            }
        }

        public static void Error(string text)
        {
            if (text != null)
            {
                file = new System.IO.StreamWriter(@"../../Debug.txt");
                file.WriteLine("Error: " + Text);
            }
        }
    }
}