using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILayerService
    {
        LayerViewModel Add(LayerViewModel entity);
        LayerViewModel Get(int entityId);
        LayerViewModel Find(int entityId);
        List<LayerViewModel> FindAll(int entityId);
        bool Update(LayerViewModel entity);
        void Delete(int entityId);
        List<LayerViewModel> SelectAll();
    }
}
