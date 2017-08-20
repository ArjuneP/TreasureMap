using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Exceptions
{
    class InputFileException : Exception
    {
        public InputFileException()
        {
        }

        public InputFileException(string message)
        : base(message)
        {
        }

        public InputFileException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
