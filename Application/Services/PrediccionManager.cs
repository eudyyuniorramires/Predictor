using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PrediccionManager 
    {

        public static IPrediccioneService seleccionModo(int tipo) 
        {

            switch (tipo)
            {
                case 0:
                    return new SmaService();
                case 1:
                    return new RegresionLinealService();
                case 2:
                    return new MomentumService();
                default:
                    throw new ArgumentException("Tipo de predicción no válido");
            }

        }


    }
}
