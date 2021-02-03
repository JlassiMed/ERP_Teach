using MetroFramework.Forms;
using System;
using System.Collections;
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
    public partial class chercher : MetroForm 
    {
        loginteachDataContext db; 

        public chercher()
        {
            InitializeComponent();
        }

        private void chercher_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();
            var query = from mod in db.modules
                        select mod;
            foreach (var m in query)
            {
                comboBox1.Items.Add(m.id_module);
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            /*var query = from enseignant in db.enseignants
                        from enseigner in db.enseigners

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
            dataGridView1.DataSource = query.ToList();
            */

            var query = from ens in db.enseigners
                        where ens.id_module == comboBox1.SelectedItem as string && ens.id_classe == Int32.Parse( comboBox2.SelectedItem.ToString())
                        select ens;
            ArrayList a = new ArrayList();

            foreach (var ex in query)
            {
                var querry = from enseignant in db.enseignants
                             where ex.cin_enseignant == enseignant.cin
                             select enseignant;
                
                var x = new {CIN= ex.cin_enseignant,Nom= querry.ToList()[0].nom, Prenom = querry.ToList()[0].prenom,Classe= ex.id_classe };
                a.Add(x);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = a;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();


            var query = from cla in db.enseigners
                        where cla.id_module== comboBox1.SelectedItem as string
                        select cla.id_classe;
                foreach (var m in query)
                    comboBox2.Items.Add(m);
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
