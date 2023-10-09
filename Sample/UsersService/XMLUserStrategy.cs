using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace UsersService;

/// <summary>
/// Стратегия управления пользователями через XML файл.
/// </summary>
public class XMLUserStrategy : IManagementUserStrategy
{
    private readonly string _sourceFile;

    public XMLUserStrategy(string sourceFile)
    {
        _sourceFile = sourceFile;
    }

    public User[] LoadUsers()
    {
        try
        {
            UserAdapter[]? users;

            // XML десериализация.
            XmlSerializer serializer = new XmlSerializer(typeof(UserAdapter[]));
            using (var stream = File.Open(_sourceFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                users = serializer.Deserialize(stream) as UserAdapter[];
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
        // XML сериализация.
        XmlSerializer serializer = new XmlSerializer(typeof(UserAdapter[]));
        using (var stream = File.Create(_sourceFile))
        {
            serializer.Serialize(stream, users.Select(u => new UserAdapter(u)).ToArray());
        }
    }
}
