using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPermiso.Core.Dtos
{
   public class PermmisionDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermmisionTypeId { get; set; }
        public DateTime PermmisionDate { get; set; }

        public PermmisionsType PermmisionsType { get; set; }



    }
}
