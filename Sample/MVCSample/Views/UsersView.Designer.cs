using System.Drawing;
using System.Windows.Forms;

namespace MVCSample.Views
{
    partial class UsersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnRegister = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            gridUsers = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnDelete);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(366, 49);
            panel1.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.AutoSize = true;
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Dock = DockStyle.Fill;
            btnRegister.Location = new Point(107, 10);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(188, 29);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Зарегистрировать";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.AutoSize = true;
            btnEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEdit.Dock = DockStyle.Left;
            btnEdit.Location = new Point(10, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(97, 29);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.BackColor = SystemColors.Control;
            btnDelete.Dock = DockStyle.Right;
            btnDelete.Location = new Point(295, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(61, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // gridUsers
            // 
            gridUsers.AllowUserToAddRows = false;
            gridUsers.AllowUserToDeleteRows = false;
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Fill;
            gridUsers.Location = new Point(0, 49);
            gridUsers.Name = "gridUsers";
            gridUsers.RowTemplate.Height = 25;
            gridUsers.Size = new Size(366, 463);
            gridUsers.TabIndex = 2;
            // 
            // UsersView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 512);
            Controls.Add(gridUsers);
            Controls.Add(panel1);
            Name = "UsersView";
            Text = "UsersView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnRegister;
        private DataGridView gridUsers;
    }
}