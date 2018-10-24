using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Credits : Display
    {
        public override GameStates Run()
        {
            Console.WriteLine("\n\nThank you for playing Zork!");
            Console.WriteLine("Zork is created by some wonderful game developers who are good at making games");
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey(); //reads any key and discards it

            return GameStates.MenuScreen;
        }
    }

}
