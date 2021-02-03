using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace ERP_Teacher
{
    public partial class modif_ens : MetroForm
    {
        loginteachDataContext db;
        bool qrgenerated = false;
        bool allgood;
        public modif_ens()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }

        private void modif_ens_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();

            textBox1.Text = gerer_ens.s.cin;
            textBox2.Text = gerer_ens.s.nom;
            textBox4.Text = gerer_ens.s.mots_de_passe;
            textBox3.Text = gerer_ens.s.prenom;
            textBox5.Text = gerer_ens.s.mail;

            /* MemoryStream ms = new MemoryStream();
             bunifuImageButton1.Image.Save(ms, ImageFormat.Jpeg);
             byte[] pic_array = new byte[ms.Length];
             ms.Position = 0;
             ms.Read(pic_array, 0, pic_array.Length);
             bunifuImageButton1.Image = byteArrayToImage(gerer_ens.s.photo.ToArray());
             MemoryStream mss = new MemoryStream();
             pictureBox1.Image.Save(mss, ImageFormat.Bmp);
             byte[] qr_array = new byte[mss.Length];
             mss.Position = 0;
             mss.Read(qr_array, 0, qr_array.Length);
             pictureBox1.Image = byteArrayToImage(gerer_ens.s.code_a_bar.ToArray());*/
            bunifuImageButton1.Image = byteArrayToImage(gerer_ens.s.photo.ToArray());
            pictureBox1.Image = byteArrayToImage(gerer_ens.s.code_a_bar.ToArray());
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            allgood = true;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                    if (c.Text.Length == 0)
                    {
                        MessageBox.Show("veuillez remplir tout les champs !");
                        c.Focus();
                        allgood = false;
                        break;
                    }
                    else if (c == textBox1 && textBox1.Text.Length < 8)
                    {
                        MessageBox.Show("cin doit être composé de 8 chiffres !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allgood = false;
                    }
            }
            if (allgood)
            {
                bool emailverif = true;
                try
                {
                    var m = new System.Net.Mail.MailAddress(textBox5.Text);
                }
                catch (System.FormatException f)
                {
                    MessageBox.Show("email incorrect !");
                    emailverif = false;
                }
                if (emailverif)
                {

                    if (gerer_ens.s.mots_de_passe != textBox4.Text && qrgenerated == false)
                        MessageBox.Show("générer votre QR code svp !", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        try
                        {
                            db = new loginteachDataContext();
                            enseignant ens = new enseignant();
                            ens.cin = textBox1.Text;
                            var query = from enseignant in db.enseignants
                                        where enseignant.cin == ens.cin
                                        select enseignant;
                            List<enseignant> listeEns = query.ToList<enseignant>();



                            foreach (enseignant ex in query)
                            {
                                ex.nom = textBox2.Text;
                                ex.prenom = textBox3.Text;
                                ex.mots_de_passe = textBox4.Text;
                                ex.mail = textBox5.Text;
                                MemoryStream ms = new MemoryStream();
                                bunifuImageButton1.Image.Save(ms, ImageFormat.Jpeg);
                                byte[] pic_array = new byte[ms.Length];
                                ms.Position = 0;
                                ms.Read(pic_array, 0, pic_array.Length);
                                ex.photo = pic_array;

                                MemoryStream mss = new MemoryStream();
                                pictureBox1.Image.Save(mss, ImageFormat.Bmp);
                                byte[] qr_array = new byte[mss.Length];
                                mss.Position = 0;
                                mss.Read(qr_array, 0, qr_array.Length);
                                ex.code_a_bar = qr_array;
                            }

                            db.SubmitChanges();
                            // len = ens.photo.ToString().Length;

                            MessageBox.Show("modification réussite !");

                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(text: "erreur d'insertion " + exx.Message, caption: "Erreur", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        }
                }
            }

        }
        public bool Checkallgood()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                    if (c.Text.Length == 0)
                    {
                        return false;
                    }

            }
            return true;
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            qrgenerated = true;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(textBox1.Text.Trim() + textBox4.Text.Trim()));
            pictureBox1.Image = result;
            bt_save.Enabled = true;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Selectionner un placement";
            dialog.RestoreDirectory = true;
            dialog.Filter = "Tous les types d'images|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png|" + "Bitmap (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image.Save(dialog.FileName, ImageFormat.Bmp);
            }
        }
    }
    }

