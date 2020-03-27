using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace TryLog.Core.Interfaces
{
    public interface IEventRepository : IDefaultRepository<Event>
    {
        
    }
}
