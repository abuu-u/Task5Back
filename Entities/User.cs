using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task5Back.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class User
    {
        [Key]
        public string Name { get; set; }

        [InverseProperty(nameof(Message.Receiver))]
        public List<Message> ReceivedMessages { get; set; }

        [InverseProperty(nameof(Message.Sender))]
        public List<Message> SentMessages { get; set; }
    }
}