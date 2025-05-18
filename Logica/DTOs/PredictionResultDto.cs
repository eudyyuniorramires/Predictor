using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTOs
{
    public class PredictionResultDto
    {
        public string PredictionMode { get; set; }
        public string Trend { get; set; }
        public decimal? PredictedValue { get; set; }
        public decimal? ShortTermSMA { get; set; }
        public decimal? LongTermSMA { get; set; }
        public double? Slope { get; set; }
        public List<RocResultDto> RocResults { get; set; }
    }
}
