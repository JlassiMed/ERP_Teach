using ERP_Enseignant;
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
    public partial class Emploi_ens : MetroFramework.Forms.MetroForm
    {
        loginteachDataContext db;
        String VE = login.ValidatedEns.cin;
        
        public Emploi_ens()
        {
            InitializeComponent();
            
        }

        private void Emploi_ens_Load(object sender, EventArgs e)
        {
            db = new loginteachDataContext();
            CIN.Text = VE;
            CIN.Enabled = false;

            var query = from enseigner in db.enseigners
                        where enseigner.cin_enseignant == VE
                        select enseigner;
            foreach (enseigner en in query)
            {
                module.Items.Add(en.id_module);


            }
            var query1 = from enseigner in db.enseigners
                        where enseigner.cin_enseignant == VE
                        select enseigner;
            foreach (enseigner en in query)
            {
                groupe.Items.Add(en.id_classe);


            }

           


        }

            private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if ( module.SelectedIndex != -1 && groupe.SelectedIndex != -1)
            {
                var query =
                            from enseigner in db.enseigners
                            from emploi_enseignant in db.emploi_enseignants

                            where emploi_enseignant.id_ens == enseigner.cin_enseignant


                            && ((emploi_enseignant.id_ens == VE)
                            && (enseigner.id_classe ==Int32.Parse( groupe.SelectedText))
                            && (enseigner.id_module == module.SelectedText))
                            select emploi_enseignant;


                emploi_ense.DataSource = query.ToList();
            }
            else if ( module.SelectedIndex == -1 && groupe.SelectedIndex == -1)
            {
                var query =
                          from enseigner in db.enseigners
                          from emploi_enseignant in db.emploi_enseignants

                          where emploi_enseignant.id_ens == enseigner.cin_enseignant


                          && (emploi_enseignant.id_ens == VE)

                          select emploi_enseignant;


                emploi_ense.DataSource = query.ToList();
            }
            else if (module.SelectedIndex == -1 && groupe.SelectedIndex != -1)
            {
                var query =
                          from enseigner in db.enseigners
                          from emploi_enseignant in db.emploi_enseignants

                          where emploi_enseignant.id_ens == enseigner.cin_enseignant


                          && (emploi_enseignant.id_ens == VE)
                           && (Int32.Parse( groupe.SelectedText)== enseigner.id_classe)

                          select emploi_enseignant;


                emploi_ense.DataSource = query.ToList();
            }
            else if (module.SelectedIndex != -1 && groupe.SelectedIndex == -1)
            {
                var query =
                          from enseigner in db.enseigners
                          from emploi_enseignant in db.emploi_enseignants

                          where emploi_enseignant.id_ens == enseigner.cin_enseignant

                          && (module.SelectedText == enseigner.id_module)
                          && (emploi_enseignant.id_ens == VE)

                          select emploi_enseignant;


                emploi_ense.DataSource = query.ToList();
            }
        }

        private void Refraichir_Click(object sender, EventArgs e)
        {
            var query =

                          from emploi_enseignant in db.emploi_enseignants
                          where 
                           emploi_enseignant.id_ens == VE
                          select emploi_enseignant;
            emploi_ense.DataSource = query.ToList();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dt = monthCalendar1.SelectionRange.Start;
            try
            {
                var query =

                         from emploi_enseignant in db.emploi_enseignants
                         where dt.CompareTo(emploi_enseignant.date) == 0
                         && emploi_enseignant.id_ens==VE 
                         select emploi_enseignant;
                emploi_ense.DataSource = query.ToList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
    }
}
