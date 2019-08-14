using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Goblin : NPC
    {
        private bool agitated = false;


        public Goblin(Location startLoc) : base("A big green goblin", "Goblin", "He looks scary", startLoc, ["grunt","muhhh","grr"], ["ouch","ooft","grr"])
	    {
        }
	    

        public void Do()
        {
            if(agitated)
            {
                Console.WriteLine("The goblin swings his sword at you.");
                Globals.game.p1.RemoveHealth(5);

            } else
            {

                Console.WriteLine(idleDialogue[Random.Next(0, IdleDialogue.Count)]);
            }
            
            agitated = true;
        }
    }
}

