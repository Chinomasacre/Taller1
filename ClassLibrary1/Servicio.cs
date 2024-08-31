using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Servicio
    {
        public double Valor_Base {  get; set; }
        public bool DHL { get; set; }
        public int Cantidad { get; set; }
        public double Peso { get; set; }
        public string Descripcion { get; set; }
        public double LiquidacionTotal { get; set; }
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
        public void AumentarxInternacional()
        {
            LiquidacionTotal *= 1.25;
        }
        public abstract double CalcularLiquidacion();
    }
}
