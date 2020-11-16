using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Interface
{
   public interface IPermmisionsRepository : IRepository<Permmisions>
    {
        Task<IEnumerable<Permmisions>> GetPermmisionTypeById(int idPermmision);
    }
}
