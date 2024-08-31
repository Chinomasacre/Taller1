using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Destinatario:Persona
    {
        public string Compañia {  get; set; }
        public string Direccion { get; set; }
        public Destinatario() { }
        public Destinatario(string compañia, string direccion,
            string identificacion, string nombre, string telefono)
            : base(identificacion, nombre, telefono)
        {
            Compañia = compañia;
            Direccion = direccion;
        }
    }
}
