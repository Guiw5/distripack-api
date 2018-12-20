namespace DistripackAPI.Helper
{
    public interface IEmailSender
    {
        void SendClientRegistrationEmail(string to, string name);

        void SendEmail(string to, string name, string subject, string body);
    }
}