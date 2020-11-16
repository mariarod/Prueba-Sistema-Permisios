using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaPermiso.Core.Entities;
using SistemaPermiso.Core.Interface;
using SistemaPermiso.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Infraestructure.Repositories
{
    //Implementation Permmisions Repository Interface
    public class PermmisionRepository : BaseRepository<Permmisions>, IPermmisionsRepository
    {
        
        public PermmisionRepository(PermmisionContext context): base(context) {
    
        }
       
        public async Task<IEnumerable<Permmisions>> GetPermmisionTypeById(int idPermmision)
        {
                return await _entities.Where(x => x.Id == idPermmision).ToListAsync();
        }

   

    }
}
