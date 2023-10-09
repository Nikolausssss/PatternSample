using MVPSample.Common;
using MVPSample.Presenters;

using System;
using System.Windows.Forms;

using UsersService;

namespace MVPSample.Views;

public partial class UserListView : Form, IUsersListView
{
    private UsersPresenter? _presenter;
    /// <summary>Часть костыля с помощью которого выделяется вся строка в DataGridView</summary>
    private bool _selectionProcessed;

    public UserListView()
    {
        InitializeComponent();

        gridUsers.SelectionChanged += ListUsers_SelectionChanged;
        btnDelete.Click += BtnDelete_Click;
        btnEdit.Click += BtnEdit_Click;
        btnRegister.Click += BtnRegister_Click;
    }

    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        _presenter?.StartRegisterUser();
    }

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        _presenter?.StartEditUser();
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        _presenter?.StartDeleteUser();
    }

    private void ListUsers_SelectionChanged(object? sender, EventArgs e)
    {
        if (!_selectionProcessed)
        {
            _selectionProcessed = true;
            if (gridUsers.SelectedCells.Count != 0)
            {
                int rowIndex = gridUsers.SelectedCells[0].RowIndex;
                DataGridViewRow row = gridUsers.Rows[rowIndex];
                row.Selected = true;
                SelectedUser = row.DataBoundItem as User;
            }
            _selectionProcessed = false;
        }
    }

    public User SelectedUser { get; private set; }

    public void UpdateUsers(User[] users)
    {
        gridUsers.DataSource = users;
    }

    void IUsersListView.SetPresenter(UsersPresenter presenter)
    {
        _presenter = presenter;
    }
}
