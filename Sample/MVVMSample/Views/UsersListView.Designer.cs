namespace MVVMSample.Views
{
    partial class UsersListView
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
            panel1 = new System.Windows.Forms.Panel();
            btnRegister = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            gridUsers = new System.Windows.Forms.DataGridView();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnDelete);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(679, 51);
            panel1.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            btnRegister.Location = new System.Drawing.Point(0, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(585, 51);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Зарегистрировать";
            btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            btnDelete.Location = new System.Drawing.Point(585, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(94, 51);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // gridUsers
            // 
            gridUsers.AllowUserToAddRows = false;
            gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colAge });
            gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            gridUsers.Location = new System.Drawing.Point(0, 51);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.RowTemplate.Height = 29;
            gridUsers.Size = new System.Drawing.Size(679, 656);
            gridUsers.TabIndex = 1;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Название";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.Width = 125;
            // 
            // colAge
            // 
            colAge.DataPropertyName = "Age";
            colAge.HeaderText = "Возраст";
            colAge.MinimumWidth = 6;
            colAge.Name = "colAge";
            colAge.Width = 125;
            // 
            // UsersListView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(679, 707);
            Controls.Add(gridUsers);
            Controls.Add(panel1);
            Name = "UsersListView";
            Text = "UsersListView";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
    }
}