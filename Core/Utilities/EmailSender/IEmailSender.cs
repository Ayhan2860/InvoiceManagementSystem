namespace Core.Utilities.EmailSender
{
    public interface IEmailSender
    {
        void SendEMail(Message message);
    }
}