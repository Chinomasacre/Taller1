using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GestionGuias
    {
        private readonly IAlmacenamientoGuia Almacenamiento;
        private readonly IConsultaGuia Consulta;

        public GestionGuias(){}

        public GestionGuias(IAlmacenamientoGuia almacenamiento, IConsultaGuia consulta)
        {
            Almacenamiento = almacenamiento;
            Consulta = consulta;
        }

        public void GuardarGuia(Guia guia)
        {
            Almacenamiento.AlmacenarGuia(guia);
        }

        public IEnumerable<Guia> ConsultarGuiaRemitente(string Identificacion)
        {
            return Consulta.ConsultarGuiaRemitente(Identificacion);
        }

        public IEnumerable<Guia> ConsultarGuiaEstado(string estado)
        {
            return Consulta.ConsultarGuiaEstado(estado);
        }
        public Guia ConsultarGuiaExistencia(int NoGuia)
        {
            return Almacenamiento.ConsultarGuiaExistencia(NoGuia);
        }
        public IEnumerable<Guia> ConsultarGuias()
        {
            return Almacenamiento.getGuias();
        }

    }
}
