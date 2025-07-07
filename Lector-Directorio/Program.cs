using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path;
        do
        {
            Console.WriteLine("Ingrese el path del directorio a analizar: ");
            path = Console.ReadLine() ?? "";
            if (!Directory.Exists(path))
            {
                Console.WriteLine("El directorio ingresado no existe, ingrese nuevamente.");
            }
        } while (!Directory.Exists(path));
        Console.WriteLine($"\nDirectorio válido ingresado: {path}");
    }
}