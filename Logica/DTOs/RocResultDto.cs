using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTOs
{
    public class RocResultDto
    {
        public int Day { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal? ROC { get; set; }
    }
}
