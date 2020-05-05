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

namespace TryLog.Sentinela.ControllerUnitTest.EnvironmentUnitTest
{
    public class EnvironmentUnitTestController
    {
        private readonly IEnvironmentRepository _repository;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static EnvironmentUnitTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public EnvironmentUnitTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();

            _repository = new EnvironmentRepository(context);
        }

        [Fact]
        public void Task_GetEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            var environmentId = environment.Id = 2;

            //Act
            var data = controller.Get(environmentId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_PostEnvironment_Return_CreatedAtActionResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            environment.Description = "POST";

            //Act
            var data = controller.Post(environment);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_PutEnvironment_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);
            var environmentId = 2;

            EnvironmentViewModel environment = new EnvironmentViewModel();
            environment.Description = "PUT";

            //Act
            var data = controller.Put(environmentId, environment);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            var environmentId = environment.Id = 2;

            //Act
            var data = controller.Delete(environmentId);

            //Assert
            Assert.IsType<OkResult>(data);
        }
    }
}
