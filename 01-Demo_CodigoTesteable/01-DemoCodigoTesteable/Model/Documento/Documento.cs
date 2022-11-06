using _01_DemoCodigoTesteable.Model.Email;
using _01_DemoCodigoTesteable.Model.Firma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _01_DemoCodigoTesteable.Model.Documento;

public class Documento
{
    private string _titulo;
    private string _cuerpo;
    private readonly IGeneradorFirma _generadorFirma;

    public Documento(IGeneradorFirma generadorFirma)
    {
        _generadorFirma = generadorFirma;
    }

    public void EscribirTitulo(string titulo)
    {
        this._titulo = titulo;
    }

    public void EscribirCuerpo(string cuerpo)
    {
        this._cuerpo = cuerpo;
    }

    public string GenerarDocumento()
    {
        // Para cumplir la D de SOLID, inyectamos la interfaz en el constructor
        //var generadorFirma = new GeneradorFirma();
        return _titulo + _cuerpo + _generadorFirma.Firma();
    }

    // Para cumplir la S de SOLID, sacamos este método de aquí
    //public void EnviarPorCorreo(string email)
    //{
    //    using var emailSender = new EmailSender();
    //    emailSender.Enviar(email, GenerarDocumento());
    //}
}
