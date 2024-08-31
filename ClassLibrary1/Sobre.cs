using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sobre:Servicio
    {
        public double Tarifa { get; set; }
        public Sobre()
        {
            Tarifa = 10000;
        }
        public Sobre(bool dHL, int cantidad, double peso, string descripcion)
             : base(dHL,cantidad,peso, descripcion) // super
        {
            
            Tarifa = 10000;
        }

        public override double CalcularLiquidacion()
        {
            LiquidacionTotal = Valor_Base + Tarifa;
            return LiquidacionTotal;
        }
    }
}
