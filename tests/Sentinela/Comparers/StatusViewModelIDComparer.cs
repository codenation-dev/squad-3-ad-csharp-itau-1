using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela.Comparers
{
    public class StatusViewModelIDComparer : IEqualityComparer<StatusViewModel>
    {
        public bool Equals(StatusViewModel x, StatusViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(StatusViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
