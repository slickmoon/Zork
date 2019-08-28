using System;

namespace Zork
{
    public class Sword : Weapon
    {
        
        public Sword() : base("Sword", "", "Rusty old sword")
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
                    int s, d, finaldamage;

                    s = p.Strength;
                    d = t.Defence;

                    finaldamage = Damage + s - d;

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