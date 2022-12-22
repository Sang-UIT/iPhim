using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xemphim
{
    public partial class Form5 : Form
    {
        string x = "";
        bool fl = true;
        public Form5(string xx)
        {
            x = xx;
            InitializeComponent();
            label1.Text = x;
            flowLayoutPanel1.AutoScroll = true;
            for (int a = 1; a <= 7; a++)
                for (int i = 1; i <= 6; i++)
                {
                    if(check_hb(a,i))
                        flowLayoutPanel1.Controls.Add(add_hb(a, i));
                }
        }
        bool check_hb(int a, int i)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            aa = aa + "\\Account" + "\\" + x + "\\Hobby\\";
            aa = aa + a + "\\" + i + ".hb";
            if (File.Exists(aa))
                return true;
            return false;
        }
        Panel add_hb(int a, int i)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Size = new System.Drawing.Size(200, 290);
            dynamicPanel.TabIndex = 0;
            TextBox name = new TextBox();
            name.Text = get_name(a,i);
            name.Location = new Point(9, 262);
            name.Size = new Size(180, 30);
            name.Enabled = false;
            PictureBox pic = new PictureBox();
            pic.Image = get_pic(a, i);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Size = new System.Drawing.Size(174, 232);
            pic.Location = new Point(12, 17);
            Label g_ai = new Label();
            g_ai.Visible = false;
            g_ai.Text = a + "," + i;
            pic.Controls.Add(g_ai);
            dynamicPanel.Controls.Add(name);
            dynamicPanel.Controls.Add(pic);
            pic.Click += new EventHandler(panel_click);
            dynamicPanel.BorderStyle = BorderStyle.FixedSingle;
            return dynamicPanel;
        }
        void load_f7(int a, int i)
        {
            Form7 f7 = new Form7(x, a, i);
            f7.ShowDialog();
        }
        void panel_click(object sender, EventArgs e)
        {
            string s = "";
            PictureBox item = (PictureBox)sender;
            foreach (Control c in item.Controls)
                if (c is Label)
                    s = c.Text;
            int a = s[0]-48;
            int i = s[2]-48;
            this.Close();
            load_f7(a, i);
        }
        string get_name(int a, int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\phim.txt";
            const Int32 BufferSize = 128;
            string line;
            using (var fileStream = File.OpenRead(xx))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                line = streamReader.ReadLine();
            }
            return line;
        }
        Image get_pic(int a, int i)
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
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 f4 = new Form4(x);
            f4.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 f6 = new Form6(x);
            f6.ShowDialog();
        }
    }
}
       