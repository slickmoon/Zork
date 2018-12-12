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
            currentGame.Run();
            return GameStates.MenuScreen;
        }
    }
}
