using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Remitente:Persona
    {
        public string Departamento { get; set; }
        public Remitente() { }

        public Remitente(string departamento, string identificacion, string nombre, string telefono)
            :base(identificacion,nombre,telefono)
        {
            Departamento = departamento;
        }
        override
        public string ToString()
        {
            return $"{base.ToString()}\n\tDepartamento: {Departamento}";
        }
    }
}
