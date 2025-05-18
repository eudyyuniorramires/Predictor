namespace Predictor.ViewModels
{
    public class PredictionModeViewModel
    {
        public string SelectedMode { get; set; }
        public List<string> AvailableModes { get; } = new List<string>
    {
        "Media Móvil Simple (SMA) Crossover",
        "Regresión Lineal",
        "Momentum (ROC)"
    };
    }
}
