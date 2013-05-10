using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class TestTemplate : ITestTemplate
    {
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


        public TestInstance FetchTestInstance(Guid id)
        {
            return TestInstances.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Question FetchQuestion(Guid questionId)
        {
            return Questions.FirstOrDefault(q => q.Id.Equals(questionId));
        }

        public TestInstance CreateTestInstance(IEnumerable<ICandidate> candidates, Guid administratorId, bool isPractice, int timeLimit)
        {
            var testInstance = new TestInstance(administratorId, isPractice, timeLimit);

            foreach (var candidate in candidates)
            {
                testInstance.CreateCandidateTest((Candidate)candidate);
            }

            TestInstances.Add(testInstance);
            return testInstance;
        }

        
    }
}
