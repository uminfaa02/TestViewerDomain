using System;
using System.Collections.Generic;
namespace Domain
{
    /// <summary>
    /// An interface that contains a single choice details
    /// </summary>
    public interface IChoice
    {
        /// <summary>
        /// Collection of answers associated with the choice
        /// </summary>
        IEnumerable<IAnswer> Answers { get; }

        /// <summary>
        /// Choice ID
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Returns if the choice is the correct answer or not
        /// </summary>
        bool IsCorrect { get; }

        /// <summary>
        /// Question where it is associated with
        /// </summary>
        IQuestion Question { get; }

        /// <summary>
        /// Question ID
        /// </summary>
        Guid QuestionId { get; }

        /// <summary>
        /// Choice text
        /// </summary>
        string Text { get; }
    }
}
