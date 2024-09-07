using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlmacenamientoLista:IAlmacenamientoGuia
    {
        private List<Guia> _Guias;

        public AlmacenamientoLista()
        {

            _Guias = new List<Guia>();
        }
        public AlmacenamientoLista(List<Guia> guias)
        {
            _Guias = guias;
        }

        public void AlmacenarGuia(Guia guia)
        {
            _Guias.Add(guia);
        }

        public Guia ConsultarGuiaExistencia(int NoGuia)
        {
            return _Guias.FirstOrDefault(g => g.getNoGuia() == NoGuia);
        }
        public IEnumerable<Guia> getGuias()
        {
            return _Guias;
        }

    }
}
