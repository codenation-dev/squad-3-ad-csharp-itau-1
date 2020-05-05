using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;
using TryLog.Services.App;
using TryLog.Services.ViewModel;
using TryLog.UseCase.Mapper;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.ControllerUnitTest.LayerUnitTest
{
    public class LayerUnitTestController
    {
        private readonly ILayerRepository _repository;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static LayerUnitTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public LayerUnitTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();

            _repository = new LayerRepository(context);
        }

        [Fact]
        public void Task_GetLayerById_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            var controller = new LayerController(layerService);

            LayerViewModel layer = new LayerViewModel();
            layer.Id = 1;

            //Act
            var data = controller.Get(layer.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_PostLayer_Return_CreatedAtActionResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            var controller = new LayerController(layerService);

            LayerViewModel layer = new LayerViewModel();
            layer.Description = "POST";

            //Act
            var data = controller.Post(layer);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_PutLayer_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            var controller = new LayerController(layerService);

            LayerViewModel layer = new LayerViewModel();
            layer.Id = 1;
            layer.Description = "PUT";

            //Act
            var data = controller.Put(layer.Id, layer);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteLayerById_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            var controller = new LayerController(layerService);

            LayerViewModel layer = new LayerViewModel();
            layer.Id = 2;

            //Act
            var data = controller.Delete(layer.Id);

            //Assert
            Assert.IsType<OkResult>(data);
        }
    }
}
