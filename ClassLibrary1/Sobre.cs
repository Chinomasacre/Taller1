using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sobre:Servicio
    {
        private double Tarifa { get; set; }
        public Sobre()
        {
            Tarifa = 10000;
        }
        public Sobre(bool dHL, int cantidad, double peso, string descripcion)
             : base(dHL,cantidad,peso, descripcion) // super
        {
            
            Tarifa = 10000;
        }
        public void setTarifa(double tarifa)
        {
            Tarifa = tarifa;
        }
        public override void CalcularLiquidacion()
        {
            LiquidacionTotal = Valor_Base + Tarifa;
        }     
        public override string ToString()
        {
            return $"\n\tTarifa: {Tarifa} {base.ToString()}";
        }
    }
}
