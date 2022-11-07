namespace _04_Demo_Accesorios;

public static class UtilidadesDirectorio
{
    public static bool ExistenLosArchivos(string[] archivos, string directorio)
    {
        var dirInfo = new DirectoryInfo(directorio);
        if (!dirInfo.Exists)
        {
            return false;
        }
        var files = dirInfo.GetFiles().Select(file => file.Name);
        return !archivos.Except(files).Any();
    }
}