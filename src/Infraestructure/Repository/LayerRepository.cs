using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class LayerRepository: AbstractRepository<Layer>, ILayerRepository
    {
        public LayerRepository(TryLogContext context):base(context)
        {
        }
        public void Create(Layer layer)
        {
            Add(layer);
        }
        public Layer Read(long layerId)
        {
            return Get(layerId);
        }
        public List<Layer> Filter(Expression<Func<Layer, bool>> predicate)
        {
            return Find(predicate);
        }
        public void Remove(Expression<Func<Layer, bool>> predicate)
        {
            Delete(predicate);
        }
        public void Update(Layer layer)
        {
            SaveOrUpdate(layer);
        }
    }
}
