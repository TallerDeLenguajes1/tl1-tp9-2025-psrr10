using AnalizarDirectorio;
class Program
{
    static void Main(string[] args)
    {
        var analizador = new AnalizadorDirectorio();

        string path = analizador.PedirPathValido();
        analizador.ListarCarpetas(path);
        analizador.ListarArchivos(path);
        analizador.GenerarReporteCSV(path);
    }
}
