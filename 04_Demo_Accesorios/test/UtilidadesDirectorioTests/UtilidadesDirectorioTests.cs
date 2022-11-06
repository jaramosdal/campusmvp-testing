using _04_Demo_Accesorios;
using UtilidadesDirectorioTests.Fixtures;

namespace TestProject1;

[Collection("Directory")]
public class UtilidadesDirectorioTests //: IClassFixture<DirectoryFixture>
{
    private readonly DirectoryFixture _directoryFixture;

    public UtilidadesDirectorioTests(DirectoryFixture directoryFixture)
    {
        _directoryFixture = directoryFixture;
    }

    [Fact]
    public void ExistenLosArchivos_ShouldBeTrue_IfFilesExist()
    {
        //Arrange

        //Act
        var result = UtilidadesDirectorio.ExistenLosArchivos(_directoryFixture.Files, _directoryFixture.DirectoryForTests);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void ExistenLosArchivos_ShouldBeFalse_IfFilesNotExist()
    {
        //Arrange

        //Act
        var result = UtilidadesDirectorio.ExistenLosArchivos(_directoryFixture.Files, Path.Combine(_directoryFixture.DirectoryForTests, "NoExisto"));

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ExistenLosArchivos_ShouldThrowArgumentNullException_IfDirectoryIsNull()
    {
        //Arrange

        //Act
        Action act = () =>
        {
            _ = UtilidadesDirectorio.ExistenLosArchivos(_directoryFixture.Files, null);
        };

        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void ExistenLosArchivos_ShouldThrowArgumentNullException_IfDirectoryIsValidAndFilesIsNull()
    {
        //Arrange

        //Act
        Action act = () =>
        {
            _ = UtilidadesDirectorio.ExistenLosArchivos(null, _directoryFixture.DirectoryForTests);
        };

        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }
}
