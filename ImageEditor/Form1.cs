using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            { 
                Bitmap image = new Bitmap(open.FileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            
            for(int i = 0; i < image.Height; i++)
            {
                for(int j = 0; j < image.Width; j++)
                {
                    Color pixelRGB = image.GetPixel(j, i);
                    int red = (-1) * pixelRGB.R + 255;
                    int green = (-1) * pixelRGB.G + 255; ;
                    int blue = (-1) * pixelRGB.B + 255; ;
                    Color newPixelRGB = Color.FromArgb(red, green, blue);
                    image.SetPixel(j, i, newPixelRGB);
                }
            }
            pictureBox2.Image = image;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            int b = trackBar1.Value;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixelRGB = image.GetPixel(j, i);
                    int red = pixelRGB.R + b;
                    int green = pixelRGB.G + b;
                    int blue = pixelRGB.B + b;
                    if (red > 255) red = 255;
                    else if (red < 0) red = 0;
                    if (blue > 255) blue = 255;
                    else if (blue < 0) blue = 0;
                    if (green > 255) green = 255;
                    else if (green < 0) green = 0;
                    Color newPixelRGB = Color.FromArgb(red, green, blue);
                    image.SetPixel(j, i, newPixelRGB);
                }
            }
            pictureBox2.Image = image;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "" + trackBar1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double b;
            Bitmap image = new Bitmap(pictureBox1.Image);
            try
            { 
                b = Convert.ToDouble(textBox2.Text);
            }
            catch(Exception excep)
            {
                b = 0;
            }
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixelRGB = image.GetPixel(j, i);
                    double red = (255 * Math.Pow(((double)pixelRGB.R / 255), b));
                    double green = (255 * Math.Pow(((double)pixelRGB.G / 255), b));
                    double blue = (255 * Math.Pow(((double)pixelRGB.B / 255), b));
                    if (red > 255) red = 255;
                    else if (red < 0) red = 0;
                    if (blue > 255) blue = 255;
                    else if (blue < 0) blue = 0;
                    if (green > 255) green = 255;
                    else if (green < 0) green = 0; 
                    Color newPixelRGB = Color.FromArgb((int)red, (int)green, (int)blue);
                    image.SetPixel(j, i, newPixelRGB);
                }
            }
            pictureBox2.Image = image;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
