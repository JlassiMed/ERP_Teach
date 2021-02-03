using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP_Teacher;
using MetroFramework.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

namespace ERP_Enseignant
{
    public partial class Emploi : MetroForm
    {
        SpeechRecognitionEngine sre;
        loginteachDataContext db;
        SpeechSynthesizer syn;
        PromptBuilder pb ;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        string[] allEns, allMod, allTasks;

        public Emploi()
        {
            InitializeComponent();
        }

        private void Emploi_Load(object sender, EventArgs e)
        {
            emploi_ens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            emploi_ens.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            db = new loginteachDataContext();

            emploi_ens.DataSource = db.emploi_enseignants;

            var query = from module in db.modules

                        select module;
            foreach (module m in query)
            {
                module.Items.Add(m.id_module);


            }
            var query1 = from classe in db.classes

                         select classe;
            foreach (classe c in query1)
            {
                groupe.Items.Add(c.id_classe);


            }
            var query2 = from enseignant in db.enseignants

                         select enseignant;
            foreach (enseignant en in query2)
            {
                cin.Items.Add(en.cin);


            }

            var query4 = from enseignant in db.enseignants
                         select enseignant.cin;
            allEns = query4.ToArray();
            var query5 = from module in db.modules
                         select module.id_module;
            allMod = query5.ToArray();
            var query6 = from emploi_enseignant in db.emploi_enseignants
                         select emploi_enseignant.id_tache.ToString();
            allTasks = query6.ToArray();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                db = new loginteachDataContext();
                int val;
                int index = emploi_ens.CurrentCell.RowIndex;
                val = (int)emploi_ens[0, index].Value;
                emploi_enseignant t1 = new emploi_enseignant();

                t1.id_tache = (int)emploi_ens[0, index].Value;
                t1.type = (string)emploi_ens[1, index].Value;
                t1.date = (DateTime)emploi_ens[2, index].Value;
                t1.heure_deb = (string)emploi_ens[3, index].Value;
                t1.heure_fin = (string)emploi_ens[4, index].Value;
                t1.salle = (string)emploi_ens[5, index].Value;
                t1.id_ens = (string)emploi_ens[6, index].Value;

                db.emploi_enseignants.InsertOnSubmit(t1);

                // ajouter une notification après chaque insertion d'une nouvelle tache 
                Notification n = new Notification();
                n.description = (string)emploi_ens[1, index].Value + " ( Nouvelle !!!) ";
                n.date = (DateTime)emploi_ens[2, index].Value;
                n.id_ens = (string)emploi_ens[6, index].Value;
                db.Notifications.InsertOnSubmit(n);

                db.SubmitChanges();
                MessageBox.Show("Tache et notification ajoutées");
                emploi_ens.DataSource = null;
                emploi_ens.DataSource = db.emploi_enseignants;


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void modifier_Click(object sender, EventArgs e)
        {
            try
            {
                int val;
                int index = emploi_ens.CurrentCell.RowIndex;
                val = (int)emploi_ens[0, index].Value;
                emploi_enseignant t1 = db.emploi_enseignants.Single(x => x.id_tache == val);
                t1.id_tache = (int)emploi_ens[0, index].Value;

                var query = from emploi_enseignant in db.emploi_enseignants
                            where emploi_enseignant.id_tache == t1.id_tache
                            select emploi_enseignant;
                foreach (emploi_enseignant emp in query)
                {
                    emp.type = (string)emploi_ens[1, index].Value;
                    emp.date = (DateTime)emploi_ens[2, index].Value;
                    emp.heure_deb = (string)emploi_ens[3, index].Value;
                    emp.heure_fin = (string)emploi_ens[4, index].Value;
                    emp.salle = (string)emploi_ens[5, index].Value;
                    emp.id_ens = (string)emploi_ens[6, index].Value;
                }

                // modifier une notification après chaque modification d'une  tache existante
                Notification n = new Notification();

                var query2 = from Notification in db.Notifications
                             select Notification;


                foreach (Notification not in query2)
                {
                    not.description = (string)emploi_ens[1, index].Value + " (a été modifiée !!)";
                    not.date = (DateTime)emploi_ens[2, index].Value;
                }


                db.SubmitChanges();


                MessageBox.Show("Tache et notification Modifiées !");
                emploi_ens.DataSource = null;
                emploi_ens.DataSource = db.emploi_enseignants;
            }

            catch (SqlException ex)
            {
                MessageBox.Show("ID enseignant est  non compatible ");
            }
        }

        private void supprimer_Click(object sender, EventArgs e)
        {

            try
            {
                int val;
                int index = emploi_ens.CurrentCell.RowIndex;
                val = (int)emploi_ens[0, index].Value;
                emploi_enseignant t1 = db.emploi_enseignants.Single(x => x.id_tache == val);
                db.emploi_enseignants.DeleteOnSubmit(t1);
                db.SubmitChanges();


                MessageBox.Show("Tache Supprimée !");
                emploi_ens.DataSource = null;
                db = new loginteachDataContext();
                emploi_ens.DataSource = db.emploi_enseignants;
            }
            // catch (System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException ex) { MessageBox.Show("Veuillez entrer un id d'un enseignant existant ! "); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Refraichir_Click(object sender, EventArgs e)
        {
            emploi_ens.DataSource = db.emploi_enseignants;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (cin.SelectedIndex != -1 && module.SelectedIndex != -1 && groupe.SelectedIndex != -1)
            {
                var query =
                            from enseigner in db.enseigners
                            from emploi_enseignant in db.emploi_enseignants

                            where emploi_enseignant.id_ens == enseigner.cin_enseignant


                            && ((emploi_enseignant.id_ens == cin.SelectedText)
                            || (enseigner.id_classe == Int32.Parse(groupe.SelectedItem.ToString()))
                            || (enseigner.id_module == module.SelectedText))
                            select emploi_enseignant;


                emploi_ens.DataSource = query.ToList();
            }
            else if (cin.SelectedIndex != -1 && module.SelectedIndex == -1 && groupe.SelectedIndex == -1)
            {
                var query =
                          from enseigner in db.enseigners
                          from emploi_enseignant in db.emploi_enseignants

                          where emploi_enseignant.id_ens == enseigner.cin_enseignant


                          && (emploi_enseignant.id_ens == cin.SelectedItem as string)

                          select emploi_enseignant;


                emploi_ens.DataSource = query.ToList();
            }
            else if (cin.SelectedIndex == -1 && module.SelectedIndex != -1 && groupe.SelectedIndex == -1)
            {
                var query =
                          from enseigner in db.enseigners
                          from emploi_enseignant in db.emploi_enseignants

                          where emploi_enseignant.id_ens == enseigner.cin_enseignant


                          && (enseigner.id_module == module.SelectedText)

                          select emploi_enseignant;


                emploi_ens.DataSource = query.ToList();

            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dt = monthCalendar1.SelectionRange.Start;
            try
            {
                var query =

                         from emploi_enseignant in db.emploi_enseignants
                         where dt.CompareTo(emploi_enseignant.date) == 0
                         select emploi_enseignant;
                emploi_ens.DataSource = query.ToList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }

        private void cin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cin.SelectedIndex != -1)
            {
                groupe.Items.Clear();
                module.Items.Clear();
                var query1 =
                from enseigner in db.enseigners
                from enseignant in db.enseignants

                where
                enseignant.cin == enseigner.cin_enseignant
                && cin.SelectedText == enseigner.cin_enseignant
                select enseigner;

                MessageBox.Show("L'enseignant  '" + cin.SelectedItem.ToString() + "'");


                foreach (enseigner emp in query1)
                {

                    groupe.Items.Add(emp.id_classe);
                    module.Items.Add(emp.id_module);
                }
            }
        }
      
        int i = 0;
        string[] volh = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        string[] TypeEnst = new string[] { "TD", "TP", "Course" };
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sre = new SpeechRecognitionEngine(/*new System.Globalization.CultureInfo("en-US")*/);
            syn = new SpeechSynthesizer();
            pb = new PromptBuilder();
            pb.ClearContent();
            pb.AppendText("Hello you want to add a module or task ? u can say m for module and t for task");
            syn.Speak(pb);
            pictureBox1.Visible = false;
            pb.ClearContent();
            //_completed = new ManualResetEvent(false);
            Choices choix = new Choices();
            choix.Add(new string[] { "module", "task", "exit","m","t" });
            choix.Add(allEns);
            choix.Add(allMod);
            choix.Add(allTasks);
            choix.Add(volh);
            choix.Add(TypeEnst);

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choix);
            try
            {
                Grammar g = new Grammar(gb);

                sre.LoadGrammar(g);

                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                sre.SetInputToDefaultAudioDevice(); // set the input of the speech recognizer to the default audio device
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            { return; }
        }
        string moduleChoisis, idteachChoisis, idtaskchoisis, nbhchoisis, typeenschoisis;

        private void Emploi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sre!=null)
            sre.Dispose();
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // MessageBox.Show("speech recognized =" +e.Result.Text.ToString());
            
