using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IQuestion
    {
        bool Active { get;  }
        IEnumerable<IChoice> Choices { get; }
        Guid Id { get;  }
        IQuestionBank QuestionBank { get;  }
        Guid QuestionBankId { get;  }
        IEnumerable<ITestTemplate> TestTemplates { get; }
        string Text { get; }
    }
}
