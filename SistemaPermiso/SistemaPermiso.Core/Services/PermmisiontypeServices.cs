using SistemaPermiso.Core.Entities;
using SistemaPermiso.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Services
{
    //Permmisions type Services
    public class PermmisiontypeServices : IPermmisionTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
   
        public PermmisiontypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        //Getting all permmision type
        public  IEnumerable<PermmisionsType> GetAll()
        {

           return  _unitOfWork.permmissionType.GetAll().ToList();

        }

        //Getting permmision type by Id
        public Task<PermmisionsType> GetPermmisionsTypeById(int id)
        {
            return _unitOfWork.permmissionType.GetById(id);
        }
    }
}
