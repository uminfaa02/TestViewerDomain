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

        public TestInstance FetchTestInstance(Guid id)
        {
            var result = TestInstances.FirstOrDefault(i => i.Id.Equals(id));
            if (result != null)
                return result;

            throw new RecordNotFoundException("Test Instance with ID '" + id + "' does not exist");
        }

        public Question FetchQuestion(Guid questionId)
        {
            return Questions.FirstOrDefault(q => q.Id.Equals(questionId));
        }

        public TestInstance CreateTestInstance(List<Candidate> candidates, Guid administratorId, bool isPractice, int timeLimit)
        {
            var testInstance = new TestInstance(administratorId, isPractice, timeLimit);

            foreach (var candidate in candidates)
            {
                testInstance.CreateCandidateTest((Candidate)candidate);
            }

            TestInstances.Add(testInstance);
            return testInstance;
        }


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
