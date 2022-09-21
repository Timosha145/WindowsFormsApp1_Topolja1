using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1_Topolja
{
    public class MinuVorm:Form
    {
        public MinuVorm() { }
        public MinuVorm(string Pealkiri, string Nupp, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50,50),
                Size= new System.Drawing.Size(100,200),
                BackColor = System.Drawing.Color.White,
            };

            nupp.Click += Nupp_Click;
            Label failinimi = new Label
            {

                Text = Fail,
                Location = new System.Drawing.Point(100, 50),
                Size = new System.Drawing.Size(100, 200),
                BackColor = System.Drawing.Color.White
            };

            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender=(Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsimus", MessageBoxButtons.YesNo);
            if (vastus==DialogResult.Yes)
            {
                using (var muusika=new SoundPlayer(@"..\..\a.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }
    }
}
