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
    public partial class AdminLogin : MetroForm
    {
        loginteachDataContext db;
        public static Administrator ValidatedAdmin = new Administrator(); 
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void cin_tb_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cin_tb.Text, "[^0-9]"))
            {
                cin_tb.Text = cin_tb.Text.Remove(cin_tb.Text.Length - 1);
                cin_tb.SelectionStart = cin_tb.Text.Length;

            }

            if (cin_tb.Text.Length == 0)
            {
                cin_tb.SelectionLength = 0;

            }
        }

        private void AdminLogincs_Load(object sender, EventArgs e) => cin_tb.Focus();

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cin_tb.Text) || cin_tb.Text.Length < 8)
                MessageBox.Show("cin vide ou de longeur inférieur à 8 !", "Réssayez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            { try
                {
                    db = new loginteachDataContext();
                    Administrator a = new Administrator();
                    a.cin = cin_tb.Text;
                    a.mot_de_passe = mdp_tb.Text;
                    var query = from Administrateur in db.Administrators
                                where Administrateur.cin == a.cin
                                select Administrateur;
                    
                    List<Administrator> listeAd = query.ToList<Administrator>();
                    if (listeAd.Count == 0)
                    {
                        MessageBox.Show("cin introuvable veuillez vérifier !");
                    }
                    else
                    {
                        Administrator ad = listeAd[0];
                        if (ad.mot_de_passe != a.mot_de_passe)
                        {
                            MessageBox.Show("mot de passe incorrect");
                        }
                        else
                        {

                            ValidatedAdmin.cin = ad.cin;
                            ValidatedAdmin.mot_de_passe =ad.mot_de_passe;
                            ValidatedAdmin.nom = ad.nom;
                            ValidatedAdmin.prenom = ad.prenom;
                            ValidatedAdmin.mail = ad.mail;
                            
                            DashboardAdmin ac = new DashboardAdmin();
                            ac.Show();
                            Hide();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                }
            } 
        }
    }
}
