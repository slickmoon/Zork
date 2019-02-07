using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    class MapException : Exception
    {
        public MapException()
        {
        }

        public MapException(string message)
            : base(message)
        {
        }

        public MapException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class DuplicateMapIDException : Exception
    {
        public DuplicateMapIDException()
        {
        }

        public DuplicateMapIDException(string message)
            : base(message)
        {
        }

        public DuplicateMapIDException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
