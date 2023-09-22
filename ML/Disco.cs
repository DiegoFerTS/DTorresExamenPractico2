using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
		public string GeneroMusical { get; set; }
        public double Duracion { get; set; }
        public DateTime Anio { get; set; }
        public string Distribuidora { get; set; }
        public int Ventas { get; set; }
        public bool Disponibilidad { get; set; }
        public List<object> Discos { get; set; }

    }
}
