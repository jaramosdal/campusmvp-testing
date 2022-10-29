using System;

namespace EjercicioRefactor.Services.Centralita
{
    public class ServicioTelefonia : IServicioTelefonia
    {
        public void LlamarPorTelefono(string nombreUsuario)
        {
            Console.WriteLine($"Llamando por telefono a {nombreUsuario}");
        }
    }
}
