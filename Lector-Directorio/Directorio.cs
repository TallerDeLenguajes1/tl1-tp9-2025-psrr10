using System;
using System.IO;

namespace AnalizarDirectorio;

public class AnalizadorDirectorio
{
    public string PedirPathValido()
    {
        string path;
        do
        {
            Console.Write("Ingrese el path del directorio a analizar: ");
            path = Console.ReadLine() ?? "";

            if (!Directory.Exists(path))
                Console.WriteLine("El directorio ingresado no existe. Intente nuevamente.\n");

        } while (!Directory.Exists(path));

        return path;
    }

    public void ListarCarpetas(string path)
    {
        Console.WriteLine("\nCarpetas dentro del directorio:");
        foreach (var carpeta in Directory.GetDirectories(path))
            Console.WriteLine("- " + Path.GetFileName(carpeta));
    }

    public void ListarArchivos(string path)
    {
        Console.WriteLine("\nArchivos dentro del directorio:");
        foreach (var archivo in Directory.GetFiles(path))
        {
            FileInfo info = new FileInfo(archivo);
            double tamañoKB = Math.Round(info.Length / 1024.0, 2);
            Console.WriteLine($"- {Path.GetFileName(archivo)} ({tamañoKB} KB)");
        }
    }

    public void GenerarReporteCSV(string path)
    {
        string[] archivos = Directory.GetFiles(path);
        string rutaCSV = Path.Combine(path, "reporte_archivos.csv");

        using (StreamWriter writer = new StreamWriter(rutaCSV))
        {
            writer.WriteLine("Nombre del Archivo,Tamaño (KB),Fecha de Última Modificación");

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
