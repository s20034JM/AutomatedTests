using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;

namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTests
    {
        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
        private const string NORMAL_SUMMARY = "Your weight is normal, keep it up";
        private readonly ITestOutputHelper outputHelper;

        public BmiCalculatorFacadeTests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(BmiClassification.Overweight,OVERWEIGHT_SUMMARY)]
        [InlineData(BmiClassification.Normal,NORMAL_SUMMARY)]
        public void GetResult_ForValidInputs_ReturnsCorrectSummary(BmiClassification bmiClassification, string expectedResult)
        {
            //arrange
            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
            bmiDeterminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);

            BmiCalculatorFacade bmiCalculatorFacade = new(UnitSystem.Metric, bmiDeterminatorMock.Object);


            //act
            BmiResult result = bmiCalculatorFacade.GetResult(1,1);

            outputHelper.WriteLine($"For classification: {bmiClassification} the result is: {result.Summary}");

            //assert
            //Assert.Equal(24.93, result.Bmi);
            //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            //Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);
            //result.Bmi.Should().Be(24.93);
            //result.BmiClassification.Should().Be(BmiClassification.Overweight);
            result.Summary.Should().Be(expectedResult);
        }
    }
}
