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

namespace TryLog.Sentinela.ControllerUnitTest.SeverityUnitTest
{
    public class SeverityUnitTestController
    {
        private readonly ISeverityRepository _repository;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static SeverityUnitTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public SeverityUnitTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();

            _repository = new SeverityRepository(context);
        }

        [Fact]
        public void Task_GetSeverityById_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            var controller = new SeverityController(severityService);

            SeverityViewModel severity = new SeverityViewModel();
            severity.Id = 1;

            //Act
            var data = controller.Get(severity.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_PostSeverity_Return_CreatedAtActionResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            var controller = new SeverityController(severityService);

            SeverityViewModel severity = new SeverityViewModel();
            severity.Description = "POST";

            //Act
            var data = controller.Post(severity);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_PutSeverity_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            var controller = new SeverityController(severityService);

            SeverityViewModel severity = new SeverityViewModel();
            severity.Id = 1;
            severity.Description = "PUT";

            //Act
            var data = controller.Put(severity.Id, severity);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteSeverityById_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            var controller = new SeverityController(severityService);

            SeverityViewModel severity = new SeverityViewModel();
            severity.Id = 2;

            //Act
            var data = controller.Delete(severity.Id);

            //Assert
            Assert.IsType<OkResult>(data);
        }
    }
}
