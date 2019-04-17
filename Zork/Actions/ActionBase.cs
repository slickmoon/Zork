using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class ActionBase
    {
        public virtual void Do()
        {
            Console.Clear(); //When every action runs, clear the screen first
        }
        
    }
}
