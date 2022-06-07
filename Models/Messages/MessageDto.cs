namespace Task5Back.Models.Messages
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }
    }
}