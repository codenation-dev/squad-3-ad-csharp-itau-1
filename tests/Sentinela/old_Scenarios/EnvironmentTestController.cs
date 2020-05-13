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
    public class EnvironmentTestController
    {
        private readonly IEnvironmentRepository _repository;
        IMapper mockMapper;
        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static EnvironmentTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public EnvironmentTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();
            _repository = new EnvironmentRepository(context);
        }

        [Fact(DisplayName = "POST")]
        public void PostEnvironment_Return_CreatedAtActionResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            EnvironmentViewModel environment = new EnvironmentViewModel();

            var controller = new EnvironmentController(environmentService);
            environment.Description = "POST";

            //Act
            var data = controller.Post(environment);
            var objeto = data as CreatedAtActionResult;
            var environmentReturn = objeto.Value;
            environment = environmentReturn as EnvironmentViewModel;
            controller.Delete(environment.Id);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            EnvironmentViewModel environment = new EnvironmentViewModel();

            var controller = new EnvironmentController(environmentService);
            environment.Description = "POST";
                        
            //Act
            var dataPost = controller.Post(environment);
            var objeto = dataPost as CreatedAtActionResult;
            var environmentReturn = objeto.Value;
            environment = environmentReturn as EnvironmentViewModel;

            var data = controller.Get(environment.Id);
            controller.Delete(environment.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutEnvironment_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            EnvironmentViewModel environment = new EnvironmentViewModel();
            EnvironmentViewModel environmentPut = new EnvironmentViewModel();

            var controller = new EnvironmentController(environmentService);

            environment.Description = "POST";
            environmentPut.Description = "PUT";

            //Act
            var dataPost = controller.Post(environment);
            var objeto = dataPost as CreatedAtActionResult;
            var environmentReturn = objeto.Value;
            environment = environmentReturn as EnvironmentViewModel;

            var data = controller.Put(environment.Id, environmentPut);
            controller.Delete(environment.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            EnvironmentViewModel environment = new EnvironmentViewModel();

            var controller = new EnvironmentController(environmentService);
            environment.Description = "POST";

            //Act
            var dataPost = controller.Post(environment);
            var objeto = dataPost as CreatedAtActionResult;
            var environmentReturn = objeto.Value;
            environment = environmentReturn as EnvironmentViewModel;

            var data = controller.Delete(environment.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}
