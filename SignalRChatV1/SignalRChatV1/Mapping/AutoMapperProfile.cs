using AutoMapper;
using SignalRChatV1.Dto;
using SignalRChatV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatV1.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MessageDto, Message>();
        }
    }
}