            if (i == -1)
                i++; 
            else
            if (e.Result.Text.ToString().Equals("exit"))
            {
                
                pb.ClearContent();
                pb.AppendText("See you again !");
                syn.Speak(pb);
                pb.ClearContent();
                sre.UnloadAllGrammars();
                i = -1;
                sre.Dispose();
                pictureBox1.Visible = true;
            }
            else if (i == 0)
            {
                if (!e.Result.Text.ToString().Equals("task") && !e.Result.Text.ToString().Equals("t") && !e.Result.Text.ToString().Equals("module") && !e.Result.Text.ToString().Equals("m"))
                {
                    pb.ClearContent();
                    pb.AppendText("Wrong answer !");
                    syn.Speak(pb);
                }
                else if (e.Result.Text.Equals("module")|| e.Result.Text.ToString().Equals("m"))
                {
                    i++;
                }
                else { i += 2; }
            }
            else if (i == 1)
            {

                pb.ClearContent();
                pb.AppendText("give me the name of the module");
                syn.Speak(pb);
                pb.ClearContent();
                i += 2;
            }
            else if (i == 2)
            {
                pb.ClearContent();
                pb.AppendText("give me the id of the task");
                syn.Speak(pb);
                pb.ClearContent();
                i += 2;
            }
            else if (i == 4)
            {
                if (!allTasks.Contains(e.Result.Text) && e.Result.Text.ToString() != "")
                {
                    pb.ClearContent();
                    pb.AppendText("the id of the task is invalid retry !");
                    syn.Speak(pb);
                    pb.ClearContent();
                }
                else
                {
                    idtaskchoisis = e.Result.Text.ToString();
                    MessageBox.Show(idtaskchoisis);
                    pb.ClearContent();
                    pb.AppendText("give me the id of the teacher");
                    syn.Speak(pb);
                    i += 2;
                }
            }
            else if (i == 3)
            {
                if (!allMod.Contains(e.Result.Text) && e.Result.Text!="")
                {
                    pb.ClearContent();
                    pb.AppendText("the name of the module is invalid retry !");
                    syn.Speak(pb);
                    pb.ClearContent();
                }
                else
                {
                    moduleChoisis = e.Result.Text.ToString();
                    MessageBox.Show(moduleChoisis);
                    pb.ClearContent();
                    pb.AppendText("give me the id of the teacher");
                    syn.Speak(pb);
                    i += 2;
                }
            }
            else if (i == 6)
            {
                if (!allEns.Contains(e.Result.Text) && e.Result.Text != "")
                {
                    pb.ClearContent();
                    pb.AppendText("the id of the teacher is invalid retry !");
                    syn.Speak(pb);
                }
                else
                {

                    idteachChoisis = e.Result.Text.ToString();
                    MessageBox.Show(idteachChoisis);

                    try
                    {
                        emploi_enseignant emp = db.emploi_enseignants.Single(x => x.id_tache.ToString().Equals(idtaskchoisis));
                        emp.enseignant = db.enseignants.Single(ens=> ens.cin==idteachChoisis);
                        db.SubmitChanges();
                        pb.ClearContent();
                        pb.AppendText("it's done thank you for your patience, you can add a task or module by clicking on the microphone again.");
                        syn.Speak(pb);
                        pb.ClearContent();

                        sre.Dispose();
                        pictureBox1.Visible = true;

                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("probleme d'insertion de task " + exx.Message);
                        sre.Dispose();
                        pictureBox1.Visible = true;

                    }

                    i = -1;
                }
            }
            else if (i == 5)
            {
                if (!allEns.Contains(e.Result.Text) && e.Result.Text != "")
                {
                    pb.ClearContent();
                    pb.AppendText("the id of the teacher is invalid retry !");
                    syn.Speak(pb);
                }
                else
                {

                    idteachChoisis = e.Result.Text.ToString();

                    MessageBox.Show(idteachChoisis);
                    pb.ClearContent();
                    pb.AppendText("give me the number of hours !");
                    syn.Speak(pb);
                    i += 2;


                }

            }
            else if (i == 7)
            {

                if (!volh.Contains(e.Result.Text.ToString()) && e.Result.Text != "")
                {
                    pb.ClearContent();
                    pb.AppendText("wrong number of hours try again !");
                    syn.Speak(pb);

                }
                else
                {
                    nbhchoisis = e.Result.Text.ToString();

                    MessageBox.Show(nbhchoisis);
                    pb.ClearContent();
                    pb.AppendText("give me the type of the teaching !");
                    syn.Speak(pb);
                    i += 2;
                }
            }
            else if (i == 9)
            {

                if (!TypeEnst.Contains(e.Result.Text.ToString()) && e.Result.Text != "")
                {
                    pb.ClearContent();
                    pb.AppendText("wrong type of teaching !");
                    syn.Speak(pb);
                }
                else
                {
                    typeenschoisis = e.Result.Text.ToString();
                    MessageBox.Show(typeenschoisis);
                    enseignant_mod md = new enseignant_mod();
                    md.id_module = moduleChoisis;
                    md.cin_enseignant = idteachChoisis;
                    md.volume_h = nbhchoisis;
                    md.type_ens = typeenschoisis;
                    try
                    {
                        db.enseignant_mods.InsertOnSubmit(md);
                        db.SubmitChanges();
                        pb.ClearContent();
                        pb.AppendText("it's done thank you for your patience, you can add a task or module by clicking on the microphone again.");
                        syn.Speak(pb);
                        pb.ClearContent();
                        sre.Dispose();
                        pictureBox1.Visible = true;
                        i = -1;
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("probleme d'insertion de module " + exx.Message);

                    }


                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
