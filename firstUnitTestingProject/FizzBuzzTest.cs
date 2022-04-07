using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace firstUnitTestingProject
{
    public class FizzBuzzTest
    {
        [Fact]
        public void Start_ShouldReturnAListWithGivenRoundsList()
        {
            const int round = 100;
            var actual = FizzBuzz.Start(round);
            //Assert.Equal(round, actual.Count);
            actual.Count.Should().Be(round);
        }
        [Theory]
        [InlineData("Fizz", 3)]
        [InlineData("Buzz", 5)]
        [InlineData("FizzBuzz", 15)]
        public void Start_ShouldReturnAListWithProperValuesAtGivenElements(string expected, int element)
        {
            const int round = 100;
            var actual = FizzBuzz.Start(round);
            Assert.Equal(expected, actual[element]);
        }

        //[Fact]
        //public void Start_ShouldReturnAListWithProperBuzzValues()
        //{
        //    const int round = 100;
        //    var actual = FizzBuzz.Start(round);
        //    Assert.Equal("Buzz", actual[5]); 
        //}

        //[Fact]
        //public void Start_ShouldReturnAListWithProperFizzValues()
        //{
        //    const int round = 100;
        //    var actual = FizzBuzz.Start(round);
        //    Assert.Equal("Fizz", actual[3]);
        //}

        //[Fact]
        //public void Start_ShouldReturnAListWithProperFizzBuzzValues()
        //{
        //    const int round = 100;
        //    var actual = FizzBuzz.Start(round);
        //    Assert.Equal("FizzBuzz", actual[15]);
        //}
    }
}
