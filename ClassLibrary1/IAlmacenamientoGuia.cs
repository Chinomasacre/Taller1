using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IAlmacenamientoGuia
    {
        void AlmacenarGuia(Guia guia);
        Guia ConsultarGuiaExistencia(int NoGuia);
        IEnumerable<Guia> getGuias();
    }
}
