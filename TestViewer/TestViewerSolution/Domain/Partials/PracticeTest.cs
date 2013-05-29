using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    internal partial class PracticeTest : CandidateTest, IPracticeTest
    {
        public PracticeTest() { }
        public PracticeTest(Candidate candidate)
            : base(candidate)
        {
        }

        #region IPracticeTest Members
        
        public new IEnumerable<IAnswer> Answers
        {
            get { return Answers.AsEnumerable<IAnswer>(); }
        }

        #endregion

    }
}
