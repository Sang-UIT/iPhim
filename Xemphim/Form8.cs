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
using System.Drawing.Imaging;

namespace Xemphim
{
    public partial class Form8 : Form
    {
        public Form8(Image a)
        {
            InitializeComponent();
            // Assign the asterisk to be the password character.
            pictureBox1.Image = a;
        }
       
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox16.Visible = false;
            using (Bitmap bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                bmp.Save("sharing.png", ImageFormat.Png); // make sure path exists!
                System.Diagnostics.Process.Start("https://www.facebook.com/dialog/share?app_id=184484190795&channel_url=https%3A%2F%2Fstaticxx.facebook.com%2Fx%2Fconnect%2Fxd_arbiter%2F%3Fversion%3D46%23cb%3Dfc09700e5a713c%26domain%3Dwww.fbrell.com%26is_canvas%3Dfalse%26origin%3Dhttp%253A%252F%252Fwww.fbrell.com%252Ffba1635317efa4%26relation%3Dopener&display=popup&e2e=%7B%7D&fallback_redirect_uri=http%3A%2F%2Fwww.fbrell.com%2FSharing%2F2%2520-%2520FB.ui%2520Dialogs%3Ffbclid%3DIwAR3PdJS-VaICmaLUCjBpSxfPPWFG4wCxQHaZi8_JmNKRPjqVQDnvmN5yWI8&href=https%3A%2F%2Fibb.co%2FVLGz7NF&locale=en_US&next=https%3A%2F%2Fstaticxx.facebook.com%2Fx%2Fconnect%2Fxd_arbiter%2F%3Fversion%3D46%23cb%3Dfda61e654691b4%26domain%3Dwww.fbrell.com%26is_canvas%3Dfalse%26origin%3Dhttp%253A%252F%252Fwww.fbrell.com%252Ffba1635317efa4%26relation%3Dopener%26frame%3Df6825364a6ef44%26result%3D%2522xxRESULTTOKENxx%2522&sdk=joey");
            }
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
