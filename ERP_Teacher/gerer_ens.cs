using ERP_Enseignant;
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
    public partial class gerer_ens : MetroForm
        {
        public static enseignant s;
        loginteachDataContext db;
        public gerer_ens()
        {
            InitializeComponent();
        }

        private void gerer_ens_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();
            enseignant s = new enseignant();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Inscription_Enseignant i = new Inscription_Enseignant();
            i.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                db = new loginteachDataContext();
                enseignant ens = new enseignant();
                ens.cin = textBox1.Text;
                var query = from enseignant in db.enseignants
                            where enseignant.cin == ens.cin
                            select enseignant;
                List<enseignant> listeEns = query.ToList<enseignant>();
                
                if (listeEns.Count != 0)
                {
                    s = listeEns[0];
                   /* s.cin = enss.cin;
                    s.code_a_bar = enss.code_a_bar;
                    s.mail = enss.mail;
                    s.mots_de_passe = enss.mots_de_passe;
                    s.nom = enss.nom;
                    s.prenom = enss.prenom;
                    s.photo = enss.photo;*/

                    modif_ens m = new modif_ens();
                    m.Show();
                }
                else MessageBox.Show("Enseignant n'est pas trouvé vérifier CIN !");
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                string val = (string)textBox1.Text;
                /*mec t2 = db.mec.Single(x => x.cin == val);
                if (t2 != null)
                db.mec.DeleteOnSubmit(t2);*/
                var query = from enseignant in db.enseignants
                            where enseignant.cin == val
                            select enseignant;
                List<enseignant> ListeEns = query.ToList();
                if (ListeEns.Count == 0)
                    MessageBox.Show("Enseignant n'est pas trouvé vérifier CIN !");
                else
                {
                    enseignant sup = ListeEns[0];
                    db.enseignants.DeleteOnSubmit(sup);
                    db.SubmitChanges();
                    MessageBox.Show("Enseignant supprimé!");
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            chercher ch = new chercher();
            ch.Show(); 
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            adm_ens ae = new adm_ens();
            ae.Show(); 
        }
    }
}
