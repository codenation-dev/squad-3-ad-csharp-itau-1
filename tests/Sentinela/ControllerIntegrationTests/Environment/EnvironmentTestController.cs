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
    public class EnvironmentTestController
    {
        private readonly IEnvironmentRepository _repository;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        //public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static EnvironmentTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseInMemoryDatabase("TryLogDb")
                //.UseSqlServer(connectionString)
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
            Assert.NotNull(data);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_GetEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            environment.Id = 1;

            //Act
            var data = controller.Get(environment.Id);

            //Assert
            Assert.NotNull(data);
            Assert.IsType<OkObjectResult>(data);
        }
        
        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //public void Task_GetEnvironmentByNonExistingId_Return_OkResult(int environmentId)
        //{
        //    //Arrange
        //    EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
        //    var controller = new EnvironmentController(environmentService);

        //    EnvironmentViewModel environment = new EnvironmentViewModel();

        //    //Act
        //    var data = controller.Get(environmentId);

        //    //Assert
        //    Assert.NotNull(data);
        //    Assert.Equal(1, environmentId);
        //}

        [Fact]
        public void Task_PutEnvironment_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            environment.Id = 1;
            environment.Description = "PUT";

            //Act
            var data = controller.Put(environment.Id, environment);

            //Assert
            Assert.NotNull(data);
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteEnvironmentById_Return_OkResult()
        {
            //Arrange
            EnvironmentService environmentService = new EnvironmentService(_repository, mockMapper);
            var controller = new EnvironmentController(environmentService);

            EnvironmentViewModel environment = new EnvironmentViewModel();
            environment.Id = 1;

            //Act
            var data = controller.Delete(environment.Id);

            //Assert
            Assert.NotNull(data);
            Assert.IsType<OkResult>(data);
        }
    }
}
