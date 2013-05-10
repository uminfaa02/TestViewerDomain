using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ICandidateTest
    {
        IEnumerable<IAnswer> Answers { get;}
        ICandidate Candidate { get; }
        Guid CandidateId { get;   }
        DateTime DateTime { get;   }
        Guid Id { get;   }
        int StateId { get;   }
        ITestInstance TestInstance { get;   }
        Guid TestInstanceId { get;   }
    }
}
