using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface IStatisticsService
    {
     List<StatisticsViewModel> Statistics();
    }

}
