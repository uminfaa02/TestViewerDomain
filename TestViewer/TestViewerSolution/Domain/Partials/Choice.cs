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
