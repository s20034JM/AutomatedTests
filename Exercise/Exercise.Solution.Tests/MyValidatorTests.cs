using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class MyValidatorTests
    {
        private List<List<DateRange>> rangeList = new()
        {
            new List <DateRange>()
            {
                new DateRange(new DateTime(2020,1,1), new DateTime(2020,1,15)),
                new DateRange(new DateTime(2020,2,1), new DateTime(2020,2,15)),
            },
            new List <DateRange>()
            {
                new DateRange(new DateTime(2020,1,15), new DateTime(2020,1,25)),
            },
            new List <DateRange>()
            {
                new DateRange(new DateTime(2020,1,8), new DateTime(2020,1,25)),
            },
            new List <DateRange>()
            {
                new DateRange(new DateTime(2020,1,12), new DateTime(2020,1,14)),
            },
        };

        private static IEnumerable<object[]> GetRangeList()
        {
            yield return new object[]
            {
                new List <DateRange>()
                {
                    new DateRange(new DateTime(2020,1,1), new DateTime(2020,1,15)),
                    new DateRange(new DateTime(2020,2,1), new DateTime(2020,2,15)),
                }
            };
            yield return new object[]
            {
                new List <DateRange>()
                {
                    new DateRange(new DateTime(2020,1,15), new DateTime(2020,1,25)),
                }
            };
            yield return new object[]
            {
                new List <DateRange>()
                {
                    new DateRange(new DateTime(2020,1,8), new DateTime(2020,1,25)),
                }
            };
            yield return new object[]
            {
                new List <DateRange>()
                {
                    new DateRange(new DateTime(2020,1,12), new DateTime(2020,1,14)),
                }
            };
        }

        [Theory]
        //[MemberData(nameof(GetRangeList))]
        [ClassData(typeof(MyValidatorTestData))]
        public void ValidateOverlapping_ForOverlappingDateRanges_ReturnsFalse(List<DateRange> ranges)
        {
            //arrange
            DateRange input = new(new DateTime(2020, 1, 10), new DateTime(2020, 1, 20));
            Validator validator = new();

            //act
            var result = validator.ValidateOverlapping(ranges, input);

            //assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void ValidateOverlapping_ForNonOverlappingDateRanges_ReturnsTrue(int index)
        {
            //arrange
            var ranges = rangeList[index];
            DateRange input = new(new DateTime(2020, 1, 16), new DateTime(2020, 1, 20));
            Validator validator = new();

            //act
            var result = validator.ValidateOverlapping(ranges, input);

            //assert
            result.Should().BeTrue();
        }
    }
}
