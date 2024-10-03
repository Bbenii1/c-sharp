using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_betoltes; //load eseménykezelő (Load += TAB TAB)
        }

        private void Form1_betoltes(object sender, EventArgs e)
        {
            Location = new Point(100, 100);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(180, 32, 65);
            button1.Enabled = true;
            button1.Click += button1_click;
        }
        private void button1_click(object sender, EventArgs e)
        {
            button1.Text = "Éljen 2024-25-ös 11IP!";
            button1.Font = new Font("Fira Code", 10f); //float-ként kell megadni a betűméretet xdd
        }

    }
}
