using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Model;
using TryLog.Services.App;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
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
            CreateMap<Environment, EnvironmentViewModel>().ReverseMap();
            CreateMap<Layer, LayerViewModel>().ReverseMap();
            CreateMap<Log, LogViewModel>().ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => src.DateRegister)).ReverseMap();
            CreateMap<Severity, SeverityViewModel>().ReverseMap();
            CreateMap<Status, StatusViewModel>().ReverseMap();
            CreateMap<UserCreateView, User>()
                .ForCtorParam("fullName", opt => opt.MapFrom(x => x.FullName))
                .ForCtorParam("userName", opt => opt.MapFrom(x => x.Email))
                .ForCtorParam("password", opt => opt.MapFrom(x => x.Password)).ReverseMap();
            CreateMap<User, UserGetView>();
        }
    }
}
