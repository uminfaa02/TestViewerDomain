using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecordAlreadyExistsException : Exception
    {
        public RecordAlreadyExistsException(string message) : base(message) { }
    }
}
