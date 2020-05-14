using Microsoft.AspNetCore.Mvc;
using TryLog.Sentinela.Comparers;
using TryLog.Services.ViewModel;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerTests
{
    public class LayerControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_GetById(int id)
        {
            var fakes = new FakeContext("LayerControllerTest");
            var fakeLayerService = fakes.FakeLayerService().Object;
            var expected = fakeLayerService.Get(id);
            var controller = new LayerController(fakeLayerService);

            var result = controller.Get(id);
            var actionResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            var actual = actionResult.Value as LayerViewModel;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LayerViewModelIDComparer());
        }
    }
}
