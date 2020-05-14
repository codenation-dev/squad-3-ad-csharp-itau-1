using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Sentinela.Comparers
{
    public class LayerViewModelIDComparer : IEqualityComparer<LayerViewModel>
    {
        public bool Equals(LayerViewModel x, LayerViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(LayerViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
