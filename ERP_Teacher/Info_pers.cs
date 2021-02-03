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
using ERP_Teacher;
using MetroFramework.Forms;
using ZXing;
using ZXing.QrCode;

namespace ERP_Enseignant
{
    public partial class info_perso : MetroFramework.Forms.MetroForm 
    {
        bool qrgenerated =false;
        bool allgood;
        loginteachDataContext db;
        public info_perso()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = login.ValidatedEns.cin;
            textBox1.Enabled = false;
            textBox2.Text = login.ValidatedEns.nom;
            textBox3.Text = login.ValidatedEns.prenom;
            textBox4.Text = login.ValidatedEns.mots_de_passe;
            textBox5.Text = login.ValidatedEns.mail;
            bunifuImageButton1.Image = byteArrayToImage(login.ValidatedEns.photo.ToArray());
            pictureBox1.Image = byteArrayToImage(login.ValidatedEns.code_a_bar.ToArray());
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
        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

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
                    
                     if ( login.ValidatedEns.mots_de_passe!= textBox4.Text && qrgenerated ==false)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;

            }
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox1.Text.Length == 0)
            {
                textBox1.SelectionLength = 0;
                bt_qrcode.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^A-Z,a-z]"))
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.Text.Length;

            }
            if (textBox2.Text.Length == 0)
                textBox2.SelectionStart = 0;

            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox2.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^A-Z,a-z]"))
            {
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                textBox3.SelectionStart = textBox3.Text.Length;

            }
            if (textBox3.Text.Length == 0)
                textBox3.SelectionStart = 0;

            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox3.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox5.Text.Length == 0)
            { bt_qrcode.Enabled = false; }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            if (Checkallgood())
            {
                bt_qrcode.Enabled = true;
            }
            if (textBox4.Text.Length == 0)
            { bt_qrcode.Enabled = false; }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = @"c:\";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Title = "Selectionner une photo";
            ofd.Filter = "Tous les types d'images|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String f1 = ofd.FileName.ToString();
                bunifuImageButton1.ImageLocation = f1;
                bunifuImageButton1.Image = Image.FromFile(f1);
               
            }

        }

        private void bt_qrcode_Click(object sender, EventArgs e)
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
