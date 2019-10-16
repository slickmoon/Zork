using System;

namespace Zork
{
    public class GoldKey : Item
    {

        public string Phrase = "";
        public GoldKey(string phrase) : base("GoldenKey", "", "It's a pretty golden key that sparkles.")
        {
            SingleUse = true;
            this.Phrase = phrase;
        }

        public override void Use()
        {
            base.Use();
        }
    }
}