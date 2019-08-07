using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    sealed class GameFactory
    {
        private static readonly GameFactory instance = new GameFactory();

        private GameFactory()
        {

        }

        public Game BuildGame()
        {
            
            List<Location> map = new List<Location>();
            
            map = MapFactory.Instance.ReadMap();
            Player p1 = new Player("Timothy", "Tim", "A cool dude!", map[0]);

            Game g1 = new Game(map,p1);
            
            Globals.game = g1;

            return g1;
        }

        public static GameFactory Instance
        {
            get
            {
                return instance;
            }
        }

        //Game baseGame = new Game(//Add parameters here);
    }
}
