using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistemaPermiso.Core.Entities
{
   public class PermmisionsType : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Description { get; set; }
        public List<Permmisions> Permmisions { get; set; }
    }
}
