using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class NPC : Player
    {
        private int hitPoints = 10;
        private int maxHitPoints;
        private Location currentLoc;
        private Inventory inventory;

        public Game CurrentGame;

        public Player(string name, string shortname, string description, Location startLoc) : base(name, shortname, description)
        {
            maxHitPoints = hitPoints;
            currentLoc = startLoc;
            inventory = new Inventory();
        }
        
        public void AddHealth(int value)
        {
            hitPoints += value;
            if(hitPoints > maxHitPoints)
            {
                Console.WriteLine("Health restored to full!");
                hitPoints = maxHitPoints;
            }
            Console.WriteLine("Your health is now: " + hitPoints);
        }

        public void RemoveHealth(int value)
        {

            hitPoints -= value;
            if ((hitPoints-value) <= 0)
            {
                Console.WriteLine("You are dead!");
                CurrentGame.GameOver = true;
            }
            else
            {
                Console.WriteLine("Your health is now: " + hitPoints);
            }
        }
        //TODO: Add Look method to look at items


    }


}
