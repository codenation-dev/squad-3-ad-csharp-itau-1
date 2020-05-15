using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using System.Linq;
using TryLog.Services.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TryLog.Services.Interfaces;
using Org.BouncyCastle.Asn1.Cms;

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

        public ErrorViewModel GetHoursErrors(int lastTimeInterval=12)
        {
            var today = DateTime.Now;

            var dbLogs = _repo.FindAll(x => x.DateRegister >= DateTime.Now.AddHours(-lastTimeInterval));

            var countError = new Dictionary<string, int>();
            
            for (int i = 0; i < lastTimeInterval; i++)
            {
                var hours = new TimeSpan(0, i, 0, 0);
                var afterDate = today.Subtract(hours);
               
                 countError.Add(afterDate.ToString("HH"), dbLogs
                                                            .Where(x => x.DateRegister.Date == afterDate.Date && x.DateRegister.Hour == afterDate.Hour)
                                                            .Select(x => x.Id)
                                                            .Count());    
            }

            return new ErrorViewModel { 
                
                Title = "Erros hora",
                Errors = countError.Select(x => x.Value).Reverse().ToList(),
                Color = "purple",
                Labels = countError.Select(x => x.Key).Reverse().ToList()
            };
        }

        public ErrorViewModel MonthsErrors()
        {
            var today = DateTime.Now;

            var countError = new List<int>();
            var countMonths = new List<string>();

            for (int i = 0; i < 360; i += 30)
            {
                //var beforeHours = new TimeSpan(i - 30, 0, 0, 0);
                var hours = new TimeSpan(i, 0, 0, 0);
                var afterDate = today.Subtract(hours);

                //countError.Add(CountErrors(afterDate));
                countMonths.Add(afterDate.ToString("MMM"));
            }

            return new ErrorViewModel
            {

                Title = "Erros mês",
                Errors = countError.ToList(),
                Color = "cyan",
                Labels = countMonths.ToList()
            };
        }
    }
}
