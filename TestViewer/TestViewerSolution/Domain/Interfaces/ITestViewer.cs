using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ITestViewer
    {  
        IEnumerable<ICandidate> Candidates { get; }
        string DevelopedBy { get;  }
        Guid Id { get; }
        IEnumerable<IPerson> People { get;  }
        IQuestionBank QuestionBank { get;  }
        IEnumerable<IQuestion> Questions { get; }
        IEnumerable<ITestTemplate> TestTemplates { get;  }
    }
}
