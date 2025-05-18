using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SmaService : IPrediccioneService
    {
        public PrediccionResultadoDto Calcular(List<ValorHistoricoDto> valores)
        {
            //Validamos si los valores para calcular la prediccion son correctos en cantidad 
            if (valores == null || valores.Count != 20) 
            {
                //Mandame un erro en el caso de que no lo sea 
                throw new ArgumentException("La lista de valores tiene que ser 20");
            
            }

            string Mensaje; 

            //organizamos los valores para que esten ordenados por fecha 
            var organizar = valores.OrderBy(x => x.Fecha).ToList();

            //Tomanos los 5 primeros valores para calcular sma corta
            var smaCorta = organizar.Take(5).Average(x => x.Valor);

            //Tomamos los 5 primeros valores para calcular sma larga
            var smaLarga = organizar.Average(x => x.Valor);

            //Hacemos las comparaciones para ver si las tendencias son alcistas o bajistas 
            if (smaCorta > smaLarga) 
            {
                Mensaje = "La tendencia es alcista";
            }
            else if(smaCorta < smaLarga)
            {

                Mensaje = "La tendencia es bajista";
            }
            else
            {
                Mensaje = "No hay tendencia definida";  
            }



            return new PrediccionResultadoDto
            {

                
                MetodoUsado = 0, //SMA

                Mensaje = Mensaje,

                Valor1 = smaCorta,

                Valor2 = smaLarga,

  


            };






        }
    }
}
