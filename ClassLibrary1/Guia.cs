using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Guia
    {
        public int NoEnvio { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public Servicio Servicio { get; set; }
        public Remitente Remitente { get; set; }
        public Destinatario Destinatario { get; set; }
        public Guia()
        {
        }
        public Guia(int noEnvio, string fecha, Servicio servicio)
        {
            NoEnvio = noEnvio;
            Fecha = fecha;
            Estado = "Despacho";
            Servicio = servicio;
        }
        public void CrearRemitente(string departamento, string identificacion, string nombre, string telefono)
        {
            Remitente = new Remitente(departamento, identificacion, nombre, telefono);
        }
        public void CrearDestinatario(string compañia, string direccion,
            string identificacion, string nombre, string telefono)
        {
            Destinatario = new Destinatario(compañia, direccion, identificacion, nombre, telefono);
        }
        public void CambiarEstado(string estado)
        {
            Estado = estado;
        }
    }
}
