using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaPermiso.Core.Entities;

namespace SistemaPermiso.Core.Interface
{

    //Generyc Repository
  public  interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);

    }
}
