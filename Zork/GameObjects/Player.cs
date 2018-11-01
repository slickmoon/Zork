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
        

        public Player(string name, string shortname, string description) : base(name, shortname, description)
        {
               
        }
        
    }


}
