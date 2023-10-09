using MVPSample.Common;

using System;
using System.Windows.Forms;

namespace MVPSample.Views;

public partial class UserEditView : Form, IUserEditView
{
    /// <summary>Подтверждение пользователя о сохранении</summary>
    private bool _result;

    public UserEditView()
    {
        InitializeComponent();

        btnClose.Click += BtnClose_Click;
        btnSave.Click += BtnSave_Click;
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(tbAge.Text, out int age))
        {
            MessageBox.Show("Возраст должен быть числом");
            return;
        }

        UserAge = age;
        UserName = tbName.Text;
        _result = true;
        Close();
    }

    private void BtnClose_Click(object? sender, EventArgs e)
    {
        _result = false;
        Close();
    }

    public int Id { get; set; }
    public int UserAge { get; set; }
    public string UserName { get; set; }

    bool IUserEditView.Show()
    {
        tbName.Text = UserName;
        tbAge.Text = UserAge.ToString();
        ShowDialog();
        return _result;
    }

}
