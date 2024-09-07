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
        private int NoEnvio { get; set; }
        private string Fecha { get; set; }
        private string Estado { get; set; }
        private Servicio Servicio { get; set; }
        private Persona Remitente { get; set; }
        private Persona Destinatario { get; set; }
        public Guia()
        {
        }
        public Guia(int noEnvio, string fecha, Servicio servicio)
        {
            NoEnvio = noEnvio;
            Fecha = fecha;
            Estado = "DESPACHO";
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
        public int getNoGuia()
        {
            return NoEnvio;
        }
        public string getEstado()
        {
            return Estado;
        }

        public void setEstado(string estado)
        {
            Estado = estado;
        }
        public Persona getRemitente()
        {
            return Remitente;
        }
        
        public string ObtenerDatos() 
        {
            return $"No Envio: {NoEnvio} \nFecha: {Fecha} \nEstado: {Estado} \nTipo De Servicio: {Servicio.GetType().Name} \nDatos del Servicio: {Servicio.ToString()}" +
                $"\nDatos del Remitente: {Remitente.ToString()} \nDatos del Destinatario {Destinatario.ToString()}";
        }
    }
}
