using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Answer : IAnswer
    {
        public Answer() { }
        public Answer(Guid choiceId) 
            : this()
        {
            ChoiceId = choiceId;
        }

        #region IAnswer Memmbers
        ICandidateTest IAnswer.CandidateTest
        {
            get { return CandidateTest; }
        }

        IChoice IAnswer.Choice
        {
            get { return Choice; }
        }
        #endregion
    }
}
