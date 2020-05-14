using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface IErrorService
    {
        ErrorViewModel HoursErrors();
        ErrorViewModel MonthsErrors();
    }
}
