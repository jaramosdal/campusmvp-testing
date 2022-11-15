using System;

namespace Configurando_Llamadas
{
    public interface IControl
    {
        bool Start();
        bool OpenDoors(string key);
    }
}
