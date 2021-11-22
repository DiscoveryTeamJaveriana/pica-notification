using Infraestructure.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;
using ApplicationCore.DTO;
using System;

namespace C3P_Notification_Api_Test
{
    public class ServicesTest
    {
        private NotificationMetadata _notificationMetadata;
        private SmtpClient _smtpClient;
        private EmailService _emailService;


        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _notificationMetadata = new NotificationMetadata();
            _smtpClient = new SmtpClient();

            _notificationMetadata.SmtpServer = config["NotificationMetadata:SmtpServer"];
            _notificationMetadata.Port = Int16.Parse(config["NotificationMetadata:Port"]);
            _notificationMetadata.UserName = config["NotificationMetadata:Username"];
            _notificationMetadata.Password = config["NotificationMetadata:Password"];
            _emailService = new EmailService(_notificationMetadata,_smtpClient);
        }

        [Test]
        public async Task SendEmailTest()
        {

            var emailMessage = new EmailMessage();

            emailMessage.Reciever = "owlblack10@gmail.com";
            var notificationResponse = await _emailService.SendEmail(emailMessage);
            Assert.AreEqual( "0", notificationResponse.statusCode);
        }
    }
}