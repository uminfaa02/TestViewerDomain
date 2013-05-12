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
           var result = TestInstances.Where(i => i.Id.Equals(instanceId)).First();
           if (result != null)
               return result;

           throw new RecordNotFoundException("Test Instance with ID '" + instanceId + "' does not exist");
        }

        #region IAdministrator Members
        IEnumerable<ITestInstance> IAdministrator.TestInstances
        {
            get { return TestInstances.AsEnumerable<ITestInstance>(); }
        }
        #endregion
    }
}
