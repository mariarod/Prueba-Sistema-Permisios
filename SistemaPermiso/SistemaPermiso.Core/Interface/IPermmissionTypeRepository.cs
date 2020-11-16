using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Interface
{
    //Permmsion type interface
   public interface IPermmissionTypeRepository : IRepository<PermmisionsType>
    {
   
        Task GetPermmisionTypesById(int id);
     
    }
}
