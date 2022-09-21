using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Media;

namespace WindowsFormsApp1_Topolja
{
    public class MinuVorm:Form
    {
        RadioButton rnupp1, rnupp2, rnupp3;
        string Fail;
        string musicList = new[] { @"..\..\m1.wav", @"..\..\m2.wav", @"..\..\m3.wav" };
        Random r = new Random();
        string music1 = musicList[Random.Next(musicList.Length)];
        public MinuVorm() { }
        public MinuVorm(string Pealkiri, string Nupp)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;

            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50,50),
                Size= new System.Drawing.Size(100,100),
                BackColor = System.Drawing.Color.RosyBrown
            };

            nupp.Click += Nupp_Click;
            Label failinimi = new Label
            {

                Text = Fail,
                Location = new System.Drawing.Point(100, 50),
                Size = new System.Drawing.Size(100, 100),
                BackColor = System.Drawing.Color.RosyBrown
            };

            this.Controls.Add(nupp);
            //this.Controls.Add(failinimi);
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender=(Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsimus", MessageBoxButtons.YesNo);
            if (vastus==DialogResult.Yes)
            {
                using (var muusika=new SoundPlayer(Fail))
                {
                    rnupp1 = new RadioButton
                    {
                        Text = "1",
                        ForeColor = Color.Black,
                        Width = 80,
                        Location = new Point()
                    };
                    rnupp2 = new RadioButton
                    {
                        Text = "2",
                        ForeColor = Color.Black,
                        Width = 80,
                        Location = new Point(rnupp1.Width)
                    };
                    rnupp3 = new RadioButton
                    {
                        Text = "3",
                        ForeColor = Color.Black,
                        Width = 80,
                        Location = new Point(rnupp1.Width + rnupp2.Width)
                    };
                    this.Controls.Add(rnupp1);
                    this.Controls.Add(rnupp2);
                    this.Controls.Add(rnupp3);

                    rnupp1.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp2.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp3.CheckedChanged += new EventHandler(rnupp_changed);
                    //MessageBox.Show("Music!");
                    //muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void rnupp_changed(object sender, EventArgs e)
        {
            var muusika1 = new SoundPlayer(music1);
            var muusika2 = new SoundPlayer(music2);
            var muusika3 = new SoundPlayer(music3);

            if (rnupp1.Checked)
            {
                muusika1.Play();
                MessageBox.Show("Music1!");
            }
            else if (rnupp2.Checked)
            {
                muusika2.Play();
                MessageBox.Show("Music2!");
            }
            else if (rnupp3.Checked)
            {
                muusika3.Play();
                MessageBox.Show("Music3!");
            }
        }
    }
}
