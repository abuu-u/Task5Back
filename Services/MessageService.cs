using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task5Back.Entities;
using Task5Back.Helpers;
using Task5Back.Models.Messages;

namespace Task5Back.Services
{
    public interface IMessageService
    {
        GetReceivedMessagesResponse GetReceivedMessages(string name);

        Task Send(SendMessageRequest model, string name);
    }

    public class MessageService : IMessageService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        private readonly IUserService _userService;

        public MessageService(
            DataContext context,
            IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task Send(SendMessageRequest model, string name)
        {
            await _userService.CreateUser(model.ReceiverName);
            await _userService.CreateUser(name);
            Message message = _mapper.Map<Message>(model);
            message.SenderName = name;
            _ = _context.Messages.Add(message);
            _ = _context.SaveChanges();
        }

        public GetReceivedMessagesResponse GetReceivedMessages(string name)
        {
            List<Message> messages = _context.Users.Where(u => u.Name == name).Include(u => u.ReceivedMessages).FirstOrDefault()?.ReceivedMessages;
            return messages?.Count == 0
                ? throw new NotFoundException("No messages found")
                : new GetReceivedMessagesResponse { Messages = _mapper.Map<List<MessageDto>>(messages) };
        }

        public Task SendAsync(SendMessageRequest model)
        {
            throw new NotImplementedException();
        }
    }
}