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
        private readonly ILogRepository _repo;
        
        public StatisticsService(ILogRepository repo)
        {
            _repo = repo;
        }


        public List<StatisticsViewModel> Statistics()
        {
            var statistics = new List<StatisticsViewModel>();

            var logsPendentes = _repo.FindAll(x => x.IdStatus == 2).Count();
            
            statistics.Add( new StatisticsViewModel { 
                Title = "Logs pendentes",
                TitleToolTip = "Soma dos logs com status de pendentes",
                Value = logsPendentes.ToString()
            });


            var logsArquivados = _repo.FindAll(x => x.IdStatus == 1).Count();

            statistics.Add(new StatisticsViewModel
            {
                Title = "Logs arquivados",
                TitleToolTip = "Quantidade de logs não arquivados",
                Value = logsArquivados.ToString()
            });

            var tempoDesdePrimeiroLog = _repo.AsQueryable().Where(x => x.DateRegister.Date != DateTime.MinValue.Date).Min(x => x.DateRegister);

            statistics.Add(new StatisticsViewModel()
            {
                Title = "Dias desde o primeiro regsitro",
                TitleToolTip = "Quantidade de tempo desde o primeiro log foi registrado",
                Value = DateTime.Now.Subtract(tempoDesdePrimeiroLog).Days.ToString()+" dias"
            });           

            return statistics;
        }
    }
}
