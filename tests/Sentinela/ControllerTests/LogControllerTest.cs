using Microsoft.AspNetCore.Mvc;
using TryLog.Sentinela.Comparers;
using TryLog.Services.ViewModel;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerTests
{
    public class LogControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_GetById(int id)
        {
            var fakes = new FakeContext("LogControllerTest");
            var fakeLogService = fakes.FakeLogService().Object;
            var expected = fakeLogService.Get(id);
            var controller = new LogController(fakeLogService);

            var result = controller.Get(id);
            var actionResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            var actual = actionResult.Value as LogViewModel;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LogViewModelIDComparer());
        }

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //public void Should_Be_Ok_When_Delete(int id)
        //{
        //    var fakes = new FakeContext("LogControllerTest");
        //    var fakeLogService = fakes.FakeLogService().Object;

        //    var controller = new LogController(fakeLogService);

        //    var result = controller.Delete(id);

        //    Assert.NotNull(result);
        //    Assert.IsType<OkResult>(result);
        //}
    }
}
