using MVCSample.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCSample.Views;

internal class DeleteUserView
{
    private readonly DeleteUserController _deleteUserController;

    public DeleteUserView(DeleteUserController  deleteUserController)
    {
        _deleteUserController = deleteUserController;
    }

    public void Show()
    {
        if(MessageBox.Show($"Вы действительно хотите удалить пользователя {_deleteUserController.User}",
                           "Подтверждение удаления",
                           MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _deleteUserController.DeleteUser();
        }
    }
}
