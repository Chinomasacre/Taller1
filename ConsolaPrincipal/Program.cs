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
        public static IAlmacenamientoGuia almacenamiento = new AlmacenamientoSet();
        public static IConsultaGuia guiaConsultador = new ConsultaGuia(almacenamiento.getGuias());
        public static GestionGuias gestion = new GestionGuias(almacenamiento, guiaConsultador);
        public static void Main(string[] args)
        {
            // Menú principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMenú Guias:");
                Console.WriteLine("1. Registrar Guias");
                Console.WriteLine("2. Registro de Entrega");
                Console.WriteLine("3. Consultar Guias");
                Console.WriteLine("4. Registrar Guias Automaticamente");
                Console.WriteLine("5. Consultar Todos");
                Console.WriteLine("6. Salir");
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
                    case 4:
                        Servicio servicio1 = new Sobre(true, 10, 15.5, "Envío internacional de documentos");
                        servicio1.CalcularLiquidacion();

                        if (servicio1.getDHL())
                        {
                            servicio1.AumentarxInternacional();
                        }
                        Servicio servicio2 = new Paquete(false, 5, 7.2, "Paquete nacional pequeño");
                        servicio2.CalcularLiquidacion();

                        if (servicio2.getDHL())
                        {
                            servicio2.AumentarxInternacional();
                        }
                        Servicio servicio3 = new Caja(true, 20, 25.3, "Carga pesada internacional");
                        servicio3.CalcularLiquidacion();

                        if (servicio3.getDHL())
                        {
                            servicio3.AumentarxInternacional();
                        }

                        Guia guia1 = new Guia(1, "2024-09-07", servicio1);
                        guia1.CrearRemitente("Tecnología", "123", "Juan Pérez", "123-456-789");
                        guia1.CrearDestinatario("Compañía A", "Av. Siempre Viva 123", "123", "Maria López", "987-654-321");
                        gestion.GuardarGuia(guia1);

                        Guia guia2 = new Guia(2, "2024-09-08", servicio2);
                        guia2.CrearRemitente("Ventas", "456", "Luis Martínez", "234-567-890");
                        guia2.CrearDestinatario("Compañía B", "Calle Falsa 456", "456", "Ana Rodríguez", "876-543-210");
                        gestion.GuardarGuia(guia2);

                        Guia guia3 = new Guia(3, "2024-09-09", servicio3);
                        guia3.CrearRemitente("Administración", "789", "Carlos Gómez", "345-678-901");
                        guia3.CrearDestinatario("Compañía C", "Plaza Mayor 789", "789", "Laura Fernández", "765-432-109");
                        gestion.GuardarGuia(guia3);

                        Console.WriteLine("Registros Exitosamente");
                        Console.ReadKey();
                        break;
                    case 5:
                        foreach (Guia g in gestion.ConsultarGuias())
                        {
                            Console.WriteLine(g.ObtenerDatos());
                            Console.WriteLine("-----------");
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
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

            if (servicio.getDHL())
            {
                servicio.AumentarxInternacional();
            }

            guia = new Guia(NoEnvio, Fecha, servicio);
            guia.CrearDestinatario(compañia, direccion, identificacionD, nombreD, telefonoD);
            guia.CrearRemitente(departamento, identificacionR, nombreR, nombreD);

            gestion.GuardarGuia(guia);

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

            Guia guia = gestion.ConsultarGuiaExistencia(NoEnvio);
            
            if (guia == null)
            {
                Console.WriteLine("No se encontro guia ");
            }
            else
            {
                Console.WriteLine($"Datos de GUia: {guia.ObtenerDatos()}");
                Console.WriteLine("Cambiar estado a 'FINALIZADA'?¿");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                Console.Write("Selecciones Opcion: ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    guia.setEstado("FINALIZADA");
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
                        Console.WriteLine("2. En Despacho");
                        Console.Write("Seleccione una opción: ");
                        int op = int.Parse(Console.ReadLine());
                        if(op == 1)
                        {
                            foreach (Guia g in gestion.ConsultarGuiaEstado("FINALIZADA"))
                            {
                                
                                Console.WriteLine(g.ObtenerDatos());
                                Console.WriteLine("-----------");

                            }
                        }
                        else
                        {
                            foreach (Guia g in gestion.ConsultarGuiaEstado("DESPACHO"))
                            {
                                Console.WriteLine(g.ObtenerDatos());
                                Console.WriteLine("-----------");

                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar por remitente:");
                        Console.Write("Ingrese Identificacion: ");
                        string idR = Console.ReadLine();
                        foreach (Guia g in gestion.ConsultarGuiaRemitente(idR))
                        {
                                Console.WriteLine(g.ObtenerDatos());
                                Console.WriteLine("-----------");
                          
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
        
    }
}
