namespace Hotel_Reservations_Management
{
    partial class frmBookRoom
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDate = new MetroFramework.Controls.MetroDateTime();
            this.toDate = new MetroFramework.Controls.MetroDateTime();
            this.btnBook = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsers = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(212, 102);
            this.fromDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(243, 30);
            this.fromDate.TabIndex = 2;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(212, 174);
            this.toDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(243, 30);
            this.toDate.TabIndex = 3;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(207, 307);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(248, 41);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Users";
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.ItemHeight = 24;
            this.cmbUsers.Location = new System.Drawing.Point(212, 245);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(243, 30);
            this.cmbUsers.TabIndex = 6;
            this.cmbUsers.UseSelectable = true;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // frmBookRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 405);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookRoom";
            this.Padding = new System.Windows.Forms.Padding(30, 94, 30, 31);
            this.Text = "Book Room";
            this.Load += new System.EventHandler(this.frmBookRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroDateTime fromDate;
        private MetroFramework.Controls.MetroDateTime toDate;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox cmbUsers;
    }
}