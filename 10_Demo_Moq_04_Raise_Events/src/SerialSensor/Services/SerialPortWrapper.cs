using System;
using System.IO.Ports;

namespace SerialSensor.Services
{
    public class SerialPortWrapper : ISerialPortWrapper,IDisposable
    {
        public event EventHandler<string> DataRecived;

        private readonly SerialPort _serialPort;

        public SerialPortWrapper(string com)
        {
            _serialPort = new SerialPort(com);
            _serialPort.DataReceived += (sender, _) =>
            {
                var sp = (SerialPort)sender;
                var indata = sp.ReadExisting();
                DataRecived?.Invoke(this, indata);
            };
            _serialPort.Open();
        }
        
        public void WriteLine(string text)
        {
            _serialPort.WriteLine(text);
        }

        public void Dispose()
        {
            _serialPort.Close();
        }
    }
}
