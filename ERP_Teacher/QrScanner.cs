using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchlessLib;
using WebCamLib;
using ZXing;
using MetroFramework.Forms;
using System.Data.SqlClient;
using ERP_Enseignant;

namespace ERP_Teacher
{
    public partial class QrScanner : MetroForm
    {
        string cin;
        string pass;
        loginteachDataContext db;
        public QrScanner()
        {
            InitializeComponent();
        }
        TouchlessMgr touch = new TouchlessMgr();
        Bitmap bf;
        private void QrScanner_Load(object sender, EventArgs e)
        {
            foreach (Camera c in touch.Cameras)
                if (c != null)
                {
                    touch.CurrentCamera = c;
                    c.OnImageCaptured += C_OnImageCaptured;
                    break;
                }
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
           if (b != null)
            {
                e.Graphics.DrawImageUnscaledAndClipped(b, pictureBox1.ClientRectangle);
            }
        }
        Bitmap b;
        private void C_OnImageCaptured(object sender, CameraEventArgs e)
        {
            if (button1.Enabled && uploadclicked==false )
            {
                b = e.Image;
               pictureBox1.Invalidate();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            touch.CurrentCamera = null;
            uploadclicked = false;
            Bitmap c = touch.CurrentCamera.GetCurrentImage();
                pictureBox1.Image = c;
                bf = c;
                button1.Enabled = false;
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Enabled = true;
            touch.CurrentCamera = null;
            uploadclicked = false;
        }

        private void M_OnChange(object sender, MarkerEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reader = new ZXing.BarcodeReader();
            
            Result results = reader.Decode(bf);
            if (results == null)
            {
                MessageBox.Show("aucun qr code");
                return;
            }
            else
            {
                try
                {
                    string decoded = results.ToString().Trim();
                    cin = decoded.Substring(0, 8);
                    pass = decoded.Substring(8);
                    bunifuFlatButton1.Enabled = true;
                }
                catch(Exception exx) { }
                
            }
                
        }
        bool uploadclicked=false;
        private void button3_Click(object sender, EventArgs e)
        {
            touch.CurrentCamera=null;
            uploadclicked = true;
             OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = @"c:\";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Title = "Selectionner une photo";
            ofd.Filter = "Tous les types d'images|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png|" + "Bitmap (*.bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String f1 = ofd.FileName.ToString();
                
                pictureBox1.ImageLocation = f1;
                pictureBox1.Image = Image.FromFile(f1);
                bf =(Bitmap) pictureBox1.Image;
                b = bf;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
}
        

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            enseignant en = new enseignant();
            en.cin = cin;
            en.mots_de_passe = pass;

            try
            {
                db = new loginteachDataContext();
                var query = from enseignant in db.enseignants
                            where enseignant.cin == en.cin
                            select enseignant;
                List<enseignant> listeEns = query.ToList<enseignant>();
                if (listeEns.Count == 0)
                {
                    MessageBox.Show("cin introuvable veuillez vérifier !");
                }
                else
                {
                    enseignant enss = listeEns[0];
                    if (enss.mots_de_passe != en.mots_de_passe)
                    {
                        MessageBox.Show("mot de passe incorrect");
                    }
                    else
                    {
                        login.ValidatedEns = new enseignant();
                        login.ValidatedEns.cin = enss.cin;
                        login.ValidatedEns.mots_de_passe = enss.mots_de_passe;
                        login.ValidatedEns.nom = enss.nom;
                        login.ValidatedEns.prenom = enss.prenom;
                        login.ValidatedEns.mail = enss.mail;
                        login.ValidatedEns.photo = enss.photo;
                        login.ValidatedEns.code_a_bar = enss.code_a_bar;
                        touch.Dispose();
                        Accueil_Enseignant ac = new Accueil_Enseignant();
                        ac.Show();
                       
                        this.Hide();
                        
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur de connection BD " + ex.Message);
            }
        }

        private void QrScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
           
             touch.Dispose();
        }
    }
    }

