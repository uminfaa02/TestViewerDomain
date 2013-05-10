using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Person : IPerson
    {
        #region IPerson Members

        ITestViewer IPerson.TestViewer
        {
            get {  return TestViewer; }
        }

        bool IPerson.Active
        {
            get { return Active; }
        }

        #endregion
    }
}
