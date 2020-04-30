using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface IStatusUC
    {
        StatusDTO Add(StatusDTO entity);
        StatusDTO Get(int entityId);
        StatusDTO Find(int entityId);
        List<StatusDTO> FindAll(int entityId);
        bool Update(StatusDTO entity);
        void Delete(int entityId);
        List<StatusDTO> SelectAll();
    }
}
