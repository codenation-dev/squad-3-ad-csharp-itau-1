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

        public ErrorViewModel HoursErrors()
        {
            var today = DateTime.Now;
            
            var countError = new Dictionary<string, int>();
            
            for (int i = 0; i < 24; i++)
            {
                var hours = new TimeSpan(0, i, 0, 0);
                var afterDate = today.Subtract(hours);
               
                countError.Add(afterDate.ToString("HH TT"), CountErrors(afterDate));    
            }

            return new ErrorViewModel { 
                
                Title = "Erros hora",
                Errors = countError.Select(x => x.Value).ToList(),
                Color = "purple",
                Labels = countError.Select(x => x.Key).ToList()
            };
        }

        private int CountErrors(DateTime date)
        {
            return _repo.FindAll(x => x.DateRegister <= DateTime.Now && x.DateRegister >= date)
                                   .Select(x => x.Id)
                                   .Count();
        }

        public ErrorViewModel MonthsErrors()
        {
            var today = DateTime.Now;

            var countError = new List<int>();
            var countMonths = new List<string>();

            for (int i = 0; i < 360; i += 30)
            {
                var hours = new TimeSpan(i, 0, 0, 0);
                var afterDate = today.Subtract(hours);

                countError.Add(CountErrors(afterDate));
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
