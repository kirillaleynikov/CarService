namespace CarService
{
    partial class Clients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxForSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoToAddClient = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxIdClient = new System.Windows.Forms.TextBox();
            this.TextBoxStateNumber = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAddPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCarMark = new System.Windows.Forms.TextBox();
            this.textBoxAddName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gold;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBoxForSearch
            // 
            this.textBoxForSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxForSearch.Location = new System.Drawing.Point(382, 120);
            this.textBoxForSearch.Name = "textBoxForSearch";
            this.textBoxForSearch.Size = new System.Drawing.Size(424, 38);
            this.textBoxForSearch.TabIndex = 1;
            this.textBoxForSearch.TextChanged += new System.EventHandler(this.textBoxForSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(274, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Поиск:";
            // 
            // btnGoToAddClient
            // 
            this.btnGoToAddClient.BackColor = System.Drawing.Color.Gold;
            this.btnGoToAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGoToAddClient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGoToAddClient.Location = new System.Drawing.Point(8, 475);
            this.btnGoToAddClient.Name = "btnGoToAddClient";
            this.btnGoToAddClient.Size = new System.Drawing.Size(296, 48);
            this.btnGoToAddClient.TabIndex = 3;
            this.btnGoToAddClient.Text = "Добавить клиента";
            this.btnGoToAddClient.UseVisualStyleBackColor = false;
            this.btnGoToAddClient.Click += new System.EventHandler(this.btnGoToAddClient_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Gold;
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(216, 272);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(283, 61);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.Gold;
            this.btnDeleteClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteClient.Location = new System.Drawing.Point(8, 535);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(296, 44);
            this.btnDeleteClient.TabIndex = 5;
            this.btnDeleteClient.Text = "Удалить клиента";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gold;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.Location = new System.Drawing.Point(8, 597);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(296, 45);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Обновить таблицу";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxIdClient);
            this.groupBox1.Controls.Add(this.TextBoxStateNumber);
            this.groupBox1.Controls.Add(this.textBoxAddPhoneNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCarMark);
            this.groupBox1.Controls.Add(this.textBoxAddName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(382, 475);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 352);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование информации";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Код клиента:";
            // 
            // textBoxIdClient
            // 
            this.textBoxIdClient.Enabled = false;
            this.textBoxIdClient.Location = new System.Drawing.Point(216, 49);
            this.textBoxIdClient.Name = "textBoxIdClient";
            this.textBoxIdClient.Size = new System.Drawing.Size(117, 30);
            this.textBoxIdClient.TabIndex = 19;
            // 
            // TextBoxStateNumber
            // 
            this.TextBoxStateNumber.Enabled = false;
            this.TextBoxStateNumber.Location = new System.Drawing.Point(216, 225);
            this.TextBoxStateNumber.Mask = "L999LL999";
            this.TextBoxStateNumber.Name = "TextBoxStateNumber";
            this.TextBoxStateNumber.Size = new System.Drawing.Size(146, 30);
            this.TextBoxStateNumber.TabIndex = 18;
            // 
            // textBoxAddPhoneNumber
            // 
            this.textBoxAddPhoneNumber.Enabled = false;
            this.textBoxAddPhoneNumber.Location = new System.Drawing.Point(216, 137);
            this.textBoxAddPhoneNumber.Mask = "+7 (999) 999-99-99";
            this.textBoxAddPhoneNumber.Name = "textBoxAddPhoneNumber";
            this.textBoxAddPhoneNumber.Size = new System.Drawing.Size(204, 30);
            this.textBoxAddPhoneNumber.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Гос номер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Марка машины:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Номер телефона:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "ФИО:";
            // 
            // textBoxCarMark
            // 
            this.textBoxCarMark.Enabled = false;
            this.textBoxCarMark.Location = new System.Drawing.Point(216, 181);
            this.textBoxCarMark.Name = "textBoxCarMark";
            this.textBoxCarMark.Size = new System.Drawing.Size(405, 30);
            this.textBoxCarMark.TabIndex = 12;
            // 
            // textBoxAddName
            // 
            this.textBoxAddName.Enabled = false;
            this.textBoxAddName.Location = new System.Drawing.Point(216, 91);
            this.textBoxAddName.Name = "textBoxAddName";
            this.textBoxAddName.Size = new System.Drawing.Size(405, 30);
            this.textBoxAddName.TabIndex = 11;
            this.textBoxAddName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddName_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(8, 656);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 74);
            this.button1.TabIndex = 8;
            this.button1.Text = "Экспорт данных в Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 113);
            this.panel1.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarService.Properties.Resources.free_icon_satisfied_customer_2039048;
            this.pictureBox1.Location = new System.Drawing.Point(201, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(310, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(492, 38);
            this.label7.TabIndex = 0;
            this.label7.Text = "Каталог клиентов автосервиса";
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1049, 846);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnGoToAddClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxForSearch);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clients";
            this.Text = "Клиенты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Clients_FormClosed);
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxForSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGoToAddClient;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox TextBoxStateNumber;
        private System.Windows.Forms.MaskedTextBox textBoxAddPhoneNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCarMark;
        private System.Windows.Forms.TextBox textBoxAddName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxIdClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}