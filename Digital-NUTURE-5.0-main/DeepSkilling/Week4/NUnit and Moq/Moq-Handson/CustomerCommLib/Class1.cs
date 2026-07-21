using System.Net;
using System.Net.Mail;

namespace CustomerCommLib;

public interface IMailSender
{
    bool SendMail(string toAddress, string message);
}

public class MailSender : IMailSender
{
    public bool SendMail(string toAddress, string message)
    {
        MailMessage mail = new MailMessage();
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress("your_email@gmail.com");
        mail.To.Add(toAddress);
        mail.Subject = "Test Mail";
        mail.Body = message;

        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("username", "password");
        smtpServer.EnableSsl = true;

        // In a real app:
        // smtpServer.Send(mail);

        return true;
    }
}

public class CustomerComm
{
    private readonly IMailSender _mailSender;

    public CustomerComm(IMailSender mailSender)
    {
        _mailSender = mailSender;
    }

    public bool SendMailToCustomer()
    {
        _mailSender.SendMail("cust123@abc.com", "Some Message");
        return true;
    }
}