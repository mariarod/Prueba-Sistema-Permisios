using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Interface
{

    //Implementing Unit of Work Repository interface
   public interface IUnitOfWork : IDisposable
    {
        IPermmisionsRepository permmisionsRepository { get; }
        IRepository<PermmisionsType> permmissionType { get; }
        void SaveChanges();
        Task SaveChangeAsync();

    }
}
