using ERP_Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Enseignant
{
    public partial class Accueil_Enseignant : MetroFramework.Forms.MetroForm
    {
        loginteachDataContext db;
    
        public Accueil_Enseignant()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();

            nom.Text = login.ValidatedEns.nom;
                        prenom.Text = login.ValidatedEns.prenom;
                        var result = byteArrayToImage(login.ValidatedEns.photo.ToArray());
                        photo.Image = result;

            var query = from Notification in db.Notifications
                        orderby Notification.date descending
                        where Notification.id_ens == login.ValidatedEns.cin
                       
                        select Notification;
            foreach (Notification n in query)
                listBox1.Items.Add("X " + n.description + " " + n.date);


            listBox1.Visible = false;



        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
                listBox1.Visible = true;
            else
                listBox1.Visible = false;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            info_perso IP = new info_perso();
            IP.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            TAR tar = new TAR();
            tar.Show();
              
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           Emploi_ens emp = new Emploi_ens();
            emp.Show();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
           /* ass as= new ass();
            as.Show(); */ 
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Telechargement tel = new Telechargement();
            tel.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            GestModule gt = new GestModule();
            gt.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            etud.Classe gc = new etud.Classe();
            gc.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            ERP_Teacher.Stats s = new ERP_Teacher.Stats();
            s.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
