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
namespace ERP_Enseignant
{
    public partial class GestModule : MetroForm
    {
        public GestModule()
        {
            InitializeComponent();
        }

        private void GestModule_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TAR t = new TAR();
            t.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ass a = new ass();
            a.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Telechargement t = new Telechargement();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TAR tar = new TAR();
            tar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* ass as= new ass();
            as.Show();*/ 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Telechargement t = new Telechargement();
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ERP_Teacher.Stats s = new ERP_Teacher.Stats();
            s.Show();
        }
    }
}
