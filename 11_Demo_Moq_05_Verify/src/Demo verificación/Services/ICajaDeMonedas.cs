using Demo_verificación.Entities;

namespace Demo_verificación.Services
{
    public interface ICajaDeMonedas
    {
        void InsertarMoneda(TipoMoneda tipo);
        void ExpulsarMonedas(TipoMoneda tipo, int cantidad);
        int CantidadMonedas(TipoMoneda tipo);
    }
}
