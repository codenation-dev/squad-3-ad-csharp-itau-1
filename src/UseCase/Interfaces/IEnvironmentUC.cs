using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface IEnvironmentUC
    {
        EnvironmentDTO Add(EnvironmentDTO entity);
        EnvironmentDTO Get(int entityId);
        EnvironmentDTO Find(int entityId);
        List<EnvironmentDTO> FindAll(int entityId);
        bool Update(EnvironmentDTO entity);
        void Delete(int entityId);
        List<EnvironmentDTO> SelectAll();
    }
}
