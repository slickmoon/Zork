
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class GateBase : GameObject
    {
       
        public bool IsActive = true;
        public Directions direction;

        public GateBase(Directions d, string name, string description) : base(name, "", description)
        {
            direction = d;
        }

        public virtual void Do(GameObject inputItem)
        {

        }


    }
}
