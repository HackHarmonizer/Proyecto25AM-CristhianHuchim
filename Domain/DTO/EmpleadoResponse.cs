using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class EmpleadoResponse
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        
        public int? FkPuesto { get; set; }
        public int? FKDepartamento { get; set; }

    }
}
