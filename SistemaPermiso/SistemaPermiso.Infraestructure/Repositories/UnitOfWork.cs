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

    //Implementation unit of work interface
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PermmisionContext _context;
        private readonly IPermmisionsRepository _permmisionsRepository;
        private readonly IRepository<PermmisionsType> _permmissionType;

        //Dependency Injection context
        public UnitOfWork(PermmisionContext context)
        {
            _context = context;

        }
        public IPermmisionsRepository permmisionsRepository => _permmisionsRepository ?? new PermmisionRepository(_context);

        public IRepository<PermmisionsType> permmissionType => _permmissionType ?? new BaseRepository<PermmisionsType>(_context);

        //Destruccion object
        public void Dispose()
        {
            if(_context != null)
            { 
            _context.Dispose();

            }
        }

        //Save objets
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //Saving async objects
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
