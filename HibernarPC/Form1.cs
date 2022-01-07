using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace HibernarPC
{
    public partial class Form1 : Form
    {
        int i = 0;
        bool condition = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (condition)
            {
                timer1.Enabled = false;
                button1.Text = "Aceptar";
                numericUpDown1.Enabled = true;
                rdb_hibernar.Enabled = true;
                rdb_reiniciar.Enabled = true;
            }
            else 
            {
                timer1.Enabled = true;
                i = 0;
                timer1.Start();
                button1.Text = "Cancelar";
                numericUpDown1.Enabled = false;
                rdb_hibernar.Enabled = false;
                rdb_reiniciar.Enabled = false;
                this.WindowState = FormWindowState.Minimized;
            }
            condition = !condition;

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(i==numericUpDown1.Value*60)
            {
                if (rdb_hibernar.Checked == true)
                {
                    Process.Start("shutdown", "/h");
                    this.Close();
                }
                else
                {
                    Process.Start("shutdown", "/r");
                    this.Close();
                }
            }
            TimeSpan sec = TimeSpan.FromSeconds((double)numericUpDown1.Value*60-i);
            string str = sec.ToString(@"hh\:mm\:ss");
            Text = str;
            i++;

        }

        private void rdb_hibernar_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Hibernar en: ";
        }

        private void rdb_reiniciar_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Reiniciar en: ";
        }
    }
}
