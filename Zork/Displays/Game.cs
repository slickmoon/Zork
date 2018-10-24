using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{ 
    class Game: Display
    {
        public override GameStates Run()
        {
            return GameStates.MenuScreen;
        }
    }
}
