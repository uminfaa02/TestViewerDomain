using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Choice : IChoice
    {

        public Choice(string text, bool isCorrect) : this()
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                throw new BusinessRuleException("Choice cannot be empty or white space");

            Text = text;
            IsCorrect = isCorrect;
        }

        #region IChoice Members

        IEnumerable<IAnswer> IChoice.Answers
        {
            get { return Answers.AsEnumerable<IAnswer>(); }
        }

        IQuestion IChoice.Question
        {
            get { return Question; }
        }

        #endregion

    }
}
