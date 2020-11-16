using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaPermiso.Core.Entities
{
  public class Permmisions : BaseEntity
    {
       
        [Key]

        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermmisionTypeId { get; set; }
        public DateTime PermmisionDate { get; set; }
        public PermmisionsType PermmisionsType { get; set; }
    }
}
