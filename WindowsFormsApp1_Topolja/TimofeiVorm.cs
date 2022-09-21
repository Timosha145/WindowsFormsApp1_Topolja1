using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace WindowsFormsApp1_Topolja
{
    public partial class TimofeiVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1,rnupp2,rnupp3,rnupp4;
        PictureBox pilt;
        ProgressBar eriba;
        Timer aeg;
        TextBox tekst;
        public TimofeiVorm()
        {
            Height = 600;
            Width = 1500;
            Text = "Minu oma vorm koos elementiga";
            puu = new TreeView();
            BackColor = Color.Blue;
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            puu.Width = 200;
            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("Dialog aken- MessageBox"));
            oksad.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            oksad.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            oksad.Nodes.Add(new TreeNode("Omavorm-Myform"));


            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
            //InitializeComponent();
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            silt = new Label 
            { 
                Text = "Minu esimine vorm", 
                Size = new Size(400, 250), 
                Location = new Point(200, 0) 
            };
                mruut1 = new CheckBox
                {
                    Checked = false,
                    Text = "üks",
                    Location=new Point(silt.Left+silt.Width, 0),
                    Width=100,
                    Height=25
                };
                mruut2 = new CheckBox
                {
                    Checked = false,
                    Text = "kaks",
                    Location = new Point(silt.Left + silt.Width, mruut1.Height),
                    Width = 100,
                    Height = 25
                };

            if (e.Node.Text == "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 60;
                nupp.Location = new Point(200, 200);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;

                this.Controls.Add(silt);
            }
            else if (e.Node.Text == "Dialog aken- MessageBox")
            {
                MessageBox.Show("Aken", "Kõike lihtsam aken");
                var vastus = MessageBox.Show("Kas paneme akek kinni?", "Valik", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (vastus==DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Loser!");
                    this.Close();
                }
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {

                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);

                mruut1.CheckedChanged += new EventHandler(mruut_1_2_Changed);
                mruut2.CheckedChanged += new EventHandler(mruut_1_2_Changed);

            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                rnupp1 = new RadioButton
                {
                    Text = "paremale",
                    ForeColor = Color.White,
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp2 = new RadioButton
                {
                    Text = "vasakule",
                    ForeColor = Color.White,
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width, mruut1.Height + mruut2.Height)
                };
                rnupp3 = new RadioButton
                {
                    Text = "ülesse",
                    ForeColor = Color.White,
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp4 = new RadioButton
                {
                    Text = "alla",
                    ForeColor = Color.White,
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width + rnupp3.Width, mruut1.Height + mruut2.Height)
                };

                pilt = new PictureBox
                {
                    Image=new Bitmap(@"kover.jpg"),
                    Location=new Point(300,450),
                    Size=new Size(100,100),
                    SizeMode=PictureBoxSizeMode.Zoom
                };

                this.Controls.Add(pilt);
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);

                rnupp1.CheckedChanged += new EventHandler(rnupp_changed);
                rnupp2.CheckedChanged += new EventHandler(rnupp_changed);
                rnupp3.CheckedChanged += new EventHandler(rnupp_changed);
                rnupp4.CheckedChanged += new EventHandler(rnupp_changed);

            }
            else if (e.Node.Text == "Edenemisriba-ProgressBar")
            {
                eriba = new ProgressBar
                {
                    Width = 400,
                    Height = 30,
                    Location = new Point(600, 500),
                    Value = 0,
                    Minimum = 0,
                    Step = 5,
                    Maximum = 100
                };
                aeg = new Timer();
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;

                this.Controls.Add(eriba);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                tekst = new TextBox
                {
                    Font = new Font("Segoe UI",25,FontStyle.Italic),
                    Location = new Point(350,400),
                    Enabled=false
                };
                MouseDoubleClick += Tekst_DoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "Omavorm-Myform")
            {
                MinuVorm oma = new MinuVorm("Muusika","Muusika?","");
                oma.ShowDialog();
            }
        }

        private void Tekst_DoubleClick(object sender, EventArgs e)
        {
            if (tekst.Enabled)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }

        int step;
        private void Aeg_Tick(object sender, EventArgs e)
        {
            step+=4;
            eriba.PerformStep();
            if (step>=100)
            {
                BackColor = Color.Red;
                MessageBox.Show("Aken", "TEIL ON VIIRUS!!!!!");
                var vastus = MessageBox.Show("Kustutame viirus?", "Valik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (vastus == DialogResult.OK)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        vastus = MessageBox.Show("Kustutame viirus?", "Valik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        int x = 300;
        int y = 450;
        private void rnupp_changed(object sender, EventArgs e)
        {
            if (rnupp1.Checked)
            {
                x += 10;
                //paremale
                pilt.Location = new Point(x, y);
                rnupp1.Checked = false;
            }
            else if (rnupp2.Checked)
            {
                x -= 10;
                //vasakule
                pilt.Location = new Point(x, y);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked)
            {
                y -= 10;
                //ülesse
                pilt.Location = new Point(x, y);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked)
            {
                y += 10;
                //alla
                pilt.Location = new Point(x-10, y);
                rnupp4.Checked = false;
            }
        }
        private void mruut_1_2_Changed(object sender, EventArgs e)
        {
            if (mruut1.Checked && !mruut2.Checked)
            {
                MessageBox.Show("1=True, 2=False", "Aken");
            }
            else if (!mruut1.Checked && mruut2.Checked)
            {
                MessageBox.Show("1=False, 2=True", "Aken");
            }
            else if (mruut1.Checked && mruut2.Checked)
            {
                MessageBox.Show("1, 2=True", "Aken");
            }
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.Black;
            silt.ForeColor = Color.Transparent;
        }

        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.BackColor = Color.White;
            silt.ForeColor=Color.Black;
        }

        int count;
        private void Nupp_Click(object sender, EventArgs e)
        {
            count++;
            if (count==1)
            {
                BackColor = Color.Red;

            }
            else if (count==2)
            {
                BackColor = Color.Yellow;
            }
            else if (count == 3)
            {
                BackColor = Color.Purple;
            }
            else if (count == 4)
            {
                BackColor = Color.Blue;
            }
            else if (count == 5)
            {
                BackColor = Color.Green;
                count = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
