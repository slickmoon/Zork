using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Location : GameObject
    {
        private int xLoc;
        private int yLoc;
        private int zLoc;

        public bool newLoc = true; //all locations are new at first, when a player enters the game will display the descriptive text if it is the first time the player has been here

        public Location(string name, string description, int x, int y, int z) : base(name, "", description)
        {
            this.xLoc = x;
            this.yLoc = y;
            this.zLoc = z;
            grid[1][3][5];
        }
    }
}