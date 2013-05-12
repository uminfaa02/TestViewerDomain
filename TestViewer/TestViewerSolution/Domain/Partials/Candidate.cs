using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Candidate : ICandidate
    {
        public Candidate(string studentNumber) : this()
        {
            if (string.IsNullOrWhiteSpace(studentNumber) || string.IsNullOrEmpty(studentNumber))
            {
                throw new BusinessRuleException("Student Number cannot be empty or white space.");
            }

            int result;
            bool isComposedOfNumber = int.TryParse(studentNumber, out result);

            if (isComposedOfNumber)
            {
                throw new BusinessRuleException("Student Number must only contain numbers.");
            }

            StudentNumber = studentNumber;
        }

        #region ICandidate Members
        IEnumerable<ICandidateTest> ICandidate.CandidateTests
        {
            get { return CandidateTests.AsEnumerable<ICandidateTest>(); }
        }
        #endregion
    }
}
