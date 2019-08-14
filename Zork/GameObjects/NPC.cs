using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class NPC : Player
  {
        /*private int hitPoints = 10;
        private int maxHitPoints;
        private Location currentLoc;
        private Inventory inventory;

        public Game CurrentGame;
        */
        /*
        public Player(string name, string shortname, string description, Location startLoc) : base(name, shortname, description)
        {
            maxHitPoints = hitPoints;
            currentLoc = startLoc;
            inventory = new Inventory();
        }
        */

        public bool Alive = true;
        public List<string> IdleDialogue = new List<string>();
        public List<string> HurtDialogue = new List<string>();


        public NPC(string name, string shortname, string description, Location startLoc, List<string> idleDialogue, List<string> hurtDialogue) : base(name, shortname, description, startLoc)
        {
            this.IdleDialogue = idleDialogue;
            this.HurtDialogue = hurtDialogue;
        }

        public virtual void Do()
        {

        }

        public override void AddHealth(int value)
        {
            hitPoints += value;
            if(hitPoints > maxHitPoints)
            {
                Console.WriteLine(Name + "'s health restored to full!");
                hitPoints = maxHitPoints;
            }
            Console.WriteLine(Name + " health is now: " + hitPoints);
        }

        public override void RemoveHealth(int value)
        {

            hitPoints -= value;
            if ((hitPoints-value) <= 0)
            {
                Console.WriteLine(Name + " has died");
                      
                Alive = false;

                //Drop items on the ground
                foreach(Item i in inventory.Items)
                {
                    Console.WriteLine(Name + " dropped a " + i.Name);
                    currentLoc.Inventory.AddItem(i);
                }
            }
            else
            {
                Random rand = new Random();
                string ouchLine = HurtDialogue[rand.Next(0, HurtDialogue.Count)];

                Console.WriteLine(Name + ": " + ouchLine);
                Console.WriteLine(Name + " health is now: " + hitPoints);
            }
        }
        //TODO: Add Look method to look at items


  }
}
