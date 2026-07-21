using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayersManagerLib.Tests;

[TestFixture]
public class PlayerTests
{
    private Mock<IPlayerMapper> _mockMapper;

    [OneTimeSetUp]
    public void Setup()
    {
        _mockMapper = new Mock<IPlayerMapper>();

        _mockMapper
            .Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>()))
            .Returns(false);
    }

    [Test]
    public void RegisterPlayer_ShouldCreatePlayer()
    {
        Player player = Player.RegisterNewPlayer("Virat", _mockMapper.Object);

        Assert.That(player.Name, Is.EqualTo("Virat"));
        Assert.That(player.Age, Is.EqualTo(23));
        Assert.That(player.Country, Is.EqualTo("India"));
        Assert.That(player.NoOfMatches, Is.EqualTo(30));

        _mockMapper.Verify(
            x => x.AddNewPlayerIntoDb(It.IsAny<string>()),
            Times.Once);
    }
}