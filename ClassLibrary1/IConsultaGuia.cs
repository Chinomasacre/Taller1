using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IConsultaGuia
    {
        IEnumerable<Guia> ConsultarGuiaRemitente(string Identificacion);
        IEnumerable<Guia> ConsultarGuiaEstado(string estado);
    }
}
