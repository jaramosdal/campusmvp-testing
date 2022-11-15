using System;

namespace Configurando_Llamadas
{
    public class Car
    {
        private IControl _control;

        public Car(IControl control)
        {
            _control = control;
        }

        public bool OpenDoors(string key)
        {
            return _control.OpenDoors(key);
            //...
        }

        public bool Start(int retries)
        {
            if(retries <=0 || retries > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(retries));
            }

            int tries = 0;
            var started = false;
            do
            {
                try
                {
                    started = _control.Start();
                }
                catch
                {

                }
                tries++;
            } while (!started && tries < retries);

            return started;
        }
    }
}