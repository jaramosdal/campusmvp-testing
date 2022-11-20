using System;

namespace SerialSensor.Services
{
    public interface ISerialPortWrapper
    {        
        void WriteLine(string text);
        event EventHandler<string> DataRecived;
    }
}
