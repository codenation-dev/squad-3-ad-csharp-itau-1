using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface ILayerUC
    {
        void Add(LayerDTO entity);
        LayerDTO Get(int entityId);
        LayerDTO Find(int entityId);
        List<LayerDTO> FindAll(int entityId);
        void SaveOrUpdate(LayerDTO entity);
        void Delete(int entityId);
        List<LayerDTO> SelectAll();
    }
}
