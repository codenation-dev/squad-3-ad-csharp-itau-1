using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface IErrorService
    {
        ErrorViewModel GetHoursErrors(int lastTimeInterval=24);
        ErrorViewModel MonthsErrors(int lastMonthInterval=12);
    }
}
