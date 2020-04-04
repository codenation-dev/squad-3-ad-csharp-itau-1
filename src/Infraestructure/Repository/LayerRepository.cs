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
    }
}
