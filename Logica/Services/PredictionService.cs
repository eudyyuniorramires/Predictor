using Logica.DTOs;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Services
{
    public class PredictionService : IPredictionService
    {
        public PredictionResultDto CalculateSMACrossover(List<DataDto> assetData)
        {
            if (assetData == null || assetData.Count != 20)
                throw new ArgumentException("Se requieren exactamente 20 valores");

            var orderedData = assetData.OrderBy(d => d.Date).ToList();

            var shortTermValues = orderedData.TakeLast(5).Select(d => d.Value);
            var longTermValues = orderedData.Select(d => d.Value);

            var shortTermSMA = shortTermValues.Average();
            var longTermSMA = longTermValues.Average();

            return new PredictionResultDto
            {
                PredictionMode = "Media Móvil Simple (SMA) Crossover",
                ShortTermSMA = shortTermSMA,
                LongTermSMA = longTermSMA,
                Trend = shortTermSMA > longTermSMA ? "Alcista" : "Bajista"
            };
        }

        public PredictionResultDto CalculateLinearRegression(List<DataDto> assetData)
        {
            if (assetData == null || assetData.Count != 20)
                throw new ArgumentException("Se requieren exactamente 20 valores");

            var orderedData = assetData.OrderBy(d => d.Date).ToList();
            var n = orderedData.Count;

            // Asignar valores X (días) e Y (valores)
            var xValues = Enumerable.Range(1, n).Select(x => (double)x).ToArray();
            var yValues = orderedData.Select(d => (double)d.Value).ToArray();

            // Calcular sumatorias
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                sumX += xValues[i];
                sumY += yValues[i];
                sumXY += xValues[i] * yValues[i];
                sumX2 += xValues[i] * xValues[i];
            }

            // Calcular pendiente (m) e intercepto (b)
            var m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            var b = (sumY - m * sumX) / n;

            // Predecir para el día n+1
            var nextDay = n + 1;
            var predictedValue = m * nextDay + b;

            return new PredictionResultDto
            {
                PredictionMode = "Regresión Lineal",
                PredictedValue = (decimal)predictedValue,
                Slope = m,
                Trend = m > 0 ? "Alcista" : "Bajista"
            };
        }

        public PredictionResultDto CalculateMomentumROC(List<DataDto> assetData)
        {
            if (assetData == null || assetData.Count != 20)
                throw new ArgumentException("Se requieren exactamente 20 valores");

            const int period = 5;
            var orderedData = assetData.OrderBy(d => d.Date).ToList();
            var results = new List<RocResultDto>();

            for (int i = 0; i < orderedData.Count; i++)
            {
                var current = orderedData[i];
                var result = new RocResultDto
                {
                    Day = i + 1,
                    Date = current.Date,
                    Price = current.Value
                };

                if (i >= period)
                {
                    var pastPrice = orderedData[i - period].Value;
                    result.ROC = (current.Value / pastPrice - 1) * 100;
                }

                results.Add(result);
            }

            return new PredictionResultDto
            {
                PredictionMode = "Momentum (ROC)",
                RocResults = results
            };
        }
    }
}

