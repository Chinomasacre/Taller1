using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paquete : Servicio
    {
        public Paquete()
        {
        }

        public Paquete( bool dHL, int cantidad, double peso, string descripcion)
            : base(dHL, cantidad, peso, descripcion)
        {
        }

        public override double CalcularLiquidacion()
        {
            LiquidacionTotal = Valor_Base * Peso;

            return LiquidacionTotal;
        }
    }
}
