using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Text;
using System.Timers;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection.Emit;

namespace thread4IG
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label[] LblTempo;
        private int cont = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblTempo= new System.Windows.Forms.Label[100];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LblTempo[cont] = new System.Windows.Forms.Label();
            LblTempo[cont].Location = new Point((cont%10)*100,cont/10*100);
            LblTempo[cont].Font = new Font(FontFamily.Families[0], 36);
            this.Controls.Add(LblTempo[cont]);
            LblTempo[cont].Size = new Size(100, 100); 
            LblTempo[cont].Text = numericUpDown1.Value.ToString();
            
            int i = cont;
            cont++;

            Thread threadTimer = new Thread(() =>
            {
                int rimasto = Convert.ToInt16(LblTempo[i].Text);

                while (rimasto > 0)
                {
                    Thread.Sleep(1000);
                    rimasto--;

                    this.Invoke(() => { LblTempo[i].Text = rimasto.ToString(); });
                }
                
                this.Invoke(() => { MessageBox.Show("BOOM"); });

            });
            threadTimer.Start();
        }
    }
}
