// See https://aka.ms/new-console-template for more information
using _01_DemoCodigoTesteable.Model.Documento;
using _01_DemoCodigoTesteable.Model.Email;
using _01_DemoCodigoTesteable.Model.Firma;

string correo = "direccion_de_correo@gmail.com";

GeneradorFirma generadorFirma = new();
Documento documento = new(generadorFirma);
documento.EscribirTitulo("Documento de pruebas");
documento.EscribirCuerpo("Este documento es una prueba para ver cómo hacer código probable");

using var emailSender = new EmailSender();
emailSender.Enviar(correo, documento.GenerarDocumento());

Console.Read();