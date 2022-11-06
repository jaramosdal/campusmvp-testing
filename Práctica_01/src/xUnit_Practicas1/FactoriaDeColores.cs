using System;
using System.Drawing;

namespace xUnit_Practicas1
{
    public static class FactoriaDeColores
    {
        public static Color GetColorByName(string nombre)
        {
            if (nombre is null)
            {
                throw new ArgumentNullException(nameof(nombre));
            }

            switch (nombre.ToLower())
            {
                case "rojo":
                    return Color.Red;
                case "azul":
                    return Color.Blue;
                case "verde":
                    return Color.Green;
                case "blanco":
                    return Color.White;
                case "negro":
                    return Color.Black;
                default:
                    return default;
            }
        }

        public static Color GetColorComposition(int red, int green, int blue)
        {
            if (red < 0 || red > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(red), "El valor rojo esta fuera de rango. Debe estar entre 0 y 255");
            }

            if (green < 0 || green > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(green), "El valor verde esta fuera de rango. Debe estar entre 0 y 255");
            }

            if (blue < 0 || blue > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(blue), "El valor azul esta fuera de rango. Debe estar entre 0 y 255");
            }

            return Color.FromArgb(red, green, blue);
        }
    }
}
