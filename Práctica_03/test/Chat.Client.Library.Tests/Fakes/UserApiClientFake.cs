using Chat.Client.Library.Services;
using Chat.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client.Library.Tests.Fakes;

internal class UserApiClientFake : IUserApiClient
{
    public async Task<ChatUser> CreateUserAsync(string username, string password)
    {
        var user = Task.Run<ChatUser>(() => {
            return new ChatUser
            {
                IdUser = 1,
                Name = "Javi",
                Password = "Pass"
            };
        });

        return await user;
    }

    public async Task<ChatUser> LoginAsync(string username, string password)
    {
        List<ChatUser> validUsers = new List<ChatUser>();
        validUsers.Add(new ChatUser { Name = "Usuario1", Password = "P2ssw0rd!" });
        validUsers.Add(new ChatUser { Name = "Usuario3", Password = "P2ssw0rd!" });

        var user = Task.Run<ChatUser>(() => {
            return validUsers.FirstOrDefault(user => user.Name == username && user.Password == password); ;
        });

        return await user;
    }
}
