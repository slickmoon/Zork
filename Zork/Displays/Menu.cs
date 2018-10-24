using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class Menu : Display
    {
        public override GameStates Run()
        { 
            int option = 0;
            bool goodInput = false;


            //ascii art menu
            Console.WriteLine("                        ___                                       ___            \n                     (   )                                     (   )            \n ___  ___  ___ .--.  | |  .--.    .--.  ___ .-. .-.    .--.    | |_     .--.   \n(   )(   )(   )    \\ | | /    \\  /    \\(   )   '   \\  /    \\  (   __)  /    \\  \n | |  | |  | |  .-. ;| ||  .-. ;|  .-. ;|  .-.  .-. ;|  .-. ;  | |    |  .-. ; \n | |  | |  | |  | | || ||  |(___) |  | || |  | |  | ||  | | |  | | ___| |  | | \n | |  | |  | |  |/  || ||  |    | |  | || |  | |  | ||  |/  |  | |(   ) |  | | \n | |  | |  | |  ' _.'| ||  | ___| |  | || |  | |  | ||  ' _.'  | | | || |  | | \n | |  ; '  | |  .'.-.| ||  '(   ) '  | || |  | |  | ||  .'.-.  | ' | || '  | | \n ' `-'   `-' '  `-' /| |'  `-' |'  `-' /| |  | |  | |'  `-' /  ' `-' ;'  `-' / \n  '.__.'.__.' `.__.'(___)`.__,'  `.__.'(___)(___)(___)`.__.'    `.__.  `.__.' \n     _____  ______          ____     ___________       ______   _______   \n    /    / /     /|     ____\\_  \\__  \\          \\     |\\     \\  \\      \\  \n   |     |/     / |    /     /     \\  \\    /\\    \\     \\\\     \\  |     /| \n   |\\____\\\\    / /    /     /\\      |  |   \\_\\    |     \\|     |/     //  \n    \\|___|/   / /    |     |  |     |  |      ___/       |     |_____//   \n       /     /_/____ |     |  |     |  |      \\  ____    |     |\\     \\   \n      /     /\\      ||     | /     /| /     /\\ \\/    \\  /     /|\\|     |  \n     /_____/ /_____/||\\     \\_____/ |/_____/ |\\______| /_____/ |/_____/|  \n     |    |/|     | || \\_____\\   | / |     | | |     ||     | / |    | |  \n     |____| |_____|/  \\ |    |___|/  |_____|/ \\|_____||_____|/  |____|/   \n                       \\|____|                \n");
            Console.WriteLine("\n--------------------------\nMain Menu\n--------------------------\n");

            while(!goodInput) //retry until we get a valid input
            {
                Console.WriteLine("1. Start\n2. Credits\n3. Exit");
                Console.Write("Please select an option: ");
                goodInput = int.TryParse(Console.ReadLine(), out option); //see if we can convert to an int

                switch (option)
                {
                    case 1:
                        return GameStates.MainGame;
                    case 2:
                        return GameStates.CreditsScreen;
                    case 3:
                        return GameStates.Exit;
                    default: //not an int or out of range
                        goodInput = false;
                        Console.WriteLine("That is not an option, please try again.\n"); 
                        break;
                }
            }

            //We should not reach here, but if we do, we will exit the game
            return GameStates.Exit;
        }
    }
}
