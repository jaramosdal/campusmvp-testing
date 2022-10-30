namespace DEMO_Pruebas_de_código_únicas
{
    public static class UtilidadesMatematicas
    {
        public static int Sumar(int a, int b)
        {
            return a + b;
        }

        public static bool EsPar(int a)
        {
            if (a % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Dividir(int a, int b)
        {
            return a / b;
        }
    }
}
