using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class WarningBeforeProceedException : Exception
    {
        public WarningBeforeProceedException(string message) : base(message) { }
    }
}
