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
    public class LogTestController
    {
        private readonly ILogRepository _repository;
        IMapper mockMapper;
        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static LogTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public LogTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();
            _repository = new LogRepository(context);
        }

        [Fact(DisplayName = "POST")]
        public void PostLog_Return_CreatedAtActionResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            LogViewModel log = new LogViewModel();
            EnvironmentViewModel environment = new EnvironmentViewModel();
            LayerViewModel layer = new LayerViewModel();
            SeverityViewModel severity = new SeverityViewModel();
            StatusViewModel status = new StatusViewModel();

            var controller = new LogController(logService);

            log.Description = "POST";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "TOKENPOST";

            //Act
            var data = controller.Post(log);
            var objeto = data as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;
            controller.Delete(log.Id);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetLogById_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            LogViewModel log = new LogViewModel();

            var controller = new LogController(logService);

            log.Description = "POST";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "TOKENPOST";

            //Act
            var dataPost = controller.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = controller.Get(log.Id);
            controller.Delete(log.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutLog_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            LogViewModel log = new LogViewModel();
            LogViewModel logPut = new LogViewModel();

            var controller = new LogController(logService);

            log.Id = 1;
            log.Description = "PUT";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "TOKENPUT";

            logPut.Description = "PUT";
            logPut.IdEnvironment = 2;
            logPut.IdLayer = 2;
            logPut.IdSeverity = 2;
            logPut.IdStatus = 2;
            logPut.Token = "TOKENPUT";

            //Act
            var dataPost = controller.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = controller.Put(log.Id, logPut);
            controller.Delete(log.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteLogById_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            LogViewModel log = new LogViewModel();

            var controller = new LogController(logService);

            log.Description = "POST";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "TOKENPOST";

            //Act
            var dataPost = controller.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = controller.Delete(log.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}