using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpingButton
{
    public partial class Form1 : Form
    {
        Button gomb;
        Random R = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region alap beállítások
            this.TopMost = true;
            Font = new Font("Times", 14f);
            Location = new Point(100, 100);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            WindowState = FormWindowState.Maximized;
            #endregion

            gomb = new Button()
            {
                Font = new Font("Arial", 7f, FontStyle.Bold),
                Parent = this,
                Size = new Size(40, 40),
                Text = "X",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Location = new Point(this.ClientSize.Width/2, this.ClientSize.Height/2),
            };
            gomb.Click += gombClick;
            gomb.MouseEnter += gombHover;
        }
        private void gombHover(object sender, EventArgs e)
        {
            //random méret
            int randW = R.Next(30, this.ClientSize.Width / 5);
            int randH = R.Next(30, this.ClientSize.Height / 5);
            gomb.Size = new Size(randW, randH);

            //random pozíció
            int randX = R.Next(20, this.ClientSize.Width-randW);
            int randY = R.Next(20, this.ClientSize.Height-randH);
            gomb.Location = new Point(randX, randY);
        }

        private void gombClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
