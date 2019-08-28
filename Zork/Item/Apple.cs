using System;

namespace Zork
{
    public class Apple : Item
    {
        public int hpToRestore;

        

        public Apple() : base("Apple", "", "It's a juicy red apple, looks healthy.")
        {

            Random a = new Random();
            hpToRestore = a.Next(3, 7);
            SingleUse = true;
        }

        public override void Use()
        {
            base.Use();
            Player player = Globals.game.p1;
            player.AddHealth(hpToRestore);
        }
    }
}