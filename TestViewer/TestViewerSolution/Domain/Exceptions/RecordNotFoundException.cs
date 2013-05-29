using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// An Exception class that throws when a particular record is not found
    /// </summary>
    public class RecordNotFoundException : Exception
    {
        /// <summary>
        /// Accepts the message the object will throw.
        /// </summary>
        /// <param name="message">The exception message</param>
        public RecordNotFoundException(string message) : base(message)
        {
            Debug.Write(message);
        }
        
    }
}
