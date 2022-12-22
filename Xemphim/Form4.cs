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
    public partial class Form4 : Form
    {
        string x = "";
        bool fl = true;
        public Form4(string xx)
        { 
            x = xx;
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog()
            {
                Filter = "PNG file (*.png)|*.png",
                Title = "Open picture"
            };
            label1.Text = x;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            try
            {
                load_text();
            }
            catch
            {

            }
        }
        public static Image CreateNonIndexedImage(string path)
        {
            using (var sourceImage = Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  PixelFormat.Format32bppArgb);
                using (var canvas = Graphics.FromImage(targetImage))
                {
                    canvas.DrawImageUnscaled(sourceImage, 0, 0);
                }
                return targetImage;
            }
        }

        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory")]
        private extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);

        public static Image CreateIndexedImage(string path)
        {
            using (var sourceImage = (Bitmap)Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  sourceImage.PixelFormat);
                var sourceData = sourceImage.LockBits(
                  new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                  ImageLockMode.ReadOnly, sourceImage.PixelFormat);
                var targetData = targetImage.LockBits(
                  new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                  ImageLockMode.WriteOnly, targetImage.PixelFormat);
                CopyMemory(targetData.Scan0, sourceData.Scan0,
                  (uint)sourceData.Stride * (uint)sourceData.Height);
                sourceImage.UnlockBits(sourceData);
                targetImage.UnlockBits(targetData);
                targetImage.Palette = sourceImage.Palette;
                return targetImage;
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        void load_text()
        {
            string a = System.IO.Directory.GetCurrentDirectory();
            a = a + "\\Account" + "\\" + x;
            string st;
            st = a + "\\Info\\name.txt";
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                textBox1.Text = streamReader.ReadLine();
            }
            st = a + "\\Info\\phonenum.txt";
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                textBox2.Text = streamReader.ReadLine();
            }
            st = a + "\\Info\\email.txt";
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                textBox3.Text = streamReader.ReadLine();
            }
            st = a + "\\Info\\address.txt";
            using (var fileStream = File.OpenRead(st))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                textBox4.Text = streamReader.ReadLine();
            }
            a = System.IO.Directory.GetCurrentDirectory();
            a = a + "\\Account" + "\\" + x + "\\Info\\avt.png";
            if (File.Exists(a))
            {
                
                pictureBox1.Image = resizeImage(CreateNonIndexedImage(a), new Size(231, 345));
        
            }
            else
            {
                a = System.IO.Directory.GetCurrentDirectory();
                pictureBox1.Image = Image.FromFile(a + "\\Account\\avt.jpg");
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            if (fl == true)
            {
                button1.Text = "Lưu";
                fl = false;
                load_text();
            }
            else
            {
                
                button1.Text = "Chỉnh sửa";
                fl = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                string a = System.IO.Directory.GetCurrentDirectory();
                a = a + "\\Account" + "\\" + x;
                string st;
                st = a + "\\Info\\name.txt";
                File.WriteAllText(st, textBox1.Text);
                st = a + "\\Info\\phonenum.txt";
                File.WriteAllText(st, textBox2.Text);
                st = a + "\\Info\\email.txt";
                File.WriteAllText(st, textBox3.Text);
                st = a + "\\Info\\address.txt";
                File.WriteAllText(st, textBox4.Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (fl==false)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        string a = System.IO.Directory.GetCurrentDirectory();
                        pictureBox1.Image = Image.FromFile(a+ "\\Account\\avt.jpg");
                        a = a + "\\Account" + "\\" + x + "\\Info\\avt.png";
                        textBox1.Text = a;
                        
                        if (File.Exists(a))
                        { 
                           File.Delete(a); 
                        }
                        string path = openFileDialog1.FileName;
                        File.Copy(path, a);
                        load_text();
                    }
                    catch {
                        
                    }
                }
            }
            else
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 f5 = new Form5(x);
            f5.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form6 f6 = new Form6(x);
            f6.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }
    }
}
       