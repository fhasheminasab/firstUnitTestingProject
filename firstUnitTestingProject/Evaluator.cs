using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstUnitTestingProject
{
    public class Evaluator
    {
        public string Evaluate(int value)
        {
            return value % 2 == 0 ? "even" : "odd";
        }
    }
}
