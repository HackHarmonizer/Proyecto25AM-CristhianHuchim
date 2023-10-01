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
    public class FacturaResponse
    {
        [Required]
        public string RazonSocial { get; set; }

        [Required]
        public string Fecha { get; set; }

        [Required]
        public string RFC { get; set; }

        public int FkCliente { get; set; }
    }
}
