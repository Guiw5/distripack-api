using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace DistripackAPI.Helper
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings emailSettings;

        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SendClientRegistrationEmail(string to, string name)
        {
            string subject = "Pedido Pepe Wagner";
            string body =
                $"Buenas buenas, { name }. " +
                "<br /><br />  Qué tal? Necesitamos que nos des una mano!!! " +
                "<br />brindándonos algunos datos para poder mejorar nuestros servicios" +
                "<br /> <br />Por favor, completa el siguiente formulario haciendo click en el link <br /> " +
                $"<a href=\"{EmailSettings.Link}?email={to}\">goo.gl/clientes</a>";

            this.SendEmail(to, name, subject, body);
        }

        public void SendEmail(string to, string name, string subject, string body)
        {
            SendEmail(EmailSettings.From, EmailSettings.Name, to, name, subject, body);
        }

        public void SendEmail(string from, string fromName, string to, string toName, string subject, string body)
        {


            var fromAddress = new MailAddress(from, fromName);
            var toAddress = new MailAddress(to, toName);

            var smtp = new SmtpClient
            {
                Host = EmailSettings.Host,
                Port = EmailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, EmailSettings.Password),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public IConfiguration Configuration { get; }

        public EmailSettings EmailSettings
        {
            get
            {
                if (emailSettings != null)
                    return emailSettings;

                emailSettings = new EmailSettings();
                Configuration.GetSection("EmailSettings").Bind(emailSettings);
                return emailSettings;
            }
        }
    }
}