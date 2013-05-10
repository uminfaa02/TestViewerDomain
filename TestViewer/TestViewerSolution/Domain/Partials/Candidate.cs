using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Candidate : ICandidate
    {

        #region ICandidate Members
        IEnumerable<ICandidateTest> ICandidate.CandidateTests
        {
            get { return CandidateTests.AsEnumerable<ICandidateTest>(); }
        }
        #endregion
    }
}
