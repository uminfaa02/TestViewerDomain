using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ICandidate : IPerson
    {
        IEnumerable<ICandidateTest> CandidateTests { get;  }
        string StudentNumber { get; }
    }
}
