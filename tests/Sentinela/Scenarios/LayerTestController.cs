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

namespace TryLog.Sentinela.Scenarios
{
    public class LayerTestController
    {
        private readonly ILayerRepository _repository;
        IMapper mockMapper;
        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static LayerTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public LayerTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();
            _repository = new LayerRepository(context);
        }

        [Fact(DisplayName = "POST")]
        public void PostLayer_Return_CreatedAtActionResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            LayerViewModel layer = new LayerViewModel();

            var controller = new LayerController(layerService);
            layer.Description = "POST";

            //Act
            var data = controller.Post(layer);
            var objeto = data as CreatedAtActionResult;
            var layerReturn = objeto.Value;
            layer = layerReturn as LayerViewModel;
            controller.Delete(layer.Id);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetLayerById_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            LayerViewModel layer = new LayerViewModel();

            var controller = new LayerController(layerService);
            layer.Description = "POST";

            //Act
            var dataPost = controller.Post(layer);
            var objeto = dataPost as CreatedAtActionResult;
            var layerReturn = objeto.Value;
            layer = layerReturn as LayerViewModel;

            var data = controller.Get(layer.Id);
            controller.Delete(layer.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutLayer_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            LayerViewModel layer = new LayerViewModel();
            LayerViewModel layerPut = new LayerViewModel();

            var controller = new LayerController(layerService);

            layer.Description = "POST";
            layerPut.Description = "PUT";

            //Act
            var dataPost = controller.Post(layer);
            var objeto = dataPost as CreatedAtActionResult;
            var layerReturn = objeto.Value;
            layer = layerReturn as LayerViewModel;

            var data = controller.Put(layer.Id, layerPut);
            controller.Delete(layer.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteLayerById_Return_OkResult()
        {
            //Arrange
            LayerService layerService = new LayerService(_repository, mockMapper);
            LayerViewModel layer = new LayerViewModel();

            var controller = new LayerController(layerService);
            layer.Description = "POST";

            //Act
            var dataPost = controller.Post(layer);
            var objeto = dataPost as CreatedAtActionResult;
            var layerReturn = objeto.Value;
            layer = layerReturn as LayerViewModel;

            var data = controller.Delete(layer.Id);


            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}
