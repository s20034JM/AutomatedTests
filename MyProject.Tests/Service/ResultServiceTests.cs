using FluentAssertions;
using Moq;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests.Service
{
    public class ResultServiceTests
    {
        [Fact()]
        public void SetOverweightResult_ForOverweightResult_UpdatedProperty()
        {
            //arrange
            var result = new BmiResult
            {
                BmiClassification = BmiClassification.Overweight
            };
            var resultRepository = new ResultRepository();
            var resultService = new ResultService(resultRepository);

            //act
            resultService.SetRecentOverweightResult(result);

            //assertion
            resultService.RecentOverweightResult.Should().Be(result);
        }
        [Fact()]
        public void SetOverweightResult_ForOverweightResult_DoesntUpdatedProperty()
        {
            //arrange
            var result = new BmiResult
            {
                BmiClassification = BmiClassification.Obesity
            };
            var resultRepository = new ResultRepository();
            var resultService = new ResultService(resultRepository);

            //act
            resultService.SetRecentOverweightResult(result);

            //assertion
            resultService.RecentOverweightResult.Should().BeNull();
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderWeightResult_InvokesSaveResultAsync()
        {
            //arrange
            var result = new BmiResult
            {
                BmiClassification = BmiClassification.Underweight
            };
            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);

            //act
            await resultService.SaveUnderweightResultAsync(result);

            //arrange
            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForNonUnderWeightResult_DoesntInvokeSaveResultAsync()
        {
            //arrange
            var result = new BmiResult
            {
                BmiClassification = BmiClassification.Normal
            };
            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);

            //act
            await resultService.SaveUnderweightResultAsync(result);

            //arrange
            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
        }
    }
}
