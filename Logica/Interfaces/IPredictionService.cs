using Logica.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IPredictionService
    {
        PredictionResultDto CalculateSMACrossover(List<DataDto> assetData);
        PredictionResultDto CalculateLinearRegression(List<DataDto> assetData);
        PredictionResultDto CalculateMomentumROC(List<DataDto> assetData);
    }
}
