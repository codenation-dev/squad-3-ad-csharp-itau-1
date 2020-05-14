using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Services.Interfaces;
using TryLog.Services.ViewModel;

namespace TryLog.Services.App
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatusRepository _status;
        private readonly ISeverityRepository _severity;
        public StatisticsService(IStatusRepository status, ISeverityRepository severity)
        {
            _status = status;
            _severity = severity;
        }


        public List<StatisticsViewModel> Statistics()
        {
            var statistics = new List<StatisticsViewModel>();

            var countError = _severity.FindAll(x => x.Description == "error").Count();
            
            statistics.Add( new StatisticsViewModel { 
                Title = "Erros",
                TitleToolTip = "Soma dos erros, apenas Classificados como erro",
                Value = countError.ToString()
            });


            var openError = _status.FindAll(x => x.Description != "Arquivado").Count();

            statistics.Add(new StatisticsViewModel
            {
                Title = "Erros abertos",
                TitleToolTip = "Quantidade de erros não arquivados",
                Value = openError.ToString()
            });


            return statistics;
        }
    }
}
