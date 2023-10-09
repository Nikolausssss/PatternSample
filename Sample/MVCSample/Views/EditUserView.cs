using MVCSample.Controllers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCSample.Views;

public partial class EditUserView : Form
{
    private EditUserController _editUserController;
    private RegisterUserController _registerUserController;


    private EditUserView(string name = "", int age = 0)
    {
        InitializeComponent();
        tbName.Text = name;
        tbAge.Text = age.ToString();
        tbAge.Validating += TbAge_Validating;
        tbName.Validating += TbName_Validating;

        btnSave.Click += BtnSave_Click;
        btnCancel.Click += (s, e) => Close();
    }

    internal EditUserView(EditUserController editUserController)
        : this(editUserController.UserName, editUserController.UserAge)
    {
        _editUserController = editUserController;
    }

    internal EditUserView(RegisterUserController registerUserController) : this()
    {
        _registerUserController = registerUserController;
    }


    private void BtnSave_Click(object? sender, EventArgs e)
    {

        if (errorProvider1.HasErrors) return;

        if (_editUserController == null)
        {
            _registerUserController.UserName = tbName.Text;
            _registerUserController.UserAge = int.Parse(tbAge.Text);
            _registerUserController.RegisterUser();
            Close();
            return;
        }
        _editUserController.UserName = tbName.Text;
        _editUserController.UserAge = int.Parse(tbAge.Text);
        _editUserController.SaveChanges();
        Close();
    }

    private void TbName_Validating(object? sender, CancelEventArgs e)
    {
        if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrWhiteSpace(tbName.Text))
        {
            errorProvider1.SetError(tbName, "Недопустимое имя");
            return;
        }
        errorProvider1.Clear();
    }

    private void TbAge_Validating(object? sender, CancelEventArgs e)
    {
        if (int.TryParse(tbAge.Text, out int age) && age > 0)
        {
            errorProvider1.Clear();
            return;
        }
        errorProvider1.SetError(tbAge, "Возраст это число");
    }

}
