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
    public class SeverityTestController
    {
        private readonly ISeverityRepository _repository;
        IMapper mockMapper;
        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static SeverityTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public SeverityTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();
            _repository = new SeverityRepository(context);
        }

        [Fact(DisplayName = "POST")]
        public void PostSeverity_Return_CreatedAtActionResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            SeverityViewModel severity = new SeverityViewModel();

            var controller = new SeverityController(severityService);
            severity.Description = "POST";

            //Act
            var data = controller.Post(severity);
            var objeto = data as CreatedAtActionResult;
            var severityReturn = objeto.Value;
            severity = severityReturn as SeverityViewModel;
            controller.Delete(severity.Id);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetSeverityById_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            SeverityViewModel severity = new SeverityViewModel();

            var controller = new SeverityController(severityService);
            severity.Description = "POST";

            //Act
            var dataPost = controller.Post(severity);
            var objeto = dataPost as CreatedAtActionResult;
            var severityReturn = objeto.Value;
            severity = severityReturn as SeverityViewModel;

            var data = controller.Get(severity.Id);
            controller.Delete(severity.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutSeverity_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            SeverityViewModel severity = new SeverityViewModel();
            SeverityViewModel severityPut = new SeverityViewModel();

            var controller = new SeverityController(severityService);

            severity.Description = "POST";
            severityPut.Description = "PUT";

            //Act
            var dataPost = controller.Post(severity);
            var objeto = dataPost as CreatedAtActionResult;
            var severityReturn = objeto.Value;
            severity = severityReturn as SeverityViewModel;

            var data = controller.Put(severity.Id, severityPut);
            controller.Delete(severity.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteSeverityById_Return_OkResult()
        {
            //Arrange
            SeverityService severityService = new SeverityService(_repository, mockMapper);
            SeverityViewModel severity = new SeverityViewModel();

            var controller = new SeverityController(severityService);
            severity.Description = "POST";

            //Act
            var dataPost = controller.Post(severity);
            var objeto = dataPost as CreatedAtActionResult;
            var severityReturn = objeto.Value;
            severity = severityReturn as SeverityViewModel;

            var data = controller.Delete(severity.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}
