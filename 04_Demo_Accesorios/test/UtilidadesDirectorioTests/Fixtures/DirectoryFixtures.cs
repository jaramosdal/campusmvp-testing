using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDirectorioTests.Fixtures;

public class DirectoryFixture : IDisposable
{
    private const string DIRECTORY = "./tests";
    private const int FILECOUNT = 5;
    private readonly string[] _files = new string[FILECOUNT];

    public string[] Files => _files;
    public string DirectoryForTests => DIRECTORY;

    public DirectoryFixture()
    {
        if (!Directory.Exists(DIRECTORY))
        {
            Directory.CreateDirectory(DIRECTORY);
        }

        for (var i = 0; i < FILECOUNT; i++)
        {
            var fileName = $"{i}.test";
            _files[i] = fileName;
            File.WriteAllText(Path.Combine(DIRECTORY, fileName), "");
        }
    }


    public void Dispose()
    {
        if (Directory.Exists(DIRECTORY))
        {
            Directory.Delete(DIRECTORY, true);
        }
    }
}
