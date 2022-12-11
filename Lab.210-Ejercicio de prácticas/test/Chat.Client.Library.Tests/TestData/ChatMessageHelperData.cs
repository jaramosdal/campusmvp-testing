using System;
using System.Collections;
using System.Collections.Generic;
using Chat.Common.Entities;
using Xunit;

namespace Chat.Client.Library.Tests.TestData
{
    public class ChatMessageHelperData : TheoryData<ChatMessage, string>
    {
        public static List<ChatMessage> ChatMessages;

        public ChatMessageHelperData()
        {
            var date = DateTime.Now;

            ChatMessages = new List<ChatMessage>
            {
                new ChatMessage { Author = "Author1", Date = date, Message = "Hello everybody!" },
                new ChatMessage { Author = "Author2", Date = date.AddMinutes(1), Message = "Hello Author1" },
                new ChatMessage { Author = "Author1", Date = date.AddMinutes(2), Message = "How are you?" }
            };

            foreach (var chatMessage in ChatMessages)
            {
                Add(chatMessage, $"{chatMessage.Date:HH mm ss}:{chatMessage.Author}->{chatMessage.Message}");
            }
        }
    }
}
