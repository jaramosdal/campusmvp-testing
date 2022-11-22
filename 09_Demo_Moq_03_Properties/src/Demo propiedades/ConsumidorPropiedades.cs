using System;

namespace Demo_propiedades
{
    public class ConsumidorPropiedades
    {
        public IPropiedades _propiedades;

        public ConsumidorPropiedades(IPropiedades propiedades)
        {
            _propiedades = propiedades;
        }

        public void SetPropiedad1(int value)
        {
            _propiedades.Prop1 = value;
        }

        public int GetPropiedad1()
        {
            return _propiedades.Prop1;
        }

        public void SetPropiedad2(double value)
        {
            _propiedades.Prop2 = value;
        }

        public double GetPropiedad2()
        {
            return _propiedades.Prop2;
        }

        public void SetPropiedad3(string value)
        {
            _propiedades.Prop3 = value;
        }

        public string GetPropiedad3()
        {
            return _propiedades.Prop3;
        }

    }
}
