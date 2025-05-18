using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PrediccionResultadoDto
    {

        public int MetodoUsado { get; set; }
        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public string Mensaje { get; set; }
    }
}
