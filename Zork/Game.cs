using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Game
    {
        private Player p1;
        private List<Location> locations;

        public Game()
        {
            locations.Add(new Location());
            locations.Add(new Location());
            locations.Add(new Location());

            locations.Add(new Location("Clearing", "", 0, 1, 0));
            locations.Add(new Location("Front of House", "", 0, 2, 0));
            locations.Add(new Location("House Hall", "", 0, 3, 0));
            locations.Add(new Location("House Kitchen", "", 0, 4, 0));
            locations.Add(new Location("House Laundry", "", 0, 5, 0));
            p1 = new Player("Me", "Me", "It's you, the hero of our story", locations[0]); //always set to start location
        }

        public void Run()
        {
            Console.WriteLine(p1.CurrentLoc.name);

        }

        private void LinkLocations()
        {

        }
        //Location List
        //Monsters
        //Items list
    }
}