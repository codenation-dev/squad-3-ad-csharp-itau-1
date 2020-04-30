using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class SeverityRepository : AbstractRepository<Severity>, ISeverityRepository
    {
        public SeverityRepository(TryLogContext context) : base(context)
        {
        }
    }
}
