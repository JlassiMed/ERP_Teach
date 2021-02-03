using Emgu.CV;
using Emgu.CV.Structure;
using ERP_Enseignant;
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
    public partial class CaptrePhoto : MetroForm
    {
        VideoCapture capture;
        public CaptrePhoto()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void CaptrePhoto_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture();
            
            Application.Idle += ProcessFrame;
        }
        private void ProcessFrame(object sender, EventArgs e)
        {

            imageBox1.Image = capture.QueryFrame();


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var img = capture.QueryFrame();
            capture.Stop(); 
            Application.Idle -= ProcessFrame;
            imageBox1.Image = img;
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

            capture.Start();
            Application.Idle += ProcessFrame;
        }
        Bitmap bit = null;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bit = imageBox1.Image.Bitmap;
            this.Close();

        }
        private void CaptrePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Inscription_Enseignant.picturecapture =bit ;
            capture.Dispose();
            
        }
    }
}
