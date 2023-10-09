using MVPSample.Common;

using System.Windows.Forms;

using UsersService;

namespace MVPSample.Views;

internal class UserDeleteView : IUserDeleteView
{
    public bool Show(User user)
    {
        return MessageBox.Show($"Вы действительно хотите удалить пользователя {user}",
                             "Подтверждение удаления",
                             MessageBoxButtons.YesNo) == DialogResult.Yes;
    }
}
