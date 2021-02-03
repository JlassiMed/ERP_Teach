using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.Face;
using System.IO;
using System.Data.Linq;
using Emgu.CV.CvEnum;
using ERP_Enseignant;

namespace ERP_Teacher
{

    public partial class FacialRecog : MetroForm
    {
        VideoCapture capture;
        CascadeClassifier cascadeClassifier = new CascadeClassifier("C:\\Users\\Mohamed\\Desktop\\7ama\\9raya\\C# finale\\projet c#\\ERP_Teacher\\ERP_Teacher\\haarcascade_frontalface_alt2.xml");
        loginteachDataContext db;
        List<enseignant> faces;

        public FacialRecog()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;

        }
        private void FacialRecog_Load(object sender, EventArgs e)
        {

            db = new loginteachDataContext();
            faces = new List<enseignant>();
            var query = from enseignant in db.enseignants
                        where enseignant.photo!=null
                        select enseignant;
            faces = query.ToList();
            
        }

        FaceRecognizer recognizer = new EigenFaceRecognizer(0,32000);

        public bool learn()
        {
            //List<Faces> allFaces = recognizer.Predict();
            if (faces.Count > 0)
            {
                var faceImages = new Image<Gray, byte>[faces.Count];
                var faceLabels = new int[faces.Count];
                for (int i = 0; i < faces.Count; i++)
                {
                    Stream stream = new MemoryStream();

                    stream.Write(faces[i].photo.ToArray(), 0, faces[i].photo.Length);

                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));

                    faceImages[i] = faceImage.Resize(400,400, interpolationType: Inter.Cubic);
                    faceLabels[i] = Int32.Parse(faces[i].cin);
                }

                recognizer.Train(faceImages, faceLabels);
            }
            return true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture();
            }
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            imageBox1.Image = capture.QueryFrame();
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            learn();
            string name;
            int resultat=0; 
            using (var imageFrame = capture.QuerySmallFrame().ToImage<Bgr, Byte>())
            {

                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    var Faces = cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                    var grayframe2 = grayframe.Resize(400, 400, interpolationType: Inter.Cubic);
                    bool found = false;
                    foreach (var face in Faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                        FaceRecognizer.PredictionResult pre = recognizer.Predict(grayframe2);
                        
                        
                            
                            if(pre.Label!=-1)
                            for (int j = 0; j < faces.Count; j++ )
                            {
                                
                                if (Int32.Parse(faces[j].cin) == pre.Label)
                                {   
                                    login.ValidatedEns.cin = faces[j].cin;
                                    login.ValidatedEns.mots_de_passe = faces[j].mots_de_passe;
                                    login.ValidatedEns.nom = faces[j].nom;
                                    login.ValidatedEns.prenom = faces[j].prenom;
                                    login.ValidatedEns.mail = faces[j].mail;
                                    login.ValidatedEns.photo = faces[j].photo;
                                    login.ValidatedEns.code_a_bar = faces[j].code_a_bar;
                                    found = true;
                                break;
                                }
                            }
                            else
                            {
                            MessageBox.Show("aucun similaire dans la base !");
                            break;
                            }
                        if (found)
                        {
                            Accueil_Enseignant ac = new Accueil_Enseignant();
                            ac.Show();
                            Close();
                            break;
                        }
                    }

                    pictureBox2.Image = imageFrame.ToBitmap();
                }
            }


        }

        private void FacialRecog_FormClosing(object sender, FormClosingEventArgs e)
        {

            capture.Dispose();
        }
    }
}
