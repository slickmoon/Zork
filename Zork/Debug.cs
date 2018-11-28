using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public static class Debug
    {
        public void Log(string text)
        {
            if (Text != null)
            {
                file = new System.IO.StreamWriter(@"../../Debug.txt");
                file.WriteLine("Log: " + Text);
            }
        }

        public void Error(string text)
        {
            if (Text != null)
            {
                file = new System.IO.StreamWriter(@"../../Debug.txt");
                file.WriteLine("Error: " + Text);
            }
        }
    }
}