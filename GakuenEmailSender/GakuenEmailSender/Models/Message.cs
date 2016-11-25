namespace GakuenEmailSender.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Reciever { get; set; }
        public string Sender { get; set; }
        public string Passcode { get; set; }
    }
}
