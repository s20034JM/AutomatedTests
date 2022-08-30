using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class MyStringHelperTests
    {
        [Theory]
        [InlineData("ala ma kota", "kota ma ala")]
        [InlineData("to jest test", "test jest to")]
        public void ReverseWords_ForGivenString_ReturnsReversedSentence(string source, string expected)
        {
            //arrange
            string result;

            //act
            result = StringHelper.ReverseWords(source);

            //assert

            //Assert.Equal(expected, result);
            // /\ i \/ jest tym samym 
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("ALA")]
        [InlineData("ala")]
        [InlineData("kajak")]
        [InlineData("kobyłamamałybok")]
        public void IsPalindrome_ForCorrectInput_ReturnsTrue(string source)
        {
            //arrange
            bool result;

            //act
            result = StringHelper.IsPalindrome(source);

            //assert
            result.Should().Be(true);
        }

        [Theory]
        [InlineData("Ala")]
        [InlineData("ola")]
        [InlineData("dupa")]
        [InlineData("kobyła ma mały bok")]
        public void IsPalindrome_ForIncorrectInput_ReturnsFalse(string source)
        {
            //arrange
            bool result;

            //act
            result = StringHelper.IsPalindrome(source);

            //assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData("Ala", false)]
        [InlineData("ola", false)]
        [InlineData("dupa", false)]
        [InlineData("kobyła ma mały bok", false)]
        [InlineData("ALA", true)]
        [InlineData("ala", true)]
        [InlineData("kajak", true)]
        [InlineData("kobyłamamałybok", true)]
        public void IsPalindrome_ForInput_ReturnsBoolean(string source, bool expectedResult)
        {
            //arrange
            bool result;

            //act
            result = StringHelper.IsPalindrome(source);

            //assert
            result.Should().Be(expectedResult);
        }
    }
}
