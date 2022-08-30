using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class MyListHelperTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] {1,3,5})]
        [InlineData(new int[] { 0, 22, 13, 0, 0, 1 }, new int[] {13,1})]
        [InlineData(new int[] { 0, 22, 0, 0 }, new int[] { })]

        public void FilterOddNumber_ForGivenArray_ReturnsOddList(int[] nonFilteredNumbersArray, int[] expectedNumbersArray)
        {
            //arrange
            List<int> nonFilteredNumbers = nonFilteredNumbersArray.ToList();
            List<int> expectedNumbers = expectedNumbersArray.ToList();
            List<int> filteringResult;

            //act
            filteringResult = ListHelper.FilterOddNumber(nonFilteredNumbers);

            //assert
            //Assert.Equal(expectedNumbers, filteringResult);
            //to samo 
            filteringResult.Should().Equal(expectedNumbers);
        }
    }
}
