namespace MVPSample.Views
{
    partial class UserEditView
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
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            tbAge = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tbName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnSave);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(11, 139);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(226, 33);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            btnClose.Location = new System.Drawing.Point(43, 0);
            btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 11, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(86, 33);
            btnClose.TabIndex = 1;
            btnClose.Text = "Отмена";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            btnSave.Location = new System.Drawing.Point(129, 0);
            btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(97, 33);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(tbAge);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tbName);
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(11, 13);
            panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(226, 126);
            panel2.TabIndex = 1;
            // 
            // tbAge
            // 
            tbAge.Dock = System.Windows.Forms.DockStyle.Top;
            tbAge.Location = new System.Drawing.Point(0, 67);
            tbAge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbAge.Name = "tbAge";
            tbAge.Size = new System.Drawing.Size(226, 27);
            tbAge.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Location = new System.Drawing.Point(0, 47);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 20);
            label1.TabIndex = 2;
            label1.Text = "Возраст";
            // 
            // tbName
            // 
            tbName.Dock = System.Windows.Forms.DockStyle.Top;
            tbName.Location = new System.Drawing.Point(0, 20);
            tbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbName.Name = "tbName";
            tbName.Size = new System.Drawing.Size(226, 27);
            tbName.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Top;
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 20);
            label2.TabIndex = 3;
            label2.Text = "Имя";
            // 
            // UserEditView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(248, 185);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "UserEditView";
            Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            Text = "UserListView";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}