using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IChoice
    {
        IEnumerable<IAnswer> Answers { get; }
        Guid Id { get; }
        bool IsCorrect { get; }
        IQuestion Question { get; }
        Guid QuestionId { get; }
        string Text { get; }
    }
}
