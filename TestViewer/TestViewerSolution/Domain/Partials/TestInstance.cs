using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestInstance : ITestInstance
    {

        public TestInstance(Guid administratorId, bool isPractice, int timeLimit)
            : this()
        {
            AdministeredBy = administratorId;
            IsPractice = isPractice;
            TimeLimit = timeLimit;            
        }

        public CandidateTest FetchCandidateTest(Guid id)
        {
            var result = CandidateTests.FirstOrDefault(c => c.CandidateId.Equals(id));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Candidate Test with ID '" + id + "' does not exist");
        }

        public CandidateTest FetchCandidateTest(Candidate candidate)
        {
            return FetchCandidateTest(candidate.Id);
        }

        public CandidateTest CreateCandidateTest(Candidate candidate)
        {
            CandidateTest candidateTest;

            if (IsPractice)
                candidateTest = new PracticeTest(candidate);
            else
                candidateTest = new ActualTest(candidate); 

            CandidateTests.Add(candidateTest);
            return candidateTest;
        }

        public void CanCandidateTestBeDeleted(CandidateTest candidateTest)
        {
            // If State is Active or Closed, Can only be modified when state is Scheduled
            if (candidateTest.StateId != 1)
                throw new BusinessRuleException("CandidateTest with Student Number '" + candidateTest.Candidate.StudentNumber + "' " +
                    "cannot be removed from Test Instance because the candidate has already been taking or finished the exam.");
        }


        public void DeleteCandidateTest(Action action, CandidateTest candidateTest)
        {
            //TODO: (DONE) Check before deleting candidateTest
            CanCandidateTestBeDeleted(candidateTest);
            action();
        }

        public bool DeleteAllowed
        {
            get
            {
                return CandidateTests.Count < 1; 
            }
        }

        #region ITestInstance Members

        IAdministrator ITestInstance.Administrator
        {
            get { return Administrator; }
        }

        IEnumerable<ICandidateTest> ITestInstance.CandidateTests
        {
            get { return CandidateTests.AsEnumerable<ICandidateTest>(); }
        }

        ITestTemplate ITestInstance.TestTemplate
        {
            get { return TestTemplate; }
        }

        #endregion
      

    }
}
