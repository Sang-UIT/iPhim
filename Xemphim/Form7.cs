using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Xemphim
{
    public partial class Form7 : Form
    {
        bool flag = true;
        string x = "";
        string name = "";
        int a = 1;
        int i = 1;
        int star = 1;
        double star_tb = 0;
        int star_tbb = 0;
        public Form7(string xx, int aa, int ii)
        {
            x = xx;
            a = aa;
            i = ii;
            InitializeComponent();
            label1.Text = get_name(a, i,1);
            label8.Text= get_name(a, i, 2);
            label9.Text = get_name(a, i, 3);
            label10.Text = get_name(a, i, 4);
            label5.Text = x;
            axWindowsMediaPlayer1.uiMode = "none";
            try
            {
                string xxx = System.IO.Directory.GetCurrentDirectory();
                xxx = xxx + "\\Film\\" + a + "\\" + i + "\\phim.mp4";
                axWindowsMediaPlayer1.URL = xxx;
            }
            catch
            {
                string xxx = System.IO.Directory.GetCurrentDirectory();
                xxx = xxx + "\\Film\\" + a + "\\" + i + "\\phim.webm";
                axWindowsMediaPlayer1.URL = xxx;
            }
            axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
            add_history();
            info_load();
            load_cmt();
            
        }
        void load_cmt()
        {
            
            
            int j = 0;
            string ss = System.IO.Directory.GetCurrentDirectory();
            ss = ss + "\\Comment\\" + a + "\\" + i + "\\" + j + ".cmt";
            while (File.Exists(ss))
            {
                string line = "";
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(ss))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    
                    line = streamReader.ReadLine();
                    
                    
                    string name = line;
                    line = streamReader.ReadLine();
                    string starr = line;
                    int star_cmt = starr[0] - 48;
                    line = streamReader.ReadToEnd();
                    string aa = System.IO.Directory.GetCurrentDirectory();

                    aa = aa + "\\Account" + "\\" + name + "\\Info\\avt.png";
                    if (File.Exists(aa))
                    {

                        flowLayoutPanel1.Controls.Add(add_cmt(name_cmt(name), line, star_cmt, Image.FromFile(aa)));

                    }
                    else
                    {
                        aa = System.IO.Directory.GetCurrentDirectory();
                        flowLayoutPanel1.Controls.Add(add_cmt(name_cmt(name), line, star_cmt, Image.FromFile(aa + "\\Account\\avt.jpg")));
                    }
                    star_tb += star_cmt;
                }
                j++;
                ss = System.IO.Directory.GetCurrentDirectory();
                ss = ss + "\\Comment\\" + a + "\\" + i + "\\" + j + ".cmt";
            }
            star_tb = star_tb / j;
            star_tb = Math.Round(star_tb, 2);
            star_tbb = (int)star_tb;
            label7.Text = star_tb + "";
            load_startb(star_tbb);
            label6.Text = "(" + j + ")";
        }
        string name_cmt(string ss)
        {
            string s = System.IO.Directory.GetCurrentDirectory();
            s = s + "\\Account" + "\\" + ss;
            string st;
            st = s + "\\Info\\name.txt";
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
               return streamReader.ReadLine();
            }

        }
        void add_history()
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            aa = aa + "\\Account" + "\\" + x + "\\History\\" + a;
            if (Directory.Exists(aa))
            {
                aa = aa + "\\" + i + ".his";
                if (!File.Exists(aa))
                    File.AppendAllText(aa, "");
            }
            else
            {
                Directory.CreateDirectory(aa);
                aa = aa + "\\" + i + ".his";
                File.AppendAllText(aa, "");

            }
        }
        Panel add_cmt(string ten, string scmt, int star, Image avt)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Size = new System.Drawing.Size(426, 75);
            dynamicPanel.TabIndex = 0;

            RichTextBox cmt = new RichTextBox();
            cmt.Text = scmt;
            cmt.ReadOnly = true;
            cmt.Location = new Point(57, 38);
            cmt.Size = new Size(368, 34);
            
            PictureBox pic = new PictureBox();
            pic.Image = avt;
            pic.BackColor = Color.White;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Size = new System.Drawing.Size(48, 57);
            pic.Location = new Point(3, 15);
            TextBox name = new TextBox();
            name.Text = ten;
            name.ReadOnly = true;
            name.Location = new Point(57, 15);

            //add star
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2 = aa;
            //star1
            PictureBox star1 = new PictureBox();
            star1.Size = new Size(28, 27);
            star1.Location = new Point(261, 8);
            star1.SizeMode = PictureBoxSizeMode.StretchImage;
            //star2
            PictureBox star2 = new PictureBox();
            star2.Size = new Size(28, 27);
            star2.Location = new Point(295, 8);
            star2.SizeMode = PictureBoxSizeMode.StretchImage;
            //star3
            PictureBox star3 = new PictureBox();
            star3.Size = new Size(28, 27);
            star3.Location = new Point(329, 8);
            star3.SizeMode = PictureBoxSizeMode.StretchImage;
            //star4
            PictureBox star4 = new PictureBox();
            star4.Size = new Size(28, 27);
            star4.Location = new Point(363, 8);
            star4.SizeMode = PictureBoxSizeMode.StretchImage;
            //star4
            PictureBox star5 = new PictureBox();
            star5.Size = new Size(28, 27);
            star5.Location = new Point(397, 8);
            star5.SizeMode = PictureBoxSizeMode.StretchImage;
            z1 = z1 + "\\Icon\\Star.png";
            z2 = z2 + "\\Icon\\Nonstar.png";
            star1.Image = Image.FromFile(z1);
            if (star > 4)
                star5.Image = Image.FromFile(z1);
            else
                star5.Image = Image.FromFile(z2);
            if (star > 3)
                star4.Image = Image.FromFile(z1);
            else
                star4.Image = Image.FromFile(z2);
            if (star > 2)
                star3.Image = Image.FromFile(z1);
            else
                star3.Image = Image.FromFile(z2);
            if (star > 1)
                star2.Image = Image.FromFile(z1);
            else
                star2.Image = Image.FromFile(z2);

            dynamicPanel.Controls.Add(name);
            dynamicPanel.Controls.Add(pic);
            dynamicPanel.Controls.Add(cmt);
            dynamicPanel.Controls.Add(star1);
            dynamicPanel.Controls.Add(star2);
            dynamicPanel.Controls.Add(star3);
            dynamicPanel.Controls.Add(star4);
            dynamicPanel.Controls.Add(star5);
            dynamicPanel.BorderStyle = BorderStyle.FixedSingle;
            return dynamicPanel;
        }
        string get_name(int a, int i,int z)
        {
            int j = 0;
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\phim.txt";
            const Int32 BufferSize = 128;
            string line="";
            using (var fileStream = File.OpenRead(xx))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                while (j < z)
                {
                    line = streamReader.ReadLine();
                    j++;
                }

            }
            return line;
        }
        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2 = aa;

            z1 = z1 + "\\Icon\\play.png";
            z2 = z2 + "\\Icon\\stop.png";
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                button2.BackgroundImage = Image.FromFile(z2);
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                button2.BackgroundImage = Image.FromFile(z1);
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                axWindowsMediaPlayer1.fullScreen = true;
            

        }
    

        private void axWindowsMediaPlayer1_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {
            
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;
            

        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //media player control's playstate change event handler
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                trackBar1.Value = 0;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //timer 1 tick event handler
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                var timeSpan = TimeSpan.FromMinutes(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                int hh = timeSpan.Hours;
                int mm = timeSpan.Minutes;
                int ss = timeSpan.Seconds;
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                label11.Text = "" + hh+":"+mm+":"+ss;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                flag = false;
                trackBar2.Visible = true;
            }
            else
            {
                flag = true;
                trackBar2.Visible = false;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
        }
        void info_load()
        {
            string a = System.IO.Directory.GetCurrentDirectory();
            a = a + "\\Account" + "\\" + x;
            string st;
            st = a + "\\Info\\name.txt";
            const Int32 BufferSize = 128;
            
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                name = streamReader.ReadLine();
            }
            label5.Text = name;
            a = System.IO.Directory.GetCurrentDirectory();
            
            a = a + "\\Account" + "\\" + x + "\\Info\\avt.png";
            if (File.Exists(a))
            {

                pictureBox6.Image = Image.FromFile(a);

            }
            else
            {
                a = System.IO.Directory.GetCurrentDirectory();
                pictureBox6.Image = Image.FromFile(a + "\\Account\\avt.jpg");
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        void load_startb(int a)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2 = aa;

            z1 = z1 + "\\Icon\\Star.png";
            z2 = z2 + "\\Icon\\Nonstar.png";
            pictureBox1.Image = Image.FromFile(z1);
            if (a > 4)
                pictureBox5.Image = Image.FromFile(z1);
            else
                pictureBox5.Image = Image.FromFile(z2);
            if (a > 3)
                pictureBox3.Image = Image.FromFile(z1);
            else
                pictureBox3.Image = Image.FromFile(z2);
            if (a > 2)
                pictureBox4.Image = Image.FromFile(z1);
            else
                pictureBox4.Image = Image.FromFile(z2);
            if (a > 1)
                pictureBox2.Image = Image.FromFile(z1);
            else
                pictureBox2.Image = Image.FromFile(z2);
            star = a;
        }
        void load_star(int a)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2 = aa;

            z1 = z1 + "\\Icon\\Star.png";
            z2 = z2 + "\\Icon\\Nonstar.png";
            pictureBox11.Image = Image.FromFile(z1);
            if(a>4)
                pictureBox7.Image = Image.FromFile(z1);
            else
                pictureBox7.Image = Image.FromFile(z2);
            if (a >3)
                pictureBox8.Image = Image.FromFile(z1);
            else
                pictureBox8.Image = Image.FromFile(z2);
            if (a >2)
                pictureBox9.Image = Image.FromFile(z1);
            else
                pictureBox9.Image = Image.FromFile(z2);
            if (a >1)
                pictureBox10.Image = Image.FromFile(z1);
            else
                pictureBox10.Image = Image.FromFile(z2);
            star = a;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            load_star(4);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            load_star(1);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            load_star(5);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            load_star(3);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load_star(2);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void trackBar2_MouseLeave(object sender, EventArgs e)
        {
            flag = true;
            trackBar2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                int j = 0;
                string xxx = System.IO.Directory.GetCurrentDirectory();
                xxx = xxx + "\\Comment\\" + a + "\\" + i + "\\" + j + ".cmt";
                while (File.Exists(xxx))
                {
                    j++;
                    xxx = System.IO.Directory.GetCurrentDirectory();
                    xxx = xxx + "\\Comment\\" + a + "\\" + i + "\\" + j + ".cmt";
                }
                File.AppendAllText(xxx, x + "\n" + star + "\n");
                File.AppendAllText(xxx, richTextBox1.Text);
                string aa = System.IO.Directory.GetCurrentDirectory();
                aa = aa + "\\Account" + "\\" + x + "\\Info\\avt.png";
                if(File.Exists(aa))
                    flowLayoutPanel1.Controls.Add(add_cmt(name_cmt(x), richTextBox1.Text, star, Image.FromFile(aa)));
                else
                {
                    aa = System.IO.Directory.GetCurrentDirectory();
                    flowLayoutPanel1.Controls.Add(add_cmt(name_cmt(x), richTextBox1.Text, star, Image.FromFile(aa + "\\Account\\avt.jpg")));
                }
            }
            else
                MessageBox.Show("Please input comment!");
           
            
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string xxx = System.IO.Directory.GetCurrentDirectory();
            xxx = xxx + "\\Film\\" + a + "\\" + i + "\\phim.mp4";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Video|*.mp4";
            saveFileDialog1.Title = "Save an Video File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                File.Copy(xxx, saveFileDialog1.FileName);
            }
                saveFileDialog1.Dispose();
            saveFileDialog1 = null;
        }
        Image load_img(int a, int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\";
            try
            {
                return Image.FromFile(xx + "phim.jpg");
            }
            catch
            {
                try
                {
                    return Image.FromFile(xx + "phim.png");
                }
                catch
                {
                    try
                    {
                        return Image.FromFile(xx + "phim.jfif");
                    }
                    catch
                    {
                        return Image.FromFile(xx + "phim.jpeg");
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            Form8 f8 = new Xemphim.Form8(load_img(a, i));
            f8.ShowDialog();
        }
    }
}