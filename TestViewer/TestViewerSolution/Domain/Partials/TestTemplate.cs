using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestTemplate : ITestTemplate
    {

        public TestTemplate(string name) : this()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Test Template Name cannot be empty.");

            Name = name;
        }
        

        #region Questions
        
        public Question FetchQuestion(Guid questionId)
        {
            return Questions.FirstOrDefault(q => q.Id.Equals(questionId));
        }

        #endregion

        #region TestInstances

        public TestInstance FetchTestInstance(Guid id)
        {
            var result = TestInstances.FirstOrDefault(i => i.Id.Equals(id));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Test Instance with ID '" + id + "' does not exist");
        }

        public TestInstance CreateTestInstance(List<Candidate> candidates, Administrator administrator, bool isPractice, int timeLimit)
        {
            var testInstance = new TestInstance(administrator, isPractice, timeLimit);

            foreach (var candidate in candidates)
            {
                testInstance.CreateCandidateTest(candidate);
            }

            TestInstances.Add(testInstance);
            return testInstance;
        }

        public bool IsBeingUsedInTestInstance
        {
            get { return TestInstances.Count > 0; }
        }

        public bool IsUsedInAScheduledTestInstance
        {
            get
            {
                return TestInstances.FirstOrDefault(ti => ti.IsScheduled) != null ? true : false;
            }
        }

        public bool IsUsedInAClosedTestInstance
        {
            get 
            {
                return TestInstances.FirstOrDefault(ti => ti.IsClosed) != null ? true : false;
            }
        }

        #endregion

        #region Candidate Test

        public CandidateTest FetchCandidateTest(Guid instanceId, Guid candidateId)
        {
            return FetchTestInstance(instanceId).FetchCandidateTest(candidateId);
        }

        public CandidateTest CreateCandidateTest(Guid instanceId, Candidate candidate)
        {
            return FetchTestInstance(instanceId).CreateCandidateTest(candidate);
        }

        public void DeleteCandidateTest(Action action, Guid instanceId, CandidateTest candidateTest)
        {
            FetchTestInstance(instanceId).DeleteCandidateTest(action, candidateTest);
        }

        #endregion


        #region ITestTemplate Members

        IEnumerable<IQuestion> ITestTemplate.Questions
        {
            get { return Questions.AsEnumerable<IQuestion>(); }
        }

        IEnumerable<ITestInstance> ITestTemplate.TestInstances
        {
            get { return TestInstances.AsEnumerable<ITestInstance>(); }
        }

        ITestViewer ITestTemplate.TestViewer
        {
            get { return TestViewer; }
        }

        #endregion

    }
}
