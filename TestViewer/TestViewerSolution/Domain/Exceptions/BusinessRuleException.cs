using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// An Exception class for Business Rule
    /// </summary>
    public class BusinessRuleException : Exception
    {
        /// <summary>
        /// Accepts the message the object will throw.
        /// </summary>
        /// <param name="message">The exception message</param>
        public BusinessRuleException(string message) : base(message) 
        {
            Debug.Write(message);
        }
    }
}
