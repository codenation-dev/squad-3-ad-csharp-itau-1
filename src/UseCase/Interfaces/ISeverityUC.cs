using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface ISeverityUC
    {
        SeverityDTO Add(SeverityDTO entity);
        SeverityDTO Get(int entityId);
        SeverityDTO Find(int entityId);
        List<SeverityDTO> FindAll(int entityId);
        bool Update(SeverityDTO entity);
        void Delete(int entityId);
        List<SeverityDTO> SelectAll();
    }
}
