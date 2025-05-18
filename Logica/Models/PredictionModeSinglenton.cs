using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class PredictionModeSinglenton
    {
        public sealed class PredictionModeSingleton
        {
            // Instancia única protegida por bloqueo
            private static PredictionModeSingleton _instance;
            private static readonly object _lock = new object();

            // Modos disponibles
            public List<string> AvailableModes { get; } = new List<string>
        {
            "Media Móvil Simple (SMA) Crossover",
            "Regresión Lineal",
            "Momentum (ROC)"
        };

            // Modo seleccionado (con valor por defecto)
            public string SelectedMode { get; set; } = "Media Móvil Simple (SMA) Crossover";

            // Constructor privado para prevenir instanciación
            private PredictionModeSingleton() { }

            // Propiedad para acceder a la instancia singleton
            public static PredictionModeSingleton Instance
            {
                get
                {
                    // Doble verificación para mejorar el rendimiento
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new PredictionModeSingleton();
                            }
                        }
                    }
                    return _instance;
                }
            }

            // Método para cambiar el modo
            public void SetMode(string mode)
            {
                if (!AvailableModes.Contains(mode))
                    throw new ArgumentException("Modo no válido");

                SelectedMode = mode;
            }
        }

    }
}
