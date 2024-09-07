using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Servicio
    {
        protected double Valor_Base {  get; set; }
        private bool DHL { get; set; }
        protected int Cantidad { get; set; }
        protected double Peso { get; set; }
        private string Descripcion { get; set; }
        protected double LiquidacionTotal { get; set; }
        public Servicio()
        {
            Valor_Base = 5000;
            LiquidacionTotal = 0;
        }
        public Servicio(bool dHL, int cantidad, double peso, string descripcion)
        { 
            LiquidacionTotal = 0;
            Valor_Base = 5000;
            DHL = dHL;
            Cantidad = cantidad;
            Peso = peso;
            Descripcion = descripcion;
        }
        public abstract void CalcularLiquidacion();
        public void AumentarxInternacional()
        {
            LiquidacionTotal *= 1.25;
        }
        public bool getDHL()
        {
            return DHL;
        }
        public void setValorBase(double vb)
        {
            Valor_Base = vb;
        }
        
        public override string ToString()
        {
            return $"\n\tValor Base: {Valor_Base} \n\tDHL: {DHL} \n\tCantidad: {Cantidad} \n\tPeso: {Peso} " +
                $"\n\tDescripcion: {Descripcion} \n\tLiquidacion Total: {LiquidacionTotal}";
        }
    }
}
