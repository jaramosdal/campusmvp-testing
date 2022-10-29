namespace EjercicioRefactor.Services.Centralita
{
    public class ServicioLlamadas : IServicioLlamadas
    {
        private readonly IServicioTelefonia _servicioTelefonia;

        public ServicioLlamadas(IServicioTelefonia servicioTelefonia)
        {
            _servicioTelefonia = servicioTelefonia;
        }

        public void Llamar(string nombreUsuario)
        {
            _servicioTelefonia.LlamarPorTelefono(nombreUsuario);
        }
    }
}
