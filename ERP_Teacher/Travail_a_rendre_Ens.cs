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
    public partial class TAR : MetroForm
    {
        public TAR()
        {
            InitializeComponent();
        }

        private void TAR_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            TAR_val val = new TAR_val();
            val.Show();
        }
    }
}
