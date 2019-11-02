using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Complejidad
{
    public class Coordenadas
    {
        public Coordenadas(double lon, double lat, string nombre)
        {
            this.lon = lon;
            this.lat = lat;
            this.nombre = nombre;
        }
        public double lon { get; set; }
        public double lat { get; set; }
        public string nombre { get; set; }
    }
    public class ArrCoordenadas
    {
        public List<Coordenadas> arreglo=new List<Coordenadas>();
        
        public void agregar(double X, double Y, string nombre)
        {
            arreglo.Add(new Coordenadas(X, Y, nombre));
        }
    }
}