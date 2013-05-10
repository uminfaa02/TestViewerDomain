using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Administrator : IAdministrator
    {
        #region IAdministrator Members
        IEnumerable<ITestInstance> IAdministrator.TestInstances
        {
            get { return TestInstances.AsEnumerable<ITestInstance>(); }
        }
        #endregion
    }
}
