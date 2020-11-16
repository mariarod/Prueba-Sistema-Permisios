using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using SistemaPermiso.Api.Reponse;
using SistemaPermiso.Core.Dtos;
using SistemaPermiso.Core.Interface;

namespace SistemaPermiso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermmissionTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPermmisionTypeServices _permmisionTypeServices;
        private ILogger _logger;
        public PermmissionTypeController(IMapper mapper,
            IPermmisionTypeServices permmisionTypeServices, 
            ILogger logger)
        {
            _mapper = mapper;
            _permmisionTypeServices = permmisionTypeServices;
            _logger = logger;

        }

        //Getting all Permmisions Type
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all permmisions type");
                var permmisionTypeDto =  _permmisionTypeServices.GetAll();
                var mapDto =  _mapper.Map<IEnumerable<PermmisionTypeDto>>(permmisionTypeDto);
                var reponse =  new ApiReponse<IEnumerable<PermmisionTypeDto>>(mapDto);
                _logger.LogInformation("Permmision type charged");
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _logger.LogError("Error charging permmision");
                return BadRequest(new { success = false, message = "Error al cargar listado" });
            }


        }


        //Getting Permmisions ty by Id

        [HttpGet]
        [Route("GetTypeById")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Getting permmisions type by id");
                var permmisionType = await _permmisionTypeServices.GetPermmisionsTypeById(id);
                var permmisionDto = _mapper.Map<PermmisionTypeDto>(permmisionType);
                var reponse = new ApiReponse<PermmisionTypeDto>(permmisionDto);
                _logger.LogInformation("Permmisions type charged");
                return Ok(reponse);


            }
            catch (Exception)
            {
                _logger.LogError("Error charging permmisions type by id");
                return BadRequest(new { success = false, message = "No se encuentra ningun archivo con este Id" });
            }

        }

      

        }
}
