using Microsoft.AspNetCore.Mvc;
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
    }
}
