using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Teacher
{
    
    public partial class GestionClasses : MetroForm
    {
        loginteachDataContext db;

        public GestionClasses()
        {
            InitializeComponent();
        }

        private void GestionClasses_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();
            dataGridView1.DataSource = db.classes;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            var query1 = (from classe in db.classes
                         select classe.section ).Distinct();


            foreach (var c in query1)
            {
                comboBox1.Items.Add(c);
            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            var query = (from classe in db.classes
                         where comboBox1.SelectedItem as string == classe.section
                         select classe.niveau).Distinct();
            foreach (var c in query)
            {
                comboBox2.Items.Add(c);
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            var query = (from classe in db.classes
                         where classe.section == (string)comboBox1.SelectedItem 
                         && classe.niveau == (int)comboBox2.SelectedItem
                         && classe.groupe==(int)comboBox3.SelectedItem
                         select classe.annee_etude).Distinct();
            foreach (var c in query)
            {
                comboBox4.Items.Add(c);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            var query = (from classe in db.classes
                         where classe.section == (string)comboBox1.SelectedItem 
                         && classe.niveau == (int)comboBox2.SelectedItem
                         select classe.groupe).Distinct();
            foreach (var c in query)
            {
                comboBox3.Items.Add(c);
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var query4 = from classe in db.classes
                         where classe.section == (string)comboBox1.SelectedItem
                         && classe.niveau == (int)comboBox2.SelectedItem
                         && classe.groupe == (int)comboBox3.SelectedItem
                         && classe.annee_etude==(string)comboBox4.SelectedItem
                         select classe;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = query4;
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.SelectedText = "";
            

            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource = db.classes;
            var query2 = (from classe in db.classes
                          select classe.section).Distinct();


            foreach (var c in query2)
            {
                comboBox1.Items.Add(c);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                int val;
                int index = dataGridView1.CurrentCell.RowIndex;
                val = (int)dataGridView1[0, index].Value;
                classe t1 = db.classes.Single(x => x.id_classe == val);
                db.classes.DeleteOnSubmit(t1);
                db.SubmitChanges();


                MessageBox.Show("Classe Supprimé !");
                dataGridView1.DataSource = null;
                db = new loginteachDataContext();
                dataGridView1.DataSource = db.classes;
            }
             catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                int val;
                int index = dataGridView1.CurrentCell.RowIndex;
                val = (int)dataGridView1[0, index].Value;
                classe t1 = db.classes.Single(x => x.id_classe == val);
                t1.id_classe = (int)dataGridView1[0, index].Value;

                var query = from classe in db.classes
                            where classe.id_classe == t1.id_classe
                            select classe;
                foreach (classe emp in query)
                {
                    emp.section = (string)dataGridView1[1, index].Value;
                    emp.niveau = (int)dataGridView1[2, index].Value;
                    emp.annee_etude = (String)dataGridView1[3, index].Value;
                    emp.groupe = (int)dataGridView1[4, index].Value;
                }
                db.SubmitChanges();


                MessageBox.Show("Classe Modifié !");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.classes;
            }

            catch (SqlException ex)
            {
                MessageBox.Show("ID enseignant est  non compatible ");
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int total = db.classes.Count();
            try
            {

                string val;
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index < total)
                {
                    MessageBox.Show("Veuillez insérer les données du classa à ajouter dans la dernière ligne !");
                }
                else
                {

                    int id = (int)dataGridView1[0, index].Value;

                    var query = from classe in db.classes
                                where classe.id_classe == id
                                select classe;
                    if (query.Count() > 0)
                    {
                        MessageBox.Show("ID déjà inscrit");
                    }
                    else
                    {
                        classe c = new classe {
                            
                            section = (string)dataGridView1[1, index].Value,
                        niveau = (int)dataGridView1[2, index].Value,
                        annee_etude = (String)dataGridView1[3, index].Value,
                        groupe = (int)dataGridView1[4, index].Value
                        };


                        db.SubmitChanges();


                        MessageBox.Show("Classe ajouté !");
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = db.classes;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ID enseignant est  non compatible ");
            }

        }
    }
}
