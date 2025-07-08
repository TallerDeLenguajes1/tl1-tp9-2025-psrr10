using System;
using System.IO;
using System.Text;
using LectorTagMP3;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la tura completa de un archivo MP3: ");
        string path = Console.ReadLine() ?? "";

        if (!File.Exists(path))
        {
            Console.WriteLine("El archivo no existe");
            return;
        }

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            if (fs.Length < 128)
            {
                Console.WriteLine("El archivo es demasiado pequeño para tener etiqueta ID3v1");
                return;
            }

            fs.Seek(-128, SeekOrigin.End);
            byte[] buffer = new byte[128];
            fs.Read(buffer, 0, 128);

            string tag = Encoding.GetEncoding("Latin1").GetString(buffer, 0, 3);

            if (tag != "TAG")
            {
                Console.WriteLine("El archivo no contiene una etiqueta ID3v1 valida");
                return;
            }

            //creo el objeto y cargo datos
            Id3v1Tag info = new Id3v1Tag
            {
                Titulo = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).TrimEnd('\0', ' '),
                Artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).TrimEnd('\0', ' '),
                Album = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).TrimEnd('\0', ' '),
                Año = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).TrimEnd('\0', ' ')
            };

            Console.WriteLine($"\n🎵 Información del archivo:");
            Console.WriteLine($"Título:  {info.Titulo}");
            Console.WriteLine($"Artista: {info.Artista}");
            Console.WriteLine($"Álbum:   {info.Album}");
            Console.WriteLine($"Año:     {info.Año}");

        }
    }
}