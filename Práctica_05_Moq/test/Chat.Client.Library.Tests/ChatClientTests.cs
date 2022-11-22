﻿using Chat.Client.Library.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Common.Entities;
using Xunit;
using System.Collections;
using Moq;

namespace Chat.Client.Library.Tests;

//En el proyecto de chat que te propusimos para la primera práctica del módulo,
//consigue que todos las pruebas estén en verde, pero esta vez utilizando Moq
//para generar el código necesario en vez de crear clases auxiliares a mano.

//Encontrarás escenarios que hay que probar y no se están probando. ¿Cuáles?
//Añade pruebas adicionales para cubrir dichos escenarios.
//Como pista sobre qué puede faltar, no se está haciendo verificación alguna sobre los mock 😉
public class ChatClientTests : IDisposable
{
    private readonly IChatClient _chatClient;

    public ChatClientTests()
    {
        var messages = new List<ChatMessage>
        {
            new ChatMessage
            {
                Author = "Usuario3",
                Message = "Test",
                Date = DateTime.Now
            }
        };
        //Creacion y configuracion de Mocks y creacion de IchatClient
        var mockUserApiClient = new Mock<IUserApiClient>();
        mockUserApiClient.Setup(apiUser => apiUser.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((ChatUser)null);
        mockUserApiClient.Setup(apiUser => apiUser.LoginAsync("Usuario1", "P2ssw0rd!")).ReturnsAsync(new ChatUser { Name = "Usuario1", Password = "P2ssw0rd!" });
        var mockChatApiClient = new Mock<IChatApiClient>();
        _chatClient = new ChatClient(mockChatApiClient.Object, mockUserApiClient.Object);
    }

    [Theory]
    [InlineData(true, "Usuario1", "P2ssw0rd!")]
    [InlineData(false, "Usuario2", "")]
    public async Task LoginAsync_ShouldBeExpectedResult(bool expected, string username, string password)
    {
        //Arrange

        //Act
        var result = await _chatClient.LoginAsync(username, password);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LoginAsync_ShouldBeArgumentNullException_IfArgumentNull()
    {
        //Arrange

        //Act
        Func<Task> act = async () => { _ = await _chatClient.LoginAsync(null, null); };

        //Assert
        Assert.ThrowsAsync<ArgumentNullException>(act);

    }

    [Theory]
    [InlineData(true, "Usuario1", "P2ssw0rd!")]
    [InlineData(false, "Usuario2", "")]
    public async Task CreateUserAsync_ShouldBeExpectedResult(bool expected, string username, string password)
    {
        //Arrange

        //Act
        var result = await _chatClient.CreateUserAsync(username, password);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CreateUserAsync_ShouldBeArgumentNullException_IfArgumentNull()
    {
        //Arrange

        //Act
        Func<Task> act = async () => { _ = await _chatClient.CreateUserAsync(null, null); };

        //Assert
        Assert.ThrowsAsync<ArgumentNullException>(act);

    }

    [Fact]
    public async Task SendMessageAsync_ShouldBeTrue_IfLoggedAndConnected()
    {
        //Arrange
        var message = "Message1";
        await _chatClient.LoginAsync("Usuario1", "P2ssw0rd!");
        _chatClient.Connect();

        //Act
        var result = await _chatClient.SendMessageAsync(message);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task SendMessageAsync_ShouldBeFalse_IfNotLogged()
    {
        //Arrange
        var message = "Message1";

        //Act
        var result = await _chatClient.SendMessageAsync(message);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public async Task NewMessageRecived_ShouldBeRaised_IfConnect()
    {
        var eventRecived = false;
        await _chatClient.LoginAsync("Usuario1", "P2ssw0rd!");
        _chatClient.NewMessageRecived += (sender, _) => eventRecived = true;
        _chatClient.Connect();

        //Act
        await Task.Delay(100); //Le damos tiempo para que se ejecute el evento

        //Assert
        Assert.True(eventRecived);
    }

    [Fact]
    public async Task OverwriteLastLine_ShouldBeRaised_IfOneMessageAndAuthorIsWhoseIsLogged()
    {
        var eventRecived = false;
        await _chatClient.LoginAsync("Usuario3", "P2ssw0rd!");
        _chatClient.OverwriteLastLine += (sender, _) => eventRecived = true;
        _chatClient.Connect();

        //Act
        await Task.Delay(100); //Le damos tiempo para que se ejecute el evento

        //Assert
        Assert.True(eventRecived);
    }

    [Fact]
    public async Task OverwriteLastLine_ShouldNotBeRaised_IfOneMessageAndAuthorIsOther()
    {
        var eventRecived = false;
        await _chatClient.LoginAsync("Usuario1", "P2ssw0rd!");
        _chatClient.OverwriteLastLine += (sender, _) => eventRecived = true;
        _chatClient.Connect();

        //Act
        await Task.Delay(100); //Le damos tiempo para que se ejecute el evento

        //Assert
        Assert.False(eventRecived);
    }

    [Fact]
    public async Task OverwriteLastLine_ShouldNotBeRaised_IfMoreThanOneMessage()
    {
        var eventRecived = false;
        var messages = new List<ChatMessage>
        {
            new ChatMessage
            {
                Author = "Usuario3",
                Message = "Test",
                Date = DateTime.Now
            },
            new ChatMessage
            {
                Author = "Usuario3",
                Message = "Test",
                Date = DateTime.Now
            }
        };
        //Modificacion de Mock

        await _chatClient.LoginAsync("Usuario1", "P2ssw0rd!");
        _chatClient.OverwriteLastLine += (sender, _) => eventRecived = true;
        _chatClient.Connect();

        //Act
        await Task.Delay(100); //Le damos tiempo para que se ejecute el evento

        //Assert
        Assert.False(eventRecived);
    }

    public void Dispose()
    {
        _chatClient?.Dispose();
    }
}
