using MVVMSample.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMSample.Views
{
    public partial class UsersListView : Form
    {
        /// <summary>Часть костыля с помощью которого выделяется вся строка в DataGridView</summary>
        private bool _selectionProcessed;

        internal UsersListView(UsersListViewModel usersListViewModel)
        {
            InitializeComponent();
            gridUsers.AutoGenerateColumns = false;

            DataContext = usersListViewModel;

            BindSelectedItem(gridUsers, usersListViewModel);
        }


        protected override void OnDataContextChanged(EventArgs e)
        {
            btnDelete.DataBindings.Add(new Binding(nameof(Button.Command),
                                                   DataContext,
                                                   nameof(UsersListViewModel.DeleteUserCommand),
                                                   true));

            btnRegister.DataBindings.Add(new Binding(nameof(Button.Command),
                                                     DataContext,
                                                     nameof(UsersListViewModel.AddNewUserCommand),
                                                     true));

            gridUsers.DataBindings.Add(new Binding(nameof(DataGridView.DataSource), DataContext, nameof(UsersListViewModel.Users)));


            base.OnDataContextChanged(e);
        }

        // Костыль для получения выбранного пользователя
        private void BindSelectedItem(DataGridView gridUsers, UsersListViewModel usersListViewModel)
        {
            // Привязка к событию изменения выборки в DataGridView.
            gridUsers.SelectionChanged += (s, e) =>
            {
                if (_selectionProcessed)
                {
                    return;
                }

                _selectionProcessed = true;

                if (gridUsers.SelectedCells.Count != 0)
                {
                    int rowIndex = gridUsers.SelectedCells[0].RowIndex;
                    DataGridViewRow row = gridUsers.Rows[rowIndex];
                    usersListViewModel.SelectedUser = row.DataBoundItem as UserViewModel;
                }

                _selectionProcessed = false;
            };

            // Привязка к изменению значения свойства SelectedItem во ViewModel
            usersListViewModel.PropertyChanged += (s, e) =>
            {
                if (_selectionProcessed)
                {
                    return;
                }

                if (e.PropertyName != nameof(UsersListViewModel.SelectedUser))
                {
                    return;
                }

                _selectionProcessed = true;

                gridUsers.ClearSelection();
                foreach (DataGridViewRow row in gridUsers.Rows)
                {
                    if (usersListViewModel.SelectedUser.Equals(row.DataBoundItem))
                    {
                        row.Selected = true;
                        break;
                    }
                }

                _selectionProcessed = false;
            };
        }
    }
}
