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
    public class StatusTestController
    {
        private readonly IStatusRepository _repository;
        IMapper mockMapper;
        public static DbContextOptions<TryLogContext> dbContextOptions { get; }
        public static readonly IConfiguration Configuration;
        public static string connectionString = "Server=MAH-DELL\\SQLEXPRESS;Database=TryLog;Trusted_Connection=True;";

        static StatusTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public StatusTestController()
        {
            var context = new TryLogContext(dbContextOptions);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mockMapper = mappingConfig.CreateMapper();
            _repository = new StatusRepository(context);
        }

        [Fact(DisplayName = "POST")]
        public void PostStatus_Return_CreatedAtActionResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            StatusViewModel status = new StatusViewModel();

            var controller = new StatusController(statusService);
            status.Description = "POST";

            //Act
            var data = controller.Post(status);
            var objeto = data as CreatedAtActionResult;
            var statusReturn = objeto.Value;
            status = statusReturn as StatusViewModel;
            controller.Delete(status.Id);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);
            var result = data as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact(DisplayName = "GET BY ID")]
        public void GetStatusById_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            StatusViewModel status = new StatusViewModel();

            var controller = new StatusController(statusService);
            status.Description = "POST";

            //Act
            var dataPost = controller.Post(status);
            var objeto = dataPost as CreatedAtActionResult;
            var statusReturn = objeto.Value;
            status = statusReturn as StatusViewModel;

            var data = controller.Get(status.Id);
            controller.Delete(status.Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var result = data as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "PUT")]
        public void PutStatus_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            StatusViewModel status = new StatusViewModel();
            StatusViewModel statusPut = new StatusViewModel();

            var controller = new StatusController(statusService);

            status.Description = "POST";
            statusPut.Description = "PUT";

            //Act
            var dataPost = controller.Post(status);
            var objeto = dataPost as CreatedAtActionResult;
            var statusReturn = objeto.Value;
            status = statusReturn as StatusViewModel;

            var data = controller.Put(status.Id, statusPut);
            controller.Delete(status.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact(DisplayName = "DELETE")]
        public void DeleteStatusById_Return_OkResult()
        {
            //Arrange
            StatusService statusService = new StatusService(_repository, mockMapper);
            StatusViewModel status = new StatusViewModel();

            var controller = new StatusController(statusService);
            status.Description = "POST";

            //Act
            var dataPost = controller.Post(status);
            var objeto = dataPost as CreatedAtActionResult;
            var statusReturn = objeto.Value;
            status = statusReturn as StatusViewModel;

            var data = controller.Delete(status.Id);

            //Assert
            Assert.IsType<OkResult>(data);
            var result = data as OkResult;
            Assert.Equal(200, result.StatusCode);
        }
    }
}
