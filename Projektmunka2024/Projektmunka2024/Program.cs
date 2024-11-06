using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektmunka2024
{
    public partial class MainForm : Form
    {
        static Random R = new Random();

        //fejben 21
        Label KezdoFelirat, HolTartunk;
        NumericUpDown MaxSzam, JatekosLepese;
        Button InditoGomb, MehetGomb, VisszaGomb;
        TrackBar FolyamatJelzo;
        int Osszeg = 0;
        List<int> Hatarok = new List<int>();

        //Nim jatek


        public MainForm()
        {
            InitializeTabs();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        private void InitializeTabs()
        {
            // Set form properties
            ClientSize = new Size(500, 300);
            Text = "Projekt Játékok";
            BackColor = Color.FromArgb(167, 148, 125);
            


            // Create TabControl and tabs
            TabControl tabControl = new TabControl { Dock = DockStyle.Fill };
            TabPage game1Tab = new TabPage("Fejben 21");
            TabPage game2Tab = new TabPage("TicTacToe");
            TabPage game3Tab = new TabPage("Nim játék");

            // Add TabControl to form
            Controls.Add(tabControl);

            // Add tabs to TabControl
            tabControl.TabPages.Add(game1Tab);
            tabControl.TabPages.Add(game2Tab);
            tabControl.TabPages.Add(game3Tab);

            //initialize game windows
            InitialilzeFejben21(game1Tab);
            //InitializeTicTac(game2Tab);
            InitializeNimJatek(game3Tab);
            
        }
        private void InitializeNimJatek(TabPage game3Tab)
        {
            game3Tab.BackColor = Color.FromArgb(128, 220, 204, 182);
            game3Tab.ForeColor = Color.Black;
        }
        private void InitialilzeFejben21(TabPage game1Tab)
        {
            game1Tab.BackColor = Color.FromArgb(128, 220, 204, 182);
            game1Tab.ForeColor = Color.Black;
            

            // Setup initial label and input controls
            KezdoFelirat = new Label
            {
                Location = new Point(20, 20),
                Text = "Állítsd be a max lépésmaximumot!",
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(300, 25),
                Parent = game1Tab,
                BackColor = Color.Transparent
            };

            MaxSzam = new NumericUpDown()
            {
                Location = new Point(320, 20),
                Size = new Size(40, 25),
                Minimum = 2,
                Maximum = 7,
                Parent = game1Tab
            };

            InditoGomb = new Button()
            {
                Location = new Point(380, 20),
                Size = new Size(75, 25),
                Text = "Indítás",
                BackColor = Color.FromArgb(167, 148, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Parent = game1Tab,
            };

            InditoGomb.FlatAppearance.BorderSize = 0;
            InditoGomb.Click += InditoGomb_Click;

            // Setup game controls
            FolyamatJelzo = new TrackBar()
            {
                Location = new Point(20, 95),
                Size = new Size(300, 25),
                Minimum = 0,
                Maximum = 21,
                Visible = false,
                Enabled = false,
                Parent = game1Tab
            };

            JatekosLepese = new NumericUpDown()
            {
                Location = new Point(330, 95),
                Size = new Size(40, 25),
                Minimum = 1,
                Visible = false,
                Parent = game1Tab
            };

            MehetGomb = new Button()
            {
                Location = new Point(400, 95),
                Size = new Size(75, 25),
                Text = "Mehet!",
                BackColor = Color.FromArgb(167, 148, 125),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Visible = false,
                Parent = game1Tab
            };

            MehetGomb.FlatAppearance.BorderSize = 0;
            MehetGomb.Click += MehetGomb_Click;

            VisszaGomb = new Button()
            {
                Location = new Point(400, 20),
                Size = new Size(75, 25),
                Text = "Menü",
                BackColor = Color.FromArgb(167, 148, 125),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Visible = false,
                Parent = game1Tab
            };

            VisszaGomb.FlatAppearance.BorderSize = 0;
            VisszaGomb.Click += VisszaGomb_Click;

            HolTartunk = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(560, 75),
                Text = "A játék állása:\n",
                Parent = game1Tab,
                BackColor = Color.Transparent
            };
        }

        private void InditoGomb_Click(object sender, EventArgs e)
        {
            KezdoFelirat.Visible = false;
            MaxSzam.Visible = false;
            InditoGomb.Visible = false;

            JatekosLepese.Maximum = (int)MaxSzam.Value;

            HolTartunk.Visible = true;

            JatekosLepese.Visible = true;
            FolyamatJelzo.Visible = true;
            MehetGomb.Visible = true;
            VisszaGomb.Visible = true;

            int NagyLepes = (int)MaxSzam.Value > 7 ? 7 : (int)MaxSzam.Value < 2 ? 2 : (int)MaxSzam.Value;
            for (int i = 21 % (++NagyLepes); i <= 21; i += NagyLepes)
            {
                Hatarok.Add(i);
            }
        }

        private void MehetGomb_Click(object sender, EventArgs e)
        {
            JatekosKovetkezik();
            GepKovetkezik();
        }

        private void VisszaGomb_Click(object sender, EventArgs e)
        {
            ResetFejben21();
        }

        private void ResetFejben21()
        {
            Osszeg = 0;
            Hatarok.Clear();

            FolyamatJelzo.Value = 0;
            HolTartunk.Text = "A játék állása:\n";

            MaxSzam.Value = 2;
            JatekosLepese.Value = 1;

            KezdoFelirat.Visible = true;
            MaxSzam.Visible = true;
            InditoGomb.Visible = true;

            FolyamatJelzo.Visible = false;
            JatekosLepese.Visible = false;
            MehetGomb.Visible = false;
            VisszaGomb.Visible = false;
        } 

        void JatekosKovetkezik()
        {
            if (!Kiertekeles())
            {
                int AktualisLepes = (int)JatekosLepese.Value < 1 ? 1 : (int)JatekosLepese.Value > (int)JatekosLepese.Maximum ? (int)JatekosLepese.Maximum : (int)JatekosLepese.Value;
                if (AktualisLepes + Osszeg > 21)
                {
                    MessageBox.Show("Besokalltál! Túllépted a 21-et! (" + (AktualisLepes + Osszeg) + ")");
                    ResetFejben21();
                }
                else
                {
                    Osszeg += AktualisLepes;
                    HolTartunk.Text += " " + Osszeg;
                    HolTartunk.Refresh();
                    FolyamatJelzo.Value = Osszeg;
                }
            }
        }

        void GepKovetkezik()
        {
            if (!Kiertekeles())
            {
                int i = Hatarok.FindIndex(h => Osszeg < h);
                Osszeg = i >= 0 && Hatarok[i] - Osszeg <= (int)MaxSzam.Value ? Hatarok[i] : Osszeg + R.Next(1, (int)MaxSzam.Value + 1);

                HolTartunk.Text += " " + Osszeg;
                HolTartunk.Refresh();
                FolyamatJelzo.Value = Osszeg;

                if (Kiertekeles())
                {
                    MessageBox.Show("Megvertelek!");
                    ResetFejben21();
                }
            }
            else
            {
                MessageBox.Show("Nyertél, gratulálok!");
                ResetFejben21();
            }
        }

        bool Kiertekeles()
        {
            return Osszeg >= 21;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}