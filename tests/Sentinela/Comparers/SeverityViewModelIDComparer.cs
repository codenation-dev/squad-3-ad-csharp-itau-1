using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela.Comparers
{
    public class SeverityViewModelIDComparer : IEqualityComparer<SeverityViewModel>
    {
        public bool Equals(SeverityViewModel x, SeverityViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(SeverityViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
