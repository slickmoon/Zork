using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class KeyDoor : GateBase
    {

        public bool IsActive = true;
        public string UnlockingPhrase = "";
        private GoldKey key;

        public KeyDoor(Directions d, string name, string description, string unlockingphrase) : base(d, name, description)
        {
            this.UnlockingPhrase = unlockingphrase; 
        }

        public void Do(GameObject inputItem)
        {
            try{
                key = inputItem as GoldKey;

                if (key != null && key.Phrase.Equals(UnlockingPhrase))
                {
                    Console.WriteLine("The " + key.Name + " slots perfectly into the lock and the " + this.Name +  " opens, revealing another place");
                    IsActive = false;
                }
                else{
                    Console.WriteLine("That item didn't work in the door");
                }
            }catch{
                Console.WriteLine("That item didn't work in the door");
            }
        }


    }
}
