using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [Author("Viktor")]
    public class TestClass
    {
        [Author("Gogicha")]
        [Obsolete]
        public void GogiMethod()
        {

        }

        [Author("Dimitrichko")]
        public void ALotOfWork()
        {

        }
    }
}
