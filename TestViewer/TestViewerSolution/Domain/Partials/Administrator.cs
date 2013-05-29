using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Administrator : IAdministrator
    {
        public TestInstance FetchTestInstance(Guid instanceId)
        {
           var result = TestInstances.FirstOrDefault(i => i.Id.Equals(instanceId));
           if (result != null)
               return result;

           throw new RecordNotFoundException("Test Instance with ID '" + instanceId + "' does not exist");
        }

        public TestInstance UpdateTestInstance(Guid instanceId, TestTemplate newTestTemplate, bool isPractice, int timeLimit)
        {
            var result = FetchTestInstance(instanceId);
            if (!result.IsScheduled)
            {
                throw new BusinessRuleException("Unable to update once Test Instance is Open.");
            }
            result.TestTemplate = newTestTemplate;
            result.IsPractice = isPractice;
            result.TimeLimit = timeLimit;
            return result;
        }

        public void DeleteTestInstance(Action action, TestInstance testInstance)
        {
            if (!testInstance.IsScheduled)
            {
                throw new BusinessRuleException("Unable to delete once Test Instance is Open.");
            }
            action();
        }

        public void OpenTestInstance(Guid instanceId)
        {
            var testInstance = FetchTestInstance(instanceId);
            testInstance.Open();
        }

        public void CloseTestInstance(Guid instanceId)
        {
            var testInstance = FetchTestInstance(instanceId);
            testInstance.Close();
        }


        #region IAdministrator Members
        IEnumerable<ITestInstance> IAdministrator.TestInstances
        {
            get { return TestInstances.AsEnumerable<ITestInstance>(); }
        }
        #endregion
    }
}
