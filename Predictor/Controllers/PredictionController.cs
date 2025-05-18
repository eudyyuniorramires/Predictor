using Microsoft.AspNetCore.Mvc;
using Predictor.ViewModels;
using static Logica.Models.PredictionModeSinglenton;

namespace Predictor.Controllers
{
    public class PredictionController : Controller
    {
        private readonly PredictionModeSingleton _predictionMode;

        public PredictionController(PredictionModeSingleton predictionMode)
        {
            _predictionMode = predictionMode;
        }

        public IActionResult Modes()
        {
            var model = new PredictionModeViewModel
            {
                SelectedMode = _predictionMode.SelectedMode
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SetMode(PredictionModeViewModel model)
        {
            _predictionMode.SelectedMode = model.SelectedMode;
            return RedirectToAction("Index", "Home");
        }
    }
}
