using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fejben_Huszonegy
{
    public partial class Form1 : Form
    {
        Label KezdoFelirat, HolTartunk; //HolTartunk - a játék aktuális állása
        NumericUpDown MaxSzam, JatekosLepese;
        Button InditoGomb, MehetGomb, VisszaGomb; //MehetGomb lépett a játékos
        TrackBar FolyamatJelzo;
        int Osszeg = 0; //ennyinél tartunk
        static Random R = new Random();
        bool JatekosLep = true; //ki következik
        List<int> Hatarok = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        //ablak megnyílásakor lefutó eseménykezelő
        private void Form1_Load(object sender, EventArgs e)
        {
            #region alap beállítások
            ClientSize = new Size(380, 100); //ablak mérete
            Location = new Point(590, 290);//(2000, 100) bal felső sarok helye
            Font = new Font("Fira Code", 10f); //betűtípus és méret
            Text = "Fejben 21"; //ablak fejléc
            BackColor = Color.FromArgb(83, 83, 83);
            ForeColor = Color.White;
            #endregion

            //Példányosítom a Kezdofelirat Label változót
            KezdoFelirat = new Label();
            KezdoFelirat.Location = new Point(20, 20);
            KezdoFelirat.Text = "Állítsd be a max lépésmaximumot!";
            KezdoFelirat.TextAlign = ContentAlignment.MiddleCenter;
            KezdoFelirat.Size = new Size(300, 25);
            this.Controls.Add(KezdoFelirat); //hozzáadom a form-hoz a labelt

            MaxSzam = new NumericUpDown()
            {
                //vessző használható, mert csak paraméterek
                Parent = this,
                Location = new Point(320, 20),
                Size = new Size(40, 25),
                Minimum = 2,
                Maximum = 7,
               
            }; //ez is olyan, mint a Controls.Add(MaxSzam);

            InditoGomb = new Button()
            {
                Parent = this,
                Location = new Point(380, 20),
                Size = new Size(75, 25),
                Text = "Indítás",
                BackColor = Color.Maroon,
                FlatStyle = FlatStyle.Popup
            };
            InditoGomb.Click += InditoGomb_Click;

            FolyamatJelzo = new TrackBar()
            {
                Parent = this,
                Location = new Point(20, 95),
                Size = new Size(300, 25),
                Minimum = 0,
                Maximum = 21,
                Visible = false,
                Enabled = false,
            };

            JatekosLepese = new NumericUpDown()
            {
                Parent = this,
                Location = new Point(330, 95),
                Size = new Size(40, 25),
                Minimum = 1,
               
                Visible = false,
            };

            MehetGomb = new Button()
            {
                Parent = this,
                Location = new Point(400, 95),
                Size = new Size(75, 25),
                Text = "Mehet!",
                BackColor = Color.Maroon,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            MehetGomb.Click += MehetGomb_Click;

            VisszaGomb = new Button()
            {
                Parent = this,
                Location = new Point(400, 20),
                Size = new Size(75, 25),
                Text = "Menü",
                BackColor = Color.Maroon,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            VisszaGomb.Click += VisszaGomb_Click;
        }
        private void InditoGomb_Click(object sender, EventArgs e)
        {
            KezdoFelirat.Visible = false;
            MaxSzam.Visible = false;
            InditoGomb.Visible = false;

            JatekosLepese.Maximum = (int)MaxSzam.Value < 2 ? 2 : (int)MaxSzam.Value > 7 ? 7 : (int)MaxSzam.Value;

            HolTartunk = new Label()
            {
                Parent = this,
                Location = new Point(20, 20),
                Size = new Size(560, 75),
                Text = "A játék állása:\n"
            };
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
            Application.Restart();

        }
        void JatekosKovetkezik()
        {
            if (!Kiertekeles())
            {
                int AktualisLepes = (int)JatekosLepese.Value < 1 ? 1 : (int)JatekosLepese.Value > (int)JatekosLepese.Maximum ? (int)JatekosLepese.Maximum : (int)JatekosLepese.Value;
                //besokallt-e?
                if (AktualisLepes + Osszeg > 21)
                {
                    MessageBox.Show("Besokalltál! Túllépted a 21-et! (" + (AktualisLepes + Osszeg) + ")");
                    Application.Restart();
                }
                else
                {
                    Osszeg += AktualisLepes;
                    HolTartunk.Text += " " + Osszeg;
                    FolyamatJelzo.Value = Osszeg;
                }
            }
            /*
            else
            {
                HolTartunk.Text += " " + Osszeg;
                MessageBox.Show("Vesztettél!");
            }*/
        }
        void GepKovetkezik()
        {
            if (!Kiertekeles())
            {
                int i = 0;
                for (i = 0; i < Hatarok.Count; i++)
                {
                    if (Osszeg < Hatarok[i]) break;
                }
                if (Hatarok[i] - Osszeg >= 1 && Hatarok[i] - Osszeg <= (int)MaxSzam.Value)
                    Osszeg = Hatarok[i];
                else Osszeg += R.Next(1, (int)MaxSzam.Value + 1);
                HolTartunk.Text += " " + Osszeg;
                FolyamatJelzo.Value = Osszeg;
                if (Kiertekeles())
                {
                    MessageBox.Show("Megvertelek!");
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Nyertél, gratulálok!");
                Application.Restart();
            }
        }
        bool Kiertekeles()
        {

            if (Osszeg < 21) return false;
            return true;
        }

    }
}