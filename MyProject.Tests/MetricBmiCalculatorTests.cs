﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTests
    {
        public static IEnumerable<object[]> GetSampleData()
        {
            yield return new object[] { 100, 170, 34.6 };
            yield return new object[] { 57, 170, 19.72 };
            yield return new object[] { 70, 170, 24.22 };
            yield return new object[] { 80, 190, 22.16 };
            yield return new object[] { 90, 190, 24.93 };
        }

        [Theory]
        [MemberData(nameof(GetSampleData))]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            //arrange
            MetricBmiCalculator calculator = new();

            //act
            double result = calculator.CalculateBmi(weight, height);

            //assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        //[InlineData(0, 190)]
        //[InlineData(-5, 150)]
        //[InlineData(-11, 150)]
        //[InlineData(90, -150)]
        //[InlineData(90, 0)]
        //[InlineData(0, 0)]
        //[ClassData(typeof(MetricBmiCalculatorTestsData))]
        [JsonFileData("Data/MetricBmiCalculatorData.json")]
        public void CalculateBmi_ForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {
            //arrange
            MetricBmiCalculator calculator = new();

            //act
            void action() => calculator.CalculateBmi(weight, height);

            //assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}