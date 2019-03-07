using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class GameFactory
    {
        public Game BuildGame()
        {
            MapFactory mapBuilder = new MapFactory();
            List<Location> map = new List<Location>();
            
            map = mapBuilder.ReadMap();
            Player p1 = new Player("Timothy", "Tim", "A cool dude!", map[0]);

            Game g1 = new Game(map,p1);
            

            return g1;
        }
            

         //Game baseGame = new Game(//Add parameters here);
    }
}
