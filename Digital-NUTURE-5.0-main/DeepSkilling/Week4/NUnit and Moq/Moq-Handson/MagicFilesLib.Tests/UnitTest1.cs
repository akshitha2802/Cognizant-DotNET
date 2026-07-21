using MagicFilesLib;
using Moq;
using NUnit.Framework;

namespace MagicFilesLib.Tests;

[TestFixture]
public class DirectoryExplorerTests
{
    private Mock<IDirectoryExplorer> _mockExplorer;

    private readonly string _file1 = "file.txt";
    private readonly string _file2 = "file2.txt";

    [OneTimeSetUp]
    public void Setup()
    {
        _mockExplorer = new Mock<IDirectoryExplorer>();

        _mockExplorer
            .Setup(x => x.GetFiles(It.IsAny<string>()))
            .Returns(new List<string>
            {
                _file1,
                _file2
            });
    }

    [Test]
    public void GetFiles_ShouldReturnMockedFiles()
    {
        var files = _mockExplorer.Object.GetFiles("C:\\Temp");

        Assert.That(files, Is.Not.Null);
        Assert.That(files.Count, Is.EqualTo(2));
        Assert.That(files.Contains(_file1), Is.True);
    }
}