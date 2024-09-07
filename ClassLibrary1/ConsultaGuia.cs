using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ConsultaGuia:IConsultaGuia
    {

        protected IEnumerable<Guia> Guias;
        public ConsultaGuia(IEnumerable<Guia> guias)
        {
            Guias = guias;
        }
        public IEnumerable<Guia> ConsultarGuiaRemitente(string Identificacion)
        {
            return Guias.Where(g => g.getRemitente().getIdentificacion() == Identificacion).ToList();
        }

        public IEnumerable<Guia> ConsultarGuiaEstado(string estado)
        {
            return Guias.Where(g => g.getEstado() == estado).ToList();
        }
    }
}
