using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UsersService;

/// <summary>
/// Стратегия управления пользователями через JSON файл.
/// </summary>
public class JSONUserStrategy : IManagementUserStrategy
{
    private string _sourceFile;

    public JSONUserStrategy(string sourceFile)
    {
        _sourceFile = sourceFile;
    }

    public User[] LoadUsers()
    {
        try
        {
            UserAdapter[]? users;

            // JSON десериализация.
            using (var stream = File.Open(_sourceFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                users = JsonSerializer.Deserialize(stream, typeof(UserAdapter[])) as UserAdapter[];
            }

            return users?.Select(ua => new User(ua.Id, ua.Name, ua.Age)).ToArray() ?? Array.Empty<User>();
        }
        catch (Exception)
        {
            return Array.Empty<User>();
        }
    }

    public void SaveUsers(User[] users)
    {
        // JSON сериализация.
        using (var stream = File.Create(_sourceFile))
        {
            JsonSerializer.Serialize(stream, users.Select(u => new UserAdapter(u)).ToArray());
        }
    }
}
