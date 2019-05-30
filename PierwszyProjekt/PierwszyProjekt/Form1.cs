using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PierwszyProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = uint.MaxValue;
            numericUpDown1.Increment = uint.MaxValue / 100;
        }

        private void button2_ClickAsync(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Algorytm.ObliczAsync((uint)numericUpDown1.Value);
            Algorytm.Wynik += Algorytm_Wynik;            

            button2.Enabled = true;
        }

        private void Algorytm_Wynik(double obj)
        {
            Invoke(new Action(() => label1.Text = "" + obj));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
             new Algorytm().ObliczAsyncMultiTask((uint)numericUpDown1.Value, 10);
            Algorytm.Wynik += Algorytm_Wynik;

            button1.Enabled = true;
        }

        private double F(object o)
        {
            var  res = 0UL;
            for (int i = 0; i < uint.MaxValue/10; i++) res = res + 1; 
            return res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var algorytm = new Algorytm1(10, new Func<object, double>(F), 1);
            label1.Text=""+algorytm.StartComputation();
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            var task = (NowaLKlasa.Licz());
            task.Start();
            double res = await task;
            label1.Text = ""+res;
        }

      

    }
}
