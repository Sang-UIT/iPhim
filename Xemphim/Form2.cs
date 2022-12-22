using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace Xemphim
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // Assign the asterisk to be the password character.
            textBox1.PasswordChar = '*';
            // Assign the asterisk to be the password character.
            textBox2.PasswordChar = '*';
            correct.Visible = false;
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
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(textBox2.Text))
                {
                    string x = System.IO.Directory.GetCurrentDirectory();
                    x = x + "\\Account" + "\\" + textBox3.Text;
                    if (!Directory.Exists(x))
                    {
                        Directory.CreateDirectory(x);
                        string s;
                        s = x + "\\Hobby";
                        Directory.CreateDirectory(s);
                        s = x + "\\History";
                        Directory.CreateDirectory(s);
                        s = x + "\\Info";
                        Directory.CreateDirectory(s);
                        string c;
                        c = s + "\\name.txt";
                        File.AppendAllText(c,"User Name");
                        c = s + "\\phonenum.txt";
                        File.AppendAllText(c, "0000000000");
                        c = s + "\\address.txt";
                        File.AppendAllText(c, "Input address");
                        c = s + "\\email.txt";
                        File.AppendAllText(c, "Input email");
                        x =x+ "\\Hash.txt";
                        File.AppendAllText(x, GetHashString(textBox2.Text));
                        correct.Text = "Create account success, please login";
                        correct.Visible = true;
                    }
                    else
                    {
                        correct.Text = "Already have an account, please try again";
                        correct.Visible = true;
                    }
                }
                else
                {
                    correct.Text = "Password confirm is not correct, please try again";
                    correct.Visible = true;
                }
                
            }
            catch
            {
                correct.Text = "Something went wrong, please try again";
                correct.Visible = true;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
