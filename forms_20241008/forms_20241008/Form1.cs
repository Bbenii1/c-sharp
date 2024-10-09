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
        public Form1()
        {
            InitializeComponent();
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

            felsohatar = new TextBox()
            {
                Parent = this,
                Location = new Point(20, 120),
                Size = new Size(260, 30),
            };

            darab = new TextBox()
            {
                Parent = this,
                Location = new Point(20, 170),
                Size = new Size(260, 30),
            };

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

                    oszthatok = new ListBox()
                    {
                        Parent = this,
                        Location = new Point(160, 20),
                        Size = new Size(120, 410),
                    };

                    oszto = new TextBox()
                    {
                        Parent = this,
                        Location = new Point(100, 440),
                        Size = new Size(100, 30),
                    };
                }
            }
        }

        private void Kilep_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
