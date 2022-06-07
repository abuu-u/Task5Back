using AutoMapper;
using Task5Back.Entities;
using Task5Back.Models.Messages;

namespace Task5Back.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            _ = CreateMap<string, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));

            _ = CreateMap<Message, MessageDto>();

            _ = CreateMap<SendMessageRequest, Message>();
        }
    }
}