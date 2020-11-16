using Microsoft.EntityFrameworkCore;
using SistemaPermiso.Core.Entities;
using SistemaPermiso.Core.Interface;
using SistemaPermiso.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Infraestructure.Repositories
{
    //Implementation Permmision type reposirory
    public class PermmisionTypeRepository : BaseRepository<PermmisionsType>, IPermmissionTypeRepository
    {
        public PermmisionTypeRepository(PermmisionContext context) : base(context)
        {

        }
   

        public Task GetPermmisionTypesById(int id)
        {
            return  _entities.FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
