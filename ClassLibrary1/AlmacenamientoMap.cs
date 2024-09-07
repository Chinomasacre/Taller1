using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlmacenamientoMap : IAlmacenamientoGuia
    {
        private Dictionary<int, Guia> _Guias { get; set; }

        public AlmacenamientoMap() 
        {
            _Guias = new Dictionary<int, Guia>();
        }
        public AlmacenamientoMap(List<Guia> guias)
        {
            _Guias = new Dictionary<int, Guia>();

            foreach (var guia in guias)
            {
                _Guias.Add(guia.getNoGuia(), guia);
            }

        }
        public void  AlmacenarGuia(Guia guia)
        {
            _Guias.Add(guia.getNoGuia(), guia);
        }


        public Guia ConsultarGuiaExistencia(int NoGuia)
        {
            return _Guias.TryGetValue(NoGuia, out Guia guia) ? guia : null;
        }
        public IEnumerable<Guia> getGuias()
        {
            return _Guias.Values;
        }
    }
}
