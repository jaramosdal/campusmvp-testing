using EjercicioRefactor.Services.Centralita;

namespace EjercicioRefactor.Services.Usuarios
{
    public class ServicioUsuarios
    {
        private readonly IServicioLlamadas _servicioLlamadas;

        public ServicioUsuarios(IServicioLlamadas servicioLlamadas)
        {
            _servicioLlamadas = servicioLlamadas;
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            //...
            return true;
        }

        public void LlamarAlUsuario(string nombreUsuario)
        {
            _servicioLlamadas.Llamar(nombreUsuario);
        }
    }
}
