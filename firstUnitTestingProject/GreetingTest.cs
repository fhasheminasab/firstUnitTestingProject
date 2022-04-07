using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace firstUnitTestingProject
{
    public class GreetingTest
    {
        [Fact]
        public void Greeting_ShouldGetName()
        {
            // Given
            var name = "mamad";
            var greet = new Greeting(name);
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            greetingResult.Should().Be("Hello " + name + ".");
        }

        [Fact]
        public void Greeting_ShouldHandleNullName()
        {
            // Given
            var greet = new Greeting();
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            greetingResult.Should().Be("Hello my friend!");
        }

        [Fact]
        public void Greeting_ShouldShoutIfTheNameIsAllCaps()
        {
            // Given
            var name = "MAMAD";
            var greet = new Greeting(name);
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            greetingResult.Should().Be("HELLO " + name + "!!");
        }
        [Fact]
        public void Greeting_ShouldBeAbleToGetTwoNames()
        {
            // Given
            List<string> names;
            names = new List<string>();
            names.Add("Ali");
            names.Add("mamad");
            var greet = new Greeting(names);
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            string greetingResultExpectation = "Hello ";
            for (int i = 0; i < names.Count - 1; i++)
            {
                greetingResultExpectation += names[i];
                greetingResultExpectation += " and ";
            }
            greetingResultExpectation += names[names.Count - 1];
            greetingResultExpectation += ".";

            greetingResult.Should().Be(greetingResultExpectation);
        }

        [Fact]
        public void Greeting_ShouldBeAbleToGetMoreThanOneName()
        {
            // Given
            List<string> names;
            names = new List<string>();
            names.Add("Ali");
            names.Add("mamad");
            names.Add("Zari");
            var greet = new Greeting(names);
            //greet.withListOfNames(names);
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            string greetingResultExpectation = GenerateExpectation_Greeting_ShouldBeAbleToGetMoreThanOneName(names);

            greetingResult.Should().Be(greetingResultExpectation);
        }

        private static string GenerateExpectation_Greeting_ShouldBeAbleToGetMoreThanOneName(List<string> names)
        {
            string greetingResultExpectation = "Hello ";

            for (int i = 0; i < names.Count - 1; i++)
            {
                greetingResultExpectation += names[i];
                if (i < names.Count - 2)
                    greetingResultExpectation += ", ";
                else
                    greetingResultExpectation += " and ";
            }
            greetingResultExpectation += names[names.Count - 1];
            greetingResultExpectation += ".";
            return greetingResultExpectation;
        }

        [Fact]
        public void Greeting_ShouldBeAbleToShoutMoreThanOneName()
        {
            // Given
            List<string> names = new List<string>();
            names.Add("ALI");
            names.Add("Ali");
            names.Add("MAMAD");
            names.Add("Zari");
            var greet = new Greeting(names);
            //greet.withListOfNames(names);
            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            string greetingResultExpectation = GenerateExpectation_Greeting_ShouldBeAbleToShoutMoreThanOneName(names);
            //string greetingResultExpectation = "Hello Ali and Zari. AND HELLO ALI and MAMAD!!";
            greetingResult.Should().Be(greetingResultExpectation);
        }

        private static string GenerateExpectation_Greeting_ShouldBeAbleToShoutMoreThanOneName(List<string> names)
        {
            string greetingResultExpectation = "";
            List<int> _lowerCaseNames = new List<int>();
            List<int> _upperCaseNames = new List<int>();
            for (int a = 0; a < names.Count; a++)
            {
                if (names[a] == names[a].ToUpper()) _upperCaseNames.Add(a);
                else _lowerCaseNames.Add(a);
            }
            if (_lowerCaseNames.Count > 0)
            {
                greetingResultExpectation += "Hello ";
                for (int i = 0; i < _lowerCaseNames.Count - 1; i++)
                {
                    greetingResultExpectation += names[_lowerCaseNames[i]];
                    if (i < _lowerCaseNames.Count - 2)
                        greetingResultExpectation += ", ";
                    else
                        greetingResultExpectation += " and ";
                }
                greetingResultExpectation += names[_lowerCaseNames[_lowerCaseNames.Count - 1]];
                greetingResultExpectation += ".";
            }
            if (_upperCaseNames.Count > 0)
            {
                greetingResultExpectation += " AND HELLO ";
                for (int i = 0; i < _upperCaseNames.Count - 1; i++)
                {
                    greetingResultExpectation += names[_upperCaseNames[i]];
                    if (i < _upperCaseNames.Count - 2)
                        greetingResultExpectation += ", ";
                    else
                        greetingResultExpectation += " and ";
                }
                greetingResultExpectation += names[_upperCaseNames[_upperCaseNames.Count - 1]];
                greetingResultExpectation += "!!";
            }
            return greetingResultExpectation;
        }
        [Fact]
        public void Greeting_ShouldBeAbleToChopInputNamesToGetMoreNames()
        {
            // Given 
            List<string> names = new List<string>();

            names.Add("ALI");
            names.Add(" mamad   ,  ali  ,zari");
            names.Add("MAMAD");
            var greet = new Greeting(names);

            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            List<string> names2 = GenerateExpectation_Greeting_ShouldBeAbleToChopInputNamesToGetMoreNames(names);

            greetingResult.Should().Be(GenerateExpectation_Greeting_ShouldBeAbleToShoutMoreThanOneName(names2));

        }

        private static List<string> GenerateExpectation_Greeting_ShouldBeAbleToChopInputNamesToGetMoreNames(List<string> names, bool escape = false)
        {

            List<string> names2 = new List<string>();
            string separator = ",";
            int count = 100;
            foreach (string name in names)
            {
                if (escape && name.Contains("\""))
                {
                    names2.Add(name);
                    continue;
                }

                List<string> splitedNames = name.Split(separator, count, StringSplitOptions.TrimEntries).ToList();
                foreach (string name2 in splitedNames)
                {
                    names2.Add(name2);
                }
            }

            return names2;
        }

        [Fact]
        public void Greeting_ShouldBeAbleToChopInputNamesToGetMoreNames_butCanEscapeSome()
        {
            // Given 
            string[] namesArray = new string[] { "Bob", "\"Charlie, Dianne\"" };
            List<string> names = new List<string>();
            names = namesArray.ToList();
            var greet = new Greeting(names);

            string greetingResult;

            // When
            greetingResult = greet.GreetThem();

            // Then
            bool escape = true;
            List<string> names2 = GenerateExpectation_Greeting_ShouldBeAbleToChopInputNamesToGetMoreNames(names, escape);

            //greetingResult.Should().Be(GenerateExpectation_Greeting_ShouldBeAbleToShoutMoreThanOneName(names2));
            greetingResult.Should().Be("Hello Bob and Charlie, Dianne.");

        }

    }
}
