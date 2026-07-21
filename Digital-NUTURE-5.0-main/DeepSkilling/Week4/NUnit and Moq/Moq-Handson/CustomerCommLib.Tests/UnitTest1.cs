using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommLib.Tests;

[TestFixture]
public class CustomerCommTests
{
    private Mock<IMailSender> _mockMailSender;
    private CustomerComm _customerComm;

    [OneTimeSetUp]
    public void Setup()
    {
        _mockMailSender = new Mock<IMailSender>();

        _mockMailSender
            .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _customerComm = new CustomerComm(_mockMailSender.Object);
    }

    [TestCase]
    public void SendMailToCustomer_ShouldReturnTrue()
    {
        bool result = _customerComm.SendMailToCustomer();

        Assert.That(result, Is.True);

        _mockMailSender.Verify(
            x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once);
    }
}