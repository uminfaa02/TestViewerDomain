using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// An Exception class that throws when the system needs confirmation to proceed with an operation
    /// </summary>
    public class WarningBeforeProceedException : Exception
    {
        /// <summary>
        /// Accepts the message the object will throw.
        /// </summary>
        /// <param name="message">The exception message</param>
        public WarningBeforeProceedException(string message) : base(message)
        {
            Debug.Write(message);
        }
    }
}
