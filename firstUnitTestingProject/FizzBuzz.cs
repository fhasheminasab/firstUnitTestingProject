using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstUnitTestingProject
{
    public class FizzBuzz
    {
        public static List<string> Start(int rounds)
        {
            var result = new List<string>();
            for (var i = 0; i < rounds; i++)
            {   //the game starts from 0
                var output = i % 3 == 0 ? "Fizz" : "";
                output += i % 5 == 0 ? "Buzz" : "";
                output += output == string.Empty ? i.ToString() : string.Empty;
                result.Add(output);
            }
            return result;

        }
    }
}
