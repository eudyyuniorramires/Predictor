using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
   
    public class PrediccionViewModel
    {
        public List<DateTime> Fechas { get; set; } = new List<DateTime>(new DateTime[19]);
        public List<decimal> Valores { get; set; } = new List<decimal>(new decimal[19]);

        public int Modo = 0;
       
      
        public PrediccionResultadoDto Resultado { get; set; }

        
    }
}
