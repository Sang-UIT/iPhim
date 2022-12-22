using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xemphim
{
    public partial class Form3 : Form
    {
        string x = "";
        int button = 1;
        public Form3(string xx)
        {
            x = xx;
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            label1.Text = x;
            // disable horizontal scrollbar
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            load_phim(1);
            flowLayoutPanel2.Visible = false;

        }
        Image check_hb(int a, int i)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2= aa;
            
            z1 = z1 + "\\Icon\\Love.png";
            z2 = z2 + "\\Icon\\Nonlove.png";
            aa = aa + "\\Account" + "\\" + x + "\\Hobby\\";
            aa = aa+a+"\\"+i+".hb";
            if (File.Exists(aa))
                return Image.FromFile(z1);
            return Image.FromFile(z2);
        }
        void load_hb(int a)
        {
            pictureBox10.Image = check_hb(a, 1);
            pictureBox11.Image = check_hb(a, 2);
            pictureBox12.Image = check_hb(a, 3);
            pictureBox13.Image = check_hb(a, 4);
            pictureBox14.Image = check_hb(a, 5);
            pictureBox15.Image = check_hb(a, 6);
        }
        string load_text(int a, int i)
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
        Image load_img(int a,int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\"+i+"\\";
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
        void load_phim(int a)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\1\\";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            
            {
                pictureBox4.Image = load_img(a, 1);
                pictureBox5.Image = load_img(a, 2);
                pictureBox6.Image = load_img(a, 3);
                pictureBox7.Image = load_img(a, 4);
                pictureBox8.Image = load_img(a, 5);
                pictureBox9.Image = load_img(a, 6);

                label2.Text = load_text(a, 1);
                label3.Text = load_text(a, 2);
                label4.Text = load_text(a, 3);
                label5.Text = load_text(a, 4);
                label6.Text = load_text(a, 5);
                label7.Text = load_text(a, 6);
            }
            load_hb(a);
        }
        public int scrollValue = 0;
        public int ScrollValue
        {
            get
            {


                return scrollValue;
            }
            set
            {
                scrollValue = value;

                if (scrollValue < flowLayoutPanel1.HorizontalScroll.Minimum)
                {
                    scrollValue = flowLayoutPanel1.HorizontalScroll.Minimum;
                }
                if (scrollValue > flowLayoutPanel1.HorizontalScroll.Maximum)
                {
                    scrollValue = flowLayoutPanel1.HorizontalScroll.Maximum;
                }

                flowLayoutPanel1.HorizontalScroll.Value = scrollValue;
                flowLayoutPanel1.PerformLayout();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 60; i++)
            {
                ScrollValue -= flowLayoutPanel1.HorizontalScroll.SmallChange;
                System.Threading.Thread.Sleep(20);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 60; i++)
            {
                ScrollValue += flowLayoutPanel1.HorizontalScroll.SmallChange;
                System.Threading.Thread.Sleep(20);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(x);
            f4.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_phim(1);
            button = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load_phim(2);
            button = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            load_phim(3);
            button = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load_phim(4);
            button = 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            load_phim(5);
            button = 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load_phim(6);
            button = 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            load_phim(7);
            button = 7;
        }
        void change_hb(int a, int i)
        {
            string aa = System.IO.Directory.GetCurrentDirectory();
            string z1 = aa;
            string z2 = aa;

            z1 = z1 + "\\Icon\\Love.png";
            z2 = z2 + "\\Icon\\Nonlove.png";
            
            aa = aa + "\\Account" + "\\" + x + "\\Hobby\\"+a;
            if (Directory.Exists(aa))
            {
                aa = aa + "\\" + i + ".hb";
                if (File.Exists(aa))
                {
                    File.Delete(aa);
                }
                else
                {
                    File.AppendAllText(aa, "");
                }
                
            }
            else
            {
                Directory.CreateDirectory(aa);
                aa = aa + "\\" + i + ".hb";
                File.AppendAllText(aa, "");
                
            }
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            change_hb(button, 1);
            load_hb(button);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            change_hb(button, 2);
            load_hb(button);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            change_hb(button, 3);
            load_hb(button);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            change_hb(button, 4);
            load_hb(button);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            change_hb(button, 5);
            load_hb(button);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            change_hb(button, 6);
            load_hb(button);
        }
        void load_f7(int a)
        {
            Form7 f7 = new Form7(x, button, a);
            f7.ShowDialog();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            load_f7(1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            load_f7(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            load_f7(3);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            load_f7(4);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            load_f7(5);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            load_f7(6);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if(flowLayoutPanel2.Visible)
            {
                flowLayoutPanel2.Visible = false;
            }
            else
                Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (textBox1.TextLength > 0)
            {
                panel18.Visible = true;
            }
            else
                panel18.Visible = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel18.Visible = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel18_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            panel18.Visible = false;
            flowLayoutPanel2.Visible = false;
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void panel19_Click(object sender, EventArgs e)
        {
            //tim ten
            if (textBox1.TextLength > 0)
            {
                clear_flpn();
                for(int i=1;i<=7;i++)
                {
                    for(int j=1;j<=6;j++)
                    try
                    {
                            if (findaccuracy(textBox1.Text, get_name(i, j)))
                                flowLayoutPanel2.Controls.Add(add_sc(i, j));
                    }
                    catch
                    {

                    }
                }
                flowLayoutPanel2.Visible = true;
                panel18.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = false;
                panel18.Visible = false;
            }
        }
        private void panel20_Click(object sender, EventArgs e)
        {
            //tim dao dien
            if (textBox1.TextLength > 0)
            {
                clear_flpn();
                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 6; j++)
                        try
                        {
                            if (findaccuracy(textBox1.Text, get_tacgia(i, j)))
                                flowLayoutPanel2.Controls.Add(add_sc(i, j));
                        }
                        catch
                        {

                        }
                }
                flowLayoutPanel2.Visible = true;
                panel18.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = false;
                panel18.Visible = false;
            }
        }
        private static readonly string[] VietNamChar = new string[]
    {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
    };
        public static string LocDau(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        private void panel21_Click(object sender, EventArgs e)
        {
            //tim dien vien
            if (textBox1.TextLength > 0)
            {
                clear_flpn();
                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 6; j++)
                        try
                        {
                            if (findaccuracy(textBox1.Text, get_dienvien(i, j)))
                                flowLayoutPanel2.Controls.Add(add_sc(i, j));
                        }
                        catch
                        {

                        }
                }
                flowLayoutPanel2.Visible = true;
                panel18.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = false;
                panel18.Visible = false;
            }
        }
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
        bool findaccuracy(string a, string b)//tim phan tram dung cua hai chuoi
        {
            a = a.ToUpper();
            b = b.ToUpper();
            a = LocDau(a);
            b = LocDau(b);
            a=ReplaceWhitespace(a, "");
            b=ReplaceWhitespace(b, "");
            a=String.Join(" ", a.ToList());
            b=String.Join(" ", b.ToList());
            
            double thien_vi;
            if (a.Length<=b.Length)
            { 
                thien_vi = (double) a.Length / b.Length;
                int min = b.Length;
                int v=0;
                for (int i = 0; i <= b.Length-a.Length; i++)
                { 
                    string c = b.Substring(i, a.Length);
                    v = FindDiff(a, c).Length;
                    
                    if (v<min)
                        min = v;
                    }

                
                if ((double)min/a.Length*100<=80)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private string FindDiff(string s1, string s2)
        {
            string shorterOne;
            string longerOne;

            if (string.IsNullOrEmpty(s1))
                return s2;
            if (string.IsNullOrEmpty(s2))
                return s1;

            if (s1.Length > s2.Length)
            {
                shorterOne = s2;
                longerOne = s1;
            }
            else
            {
                shorterOne = s1;
                longerOne = s2;
            }


            string strDiff = string.Empty;

            string RegexString = "(" + shorterOne + ")";
            Regex regex = new Regex(RegexString, RegexOptions.IgnoreCase);
            string[] parts = regex.Split(longerOne);
            foreach (string part in parts)
            {
                if (part != shorterOne)
                {
                    strDiff += part;
                }
            }

            return strDiff;
        }
        private void panel22_Click(object sender, EventArgs e)
        {
            //tim nam

            if (textBox1.TextLength > 0)
            {
                clear_flpn();
                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 6; j++)
                        try
                        {
                            if (findaccuracy(textBox1.Text, get_nam(i, j)))
                                flowLayoutPanel2.Controls.Add(add_sc(i, j));
                        }
                        catch
                        {

                        }
                }
                flowLayoutPanel2.Visible = true;
                panel18.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = false;
                panel18.Visible = false;
            }
        }
        void clear_flpn()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel2.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayoutPanel2.Controls.Remove(control);
                control.Dispose();
            }
        }
        Panel add_sc(int a, int i)
        {
            Panel dynamicPanel = new Panel();
            dynamicPanel.Size = new System.Drawing.Size(200, 290);
            dynamicPanel.TabIndex = 0;
            TextBox name = new TextBox();
            name.Text = get_name(a, i);
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
            int a = s[0] - 48;
            int i = s[2] - 48;
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
        string get_tacgia(int a, int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\phim.txt";
            const Int32 BufferSize = 128;
            string line;
            using (var fileStream = File.OpenRead(xx))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
            }
            return line;
        }
        string get_dienvien(int a, int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\phim.txt";
            const Int32 BufferSize = 128;
            string line;
            using (var fileStream = File.OpenRead(xx))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
            }
            return line;
        }

        string get_nam(int a, int i)
        {
            string xx = System.IO.Directory.GetCurrentDirectory();
            xx = xx + "\\Film\\" + a + "\\" + i + "\\phim.txt";
            const Int32 BufferSize = 128;
            string line;
            using (var fileStream = File.OpenRead(xx))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
                line = streamReader.ReadLine();
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
        void visi_flow()
        {
            flowLayoutPanel2.Visible = true;
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        
    }
}
