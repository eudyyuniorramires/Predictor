using System.ComponentModel.DataAnnotations;

namespace Predictor.ViewModels
{
    public class AssetInputViewModel
    {
        [Required(ErrorMessage = "Debe ingresar datos históricos")]
        [RegularExpression(@"^(\d{4}-\d{2}-\d{2},\s\d+\.\d{2}(\r?\n|\r)){19}\d{4}-\d{2}-\d{2},\s\d+\.\d{2}$",
            ErrorMessage = "Formato incorrecto. Requiere 20 líneas con formato: YYYY-MM-DD, 123.45")]
        public string RawData { get; set; }

        // Validación alternativa para inputs individuales
      
        public List<DateTime> Dates { get; set; } = new List<DateTime>();

        public List<decimal> Values { get; set; } = new List<decimal>();
    }
}