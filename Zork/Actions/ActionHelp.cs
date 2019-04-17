using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zork
{
    class ActionHelp : ActionBase
    {
        public ActionHelp()
        {
        }

        public override void Do()
        {
            base.Do();
            Console.WriteLine(File.ReadAllText(@"../../Assets/Help.txt"));
        }
    }
}