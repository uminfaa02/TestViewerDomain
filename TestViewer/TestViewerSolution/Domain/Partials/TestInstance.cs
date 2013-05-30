using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestInstance : ITestInstance
    {

        public TestInstance(Administrator administrator, bool isPractice, int timeLimit)
            : this()
        {
            Administrator = administrator;
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

            try
            {
                FetchCandidateTest(candidate);
                throw new BusinessRuleException("Candidate already exists in the Test Instance");
            }
            catch (RecordNotFoundException)
            {
                if (IsPractice)
                    candidateTest = new PracticeTest(candidate);
                else
                    candidateTest = new ActualTest(candidate);

                CandidateTests.Add(candidateTest);
                return candidateTest;
            }
        }

        public void Open()
        {
            foreach (var candidateTest in CandidateTests)
            {
                candidateTest.Activate();
            }
        }

        public void Close()
        {
            foreach (var candidateTest in CandidateTests)
            {
                candidateTest.Close();
            }
        }

        public void DeleteCandidateTest(Action action, CandidateTest candidateTest)
        {
            if (!IsOpen)
            {
                throw new BusinessRuleException("Unable to delete Candidate Test once the Test Instance has been set to Open");
            }
            action();
        }

        public DateTime DateCreated
        {
            get { return CandidateTests.Select(ct => ct.DateTime).FirstOrDefault(); }
        }

        public bool IsOpen
        {
            get { return CandidateTests.FirstOrDefault(ct => ct.StateId.Equals((int)ExamState.Scheduled)) != null ? true : false; }
        }

        public bool IsClosed
        {
            get { return CandidateTests.FirstOrDefault(ct => ct.StateId.Equals((int)ExamState.Closed)) != null ? true : false; }
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
