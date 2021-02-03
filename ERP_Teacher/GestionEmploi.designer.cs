namespace ERP_Enseignant
{
    partial class Emploi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Refraichir = new System.Windows.Forms.Button();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.cin = new System.Windows.Forms.ComboBox();
            this.emploi_ens = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupe = new System.Windows.Forms.ComboBox();
            this.module = new System.Windows.Forms.ComboBox();
            this.supprimer = new System.Windows.Forms.Button();
            this.modifier = new System.Windows.Forms.Button();
            this.ajouter = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emploi_ens)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Refraichir);
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.cin);
            this.panel1.Controls.Add(this.emploi_ens);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupe);
            this.panel1.Controls.Add(this.module);
            this.panel1.Controls.Add(this.supprimer);
            this.panel1.Controls.Add(this.modifier);
            this.panel1.Controls.Add(this.ajouter);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(5, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 387);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERP_Teacher.Properties.Resources._15_512;
            this.pictureBox1.Location = new System.Drawing.Point(782, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Refraichir
            // 
            this.Refraichir.Location = new System.Drawing.Point(600, 346);
            this.Refraichir.Name = "Refraichir";
            this.Refraichir.Size = new System.Drawing.Size(75, 23);
            this.Refraichir.TabIndex = 17;
            this.Refraichir.Text = "Refraichir";
            this.Refraichir.UseVisualStyleBackColor = true;
            this.Refraichir.Click += new System.EventHandler(this.Refraichir_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = global::ERP_Teacher.Properties.Resources.icons8_Search_48px_1;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(663, 10);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(38, 29);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton1.TabIndex = 14;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // cin
            // 
            this.cin.FormattingEnabled = true;
            this.cin.Location = new System.Drawing.Point(75, 13);
            this.cin.Name = "cin";
            this.cin.Size = new System.Drawing.Size(121, 21);
            this.cin.TabIndex = 13;
            this.cin.SelectedIndexChanged += new System.EventHandler(this.cin_SelectedIndexChanged);
            // 
            // emploi_ens
            // 
            this.emploi_ens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emploi_ens.Location = new System.Drawing.Point(17, 51);
            this.emploi_ens.Name = "emploi_ens";
            this.emploi_ens.Size = new System.Drawing.Size(684, 283);
            this.emploi_ens.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(778, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calendrier du mois";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "CIN";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(229, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Module";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(459, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Groupe";
            // 
            // groupe
            // 
            this.groupe.FormattingEnabled = true;
            this.groupe.Location = new System.Drawing.Point(529, 12);
            this.groupe.Name = "groupe";
            this.groupe.Size = new System.Drawing.Size(121, 21);
            this.groupe.TabIndex = 6;
            // 
            // module
            // 
            this.module.FormattingEnabled = true;
            this.module.Location = new System.Drawing.Point(312, 12);
            this.module.Name = "module";
            this.module.Size = new System.Drawing.Size(121, 21);
            this.module.TabIndex = 5;
            // 
            // supprimer
            // 
            this.supprimer.Location = new System.Drawing.Point(442, 344);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(75, 23);
            this.supprimer.TabIndex = 4;
            this.supprimer.Text = "Supprimer";
            this.supprimer.UseVisualStyleBackColor = true;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // modifier
            // 
            this.modifier.Location = new System.Drawing.Point(260, 344);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(75, 23);
            this.modifier.TabIndex = 3;
            this.modifier.Text = "Modifier";
            this.modifier.UseVisualStyleBackColor = true;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // ajouter
            // 
            this.ajouter.Location = new System.Drawing.Point(75, 344);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(75, 23);
            this.ajouter.TabIndex = 2;
            this.ajouter.Text = "Ajouter";
            this.ajouter.UseVisualStyleBackColor = true;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(709, 125);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // Emploi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 446);
            this.Controls.Add(this.panel1);
            this.Name = "Emploi";
            this.Text = "Gestion Emplois ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Emploi_FormClosing);
            this.Load += new System.EventHandler(this.Emploi_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emploi_ens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Refraichir;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.ComboBox cin;
        private System.Windows.Forms.DataGridView emploi_ens;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupe;
        private System.Windows.Forms.ComboBox module;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.Button modifier;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}