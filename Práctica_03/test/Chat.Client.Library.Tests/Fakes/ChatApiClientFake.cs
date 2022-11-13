using Chat.Client.Library.Services;
using Chat.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client.Library.Tests.Fakes;

internal class ChatApiClientFake : IChatApiClient
{
    private readonly List<ChatMessage> _messages;

    public ChatApiClientFake(IEnumerable<ChatMessage> messages)
    {
        _messages = messages.ToList();
    }

    public async Task<IEnumerable<ChatMessage>> GetChatMessagesAsync()
    {
        var mensajes = Task.Run(() => _messages);
        return await mensajes;
    }

    public async Task<bool> SendMessageAsync(ChatMessage message)
    {
        var crearMensaje = Task.Run(() =>
        {
            _messages.Add(message);
            return true;
        });

        return await crearMensaje;
    }
}
