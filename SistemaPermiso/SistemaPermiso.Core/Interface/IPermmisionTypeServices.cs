using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Interface
{

    //PERMMISIONS TYPE SERVICES INTERFACE
   public interface IPermmisionTypeServices
    {
        IEnumerable<PermmisionsType> GetAll();
        Task<PermmisionsType> GetPermmisionsTypeById(int id);
    }
}
