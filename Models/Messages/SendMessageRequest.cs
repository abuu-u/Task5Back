using System.ComponentModel.DataAnnotations;

namespace Task5Back.Models.Messages
{
    public class SendMessageRequest
    {
        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
    }
}