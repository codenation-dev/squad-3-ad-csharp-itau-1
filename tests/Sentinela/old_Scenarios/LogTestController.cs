using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;
using TryLog.Services.App;
using TryLog.Services.Interfaces;
using TryLog.Services.ViewModel;
using TryLog.UseCase.Mapper;
using TryLog.WebApi.Controllers.V1;
using Xunit;

namespace TryLog.Sentinela.Scenarios
{
    public class LogTestController
    {
        IMapper mockMapper;
        private ILogRepository _logRepository;
        private IEnvironmentRepository _EnvironmentRepository;
        private ILayerRepository _layerRepository;
        private ISeverityRepository _severityRepository;
        private IStatusRepository _statusRepository;

        private EnvironmentController environmentController;
        private LogController logController;
        private LayerController layerController;
        private SeverityController severityController;
        private StatusController statusController;

        public ILogService logService;
        public IEnvironmentService environmentService;
        public ILayerService layerService;
        public ISeverityService severityService;
        public IStatusService statusService;

        private CreatedAtActionResult environmentPost;
        private CreatedAtActionResult layerPost;
        private CreatedAtActionResult severityPost;
        private CreatedAtActionResult statusPost;

        EnvironmentViewModel environmentModel;
        LayerViewModel layerModel;
        SeverityViewModel severityModel;
        StatusViewModel statusModel;

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
            _logRepository = new LogRepository(context);
            _EnvironmentRepository = new EnvironmentRepository(context);
            _layerRepository = new LayerRepository(context);
            _severityRepository = new SeverityRepository(context);
            _statusRepository = new StatusRepository(context);

            logService = new LogService(_logRepository, mockMapper);
            environmentService = new EnvironmentService(_EnvironmentRepository, mockMapper);
            layerService = new LayerService(_layerRepository, mockMapper);
            severityService = new SeverityService(_severityRepository, mockMapper);
            statusService = new StatusService(_statusRepository, mockMapper);

            logController = new LogController(logService);
            environmentController = new EnvironmentController(environmentService);
            layerController = new LayerController(layerService);
            severityController = new SeverityController(severityService);
            statusController = new StatusController(statusService);

            environmentModel = new EnvironmentViewModel();
            layerModel = new LayerViewModel();
            severityModel = new SeverityViewModel();
            statusModel = new StatusViewModel();

            //DROP DATABASE && MIGRATION
            //context.Database.EnsureDeleted();
            //context.Database.Migrate();
        }

        public void CreateRegisters()
        {
            EnvironmentViewModel environment = new EnvironmentViewModel() { Description = "POST" };
            LayerViewModel layer = new LayerViewModel() { Description = "POST" };
            SeverityViewModel severity = new SeverityViewModel() { Description = "POST" };
            StatusViewModel status = new StatusViewModel() { Description = "POST" };

            environmentPost = environmentController.Post(environment) as CreatedAtActionResult;
            environmentModel = environmentPost.Value as EnvironmentViewModel;

            layerPost = layerController.Post(layer) as CreatedAtActionResult;
            layerModel = layerPost.Value as LayerViewModel;

            severityPost = severityController.Post(severity) as CreatedAtActionResult;
            severityModel = severityPost.Value as SeverityViewModel;

            statusPost = statusController.Post(status) as CreatedAtActionResult;
            statusModel = statusPost.Value as StatusViewModel;
        }

        public void DeleteRegisters()
        {
            if (environmentModel != null) environmentController.Delete(environmentModel.Id);

            if (layerModel != null) layerController.Delete(layerModel.Id);

            if (severityModel != null) severityController.Delete(severityModel.Id);

            if (statusModel != null) statusController.Delete(statusModel.Id);
        }

        [Fact(DisplayName = "POST")]
        public void PostLog_Return_CreatedAtActionResult()
        {
            //Arrange
            LogViewModel log = new LogViewModel();

            CreateRegisters();

            log.Description = "POST";
            log.IdEnvironment = environmentModel.Id;
            log.IdLayer = layerModel.Id;
            log.IdSeverity = severityModel.Id;
            log.IdStatus = statusModel.Id;
            log.Token = "TOKENPOST";

            //Act
            var data = logController.Post(log);
            var objeto = data as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            DeleteRegisters();

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetLogById_Return_OkResult()
        {
            //Arrange
            LogViewModel log = new LogViewModel();

            CreateRegisters();

            log.Description = "POST";
            log.IdEnvironment = environmentModel.Id;
            log.IdLayer = layerModel.Id;
            log.IdSeverity = severityModel.Id;
            log.IdStatus = statusModel.Id;
            log.Token = "TOKENPOST";

            //Act
            var dataPost = logController.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = logController.Get(log.Id);

            DeleteRegisters();

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutLog_Return_OkResult()
        {
            //Arrange
            LogViewModel log = new LogViewModel();

            CreateRegisters();

            log.Description = "POST";
            log.IdEnvironment = environmentModel.Id;
            log.IdLayer = layerModel.Id;
            log.IdSeverity = severityModel.Id;
            log.IdStatus = statusModel.Id;
            log.Token = "TOKENPOST";

            //Act
            var dataPost = logController.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = logController.Put(log.Id, log);

            DeleteRegisters();

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteLogById_Return_OkResult()
        {
            //Arrange
            LogViewModel log = new LogViewModel();

            CreateRegisters();

            log.Description = "POST";
            log.IdEnvironment = environmentModel.Id;
            log.IdLayer = layerModel.Id;
            log.IdSeverity = severityModel.Id;
            log.IdStatus = statusModel.Id;
            log.Token = "TOKENPOST";

            //Act
            var dataPost = logController.Post(log);
            var objeto = dataPost as CreatedAtActionResult;
            var logReturn = objeto.Value;
            log = logReturn as LogViewModel;

            var data = logController.Delete(log.Id);

            DeleteRegisters();

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}