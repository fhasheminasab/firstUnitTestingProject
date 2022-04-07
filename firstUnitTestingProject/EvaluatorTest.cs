using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace firstUnitTestingProject
{
    public class EvaluatorTest
    {
        [Fact]
        public void Evaluate_Should_return_Event()
        {
            const int input = 6;
            var evaluator = new Evaluator();
            var actual = evaluator.Evaluate(input);
            Assert.Equal("even", actual);
        }

        [Fact]
        public void Evaluate_Should_return_Odd()
        {
            const int input = 5;
            var evaluator = new Evaluator();
            var actual = evaluator.Evaluate(input);
            Assert.Equal("odd", actual);
        }
    }
}
