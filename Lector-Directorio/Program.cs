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

        //Listar carpetas 
        Console.WriteLine("\nCarpetas dentro del directorio:");
        string[] carpetas = Directory.GetDirectories(path);

        foreach (var carpeta in carpetas)
        {
            string NombreCarpeta = Path.GetFileName(carpeta);
            Console.WriteLine("-" + NombreCarpeta);
        }

        //Listar archivos dentro del path y su tamaño
        Console.WriteLine("\nArchivos dentro del directorio:");
        string[] archivos = Directory.GetFiles(path);
        foreach (var archivo in archivos)
        {
            string NombreArchivo = Path.GetFileName(archivo);
            FileInfo info = new FileInfo(archivo);
            double tamañoKB = Math.Round(info.Length / 1024.0, 2);
            Console.WriteLine("-" + NombreArchivo + $"({tamañoKB} KB)");
        }

        // Crear ruta del archivo CSV 
        string rutaCSV = Path.Combine(path, "reporte_archivos.csv");

        // Abrir StreamWriter para escribir el archivo
        using (StreamWriter writer = new StreamWriter(rutaCSV))
        {
            // Escribir encabezado
            writer.WriteLine("Nombre del Archivo,Tamaño (KB),Fecha de Última Modificación");

            // Escribir información de cada archivo
            foreach (var archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);
                string nombre = info.Name;
                double tamañoKB = Math.Round(info.Length / 1024.0, 2);
                string fecha = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

                writer.WriteLine($"{nombre},{tamañoKB},{fecha}");
            }
        }

        Console.WriteLine($"\nArchivo CSV creado correctamente en: {rutaCSV}");


    }
}