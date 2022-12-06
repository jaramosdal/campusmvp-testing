using Chat.Client.Library.Services;
using Chat.Common.Entities;
using Chat.Server.Library.Data;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chat.Client.Library.Tests;

public class DesignTests
{
    [Fact]
    public void ChatClientLibrary_ShouldReferenceChatCommon()
    {
        //Arrange
        var chatClientLibraryAssembly = typeof(IChatClient).Assembly;
        var chatCommonAssembly = typeof(ChatUser).Assembly;

        //Act

        //Assert
        chatClientLibraryAssembly.Should().Reference(chatCommonAssembly);
    }

    [Fact]
    public void ChatClientLibrary_ShouldNotReferenceChatClient()
    {
        //Arrange
        var chatClientLibraryAssembly = typeof(IChatClient).Assembly;
        var chatClientAssembly = typeof(Program).Assembly;

        //Act

        //Assert
        chatClientLibraryAssembly.Should().NotReference(chatClientAssembly);
    }

    [Fact]
    public void ChatClientLibrary_ShouldNotReferenceChatServer()
    {
        //Arrange
        var chatClientLibraryAssembly = typeof(IChatClient).Assembly;
        var chatServerAssembly = typeof(Server.Program).Assembly;

        //Act

        //Assert
        chatClientLibraryAssembly.Should().NotReference(chatServerAssembly);
    }

    [Fact]
    public void ChatClientLibrary_ShouldNotReferenceChatServerLibrary()
    {
        //Arrange
        var chatClientLibraryAssembly = typeof(IChatClient).Assembly;
        var chatServerLibraryAssembly = typeof(ChatDbContext).Assembly;

        //Act

        //Assert
        chatClientLibraryAssembly.Should().NotReference(chatServerLibraryAssembly);
    }
}
