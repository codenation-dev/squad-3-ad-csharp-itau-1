using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Model;
using TryLog.UseCase.App;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.UseCase.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }
        public AutoMapperConfig()
        {
            CreateMap<Environment, EnvironmentDTO>().ReverseMap();
            CreateMap<Layer, LayerDTO>().ReverseMap();
            CreateMap<Log, LogDTO>().ReverseMap();
            CreateMap<Severity, SeverityDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
        }
    }
}
