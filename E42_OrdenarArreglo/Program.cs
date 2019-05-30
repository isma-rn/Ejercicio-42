using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E42_OrdenarArreglo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion;
            do
            {
                Console.Clear();                
                int?[] prueba = ObtenerArregloEnterosConAleatorios(10, 99, 15);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Arreglo enteros generado con número aleatorios:");
                if (prueba != null)
                {
                    foreach (var v in prueba)
                        Console.Write("[{0}]", v);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nArreglo ordenado ascendente:");
                    foreach (var v in OrdenarAsendente(prueba))
                        Console.Write("[{0}]", v);

                    Console.WriteLine("\n\nArreglo ordenado ascendente (LINQ):");
                    foreach (var v in prueba.OrderBy(x => x))
                        Console.Write("[{0}]", v);

                    Console.WriteLine("\n\nArreglo ordenado descendente:");
                    foreach (var v in OrdenarDesendente(prueba))
                        Console.Write("[{0}]", v);

                    Console.WriteLine("\n\nArreglo ordenado descendente (LINQ):");
                    foreach (var v in prueba.OrderByDescending(x => x))
                        Console.Write("[{0}]", v);
                }
                else
                    Console.WriteLine("Error, no se puedo obtener arreglo");

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nn : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);

        }
        public static int?[] OrdenarAsendente(int?[] arreglo)
        {
            int? t;
            for (int a = 1; a < arreglo.Length; a++)
                for (int b = arreglo.Length - 1; b >= a; b--)
                {
                    if (arreglo[b - 1] > arreglo[b])
                    {
                        t = arreglo[b - 1];
                        arreglo[b - 1] = arreglo[b];
                        arreglo[b] = t;
                    }
                }
            return arreglo;
        }
        public static int?[] OrdenarDesendente(int?[] arreglo)
        {
            int? t;
            for (int a = 1; a < arreglo.Length; a++)
                for (int b = arreglo.Length - 1; b >= a; b--)
                {
                    if (arreglo[b - 1] < arreglo[b])
                    {
                        t = arreglo[b - 1];
                        arreglo[b - 1] = arreglo[b];
                        arreglo[b] = t;
                    }
                }
            return arreglo;
        }
        public static int?[] ObtenerArregloEnterosConAleatorios(int min, int max, int size)
        {
            Random random = new Random();
            int?[] resultado = null;
            if (size > 0 && min < max)
            {
                resultado = new int?[size];
                for (int i = 0; i < size; i++)
                        resultado[i] = random.Next(min, max);
            }
            return resultado;
        }
    }
}
