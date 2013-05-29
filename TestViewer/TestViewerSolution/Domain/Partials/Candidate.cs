using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Candidate : ICandidate
    {
        public Candidate(string studentNumber) : this()
        {
            if (string.IsNullOrWhiteSpace(studentNumber) || string.IsNullOrEmpty(studentNumber) || studentNumber.Contains(' '))
            {
                throw new BusinessRuleException("Student Number cannot be empty or contain white space.");
            }

            //Number Check with RegEx
            //bool isComposedOfNumber = Regex.IsMatch(studentNumber, @"^\d+$");

            // Rank 60.10: I used "out" to catch the result that has been converted into datatype long as I need
            // to determine whether the student number is a valid number or not.
            long studentNumberResult;
            bool isComposedOfNumber = Int64.TryParse(studentNumber, out studentNumberResult);
            if (!isComposedOfNumber)
            {
                throw new BusinessRuleException("Student Number must only contain numbers.");
            }

            StudentNumber = studentNumber;
        }

        public bool HadTakenExam
        {
            get { return CandidateTests.Count > 0; }
        }

        public bool HasPendingExams
        {
            get { return PendingExams.Count > 0; }
        }

        public bool HasInProgressExams
        {
            get { return InProgressExams.Count > 0; }
        }

        public List<CandidateTest> PendingExams
        {
            get { return CandidateTests.Where(ct => ct.StateId.Equals((int)ExamState.Active)).ToList(); }
        }

        public List<CandidateTest> InProgressExams
        {
            get { return CandidateTests.Where(ct => ct.StateId.Equals((int)ExamState.InProgress)).ToList(); }
        }


        #region Candidate Test

        public CandidateTest FetchCandidateTest(Guid candidateTestId)
        {
            return CandidateTests.FirstOrDefault(ct => ct.Id.Equals(candidateTestId));
        }

        public CandidateTest GetExamByTokenId(int tokenId)
        {
            return PendingExams.FirstOrDefault(e => e.TokenId.Equals(tokenId));
        }

        public void BeginExam(Guid candidateTestId)
        {
            var exam = FetchCandidateTest(candidateTestId);
            exam.Start();
        }

        public void SaveAnswer(Guid candidateTestId, Guid choiceId)
        {
            var exam = FetchCandidateTest(candidateTestId);
            exam.SaveAnswer(choiceId);
        }

        public void FinishExam(Guid candidateTestId)
        {
            var exam = FetchCandidateTest(candidateTestId);
            exam.Close();
        }

        #endregion


        #region ICandidate Members
        IEnumerable<ICandidateTest> ICandidate.CandidateTests
        {
            get { return CandidateTests.AsEnumerable<ICandidateTest>(); }
        }

        IEnumerable<ICandidateTest> ICandidate.PendingExams
        {
            get { return PendingExams.AsEnumerable<ICandidateTest>(); }
        }

        IEnumerable<ICandidateTest> ICandidate.InProgressExams
        {
            get { return InProgressExams.AsEnumerable<ICandidateTest>(); }
        }
        #endregion
    }
}
