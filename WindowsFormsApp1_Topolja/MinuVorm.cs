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
        private string[] musicList = { @"..\..\My Girlfriend's Birthday Is Today.wav", @"..\..\Narcos.wav", @"..\..\Stereo Madness.wav", @"..\..\Which Autumn In Camps.wav" };
        private string[] imageList = { @"..\..\My Girlfriend's Birthday Is Today.jpg", @"..\..\Narcos.jpg", @"..\..\Stereo Madness.jpg", @"..\..\Which Autumn In Camps.jpg" };

        Random r = new Random();
        PictureBox pilt;


        private string muusika1, muusika2, muusika3 = " ";
        private System.Media.SoundPlayer m1, m2, m3 = new SoundPlayer();

        public MinuVorm() 
        {

        }

        public MinuVorm(string Pealkiri, string Nupp)
        {

            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Text = Pealkiri;

            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(35,35),
                Size= new System.Drawing.Size(50,30),
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
                        Width = 170,
                        Location = new Point()
                    };
                    rnupp2 = new RadioButton
                    {
                        Text = "2",
                        ForeColor = Color.Black,
                        Width = 170,
                        Location = new Point(0, rnupp1.Height)
                    };
                    rnupp3 = new RadioButton
                    {
                        Text = "3",
                        ForeColor = Color.Black,
                        Width = 170,
                        Location = new Point(0, rnupp1.Height+rnupp2.Height)
                    };
                    rnupp4 = new RadioButton
                    {
                        Text = "Uus laulud",
                        ForeColor = Color.White,
                        BackColor = Color.Tomato,
                        Width = 90,
                        Location = new Point(0, rnupp1.Height + rnupp2.Height + rnupp3.Height)
                    };
                    pilt = new PictureBox
                    {
                        Image = new Bitmap(@"..\..\a.jpg"),
                        Location = new Point(170),
                        Size = new Size(100, 100),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    this.Controls.Add(rnupp1);
                    this.Controls.Add(rnupp2);
                    this.Controls.Add(rnupp3);
                    this.Controls.Add(rnupp4);
                    this.Controls.Add(pilt);

                    rnupp1.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp2.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp3.CheckedChanged += new EventHandler(rnupp_changed);
                    rnupp4.CheckedChanged += new EventHandler(rnupp_changed);
                //MessageBox.Show("Music!");
                //muusika.Play();
                nupp_sender.Hide();
                pilt.Hide();
                this.ClientSize = new System.Drawing.Size(300, 100);

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
            if (muusika1 != " " && muusika2 != " " && muusika3 != " ")
            {
                m1 = new SoundPlayer(muusika1);
                m2 = new SoundPlayer(muusika2);
                m3 = new SoundPlayer(muusika3);

                string a1 = muusika1.Remove(0,6);
                string a2 = muusika2.Remove(0,6);
                string a3 = muusika3.Remove(0,6);

                rnupp1.Text = a1.Remove(a1.Length - 4);
                rnupp2.Text = a2.Remove(a2.Length - 4);
                rnupp3.Text = a3.Remove(a3.Length - 4);

                if (rnupp1.Checked)
                {
                    pilt.Show();
                    pilt.Image = new Bitmap(imageList[Array.IndexOf(musicList, muusika1)]);
                    m1.Play();
                    //MessageBox.Show(muusika1);
                }
                else if (rnupp2.Checked)
                {
                    pilt.Show();
                    pilt.Image = new Bitmap(imageList[Array.IndexOf(musicList, muusika2)]);
                    m2.Play();
                    //MessageBox.Show(muusika2);
                }
                else if (rnupp3.Checked)
                {
                    pilt.Show();
                    pilt.Image = new Bitmap(imageList[Array.IndexOf(musicList, muusika3)]);
                    m3.Play();
                    //MessageBox.Show(muusika3);
                }
            }
            else
            {
                MessageBox.Show("Laulud ei ole veel uuendatud");
            }

        }
    }
}
