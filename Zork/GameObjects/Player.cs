using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Player : GameObject
    {
        int hitPoints;
        Location currentLoc;
        

        public Player(string name, string shortname, string description, Location startLoc) : base(name, shortname, description)
        {
            currentLoc = startLoc;      
        }
        
    }


}
