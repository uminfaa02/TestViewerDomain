using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Particular candidate's exam state
    /// </summary>
    public enum ExamState
    {
        /// <summary>
        /// The Exam is created but not open for access by the candidates
        /// </summary>
        Scheduled = 1,
        /// <summary>
        /// The Exam is open for access by the candidates
        /// </summary>
        Active = 2,
        /// <summary>
        /// The Candidate started answering exam questions
        /// </summary>
        InProgress = 3,
        /// <summary>
        /// The Exam is closed and no longer be available for access by the candidates
        /// </summary>
        Closed = 4
    }
}
