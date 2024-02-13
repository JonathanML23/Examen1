// See https://aka.ms/new-console-template for more information
//Examen hecho por Jonathan David Muñoz Lopez
//Primer examen de programacion 2

using System;

class Program
{
    static int[] numeroFactura = new int[15];
    static string[] numeroPlaca = new string[15];
    static string[] fecha = new string[15];
    static string[] hora = new string[15];
    static int[] tipoVehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static double[] montoPagar = new double[15];
    static string[] pagaCon = new string[15];
    static double[] vuelto = new double[15];
    static int contador = 0;

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("Menú Principal del Sistema:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por número de Placa");
            Console.WriteLine("4. Modificar Datos Vehículos por número de Placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");
            Console.WriteLine("Ingrese su opción:");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;
                    case 2:
                        IngresarPasoVehicular();
                        break;
                    case 3:
                        ConsultaVehiculosPorPlaca();
                        break;
                    case 4:
                        ModificarDatos();
                        break;
                    case 5:
                        ReporteTodosLosDatos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del registro de vehiculos, muchas gracias por usar el programa");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, por favor ingrese una opción válida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor ingrese un número válido");
            }

        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        numeroFactura = new int[15];
        numeroPlaca = new string[15];
        fecha = new string[15];
        hora = new string[15];
        tipoVehiculo = new int[15];
        numeroCaseta = new int[15];
        montoPagar = new double[15];
        pagaCon = new string[15];
        vuelto = new double[15];
        Console.WriteLine();
        Console.WriteLine("Vectores inicializados correctamente");
        Console.WriteLine("Digite cualquier tecla para continuar");
        Console.ReadKey();
        Console.Clear();
    }

    static void IngresarPasoVehicular()
    {
        Console.Clear();
        string continuar = "S"; // Inicializamos la variable en S para que entre al bucle

        while (continuar.ToUpper() == "S")
        {
            Console.WriteLine("REGISTRAR FLUJO VEHICULAR");
            Console.Write("Numero Factura: ");
            numeroFactura[contador] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Numero PLACA: ");
            numeroPlaca[contador] = Console.ReadLine();

            Console.Write("Fecha: ");
            fecha[contador] = Console.ReadLine();

            Console.Write("Hora: ");
            hora[contador] = Console.ReadLine();

            int tipo;
            do
            {
                Console.WriteLine("Tipo de vehículo: ");
                Console.WriteLine("[1= Moto  2= Vehículo Liviano  3=Camión o Pesado  4=Autobús]");
                tipo = Convert.ToInt32(Console.ReadLine());

                if (tipo < 1 || tipo > 4)
                {
                    Console.WriteLine("Error: Por favor ingrese un tipo de vehículo válido (1 a 4)");
                }
            } while (tipo < 1 || tipo > 4);
            tipoVehiculo[contador] = tipo;

            int caseta;
            do
            {
                Console.WriteLine("Numero caseta: ");
                Console.WriteLine("[1= caseta 1  2=caseta 2  3=caseta 3]");
                caseta = Convert.ToInt32(Console.ReadLine());

                if (caseta < 1 || caseta > 3)
                {
                    Console.WriteLine("Error: Por favor ingrese un número de caseta válido (1 a 3)");
                }
            } while (caseta < 1 || caseta > 3);
            numeroCaseta[contador] = caseta;

            // Asignar el monto a pagar según el tipo de vehículo
            switch (tipoVehiculo[contador])
            {
                case 1:
                    montoPagar[contador] = 500; // Monto para Motocicleta
                    break;
                case 2:
                    montoPagar[contador] = 700; // Monto para Vehículo Liviano
                    break;
                case 3:
                    montoPagar[contador] = 2700; // Monto para Camión o Pesado
                    break;
                case 4:
                    montoPagar[contador] = 3700; // Monto para Autobús
                    break;
                default:
                    Console.WriteLine("Tipo de vehículo inválido");
                    break;
            }

            Console.WriteLine("Monto a pagar: " + montoPagar[contador]);

            do
            {
                Console.Write("Paga con: ");
                pagaCon[contador] = Console.ReadLine();

                // Calcula el vuelto como la resta entre lo pagado y el monto correcto
                vuelto[contador] = Convert.ToDouble(pagaCon[contador]) - montoPagar[contador];

                if (vuelto[contador] < 0)
                {
                    Console.WriteLine("Error: El monto pagado es insuficiente. Intente nuevamente");
                }
            } while (vuelto[contador] < 0);

            Console.WriteLine("Vuelto: " + vuelto[contador]);

            contador++;

            Console.WriteLine("Desea continuar digite las teclas S/N?");
            continuar = Console.ReadLine();
            Console.Clear();
        }
    }

    // Método auxiliar para obtener el costo base según el tipo de vehículo
    static double ObtenerCostoBase(int tipoVehiculo)
    {
        switch (tipoVehiculo)
        {
            case 1:
                return 500; // Costo base para Motocicleta
            case 2:
                return 700; // Costo base para Vehículo Liviano
            case 3:
                return 2700; // Costo base para Camión o Pesado
            case 4:
                return 3700; // Costo base para Autobús
            default:
                return 0;
        }
    }

    static void ConsultaVehiculosPorPlaca()
    {
        Console.Clear();
        Console.WriteLine("Ingrese el número de placa a consultar: ");
        string placaConsulta = Console.ReadLine();

        bool encontrado = false;

        Console.WriteLine("Resultados de la consulta: ");

        for (int i = 0; i < contador; i++)
        {
            if (numeroPlaca[i] == placaConsulta)
            {
                encontrado = true;
                Console.WriteLine("Número Factura: " + numeroFactura[i]);
                Console.WriteLine("Numero PLACA: " + numeroPlaca[i]);
                Console.WriteLine("Fecha: " + fecha[i]);
                Console.WriteLine("Hora: " + hora[i]);
                Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                Console.WriteLine("Numero caseta: " + numeroCaseta[i]);
                Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                Console.WriteLine("Paga con: " + pagaCon[i]);
                Console.WriteLine("Vuelto: " + vuelto[i]);
                Console.WriteLine();
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron registros para el número de placa ingresado");
        }
    }


    static void ModificarDatos()
    {
        Console.Clear();
        Console.WriteLine("Ingrese el número de placa del vehículo a modificar: ");
        string placaConsulta = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (numeroPlaca[i] == placaConsulta)
            {
                encontrado = true;

                Console.WriteLine("Datos del vehículo encontrado:");
                Console.WriteLine("Número Factura: " + numeroFactura[i]);
                Console.WriteLine("Numero PLACA: " + numeroPlaca[i]);
                Console.WriteLine("Fecha: " + fecha[i]);
                Console.WriteLine("Hora: " + hora[i]);
                Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                Console.WriteLine("Numero caseta: " + numeroCaseta[i]);
                Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                Console.WriteLine("Paga con: " + pagaCon[i]);
                Console.WriteLine("Vuelto: " + vuelto[i]);

                Console.WriteLine("Seleccione el dato a modificar:");
                Console.WriteLine("1. Fecha");
                Console.WriteLine("2. Hora");
                Console.WriteLine("3. Tipo de vehículo");
                Console.WriteLine("4. Numero de caseta");
                Console.WriteLine("5. Paga con");
                Console.WriteLine("6. Salir");

                Console.Write("Opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese la nueva fecha: ");
                        fecha[i] = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese la nueva hora: ");
                        hora[i] = Console.ReadLine();
                        break;
                    case 3:
                        int tipo;
                        do
                        {
                            Console.WriteLine("Ingrese el nuevo tipo de vehículo:");
                            Console.WriteLine("[1= Moto  2= Vehículo Liviano  3=Camión o Pesado  4=Autobús]");
                            tipo = Convert.ToInt32(Console.ReadLine());

                            if (tipo < 1 || tipo > 4)
                            {
                                Console.WriteLine("Error: Por favor ingrese un tipo de vehículo válido (1 a 4)");
                            }
                        } while (tipo < 1 || tipo > 4);
                        tipoVehiculo[i] = tipo;

                        // Recalcular monto a pagar
                        switch (tipoVehiculo[i])
                        {
                            case 1:
                                montoPagar[i] = 500; // Monto para Motocicleta
                                break;
                            case 2:
                                montoPagar[i] = 700; // Monto para Vehículo Liviano
                                break;
                            case 3:
                                montoPagar[i] = 2700; // Monto para Camión o Pesado
                                break;
                            case 4:
                                montoPagar[i] = 3700; // Monto para Autobús
                                break;
                            default:
                                Console.WriteLine("Tipo de vehículo inválido");
                                break;
                        }
                        Console.WriteLine("Monto a pagar actualizado: " + montoPagar[i]);
                        break;
                    case 4:
                        int caseta;
                        do
                        {
                            Console.WriteLine("Ingrese el nuevo número de caseta: ");
                            Console.WriteLine("[1= caseta 1  2=caseta 2  3=caseta 3]");
                            caseta = Convert.ToInt32(Console.ReadLine());

                            if (caseta < 1 || caseta > 3)
                            {
                                Console.WriteLine("Error: Por favor ingrese un número de caseta válido (1 a 3)");
                            }
                        } while (caseta < 1 || caseta > 3);
                        numeroCaseta[i] = caseta;
                        break;
                    case 5:
                        Console.WriteLine("Ingrese la nueva cantidad pagada: ");
                        pagaCon[i] = Console.ReadLine();
                        // Recalcular vuelto
                        vuelto[i] = Convert.ToDouble(pagaCon[i]) - montoPagar[i];
                        Console.WriteLine("Vuelto actualizado: " + vuelto[i]);
                        break;
                    case 6:
                        Console.WriteLine("Saliendo de la parte de modificaciones");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Saliendo al menu principal");
                        break;
                }

                if (opcion == 6)
                {
                    break;
                }
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron registros para el número de placa ingresado");
        }
    }


    static void ReporteTodosLosDatos()
    {
        Console.Clear();
        Console.WriteLine("N# factura\tPlaca\t\tTipo de vehículo\tCaseta\tMonto a pagar\tPago con\tVuelto");
        Console.WriteLine("========================================================================================================");

        for (int i = 0; i < contador; i++)
        {
            string numeroFacturaStr = numeroFactura[i].ToString().PadRight(17);
            string numeroPlacaStr = numeroPlaca[i].PadRight(18);
            string tipoVehiculoStr = tipoVehiculo[i].ToString().PadRight(25);
            string numeroCasetaStr = numeroCaseta[i].ToString().PadRight(13);
            string montoPagarStr = montoPagar[i].ToString().PadRight(15);
            string pagaConStr = pagaCon[i].PadRight(12);
            string vueltoStr = vuelto[i].ToString().PadRight(10);

            Console.WriteLine($"{numeroFacturaStr}{numeroPlacaStr}{tipoVehiculoStr}{numeroCasetaStr}{montoPagarStr}{pagaConStr}{vueltoStr}");
        }

        Console.WriteLine("========================================================================================================");
        Console.WriteLine($"Cantidad de vehículos: {contador}\t\tTotal: {CalcularTotalVuelto()}");
        Console.WriteLine("========================================================================================================");
        Console.WriteLine("\t\t\t\t\t<<<Pulse cualquier tecla para regresar >>>");
        Console.ReadLine();
        Console.Clear();
    }

    static double CalcularTotalVuelto()
    {
        double totalVuelto = 0;
        for (int i = 0; i < contador; i++)
        {
            totalVuelto += vuelto[i];
        }
        return totalVuelto;
    }


}

