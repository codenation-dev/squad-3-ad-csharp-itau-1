using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TryLog.Sentinela.Comparers;
using TryLog.Services.ViewModel;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerTests
{
    public class SeverityControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_GetById(int id)
        {
            var fakes = new FakeContext("SeverityControllerTest");
            var fakeSeverityService = fakes.FakeSeverityService().Object;
            var expected = fakeSeverityService.Get(id);
            var controller = new SeverityController(fakeSeverityService);

            var result = controller.Get(id);
            var actionResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            var actual = actionResult.Value as SeverityViewModel;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new SeverityViewModelIDComparer());
        }

        [Fact]
        public void Should_Be_Ok_When_SelectAll()
        {
            var fakes = new FakeContext("SeverityControllerTest");
            var fakeSeverityService = fakes.FakeSeverityService().Object;
            var expected = fakeSeverityService.SelectAll();
            var controller = new SeverityController(fakeSeverityService);

            var result = controller.Get();
            var actionResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            var actual = actionResult.Value as List<SeverityViewModel>;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new SeverityViewModelIDComparer());
        }

        [Fact]
        public void Should_Be_Ok_When_Posting()
        {
            var fakes = new FakeContext("SeverityControllerTest");
            var fakeSeverityService = fakes.FakeSeverityService().Object;
            List<SeverityViewModel> expected = fakes.Get<SeverityViewModel>();
            var controller = new SeverityController(fakeSeverityService);

            foreach (var item in expected)
            {
                var result = controller.Post(item);

                Assert.NotNull(result);
                Assert.IsType<CreatedAtActionResult>(result);
            }
        }
    }
}
