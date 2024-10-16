namespace thread4IG
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer[] timer;
        private System.Windows.Forms.Label[] LblTempo;
        private int cont = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int n = Convert.ToInt16((sender as System.Windows.Forms.Timer).Tag);
            LblTempo[n].Text = (Convert.ToInt16(LblTempo[n].Text) - 1).ToString();
            if (LblTempo[n].Text == "0")
            {
                timer[n].Stop();
                MessageBox.Show("BOOM!");
                LblTempo[n].Text = numericUpDown1.Value.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer[100];
            LblTempo= new System.Windows.Forms.Label[100];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer[cont] = new System.Windows.Forms.Timer();
            timer[cont].Interval = 1000;
            timer[cont].Tick += timer1_Tick;
            timer[cont].Start();
            
            LblTempo[cont] = new System.Windows.Forms.Label();
            LblTempo[cont].Location = new Point((cont%10)*100,cont/10*100);
            LblTempo[cont].Font = new Font(FontFamily.Families[0], 36);
            this.Controls.Add(LblTempo[cont]);
            LblTempo[cont].Size = new Size(100, 100);
            
            LblTempo[cont].Text = numericUpDown1.Value.ToString();
            timer[cont].Tag = cont;
            timer[cont].Start();
            cont++;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if(timer1.Enabled == false) LblTempo.Text = numericUpDown1.Value.ToString();
        }
    }
}
