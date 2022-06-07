using System.ComponentModel.DataAnnotations.Schema;

namespace Task5Back.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        [ForeignKey(nameof(SenderName))]
        [InverseProperty(nameof(User.SentMessages))]
        public User Sender { get; set; }

        public string ReceiverName { get; set; }

        [ForeignKey(nameof(ReceiverName))]
        [InverseProperty(nameof(User.ReceivedMessages))]
        public User Receiver { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }
    }
}