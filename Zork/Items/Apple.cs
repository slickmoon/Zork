using System;

namespace Zork
{
    class Apple : Item
    {
        public int hpToRestore;

        public Apple() : base(name, shortname, description)
        {
            this.name = "Apple";
            this.shortname = "";
            this.description = "It's a juicy red apple, looks healthy.";

            Random a = new Random();
            hpToRestore = a.Next(3, 7);
            singleUse = true;
        }

        public override void Use(Player player)
        {
            player.AddHealth(hpToRestore);
        }
    }
}