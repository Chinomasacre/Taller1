using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Caja:Servicio
    {
        private double Tarifa { get; set; }

        public Caja()
        {
            Tarifa = 25000;
        }
        public Caja(bool dHL, int cantidad, double peso, string descripcion)
            : base(dHL, cantidad, peso, descripcion)
        {
            Tarifa = 25000;
        }

        public override void CalcularLiquidacion()
        {
            LiquidacionTotal = Valor_Base * Peso + Tarifa;
        }
        override
        public string ToString()
        {
            return $"\n\tTarifa: {Tarifa} {base.ToString()}";
        }
    }
}
