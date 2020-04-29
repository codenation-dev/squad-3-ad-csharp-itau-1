using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface ILayerUC
    {
        LayerDTO Add(LayerDTO entity);
        LayerDTO Get(int entityId);
        LayerDTO Find(int entityId);
        List<LayerDTO> FindAll(int entityId);
        bool Update(LayerDTO entity);
        void Delete(int entityId);
        List<LayerDTO> SelectAll();
    }
}
