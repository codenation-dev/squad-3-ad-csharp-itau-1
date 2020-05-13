using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Sentinela.Comparers
{
    public class EnvironmentIDComparer : IEqualityComparer<Core.Model.Environment>
    {
        public bool Equals(Core.Model.Environment x, Core.Model.Environment y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Core.Model.Environment obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
