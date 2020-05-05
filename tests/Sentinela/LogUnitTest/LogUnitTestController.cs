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

namespace TryLog.Sentinela
{
    public class LogUnitTestController
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;
        AutoMapperConfig mapperConfig;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static LogUnitTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public LogUnitTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();

            _repository = new LogRepository(context);
        }

        [Fact]
        public void Task_GetLogById_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            var controller = new LogController(logService);

            LogViewModel log = new LogViewModel();
            var logId = log.Id = 20;

            //Act
            var data = controller.Get(logId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_PostLog_Return_CreatedAtActionResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            var controller = new LogController(logService);

            LogViewModel log = new LogViewModel();
            log.Description = "ABC";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "teste";

            //Act
            var data = controller.Post(log);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_PutLog_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            var controller = new LogController(logService);
            var logId = 2;

            LogViewModel log = new LogViewModel();
            log.Description = "PUT";
            log.IdEnvironment = 1;
            log.IdLayer = 1;
            log.IdSeverity = 1;
            log.IdStatus = 1;
            log.Token = "teste";

            //Act
            var data = controller.Put(logId, log);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteLogById_Return_OkResult()
        {
            //Arrange
            LogService logService = new LogService(_repository, mockMapper);
            var controller = new LogController(logService);

            LogViewModel log = new LogViewModel();
            var logId = log.Id = 23;

            //Act
            var data = controller.Delete(logId);

            //Assert
            Assert.IsType<OkResult>(data);
        }
    }
}