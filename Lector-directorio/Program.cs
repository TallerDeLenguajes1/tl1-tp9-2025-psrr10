using System;
using System.IO;


class Program
{
    static void Main()
    {
        string path;
        do
        {
            Console.WriteLine("Ingrese un directorio:");
            path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directorio Invalido, ingrese nuevamente:");

            }
        } while (!Directory.Exists(path));
        Console.WriteLine("Directorio Valido");

        string[] carpetas = Directory.GetDirectories(path);
        if (carpetas.Length == 0)
        {
            Console.WriteLine("No existen carpetas en el directorio proporcionado");
        }
        else
        {
                Console.WriteLine("Carpetas encontradas:");
            foreach (string carpeta in carpetas)
            {
                Console.WriteLine("-" + Path.GetFileName(carpeta));
            }
        }
    }
}