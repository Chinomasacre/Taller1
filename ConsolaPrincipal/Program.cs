using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ConsolaPrincipal
{
    public class Program
    {
        public static List<Guia> guias;
        static void Main(string[] args)
        {
            guias = new List<Guia>();
            // Menú principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMenú Guias:");
                Console.WriteLine("1. Registrar Guias");
                Console.WriteLine("2. Registro de Entrega");
                Console.WriteLine("3. Consultar Guias");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Registrarguias();

                        break;
                    case 2:
                        RegistroEntrgas();
                        break;
                    case 3:
                        ConsultarGuias();

                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
        public static void Registrarguias()
        {
            Console.Clear();
            Console.WriteLine("\nIngreso de datos de la guia");
            Guia guia = new Guia();
            Console.Write("Ingrese el número de envío: ");
            int NoEnvio = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la fecha (dd/MM/yyyy): ");
            string Fecha = Console.ReadLine();

            // Crear un Destinatario
            Console.WriteLine("\nIngreso de datos del Destinatario");
            Console.Write("Ingrese la identificación: ");
            string identificacionD = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombreD = Console.ReadLine();
            Console.Write("Ingrese la compañia: ");
            string compañia = Console.ReadLine();
            Console.Write("Ingrese la Direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el teléfono: ");
            string telefonoD = Console.ReadLine();

            // Crear un Remitente
            Console.WriteLine("\nIngreso de datos del Remitente");
            Console.Write("Ingrese la identificación: ");
            string identificacionR = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombreR = Console.ReadLine();
            Console.Write("Ingrese el departamento: ");
            string departamento = Console.ReadLine();
            Console.Write("Ingrese el teléfono: ");
            string telefonoR = Console.ReadLine();


            // Datos del paquete
            Servicio servicio;
            Console.WriteLine("Datos del Servicio:");
            Console.WriteLine("1. Sobre");
            Console.WriteLine("2. Paquete");
            Console.WriteLine("3. Caja");
            Console.Write("Seleccione el tipo de paquete: ");
            int tipoPaquete = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Peso");
            double Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Cantidad");
            int Cantidad = int.Parse(Console.ReadLine());
            Console.WriteLine("DHL(internacional):");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");

            int tipodhl = int.Parse(Console.ReadLine());
            bool dHL;
            if (tipodhl == 1)
            {
                dHL = true;
            }
            else
            {
                dHL = false;
            }
            Console.WriteLine("Ingrese Descripcion");
            string Descripcion = Console.ReadLine();

            
            if (tipoPaquete == 1)
            {
                servicio = new Sobre(dHL, Cantidad, Peso, Descripcion);
            }
            else if (tipoPaquete == 2)
            {
                servicio = new Paquete(dHL, Cantidad, Peso, Descripcion);
            }
            else
            {
                servicio = new Caja(dHL, Cantidad, Peso, Descripcion);
            }
            servicio.CalcularLiquidacion();

            if (servicio.DHL)
            {
                servicio.AumentarxInternacional();
            }

            guia = new Guia(NoEnvio, Fecha, servicio);
            guia.CrearDestinatario(compañia, direccion, identificacionD, nombreD, telefonoD);
            guia.CrearRemitente(departamento, identificacionR, nombreR, nombreD);

            guias.Add(guia);

            Console.WriteLine("Guardado Correctamente");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        public static void RegistroEntrgas()
        {
            Console.Clear();
            Console.WriteLine("\nCambiar estado de entrega:");
            Console.WriteLine("Ingrese No Envio: ");
            int NoEnvio = int.Parse(Console.ReadLine());

            Guia guia = null;
            foreach(Guia g in guias)
            {
                if(g.NoEnvio == NoEnvio)
                {
                    guia = g;
                    break;
                }
            }
            if (guia  == null)
            {
                Console.WriteLine("No se encontro guia ");
            }
            else
            {
                Console.WriteLine($"No Envio: {guia.NoEnvio}");
                Console.WriteLine($"Feacha: {guia.Fecha}");
                Console.WriteLine($"Estado: {guia.Estado}");
                Console.WriteLine("Cambiar estado a 'FINALIZADA'?¿");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    guia.CambiarEstado("FINALIZADA");
                    Console.WriteLine($"Estado Cambiado");
                }
                else
                {
                    Console.WriteLine($"Estado queda igual");
                }
            }
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        public static void ConsultarGuias()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\nConsultar Guias:");
                Console.WriteLine("1. Por Estado");
                Console.WriteLine("2. Destinatario");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nConsultar por estado:");
                        Console.WriteLine("1. Finalizado");
                        Console.WriteLine("2. En proceso");
                        Console.Write("Seleccione una opción: ");
                        int op = int.Parse(Console.ReadLine());
                        if(op == 1)
                        {
                            foreach(Guia g in guias)
                            {
                                if(g.Estado == "FINALIZADA")
                                {
                                    Pintar(g);
                                }
                            }
                        }
                        else
                        {
                            foreach (Guia g in guias)
                            {
                                if (g.Estado != "FINALIZADA")
                                {
                                    Pintar(g);
                                }
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar por remitente:");
                        Console.Write("Ingrese Identificacion: ");
                        string idR = Console.ReadLine();
                        foreach (Guia g in guias)
                        {
                            if (g.Remitente.Identificacion == idR)
                            {
                                Pintar(g);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Saliendo de consultas...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            } while(opcion != 3);
           
        }
        public static void Pintar(Guia g)
        {
            Console.WriteLine($"NoEnvio: {g.NoEnvio}");
            Console.WriteLine($"Fecha: {g.Fecha}");
            Console.WriteLine($"Servicio: {g.Servicio}");
            Console.WriteLine($"Compañia: {g.Destinatario.Compañia}");
            Console.WriteLine($"Direccion: {g.Destinatario.Direccion}");
            Console.WriteLine($"Identificacion Destinatario: {g.Destinatario.Identificacion}");
            Console.WriteLine($"Nombre Destinatario: {g.Destinatario.Nombre}");
            Console.WriteLine($"Telefono Destinatario: {g.Destinatario.Telefono}");
            Console.WriteLine($"Departamento Remitente: {g.Remitente.Departamento}");
            Console.WriteLine($"Identificacion Remitente: {g.Remitente.Identificacion}");
            Console.WriteLine($"Nombre Remitente: {g.Remitente.Nombre}");
            Console.WriteLine($"Estado: {g.Estado}");
            Console.WriteLine();
        }
    }
}
