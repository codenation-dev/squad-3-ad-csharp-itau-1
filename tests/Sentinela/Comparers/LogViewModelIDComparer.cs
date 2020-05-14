using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela.Comparers
{
    public class LogViewModelIDComparer : IEqualityComparer<LogViewModel>
    {
        public bool Equals(LogViewModel x, LogViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(LogViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
