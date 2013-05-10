using System;
namespace Domain
{
    public interface IAnswer
    {
        ICandidateTest CandidateTest { get;  }
        Guid CandidateTestId { get;  }
        IChoice Choice { get;  }
        Guid ChoiceId { get;  }
        DateTime DateTime { get;  }
        Guid Id { get;  }
    }
}
