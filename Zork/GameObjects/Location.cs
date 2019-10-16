
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Location : GameObject
    {
        public int mapID;
        public Location northLoc;
        public Location southLoc;
        public Location eastLoc;
        public Location westLoc;
        public Location upLoc;
        public Location downLoc;
        private Inventory inventory = new Inventory();
        public List<NPC> bots = new List<NPC>();
        public List<GateBase> Gates = new List<GateBase>();

        public bool newLoc = true; //all locations are new at first, when a player enters the game will display the descriptive text if it is the first time the player has been here

        public Location(int mapID, string name,string description):base(name,"",description)
        {
            this.mapID = mapID;
            inventory.CanBePickedUp = false;
            Gates.Add(new KeyDoor(Directions.North, "RedDoor", "A big ominous red door", "Red"));
        }

        public void Do()
        {
            foreach (NPC bot in bots)
            {
                
                
                if(bot.Alive)
                {
                    Console.WriteLine("There is a " + bot.Name + ". " + bot.Description);
                    bot.Do();
                } else
                {
                    Console.WriteLine("There is a dead " + bot.Name + " here.");
                }
            }
        }


        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }
    }
}
