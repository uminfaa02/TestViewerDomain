using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IQuestionBank
    {
        IEnumerable<IQuestion> Questions { get; }
        ITestViewer TestViewer { get;  }
        Guid TestViewerId { get;  }
    }
}
