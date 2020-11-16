using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPermiso.Core.Dtos
{
   public class UpdatePermmisionsDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string PermmisionTypeId { get; set; }
        public DateTime PermmisionDate { get; set; }
    }
}
