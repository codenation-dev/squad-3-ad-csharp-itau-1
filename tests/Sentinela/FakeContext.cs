using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Services.Interfaces;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela
{
    public class FakeContext
    {
        public DbContextOptions<TryLogContext> FakeOptions { get; }
        public readonly IMapper Mapper;

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<TryLogContext>()
                .UseInMemoryDatabase(databaseName: $"TryLog_{testName}")
                .Options;

            DataFileNames.Add(typeof(Core.Model.Environment), $"FakeData{Path.DirectorySeparatorChar}environments.json");
            DataFileNames.Add(typeof(EnvironmentViewModel), $"FakeData{Path.DirectorySeparatorChar}environments.json");
            DataFileNames.Add(typeof(Layer), $"FakeData{Path.DirectorySeparatorChar}layers.json");
            DataFileNames.Add(typeof(LayerViewModel), $"FakeData{Path.DirectorySeparatorChar}layers.json");
            DataFileNames.Add(typeof(Log), $"FakeData{Path.DirectorySeparatorChar}logs.json");
            DataFileNames.Add(typeof(LogViewModel), $"FakeData{Path.DirectorySeparatorChar}logs.json");
            DataFileNames.Add(typeof(Severity), $"FakeData{Path.DirectorySeparatorChar}severities.json");
            DataFileNames.Add(typeof(SeverityViewModel), $"FakeData{Path.DirectorySeparatorChar}severities.json");
            DataFileNames.Add(typeof(Status), $"FakeData{Path.DirectorySeparatorChar}statuses.json");
            DataFileNames.Add(typeof(StatusViewModel), $"FakeData{Path.DirectorySeparatorChar}statuses.json");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Core.Model.Environment, EnvironmentViewModel>().ReverseMap();
                cfg.CreateMap<Layer, LayerViewModel>().ReverseMap();
                cfg.CreateMap<Log, LogViewModel>().ReverseMap();
                cfg.CreateMap<Severity, SeverityViewModel>().ReverseMap();
                cfg.CreateMap<Status, StatusViewModel>().ReverseMap();
            });

            Mapper = configuration.CreateMapper();
        }

        public void FillWithAll()
        {
            FillWith<Core.Model.Environment>();
            FillWith<Layer>();
            FillWith<Log>();
            FillWith<Severity>();
            FillWith<Status>();
        }

        public void FillWith<T>() where T : class
        {
            using (var context = new TryLogContext(FakeOptions))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in Get<T>())
                        context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<IEnvironmentService> FakeEnvironmentService()
        {
            var service = new Mock<IEnvironmentService>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<EnvironmentViewModel>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<EnvironmentViewModel>())).
                Returns((EnvironmentViewModel environment) =>
                {
                    if (environment.Id == 0)
                        environment.Id = 999;
                    return environment;
                });

            return service;
        }

        public Mock<ILayerService> FakeLayerService()
        {
            var service = new Mock<ILayerService>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<LayerViewModel>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<LayerViewModel>())).
                Returns((LayerViewModel layer) =>
                {
                    if (layer.Id == 0)
                        layer.Id = 999;
                    return layer;
                });

            return service;
        }

        public Mock<ILogService> FakeLogService()
        {
            var service = new Mock<ILogService>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<LogViewModel>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<LogViewModel>(), It.IsAny<string>())).
                Returns((LogViewModel log) =>
                {
                    if (log.Id == 0)
                        log.Id = 999;
                    return log;
                });

            return service;
        }

        public Mock<ISeverityService> FakeSeverityService()
        {
            var service = new Mock<ISeverityService>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<SeverityViewModel>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<SeverityViewModel>())).
                Returns((SeverityViewModel severity) =>
                {
                    if (severity.Id == 0)
                        severity.Id = 999;
                    return severity;
                });

            return service;
        }

        public Mock<IStatusService> FakeStatusService()
        {
            var service = new Mock<IStatusService>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<StatusViewModel>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<StatusViewModel>())).
                Returns((StatusViewModel status) =>
                {
                    if (status.Id == 0)
                        status.Id = 999;
                    return status;
                });

            return service;
        }
    }
}