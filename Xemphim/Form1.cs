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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            correct.Visible = false;
            // Assign the asterisk to be the password character.
            textBox2.PasswordChar = '*';
        }
        

    public static byte[] GetHash(string inputString)
    {
        using (HashAlgorithm algorithm = SHA256.Create())
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string GetHashString(string inputString)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
    private void Login_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        

       
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string x = System.IO.Directory.GetCurrentDirectory();
                x = x + "\\Account" + "\\" + textBox1.Text+"\\Hash.txt";
                string pass = textBox2.Text;
                const Int32 BufferSize = 128;
                string line;
                using (var fileStream = File.OpenRead(x))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                   line= streamReader.ReadLine();
                }
                if (line.Equals(GetHashString(pass)))
                    {
                    Form3 f3 = new Form3(textBox1.Text);
                    f3.ShowDialog();
                }
                else
                {
                    correct.Text = "Password is not correct, please try again";
                    correct.Visible = true;
                }
                }
            catch
            {
                correct.Text = "Username is not correct, please try again";
                correct.Visible = true;
            }
        }

        private void correct_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
