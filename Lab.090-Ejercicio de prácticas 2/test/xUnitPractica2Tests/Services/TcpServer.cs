using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace xUnitPractica2Tests.Services
{
    public class ServidorTcp
    {
        public delegate void DataReceivedEventHandler(string e);

        public event DataReceivedEventHandler DataReceived;

        private TcpClient _client;
        private TcpListener _listener;
        private NetworkStream _netStream;
        private StreamReader _redStream;
        private StreamWriter _writStream;
        private Thread _threadRecibir;
        private ManualResetEvent _eventdesconectar;
        private int _port;
        private readonly IPAddress _localAddr = IPAddress.Parse("127.0.0.1");

        private void OnDataRecived(string e)
        {
            DataReceived?.Invoke(e);
        }

        private bool _Conectar()
        {
            _threadRecibir = new Thread(_Recibir)
            {
                Name = "Thread Data Receive"
            };
            _threadRecibir.Start();
            return true;
        }

        private void _Recibir()
        {
            _listener = new TcpListener(_localAddr, _port);
            _listener.Start();
            try
            {
                _client = _listener.AcceptTcpClient(); //Saltara al catch si se cierra el thread
            }
            catch
            {
                return;
            }

            _netStream = _client.GetStream();
            _redStream = new StreamReader(_netStream);
            _writStream = new StreamWriter(_netStream);
            _eventdesconectar = new ManualResetEvent(false);
            while (!_eventdesconectar.WaitOne(0))
            {
                try
                {
                    var strRec = _redStream.ReadLine();
                    if (strRec == null)
                    {
                        Desconectar();
                    }
                    else
                    {
                        OnDataRecived(strRec);
                    }
                }
                catch
                {
                    Desconectar();
                }
            }
        }

        /// <summary>
        /// Inicia la escucha de un puerto
        /// </summary>
        /// <param name="port">Puerto a escuchar</param>
        /// <returns></returns>
        public bool Escuchar(int port)
        {
            try
            {
                _port = port;
                return _Conectar();
            }
            catch
            {
                Desconectar();
                return false;
            }
        }

        /// <summary>
        /// Desconecta el socket
        /// </summary>
        /// <returns></returns>
        public bool Desconectar()
        {
            try
            {
                _listener.Stop();
                _eventdesconectar.Set();
                _threadRecibir = null;
                _client.Close();
                _netStream.Close();
                _redStream.Close();
                _writStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}