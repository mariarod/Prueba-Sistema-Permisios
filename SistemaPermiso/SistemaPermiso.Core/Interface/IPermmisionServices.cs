using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Interface
{

    //PERMISIONS SERVICES INTERFACE
   public interface IPermmisionServices
    {
        IEnumerable<Permmisions> GetAll();
        Task<Permmisions> GetPermmisionsById(int id);
        Task InsertPermmisions(Permmisions permmisions);
        Task<bool> UpdatePermmision(Permmisions permmisions);
        Task<bool> DeletePermmision(int id);
    }
}
