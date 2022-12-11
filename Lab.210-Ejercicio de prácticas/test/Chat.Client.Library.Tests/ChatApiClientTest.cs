using Chat.Client.Library.Services;
using Chat.Client.Library.Tests.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Chat.Client.Library.Tests;

public class ChatApiClientTest
{
    private readonly ChatApiClient _chatApiClient;

    public ChatApiClientTest()
    {
        var client = new HttpClient(new FakeMessageHandler());
        client.BaseAddress = new Uri("http://localhost:5000/api/");
        _chatApiClient = new ChatApiClient(client);
    }

    [Fact]
    public async Task GetMessages_ShouldBeExpectedMessages()
    {
        //Arrange

        //Act
        var result = await _chatApiClient.GetChatMessagesAsync();

        //Assert
        result.Should().HaveCount(3);
    }
}

public class FakeMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = null;

        if (request.Method == HttpMethod.Post)
        {
            response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
            };
        }
        else
        {
            response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(ChatMessageHelperData.ChatMessages), Encoding.UTF8, "application/json")
            };
        }

        return Task.FromResult(response);
    }
}