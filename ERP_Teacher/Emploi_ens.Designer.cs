namespace ERP_Teacher
{
    partial class Emploi_ens
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
            this.Refraichir = new System.Windows.Forms.Button();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.emploi_ense = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupe = new System.Windows.Forms.ComboBox();
            this.module = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.CIN = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emploi_ense)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CIN);
            this.panel1.Controls.Add(this.Refraichir);
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.emploi_ense);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupe);
            this.panel1.Controls.Add(this.module);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(7, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 387);
            this.panel1.TabIndex = 2;
            // 
            // Refraichir
            // 
            this.Refraichir.Location = new System.Drawing.Point(775, 326);
            this.Refraichir.Name = "Refraichir";
            this.Refraichir.Size = new System.Drawing.Size(104, 23);
            this.Refraichir.TabIndex = 17;
            this.Refraichir.Text = "Afficher Tout";
            this.Refraichir.UseVisualStyleBackColor = true;
            this.Refraichir.Click += new System.EventHandler(this.Refraichir_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = global::ERP_Teacher.Properties.Resources.icons8_Search_48px_1;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(723, 26);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(38, 42);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton1.TabIndex = 14;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // emploi_ense
            // 
            this.emploi_ense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emploi_ense.Location = new System.Drawing.Point(13, 89);
            this.emploi_ense.Name = "emploi_ense";
            this.emploi_ense.Size = new System.Drawing.Size(684, 283);
            this.emploi_ense.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(772, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calendrier du mois";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "CIN";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(210, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Module";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(459, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Groupe";
            // 
            // groupe
            // 
            this.groupe.FormattingEnabled = true;
            this.groupe.Location = new System.Drawing.Point(529, 28);
            this.groupe.Name = "groupe";
            this.groupe.Size = new System.Drawing.Size(121, 21);
            this.groupe.TabIndex = 6;
            // 
            // module
            // 
            this.module.FormattingEnabled = true;
            this.module.Location = new System.Drawing.Point(312, 26);
            this.module.Name = "module";
            this.module.Size = new System.Drawing.Size(121, 21);
            this.module.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(706, 140);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // CIN
            // 
            this.CIN.Location = new System.Drawing.Point(78, 26);
            this.CIN.Multiline = true;
            this.CIN.Name = "CIN";
            this.CIN.Size = new System.Drawing.Size(100, 23);
            this.CIN.TabIndex = 18;
            this.CIN.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Emploi_ens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 470);
            this.Controls.Add(this.panel1);
            this.Name = "Emploi_ens";
            this.Text = "Voici votre Emploi ";
            this.Load += new System.EventHandler(this.Emploi_ens_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emploi_ense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CIN;
        private System.Windows.Forms.Button Refraichir;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.DataGridView emploi_ense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupe;
        private System.Windows.Forms.ComboBox module;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}