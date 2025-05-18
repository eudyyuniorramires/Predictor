using Logica.DTOs;

namespace Predictor.ViewModels
{
    public class PredictionResultViewModel
    {
        public PredictionResultDto Result { get; set; }
        public List<DataDto> InputData { get; set; }
    }
}
