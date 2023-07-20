﻿using Key.AiAssistant.Application.DTOs.Messages;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Requests.Queries
{
    public class GetMessageListRequest : IRequest<List<MessageDto>>
    {
    }
}
