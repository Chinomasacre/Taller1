using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        private string Identificacion { get; set; }
        private string Nombre { get; set; }
        private string Telefono { get; set; }
        public Persona() { }

        public Persona(string identificacion, string nombre, string telefono)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Telefono = telefono;
        }

        public string getIdentificacion()
        {
            return Identificacion;
        }
        override
        public string ToString()
        {
            return $"\n\tIdentificacion: {Identificacion} \n\tNombre: {Nombre}\n\tTelefono: {Telefono}";
        }
    }
}
