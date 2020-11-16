using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
    //Implementation Generyc Repository Interface
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PermmisionContext _context;
        public readonly DbSet<T> _entities;
        public BaseRepository(PermmisionContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        //Get All permmisions method
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        //Getting permmisions by id Method
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        //Add permmisions Method
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        //Update permmisions Method
        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        //Delete permmisions Method
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

      

    }
}
