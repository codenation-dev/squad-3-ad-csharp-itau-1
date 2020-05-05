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

namespace TryLog.Sentinela.ControllerUnitTest.StatusUnitTest
{
    public class StatusUnitTestController
    {
        private readonly IStatusRepository _repository;
        IMapper mockMapper;

        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static StatusUnitTestController()
        {

            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public StatusUnitTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();

            _repository = new StatusRepository(context);
        }

        [Fact]
        public void Task_GetStatusById_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            var controller = new StatusController(statusService);

            StatusViewModel status = new StatusViewModel();
            status.Id = 1;

            //Act
            var data = controller.Get(status.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_PostStatus_Return_CreatedAtActionResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            var controller = new StatusController(statusService);

            StatusViewModel status = new StatusViewModel();
            status.Description = "POST";

            //Act
            var data = controller.Post(status);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public void Task_PutStatus_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            var controller = new StatusController(statusService);

            StatusViewModel status = new StatusViewModel();
            status.Id = 1;
            status.Description = "PUT";

            //Act
            var data = controller.Put(status.Id, status);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_DeleteStatusById_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            var controller = new StatusController(statusService);

            StatusViewModel status = new StatusViewModel();
            status.Id = 2;

            //Act
            var data = controller.Delete(status.Id);

            //Assert
            Assert.IsType<OkResult>(data);
        }
    }
}
