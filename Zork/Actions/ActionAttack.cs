using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class ActionAttack : ActionBase
    {
        string[] inputArray;
        Player player;

        public ActionAttack(string[] inputArray, Player player)
        {
            this.inputArray = inputArray;
            this.player = player;
        }

        public override void Do()
        {
            base.Do(); //Do the base Do() function that ActionMove inherits from in ActionBase
            try
            {
                GameObject target = null;
                Item sourceItem = null;
                //hit goblin with sword

                if (inputArray.Length > 1)
                {
                    //find the target
                    foreach (NPC n in player.CurrentLoc.bots)
                    {
                        if(n.Name.Equals(inputArray[1]) && n.Alive)
                        {
                            target = n as GameObject;
                            break;
                        }
                    }

                    if (target != null)
                    {
                        //find the weapon
                        if(inputArray.Length > 3)
                        {

                            sourceItem = player.Inventory.GetItem(inputArray[3]);

                        } else 
                        {

                            Console.WriteLine("There isn't a " + inputArray[3] + " to attack with");

                        }

                        //i may have an item, and may have a target
                        //1. is source item null??
                        //2. get stats from player, item, and target
                        //3. do some maths to get our damage value
                        //4. actually take health away

                    } else 
                    {

                        Console.WriteLine("There isn't a " + inputArray[1] + " here to attack");
                    }



                } else {
                    Console.WriteLine("I don't know what to " + inputArray[0]);
                }

            }
            catch (Exception ex)
            {
                Debug.Log("Fix Your Game Epic!" + "\n" + ex.ToString());
            }
            //base.Do();
        }
    }
}