using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestInstance : ITestInstance
    {
        //private CandidateTest candidateTest;

        public TestInstance(Guid administratorId, bool isPractice, int timeLimit)
            : this()
        {
            AdministeredBy = administratorId;
            IsPractice = isPractice;
            TimeLimit = timeLimit;
            

            //if (IsPractice)
            //    candidateTest = new PracticeTest();
            //else
            //    candidateTest = new ActualTest(); 
        }

        public CandidateTest CreateCandidateTest(Candidate candidate)
        {
            CandidateTest candidateTest;

            if (IsPractice)
                candidateTest = new PracticeTest(candidate);
            else
                candidateTest = new ActualTest(candidate); 

            //candidateTest.Candidate = candidate;
            CandidateTests.Add(candidateTest);
            return candidateTest;
        }

        //public ActualTest CreateActualTest(Candidate candidate)
        //{
        //    var test = new ActualTest(this,candidate);
        //    this.CandidateTests.Add(test);
        //    return test; 
        //}

        //public PracticeTest CreatePracticeTest(Candidate candidate)
        //{
        //    var test = new PracticeTest(this, candidate);
        //    this.CandidateTests.Add(test);
        //    return test;
        //}

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
