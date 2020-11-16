using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaPermiso.Api.Reponse;
using SistemaPermiso.Core.Dtos;
using SistemaPermiso.Core.Entities;
using SistemaPermiso.Core.Interface;

namespace SistemaPermiso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermmissionsController : ControllerBase
    {
        private readonly IPermmisionServices _services;
        private readonly IMapper _mapper;
        private  ILogger _logger;
        public PermmissionsController( IPermmisionServices services, IMapper mapper, ILogger logger)
        {
            _services = services;
            _mapper = mapper;
            _logger = logger;
        }

        //Get all permmisions
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all permmision");
                var permmisionTypeDto = _services.GetAll();
                var mapDto = _mapper.Map<IEnumerable<PermmisionDto>>(permmisionTypeDto);
                var reponse = new ApiReponse<IEnumerable<PermmisionDto>>(mapDto);
                _logger.LogInformation("All permmisions getted");
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error getting all permmisions");
                return BadRequest(new { success = false, message = "Error al cargar listado" });
            }


        }

        //Get permmisions by id
        [HttpGet]
        [Route("getPermmisionById")]
        public async Task<IActionResult> GetPermmissionById(int id)
        {
            try
            {
                var permmision = await _services.GetPermmisionsById(id);

                var permmisionDto = _mapper.Map<PermmisionDto>(permmision);
                var reponse = new ApiReponse<PermmisionDto>(permmisionDto);
                _logger.LogInformation("Getting permmision by Id");
                return Ok(reponse);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error =gtting permmision by Id");
                return BadRequest(new { success = false, message = "Error al cargar registro" });
            }
        }


        //Adding permmision
        [HttpPost]
        [Route("addPermmision")]
        public async Task< IActionResult> AddPermissions(PermmisionsCreateDto permmisionsDto)
        {
             this._logger.LogInformation("Validation null or empty valuse");
            if(string.IsNullOrEmpty(permmisionsDto.EmployeeName)) { return BadRequest(new { success = false, message = "El campo nombre es obligatorio" }); }
            if (string.IsNullOrEmpty(permmisionsDto.EmployeeLastName)) { return BadRequest(new { success = false, message = "El campo apellidos es obligatorio" }); }
            if (string.IsNullOrEmpty(permmisionsDto.PermmisionDate.ToShortDateString())) { return BadRequest(new { success = false, message = "El campo fecha es obligatorio" }); }
            if (string.IsNullOrEmpty(permmisionsDto.PermmisionTypeId)) { return BadRequest(new { success = false, message = "El campo tipoPermiso es obligatorio" }); }

            try
            {
                var permmision = _mapper.Map<Permmisions>(permmisionsDto);
                await _services.insertPermmisions(permmision);
                permmisionsDto = _mapper.Map<PermmisionsCreateDto>(permmision);
                var reponse = new ApiReponse<PermmisionsCreateDto>(permmisionsDto);
                _logger.LogInformation("Permmision created");
                return Ok(new {resp = reponse, success = true, message = "Permiso Guardado Correctamente"});
              
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error create permmision");
                return BadRequest(new { success = false, message = "Error al insertar un permiso" });
            }

       
        }

        //Updating permmision
        [HttpPut]
        [Route("updatePermision")]
        public async Task<IActionResult>UpdatePermission(int? id, PermmisionDto permmisionDto)
        {
            try
            {
                _logger.LogInformation("Updating permmisions");
                var permision = _mapper.Map<Permmisions>(permmisionDto);
                //permision.Id = Convert.ToInt16(id);
                var result = await _services.UpdatePermmision(permision);
                var reponse = new ApiReponse<bool>(result);
                _logger.LogInformation("Permmision updated");
                return Ok(new { success = true, message = "Registro Actualizado Correctamente" });
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error updating permmision");
                return BadRequest(new { success = false, message = "Error al actualizar registro" });
            }
        }

   
        
        //Deleting permmisions
        [HttpDelete]
        [Route("deletePermission")]
        public async Task<IActionResult>DeletePermission(int id)
        {
            try
            {
                _logger.LogInformation("Deleting permmision");
                var result = await _services.DeletePermmision(id);
                var reponse = new ApiReponse<bool>(result);
                _logger.LogInformation("Permmision deleted");
                return Ok(new { success = true, message = "Registro eliminado correctamente" });

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error deleting permmision");
                return BadRequest(new { success = false, message = "No se ha encontrado un registro con este Id" });
            }
        }



    }
}
