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
            if(!Directory.Exists(path))
            {
                Console.WriteLine("Directorio Invalido, ingrese nuevamente:");

            }
        }while(!Directory.Exists(path));
        Console.WriteLine("Directorio Valido");
    }
}