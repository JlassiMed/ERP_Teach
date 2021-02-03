using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.Linq.Mapping;
using ERP_Teacher;
using Bunifu.Framework;
using System.Data.SqlClient;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;
using System.Collections.Specialized;
using Nemiro.OAuth.LoginForms;

namespace ERP_Enseignant
{
    public partial class login : MetroForm 
    {
        

        loginteachDataContext db;
        // loginteachDataContext db = new loginteachDataContext(@"Data Source = MEDJL47\SQLEXPRESS; Initial Catalog = ERP_Teacher; Integrated Security = True;Pooling=False");
        public static string logintype;
        public static enseignant ValidatedEns;
        public login()
        {
            InitializeComponent();
       
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ValidatedEns = new enseignant();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (cin_tb.Text == "")
                MessageBox.Show("Veuillez remplir cin");
            else if(cin_tb.Text.Length>8)
                MessageBox.Show("la longueur de cin dépasse les 8 chiffres veuillez vérifier !");
            else if (mdp_tb.Text == "")
                MessageBox.Show("Veuillez remplir mot de passe !");
           
            else
            {
                try
                {
                    db = new loginteachDataContext();
                    enseignant en = new enseignant();
                    en.cin = cin_tb.Text.ToString();
                    en.mots_de_passe = mdp_tb.Text.ToString();
                    

                    var query = from enseignant in db.enseignants
                                where enseignant.cin == en.cin
                                 select enseignant ;
                    List<enseignant> listeEns = query.ToList<enseignant>();
                    if (listeEns.Count==0 )
                    {
                        MessageBox.Show("cin introuvable veuillez vérifier !");
                    }
                    else
                    {
                        enseignant enss = listeEns[0];
                        if(enss.mots_de_passe!=en.mots_de_passe)
                        {
                            MessageBox.Show("mot de passe incorrect");
                        }
                        else
                        {
                            
                            ValidatedEns.cin = enss.cin;
                            ValidatedEns.mots_de_passe = enss.mots_de_passe;
                            ValidatedEns.nom = enss.nom;
                            ValidatedEns.prenom = enss.prenom;
                            ValidatedEns.mail = enss.mail;
                            ValidatedEns.photo = enss.photo;
                            ValidatedEns.code_a_bar = enss.code_a_bar;
                            Accueil_Enseignant ac = new Accueil_Enseignant();
                            ac.Show();
                            Hide();
                        }
                    }
                    
                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Erreur de connection BD "+ex.Message);
                }
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Inscription_Enseignant i = new Inscription_Enseignant();
            i.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            QrScanner q = new QrScanner();
            q.Show();
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            var login = new FacebookLogin("1435890426686808", "c6057dfae399beee9e8dc46a4182e8fd", true, true);


            login.ShowDialog();
            if (login.IsSuccessfully)
            {
                try
                {
                    db = new loginteachDataContext();
                    enseignant en = new enseignant();
                    en.fbid = login.UserInfo.UserId;
                    var query = from enseignant in db.enseignants
                                where enseignant.fbid == en.fbid
                                select enseignant;
                    List<enseignant> listeEns = query.ToList<enseignant>();
                    if (listeEns.Count == 0)
                    {
                        MessageBox.Show("aucun compte n'est lié à ce compte facebook !");
                    }
                    else
                    {
                        enseignant enss = listeEns[0];
                        ValidatedEns.cin = enss.cin;
                        ValidatedEns.mots_de_passe = enss.mots_de_passe;
                        ValidatedEns.nom = enss.nom;
                        ValidatedEns.prenom = enss.prenom;
                        ValidatedEns.mail = enss.mail;
                        ValidatedEns.photo = enss.photo;
                        ValidatedEns.code_a_bar = enss.code_a_bar;
                        Accueil_Enseignant ac = new Accueil_Enseignant();
                        ac.Show();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur de connection BD " + ex.Message);
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            //var login = new GoogleLogin("934704666049 - 129jsvmelksmcmf250ir90aqn8pk4nak.apps.googleusercontent.com", "OS7HZ1cfJnhdIFZ6fUsgamH-", returnUrl: null, autoLogout: true, loadUserInfo: true);
            var login = new GoogleLogin
            ("934704666049-129jsvmelksmcmf250ir90aqn8pk4nak.apps.googleusercontent.com",
              "OS7HZ1cfJnhdIFZ6fUsgamH-", returnUrl: null, scope: "https://www.googleapis.com/auth/drive", loadUserInfo: true,responseType: ResponseType.Code);
            login.ShowDialog();
            if (login.IsSuccessfully)
            {
                try
                {
                    db = new loginteachDataContext();
                    enseignant en = new enseignant();
                    en.gmailid = login.UserInfo.UserId;
                    var query = from enseignant in db.enseignants
                                where enseignant.gmailid == en.gmailid
                                select enseignant;
                    List<enseignant> listeEns = query.ToList<enseignant>();
                    if (listeEns.Count == 0)
                    {
                        MessageBox.Show("ce compte gmail n'est pas lié à aucun compte !");
                    }
                    else
                    {

                        enseignant enss = listeEns[0];
                        ValidatedEns.cin = enss.cin;
                        ValidatedEns.mots_de_passe = enss.mots_de_passe;
                        ValidatedEns.nom = enss.nom;
                        ValidatedEns.prenom = enss.prenom;
                        ValidatedEns.mail = enss.mail;
                        ValidatedEns.photo = enss.photo;
                        ValidatedEns.code_a_bar = enss.code_a_bar;
                        Accueil_Enseignant ac = new Accueil_Enseignant();
                        ac.Show();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur de connection BD " + ex.Message);
                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FacialRecog fr = new FacialRecog();
            fr.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Show();
            
        }
    }
}
