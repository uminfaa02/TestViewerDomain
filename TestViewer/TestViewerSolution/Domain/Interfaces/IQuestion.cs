using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An interface that contains question details
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        /// Candidate Status (True or False)
        /// </summary>
        bool Active { get;  }

        /// <summary>
        /// Collection of choices contained in the question
        /// </summary>
        IEnumerable<IChoice> Choices { get; }

        /// <summary>
        /// Question ID
        /// </summary>
        Guid Id { get;  }

        /// <summary>
        /// QuestionBank where it belongs to
        /// </summary>
        IQuestionBank QuestionBank { get;  }

        /// <summary>
        /// Question Bank ID
        /// </summary>
        Guid QuestionBankId { get;  }

        /// <summary>
        /// Collection of Test Templates associated with the question
        /// </summary>
        IEnumerable<ITestTemplate> TestTemplates { get; }

        /// <summary>
        /// Question text
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Question is valid or not
        /// </summary>
        bool Isvalid { get; }

        /// <summary>
        /// Question is being used in Test Instance
        /// </summary>
        bool IsBeingUsedInTestInstance { get; }

        /// <summary>
        /// Question is being used in Test Template
        /// </summary>
        bool IsBeingUsedInTestTemplate { get; }
    }
}
