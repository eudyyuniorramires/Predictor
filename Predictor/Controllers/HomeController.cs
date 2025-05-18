using Logica.DTOs;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Predictor.Models;
using Predictor.ViewModels;
using System.Diagnostics;
using static Logica.Models.PredictionModeSinglenton;

namespace Predictor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPredictionService _predictionService;
        private readonly PredictionModeSingleton _predictionMode;

        public HomeController(
            IPredictionService predictionService,
            PredictionModeSingleton predictionMode)
        {
            _predictionService = predictionService;
            _predictionMode = predictionMode;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentMode = _predictionMode.SelectedMode;
            return View(new AssetInputViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(AssetInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CurrentMode = _predictionMode.SelectedMode;
                return View("Index", model);
            }

            var assetData = ParseInputData(model.RawData);
            PredictionResultDto result;

            switch (_predictionMode.SelectedMode)
            {
                case "Regresión Lineal":
                    result = _predictionService.CalculateLinearRegression(assetData);
                    break;
                case "Momentum (ROC)":
                    result = _predictionService.CalculateMomentumROC(assetData);
                    break;
                default:
                    result = _predictionService.CalculateSMACrossover(assetData);
                    break;
            }

            var viewModel = new PredictionResultViewModel
            {
                Result = result,
                InputData = assetData
            };

            return View("Result", viewModel);
        }

        private List<DataDto> ParseInputData(string rawData)
        {
            var lines = rawData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var result = new List<DataDto>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length != 2) continue;

                if (DateTime.TryParse(parts[0].Trim(), out var date) &&
                    decimal.TryParse(parts[1].Trim(), out var value))
                {
                    result.Add(new DataDto { Date = date, Value = value });
                }
            }

            return result.OrderBy(d => d.Date).ToList();
        }
    }
}
