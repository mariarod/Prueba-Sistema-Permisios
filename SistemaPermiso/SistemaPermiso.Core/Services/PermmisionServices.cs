using SistemaPermiso.Core.Entities;
using SistemaPermiso.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Core.Services
{
    //Implemmenting permmisions service
    public class PermmisionServices : IPermmisionServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PermmisionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        //Getting all permmisions
        public IEnumerable<Permmisions> GetAll()
        {
            return _unitOfWork.permmisionsRepository.GetAll().ToList();

        }

        //Getting all permmisions by Id
        public async Task<Permmisions> GetPermmisionsById(int id)
        {
            return await _unitOfWork.permmisionsRepository.GetById(id);
        }


        //Adding Permmisions from services
        public async Task InsertPermmisions(Permmisions permmisions)
        {
            await _unitOfWork.permmisionsRepository.Add(permmisions);
            await _unitOfWork.SaveChangeAsync();
           
        }


        //Updatting permmisions from services
        public async Task<bool> UpdatePermmision(Permmisions permmisions)
        {
            var permmisionId = await _unitOfWork.permmisionsRepository.GetById(permmisions.Id);
            if ( permmisionId != null)
            {
                permmisionId.EmployeeLastName = permmisions.EmployeeLastName;
                permmisionId.EmployeeName = permmisions.EmployeeName;
                permmisionId.PermmisionTypeId = permmisions.PermmisionTypeId;
                permmisionId.PermmisionDate = permmisions.PermmisionDate;
                _unitOfWork.permmisionsRepository.Update(permmisions);
               await _unitOfWork.SaveChangeAsync();
                return true;

            }

            return false;
        }

        //Deleting Permmisions from services
        public async Task<bool> DeletePermmision(int id)
        {
          
                await _unitOfWork.permmisionsRepository.Delete(id);
                await _unitOfWork.SaveChangeAsync();
                return true;

          

        }
    }
}
