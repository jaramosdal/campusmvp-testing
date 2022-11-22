using System;

namespace SerialSensor.Services
{
    public class SerialSensorDevice : IDisposable
    {
        private readonly ISerialPortWrapper _serialPort;
        private string _lastTextReaded = string.Empty;


        public SerialSensorDevice(ISerialPortWrapper serialPort)
        {
            _serialPort = serialPort;
            _serialPort.DataRecived += NewData;
        }

        public void SendMessage(string text) => _serialPort.WriteLine(text);

        public string GetLastData() => _lastTextReaded;

        public void Dispose() => _serialPort.DataRecived -= NewData;

        private void NewData(object sender, string text) => _lastTextReaded = text;
    }
}
