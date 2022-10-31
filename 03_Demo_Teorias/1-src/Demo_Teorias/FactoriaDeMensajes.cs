namespace Demo_Teorias;
public static class FactoríaDeMensajes
{
    public static string ObtenerMensaje(int código)
    {
        switch(código)
        {
            case 0:
                return "Hola";
            case 1:
                return "Adiós";
            case 2:
                return "CampusMVP";
            case 3:
                return "Pruebas";
            case 4:
                return "De";
            case 5:
                return "Código";
            default:
                return "No se ha podido recuperar";
        }
    }
}