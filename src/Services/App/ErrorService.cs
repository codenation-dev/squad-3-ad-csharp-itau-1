using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using System.Linq;
using TryLog.Services.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TryLog.Services.Interfaces;

namespace TryLog.Services.App
{
    public class ErrorService : IErrorService
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;
        public ErrorService(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private int CountErrorsHours(DateTime date)
        {
            return _repo.FindAll(x => x.DateRegister.Date == date.Date && x.DateRegister.Hour == date.Hour)
                        .Select(x => x.Id)
                        .Count();
        }
        public ErrorViewModel HoursErrors()
        {
            var today = DateTime.Now;
            
            var countError = new Dictionary<string, int>();
            
            for (int hour = 0; hour < 24; hour++)
            {
                var hours = new TimeSpan(0, hour, 0, 0);
                var afterDate = today.Subtract(hours);
               
                countError.Add(afterDate.ToString("HH tt", new System.Globalization.CultureInfo("en-US")), CountErrorsHours(afterDate));    
            }

            return new ErrorViewModel { 
                
                Title = "Erros hora",
                Errors = countError.Select(x => x.Value).ToList(),
                Color = "purple",
                Labels = countError.Select(x => x.Key).ToList()
            };
        }

        private int CountErrorsMonths(DateTime date)
        {
            return _repo.FindAll(x => x.DateRegister.Year == date.Year && x.DateRegister.Month == date.Month)
                        .Select(x => x.Id)
                        .Count();
        }
        public ErrorViewModel MonthsErrors()
        {
            var today = DateTime.Now;

            var countErrorMounth = new Dictionary<string, int>();

            for (int days = 0; days < 360; days += 30)
            {
                var mounth = new TimeSpan(days, 0, 0, 0);
                var afterDate = today.Subtract(mounth);

                countErrorMounth.Add(afterDate.ToString("MMM"), CountErrorsMonths(afterDate));
            }

            return new ErrorViewModel
            {
                Title = "Erros mês",
                Errors = countErrorMounth.Select(x => x.Value).ToList(),
                Color = "cyan",
                Labels = countErrorMounth.Select(x => x.Key).ToList()
            };
        }

        //private int CountErrorsWeek(DateTime date)
        //{
        //    //return _repo.FindAll(x => x.DateRegister.Year == date.Year && x.DateRegister.Month == date.Month && x.DateRegister == date.Year)
        //    //            .Select(x => x.Id)
        //    //            .Count();
        //}
        //public ErrorViewModel WeekErrors()
        //{
        //    var today = DateTime.Now;

        //    var countErrorMounth = new Dictionary<string, int>();

        //    for (int days = 0; days < 360; days += 30)
        //    {
        //        var mounth = new TimeSpan(days, 0, 0, 0);
        //        var afterDate = today.Subtract(mounth);

        //        countErrorMounth.Add(afterDate.ToString("MMM"), CountErrorsWeek(afterDate));
        //    }

        //    return new ErrorViewModel
        //    {
        //        Title = "Erros mês",
        //        Errors = countErrorMounth.Select(x => x.Value).ToList(),
        //        Color = "cyan",
        //        Labels = countErrorMounth.Select(x => x.Key).ToList()
        //    };
        //}
    }
}
