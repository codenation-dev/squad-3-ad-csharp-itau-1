using System;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;
using System.Linq.Expressions;
using System.Collections.Generic;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.Repository
{
    public class EnvironmentRepository : AbstractRepository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(TryLogContext context):base(context)
        {
        }
    }
}
