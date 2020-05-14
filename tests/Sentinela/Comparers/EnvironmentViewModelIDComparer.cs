using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela.Comparers
{
    public class EnvironmentViewModelIDComparer : IEqualityComparer<EnvironmentViewModel>
    {
        public bool Equals(EnvironmentViewModel x, EnvironmentViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(EnvironmentViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
