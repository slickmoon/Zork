using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class ActionUse : ActionBase
    {
        string[] inputArray;
        Player currentPlayer;

        public void ActionUse(string[] inputArray, Player currentPlayer)
        {
            this.inputArray = inputArray;

            this.currentPlayer = currentPlayer;
        }

        public override void Do()
        {
            
        }
    }
}
