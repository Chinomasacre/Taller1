using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public Persona() { }

        public Persona(string identificacion, string nombre, string telefono)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
