using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
  public class GameScreen : Display
    {
        private Game currentGame;

        public GameScreen()
        {
            currentGame = GameFactory.Instance.BuildGame();
        }
        public override GameStates Run()
        {
            currentGame.Run();
            return GameStates.MenuScreen;
        }
    }
}
