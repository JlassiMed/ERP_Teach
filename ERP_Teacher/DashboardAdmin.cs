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
    public partial class DashboardAdmin : MetroForm
    {
        

        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            

        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            GestionClasses gs = new GestionClasses();
            gs.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            GestionClasses gs = new GestionClasses();
            gs.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            gerer_ens ge = new gerer_ens();
            ge.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Emploi ge = new Emploi();
            ge.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Emploi ge = new Emploi();
            ge.Show();
        }
    }
}
