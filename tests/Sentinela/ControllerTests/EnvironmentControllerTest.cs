using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TryLog.Infraestructure.EF;
using TryLog.Sentinela.Comparers;
using TryLog.Services.App;
using TryLog.Services.ViewModel;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerTests
{
    public class EnvironmentControllerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_FindById(int id)
        {
            var fakes = new FakeContext("EnvironmentControllerTest");
            var fakeEnvironmentService = fakes.FakeEnvironmentService().Object;
            var expected = fakes.Mapper.Map<List<Core.Model.Environment>>(fakeEnvironmentService.Find(id));
            var controller = new EnvironmentController(fakeEnvironmentService);

            var result = controller.Get(id);
            var actionResult = result as CreatedAtActionResult;
            var actionReturn = actionResult.Value;

            Assert.IsType<OkObjectResult>(actionResult.Value);
            var actual = (actionResult.Value as OkObjectResult).Value as List<Core.Model.Environment>;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new EnvironmentIDComparer());
        }
    }
}
