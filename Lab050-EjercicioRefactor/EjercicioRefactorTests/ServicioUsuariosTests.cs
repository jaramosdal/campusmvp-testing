using EjercicioRefactor.Services.Centralita;
using EjercicioRefactor.Services.Usuarios;

namespace EjercicioRefactorTests;

public class ServicioUsuariosTests
{
    [Fact]
    public void LlamarAlUsuario_LlamaAlUsuario()
    {
        //Arrange
        string usuario = "Javier Ramos Nodal";
        var servicioUsuarios = new ServicioUsuarios(new ServicioLlamadas(new ServicioTelefonia()));

        //Act
        servicioUsuarios.LlamarAlUsuario(usuario);

        //Assert

    }
}