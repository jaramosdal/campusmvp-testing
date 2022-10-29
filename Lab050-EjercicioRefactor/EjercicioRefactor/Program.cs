using EjercicioRefactor.Services.Centralita;
using EjercicioRefactor.Services.Usuarios;
using System;

namespace EjercicioRefactor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nombreUsuario = "Jorge Turrado";
            var servicioUsuarios = new ServicioUsuarios(new ServicioLlamadas(new ServicioTelefonia()));

            if (servicioUsuarios.ExisteUsuario(nombreUsuario))
            {
                servicioUsuarios.LlamarAlUsuario(nombreUsuario);
            }
            Console.Read();
        }
    }
}
