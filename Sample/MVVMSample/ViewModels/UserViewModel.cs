using UsersService;

namespace MVVMSample.ViewModels;

/// <summary>Предстваляет ViewModel пользователя</summary>
internal class UserViewModel
{
    public UserViewModel(User user)
    {
        User = user;
        Name = user.Name;
        Age = user.Age;
    }


    public User User { get; }
    public string Name { get; set; }
    public int Age { get; set; }
}
