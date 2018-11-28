using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class GameScreen : Display
    {
        private Game currentGame = new Game();
        public override GameStates Run()
        {
            while(!currentGame.gameOver)
            {
                currentGame.Run();
                //return GameStates.MenuScreen;
            }

            return GameStates.MainMenu;
        }
    }
}
