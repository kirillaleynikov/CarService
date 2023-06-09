namespace CarService
{
    partial class MenuForEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForEmployees));
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRepairs = new System.Windows.Forms.Button();
            this.btnSpares = new System.Windows.Forms.Button();
            this.btnWorkers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.Gold;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.Location = new System.Drawing.Point(99, 113);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(280, 94);
            this.btnClients.TabIndex = 0;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnRepairs
            // 
            this.btnRepairs.BackColor = System.Drawing.Color.Gold;
            this.btnRepairs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRepairs.Location = new System.Drawing.Point(423, 113);
            this.btnRepairs.Name = "btnRepairs";
            this.btnRepairs.Size = new System.Drawing.Size(280, 94);
            this.btnRepairs.TabIndex = 1;
            this.btnRepairs.Text = "Ремонты";
            this.btnRepairs.UseVisualStyleBackColor = false;
            this.btnRepairs.Click += new System.EventHandler(this.btnRepairs_Click);
            // 
            // btnSpares
            // 
            this.btnSpares.BackColor = System.Drawing.Color.Gold;
            this.btnSpares.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSpares.Location = new System.Drawing.Point(99, 246);
            this.btnSpares.Name = "btnSpares";
            this.btnSpares.Size = new System.Drawing.Size(280, 94);
            this.btnSpares.TabIndex = 2;
            this.btnSpares.Text = "Запчасти";
            this.btnSpares.UseVisualStyleBackColor = false;
            this.btnSpares.Click += new System.EventHandler(this.btnSpares_Click);
            // 
            // btnWorkers
            // 
            this.btnWorkers.BackColor = System.Drawing.Color.Gold;
            this.btnWorkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWorkers.Location = new System.Drawing.Point(423, 246);
            this.btnWorkers.Name = "btnWorkers";
            this.btnWorkers.Size = new System.Drawing.Size(280, 94);
            this.btnWorkers.TabIndex = 3;
            this.btnWorkers.Text = "Сотрудники";
            this.btnWorkers.UseVisualStyleBackColor = false;
            this.btnWorkers.Click += new System.EventHandler(this.btnWorkers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarService.Properties.Resources._1674277465_catherineasquithgallery_com_p_serii_fon_avtoservis_foto_81;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 459);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MenuForEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWorkers);
            this.Controls.Add(this.btnSpares);
            this.Controls.Add(this.btnRepairs);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForEmployees";
            this.Text = "Меню для сотрудников";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForEmployees_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRepairs;
        private System.Windows.Forms.Button btnSpares;
        private System.Windows.Forms.Button btnWorkers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}