using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using System.Linq;
using TryLog.Services.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TryLog.Services.Interfaces;
using System.Globalization;

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

        public ErrorViewModel GetHoursErrors(int lastTimeInterval = 12)
        {
            var today = DateTime.Now;

            var dbLogs = _repo.FindAll(x => x.DateRegister >= DateTime.Now.AddHours(-lastTimeInterval));

            var countError = new Dictionary<string, int>();

            for (int i = 0; i < lastTimeInterval; i++)
            {
                var hour = new TimeSpan(0, i, 0, 0);
                var afterDate = today.Subtract(hour);

                countError.Add(afterDate.ToString("HH"), dbLogs
                                                           .Where(x => x.DateRegister.Date == afterDate.Date && x.DateRegister.Hour == afterDate.Hour)
                                                           .Select(x => x.Id)
                                                           .Count());
            }

            return new ErrorViewModel
            {

                Title = "Erros hora",
                Errors = countError.Select(x => x.Value).Reverse().ToList(),
                Color = "purple",
                Labels = countError.Select(x => x.Key).Reverse().ToList()
            };
        }

        public ErrorViewModel MonthsErrors(int lastMonthInterval)
        {
            var today = DateTime.Now;

            var countErrorMounth = new Dictionary<string, int>();

            var grouppedDbLog = (from l in _repo.AsQueryable().Where(x => x.DateRegister >= today.AddMonths(-lastMonthInterval))
                                 group l by new
                                 {
                                     Year = l.DateRegister.Year,
                                     Month = l.DateRegister.Month
                                 } into g
                                 select new
                                 {
                                     Year = g.Key.Year,
                                     Month = g.Key.Month,
                                     Total = g.Count(),
                                 }
                          ).AsEnumerable()
                          .Select(g => new
                          {
                              Month = g.Month,
                              TotalLogs = g.Total
                          });

            for (int monthIterator = 0; monthIterator < lastMonthInterval; monthIterator++)
            {
                var actualMonth = today.AddMonths(-(monthIterator)).Month;
                countErrorMounth.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(actualMonth).Substring(0, 3),
                                                            grouppedDbLog
                                                            .Where(x => x.Month == actualMonth)
                                                            .Select(x => x.TotalLogs).FirstOrDefault());
            }

            return new ErrorViewModel
            {
                Title = "Erros mês",
                Errors = countErrorMounth.Select(x => x.Value).Reverse().ToList(),
                Color = "cyan",
                Labels = countErrorMounth.Select(x => x.Key).Reverse().ToList()
            };
        }

        public ErrorViewModel WeeksErrors(int lastMonthInterval)
        {
            var today = DateTime.Now;

            var dbLogs = _repo.FindAll(x => x.DateRegister >= DateTime.Now.AddMonths(-lastMonthInterval));

            var countErrorWeek = new Dictionary<string, int>();
            var weekDateInital = today;

            for (int week = 7; week < DateTime.DaysInMonth(today.Year, today.Month); week += 7)
            {
                var weekDateFinal = DateTime.Now.AddDays(-week);

                countErrorWeek.Add($"week {week}", dbLogs.Where(x => x.DateRegister.Date <= weekDateInital.Date && x.DateRegister.Date > weekDateFinal.Date)
                                                        .Select(x => x.Id)
                                                        .Count());
                weekDateInital = weekDateFinal;
            }

            return new ErrorViewModel
            {
                Title = "Erros semana",
                Errors = countErrorWeek.Select(x => x.Value).ToList(),
                Color = "grey",
                Labels = countErrorWeek.Select(x => x.Key).ToList()
            };



        }
    }
}