using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// An Interface that contains Candidate Test details
    /// </summary>
    public interface IPracticeTest : ICandidateTest
    {
        /// <summary>
        /// Collection of answers that is associated with the candidate test
        /// </summary>
        IEnumerable<IAnswer> Answers { get; }
    }
}
