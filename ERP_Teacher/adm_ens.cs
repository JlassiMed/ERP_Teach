using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Teacher
{
    public partial class adm_ens : MetroForm
    {
        loginteachDataContext db; 
        public adm_ens()
        {
            InitializeComponent();
        }

        private void adm_ens_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.mecs;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                db = new loginteachDataContext();
                int val;
                int index = dataGridView1.CurrentCell.RowIndex;
                val = (int)dataGridView1[0, index].Value;
                mec t1 = new mec();

                t1.id = (int)dataGridView1[0, index].Value;
                t1.cin = (string)dataGridView1[1, index].Value;
                t1.module = (string)dataGridView1[2, index].Value;
                t1.classe = (int)dataGridView1[3, index].Value;
                if (t1 == null)
                {
                    MessageBox.Show("veuillez saisir les champs");

                }
                else
                {
                    db.mecs.InsertOnSubmit(t1);
                    db.SubmitChanges();
                    MessageBox.Show("Module affecté à "+t1.cin);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.mecs;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int val;
            int index = dataGridView1.CurrentCell.RowIndex;
            string cin= "";
            if (index < 0)
            { MessageBox.Show("selectionnez une ligne svp!"); }
            else
            {
                val = (int)dataGridView1[0, index].Value;
                mec t1 = db.mecs.Single(x => x.id == val);
                t1.id = (int)dataGridView1[0, index].Value;

                var query = from mec in db.mecs
                            where mec.id == t1.id
                            select mec;
                
                foreach (mec emp in query)
                {
                    //emp.cin_enseignant = (string)dataGridView1[0, index].Value;
                    emp.cin =(string)dataGridView1[1, index].Value;
                    cin = emp.cin;
                    emp.module = (string)dataGridView1[2, index].Value;
                    emp.classe = (int)dataGridView1[3, index].Value;
                    //emp.classe = (string)dataGridView1[4, index].Value;
                }

                db.SubmitChanges();


                MessageBox.Show(text: "Module Modifiée pour " +cin);
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = db.mecs;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                /*string val;
                val = textBox2.Text;
                val = (string)dataGridView1.CurrentRow.Cells[0].Value;*/
                /*string val;
                int index = dataGridView1.CurrentCell.RowIndex;
                val = (string)dataGridView1[0, index].Value;


                enseigner e1 = db.enseigner.SingleOrDefault(x => x.cin_enseignant == val && x.id_module == (string)dataGridView1[3, index].Value && x.id_classe == (string)dataGridView1[4, index].Value);
                enseignant e2 = db.enseignant.SingleOrDefault(x => x.cin == val);
                enseignant_mod e3 = db.enseignant_mod.SingleOrDefault(x => x.cin_enseignant == val && x.id_module== (string)dataGridView1[3, index].Value);
                db.enseignant.DeleteOnSubmit(e2);
                db.enseigner.DeleteOnSubmit(e1);
                
                db.enseignant_mod.DeleteOnSubmit(e3);
                
                db.SubmitChanges();
                MessageBox.Show("enseignant successfully deleted");
                //dataGridView1.DataSource = null;
                var query = from enseignant in db.enseignant
                            from enseigner in db.enseigner

                            where enseignant.cin == enseigner.cin_enseignant

                            && (enseigner.id_classe == comboBox2.SelectedText
                            || enseigner.id_module == comboBox2.SelectedText)
                            select new
                            {
                                cin = enseignant.cin,
                                nom = enseignant.nom,
                                prenom = enseignant.prenom,
                                module = enseigner.id_module,
                                classe = enseigner.id_classe
                            };
                dataGridView1.DataSource = query.ToList();*/

                int val;
                int index = dataGridView1.CurrentCell.RowIndex;
                val = (int)dataGridView1[0, index].Value;
                mec t1 = db.mecs.Single(x => x.id == val);
                db.mecs.DeleteOnSubmit(t1);
                db.SubmitChanges();


                MessageBox.Show("module Supprimée de "+t1.cin);
                dataGridView1.DataSource = null;
                loginteachDataContext d = new loginteachDataContext();
                dataGridView1.DataSource = d.mecs;




            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
