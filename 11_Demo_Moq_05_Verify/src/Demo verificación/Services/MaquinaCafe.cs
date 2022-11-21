using Demo_verificación.Entities;
using System;
using System.Collections.Generic;

namespace Demo_verificación.Services
{
    public class MaquinaCafe
    {
        private readonly ICajaDeMonedas _cajaMonedas;

        public MaquinaCafe(ICajaDeMonedas cajaMonedas)
        {
            _cajaMonedas = cajaMonedas;
        }

        //Resto de métodos necesarios de la clase

        public void DevolverCambio(int total)
        {
            var devoluciones = CalcularCambio(total);            

            foreach (var devolución in devoluciones)
            {
                _cajaMonedas.ExpulsarMonedas(devolución.Tipo, devolución.Cantidad);
            }
        }

        private List<Devolución> CalcularCambio(int total, TipoMoneda tipo = TipoMoneda.DosEuros)
        {
            var devoluciónTotal = new List<Devolución>();

            if (total < (int)tipo)
            {
                devoluciónTotal.AddRange(CalcularCambio(total, SiguienteTipo(tipo)));
                return devoluciónTotal;
            }

            var cantidadTipo = _cajaMonedas.CantidadMonedas(tipo);

            if (cantidadTipo == 0)
            {
                devoluciónTotal.AddRange(CalcularCambio(total, SiguienteTipo(tipo)));
                return devoluciónTotal;
            }

            var cantidadNecesarias = total / ((int)tipo);


            var devolución = new Devolución();
            devolución.Tipo = tipo;
            devolución.Cantidad = cantidadTipo >= cantidadNecesarias ? cantidadNecesarias : cantidadTipo;
            total = total - (devolución.Cantidad * (int)devolución.Tipo);

            devoluciónTotal.Add(devolución);

            if(total > 0)
            {
                devoluciónTotal.AddRange(CalcularCambio(total, SiguienteTipo(tipo)));
                return devoluciónTotal;
            }
            return devoluciónTotal;
        }

        private TipoMoneda SiguienteTipo(TipoMoneda tipo)
        {
            switch (tipo)
            {
                case TipoMoneda.DosEuros:
                    return TipoMoneda.UnEuro;
                case TipoMoneda.UnEuro:
                    return TipoMoneda.CincuentaCent;
                case TipoMoneda.CincuentaCent:
                    return TipoMoneda.VeinteCent;
                case TipoMoneda.VeinteCent:
                    return TipoMoneda.DiezCent;
                case TipoMoneda.DiezCent:
                    return TipoMoneda.CincoCent;
                case TipoMoneda.CincoCent:
                    return TipoMoneda.DosCent;
                case TipoMoneda.DosCent:
                    return TipoMoneda.UnCent;
                default:
                    throw new Exception("Cambio insuficiente");
            }
        }
    }
}
