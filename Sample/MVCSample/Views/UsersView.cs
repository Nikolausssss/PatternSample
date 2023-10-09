using MVCSample.Controllers;
using MVCSample.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UsersService;

namespace MVCSample.Views;

public partial class UsersView : Form
{
    /// <summary>Часть костыля с помощью которого выделяется вся строка в DataGridView</summary>
    private bool _selectionProcessed;

    private readonly UsersController _usersController;
    private readonly ModelActionListenerService _actionListenerService;

    private User _selectedUser;


    internal UsersView(UsersController usersController, ModelActionListenerService actionListenerService)
    {
        InitializeComponent();
        _usersController = usersController;
        _actionListenerService = actionListenerService;
        _actionListenerService.AddListener(UserUpdate);

        gridUsers.SelectionChanged += GridUsers_SelectionChanged;

        btnDelete.Click += (s, e) => _usersController.DeleteUser(_selectedUser);
        btnEdit.Click += (s, e) => _usersController.EditUser(_selectedUser);
        btnRegister.Click += (s, e) => _usersController.RegisterUser();
    }

    private void GridUsers_SelectionChanged(object? sender, EventArgs e)
    {
        if (!_selectionProcessed)
        {
            _selectionProcessed = true;
            if (gridUsers.SelectedCells.Count != 0)
            {
                int rowIndex = gridUsers.SelectedCells[0].RowIndex;
                DataGridViewRow row = gridUsers.Rows[rowIndex];
                row.Selected = true;
                _selectedUser = row.DataBoundItem as User;
            }
            _selectionProcessed = false;
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        _actionListenerService.RemoveListener(UserUpdate);
        base.OnClosed(e);
    }

    private void UserUpdate(User[] users)
    {
        gridUsers.DataSource = users;
    }
}
