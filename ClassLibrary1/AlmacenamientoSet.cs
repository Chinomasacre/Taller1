using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlmacenamientoSet : IAlmacenamientoGuia
    {
        private HashSet<Guia> _Guias;

        public AlmacenamientoSet()
        {
            _Guias = new HashSet<Guia>();
        }

        public AlmacenamientoSet(HashSet<Guia> guias)
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
