using System;

namespace Zork
{
    public class Pike : Weapon
    {
        
        public Pike() : base("Pike", "", "Rusty old pike")
        {

        }

        public override void Use(GameObject source, GameObject target)
        {

            NPC t;
            Player p;

            base.Use(source,target);

            try
            {
                t = target as NPC;
                p = source as Player;


                if (t != null && p != null)
                {
                    int s, finaldamage;

                    s = p.Strength;

                    finaldamage = Damage + s;

                    if (finaldamage < 0)
                        finaldamage = 0;

                    Console.WriteLine(t.Name + " has taken " + finaldamage.ToString() + " damage");

                    t.RemoveHealth(finaldamage);

                }
            }
            catch (Exception ex)
            {
                Debug.Error("Error unpacking and applying damage between source and target in attack \n" + ex.ToString());
            }


        }
    }
}