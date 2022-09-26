using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Collections;

namespace WindowsFormsApp1_Topolja
{
    public class MinuVorm:Form
    {
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        string Fail=" ";
        private string[] musicList = { @"..\..\m1.wav", @"..\..\m2.wav", @"..\..\m3.wav", @"..\..\m4.wav" };
        Random r = new Random();

        private string muusika1, muusika2, muusika3 = " ";
        private System.Media.SoundPlayer m1, m2, m3 = new SoundPlayer();

        public MinuVorm() 
        {

        }

        public MinuVorm(string Pealkiri, string Nupp)
        {

            this.ClientSize = new System.Drawing.Size(320, 200);
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
                    rnupp4 = new RadioButton
                    {
                        Text = "Uus laulud",
                        ForeColor = Color.White,
                        BackColor = Color.Tomato,
                        Width = 90,
                        Location = new Point(rnupp1.Width + rnupp2.Width +rnupp3.Width)
                    };
                    this.Controls.Add(rnupp1);
                    this.Controls.Add(rnupp2);
                    this.Controls.Add(rnupp3);
                    this.Controls.Add(rnupp4);

                    rnupp1.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp2.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp3.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp4.CheckedChanged += new EventHandler(rnupp_changed);
                //MessageBox.Show("Music!");
                //muusika.Play();

            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        void rnupp_changed(object sender, EventArgs e)
        {
            if (rnupp4.Checked)
            {
            while (true)
            {
                muusika1 = musicList[r.Next(musicList.Length)];
                muusika2 = musicList[r.Next(musicList.Length)];
                muusika3 = musicList[r.Next(musicList.Length)];
                if (muusika1 != muusika2 && muusika1 != muusika3 && muusika2 != muusika3)
                {
                    break;
                }
            }
            rnupp4.Checked = false;
            }
            m1 = new SoundPlayer(muusika1);
            m2 = new SoundPlayer(muusika2);
            m3 = new SoundPlayer(muusika3);
            rnupp1.Text = muusika1.Remove(0,6);
            rnupp2.Text = muusika2.Remove(0,6);
            rnupp3.Text = muusika3.Remove(0,6);

            if (rnupp1.Checked)
            {
                m1.Play();
                //MessageBox.Show(muusika1);
            }
            else if (rnupp2.Checked)
            {
                m2.Play();
                //MessageBox.Show(muusika2);
            }
            else if (rnupp3.Checked)
            {
                m3.Play();
                //MessageBox.Show(muusika3);
            }
        }
    }
}
