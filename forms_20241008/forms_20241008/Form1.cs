using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forms_20241008
{
    public partial class Form1 : Form
    {

        ListBox alap, oszthatok;
        TextBox alsohatar, felsohatar, darab, oszto;
        Button kilep;
        static Random R = new Random();
        ToolTip TT = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            TT.AutoPopDelay = 5000; //meddig látható a tooltip
            TT.ReshowDelay = 500; //mennyi idő kell, hogy újra látszódjon a tooltip
            TT.InitialDelay = 500; //meddig várjon, amíg megmutatja a tooltip-et
            TT.SetToolTip(this, "Listákat manipuláló program");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region alap beállítások
            Font = new Font("Times", 14f);
            Location = new Point(100, 100);
            ClientSize = new Size(300, 500);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.BurlyWood;
            #endregion

            alsohatar = new TextBox()
            {
                Parent = this,
                Location = new Point(20, 70),
                Size = new Size(260, 30),
            };
            TT.SetToolTip(alsohatar, "Add meg a listába kerülő számok alsó határát");

            felsohatar = new TextBox()
            {
                Parent = this,
                Location = new Point(20, 120),
                Size = new Size(260, 30),
            };
            TT.SetToolTip(felsohatar, "Add meg a listába kerülő elemek felső határát");

            darab = new TextBox()
            {
                Parent = this,
                Location = new Point(20, 170),
                Size = new Size(260, 30),
            };
            TT.SetToolTip(darab, "Add meg hány elem kerüljön a listába");

            alsohatar.KeyDown += Textbox_KeyDown;
            felsohatar.KeyDown += Textbox_KeyDown;
            darab.KeyDown += Textbox_KeyDown;

            kilep = new Button()
            {
                Font = new Font("Arial", 5f, FontStyle.Bold),
                Parent = this,
                Size = new Size(15, 15),
                Text = "X",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Location = new Point(this.ClientSize.Width-19, 3),
            };
            kilep.Click += Kilep_Click;
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            var aktualis = sender as TextBox; //var aktualis = (TextBox)sender;
            if ( e.KeyCode == Keys.Enter )
            {
                int fh = 0, ah = 0, db = 0;
                // egész számokká konvertálás vizsgálat
                if (int.TryParse(felsohatar.Text, out fh) && int.TryParse(alsohatar.Text, out ah) && int.TryParse(darab.Text, out db) && db > 0)
                {
                    felsohatar.Visible = false;
                    alsohatar.Visible = false;
                    darab.Visible = false;

                    alap = new ListBox()
                    {
                        Parent = this,
                        Location = new Point(20, 20),
                        Size = new Size(120, 410),
                    };
                    TT.SetToolTip(alap, "Ebbe kerülnek a kisorsolt számok");

                    oszthatok = new ListBox()
                    {
                        Parent = this,
                        Location = new Point(160, 20),
                        Size = new Size(120, 410),
                    };
                    TT.SetToolTip(oszthatok, "Ide kerülnek az alább megadott számmal osztható számok");

                    oszto = new TextBox()
                    {
                        Parent = this,
                        Location = new Point(100, 440),
                        Size = new Size(100, 30),
                    };
                    oszto.KeyPress += Oszto_KeyPress;
                    oszto.KeyDown += Oszto_KeyDown;
                    TT.SetToolTip(oszto, "Add meg a vizsgálni kívánt osztót");

                    // minden esetben az alsóhatár legyen a kisebb szám
                    int csere = ah;
                    ah = ah > fh ? fh : ah;
                    fh = fh == ah ? csere : fh;

                    // lista feltöltpése random elemekkel a megadott intervallumon
                    List<int> list = new List<int>();
                    for (int i = 0; i < db; i++)
                    {
                        list.Add(R.Next(ah, fh+1));
                    }
                    list.Sort();
                    alap.DataSource = list;
                }
            }
        }

        private void Oszto_KeyDown(object sender, KeyEventArgs e)
        {
            int osztoszam = 0;
            if (e.KeyCode == Keys.Enter && int.TryParse(oszto.Text, out osztoszam) && osztoszam > 0)
            {
                oszthatok.Items.Clear();

                foreach (int szam in alap.Items)
                {
                    if (szam % osztoszam == 0)
                    {
                        oszthatok.Items.Add(szam);
                    }
                }
            }
        }

        private void Oszto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ha nem szám/backspace/enter a leütött billentyű, akkor ne is engedje, hogy beírjuk a textboxba
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
        private void Kilep_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
