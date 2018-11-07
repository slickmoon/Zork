using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Location : GameObject
    {
        public Location northLoc;
        public Location southLoc;
        public Location eastLoc;
        public Location westLoc;
        public Location upLoc;
        public Location downLoc;

        public bool newLoc = true; //all locations are new at first, when a player enters the game will display the descriptive text if it is the first time the player has been here

        public Location(string name,string description):base(name,"",description)
        {
            
        }
    }
}
