using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Mandelbrot : Form
    {
 
        //variable member declared outside of any specific function, in order to make it available throughout the class in all functions
        int mandelBrotGetal;
        int maxgetal = 100;
        double scale = 0.01;
        double midX = 0;
        double midY = 0;

        int width = 500;
        int height = 500;
        int widthForm = 600;
        int heightForm = 700;
  

        public Mandelbrot()
        {
            InitializeComponent();
            Tmaxgetal.Text = maxgetal.ToString();
            Tscale.Text = scale.ToString();
            TmidX.Text = midX.ToString();
            TmidY.Text = midY.ToString();


            this.Text = "Mandelbrot";
            this.Size = new Size(widthForm, heightForm);
            panel2.Paint += this.tekenscherm;
            this.Click += this.button1_Click;
            panel2.MouseClick += this.mouse_click;
        }

        void tekenscherm(object o, PaintEventArgs pea)
        {
            //I created a bitmap because of its bitmap.setpixel() function to color each pixel
            Bitmap image = new Bitmap(width,height);

            //the next few lines deal with applying the mandelFunction to one pixel(x,y)

            //we  make a nested for loop here to let it run through every pixel
            for (int y = 0; y < height; y++)
            {

                for (int x = 0; x < width; x++)
                {

                    double afstand = 0;
                    mandelBrotGetal = 0;

                    // coordinaat ingesteld zodat het ook negatieve waardes aanneemt.
                    // scale kan je instellen zodat x wordt gescaled naar andere waardes
                    Punt coordinaat = new Punt((x - width / 2) * scale + midX, (y - height / 2) * scale + midY);
                    Punt varPunt = new Punt(0, 0);

                    // coordinaat is constant and refers to the position of the pixel
                    // varPunt is variable, a linear transformation or function is applied to it several times and it changes each time

                    /* Here we apply the function to varPunt until its distance to the origin is more than 2 
                    OR the mandelbrotgetal gets above 100 (the collegedictaat suggested this to mean mandelbrotgetal = infinite) */

                    while (afstand < 2 && mandelBrotGetal < maxgetal)
                    {
                        // the new variable point varPunt(a,b) is the output of the mandelbrotfunction(a,b) using itself as input
                        varPunt = (mandelbrotfunctie(varPunt, coordinaat));

                        // using the Pythagorean Theorem to calculate the distant between (a,b) and (0,0)
                        afstand = System.Math.Sqrt(varPunt.A * varPunt.A + varPunt.B * varPunt.B);
                    }

                    // convert the mandelbrotGetal to a color
                    // even mandelbrotGetallen become white, uneven become black, infinite also become black
                    Color kleur;
                    if (mandelBrotGetal == maxgetal)
                    {
                        kleur = Color.Black;
                    }
                    else if (mandelBrotGetal % 2 == 0)
                    {
                        kleur = Color.White;
                    }
                    else
                    {
                        kleur = Color.Black;
                    }

                    // TODO: now we have the mandelbrotgetal for any coordinaat(x,y) or pixel(x,y) on the window !
                    // TODO: here we should paint the given pixel black or white
                    image.SetPixel(x, y, kleur);


                }
                
            }
            // Draw image (should be outside for-loops)
            pea.Graphics.DrawImage(image, 0, 0, width, height);
        }

        Punt mandelbrotfunctie(Punt varPunt, Punt coordinaat)
        {
            Punt resultaat = new Punt(0,0);
            resultaat.A = varPunt.A * varPunt.A - varPunt.B * varPunt.B + coordinaat.A;
            resultaat.B = 2 * varPunt.A * varPunt.B + coordinaat.B;

            mandelBrotGetal++; 

            return resultaat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // User Interface veranderingen aangegeven in de textboxen
            scale = Double.Parse(Tscale.Text);
            maxgetal = int.Parse(Tmaxgetal.Text);
            midX = Double.Parse(TmidX.Text); // moeten we scalen
            midY = Double.Parse(TmidY.Text);
            panel2.Invalidate();

        }
        private void mouse_click(object sender, MouseEventArgs mea)
        {
            midX = (mea.X - width / 2)  * scale;
            midY = (mea.Y - height / 2)  * scale;
            scale = scale / 2;
            
            panel2.Invalidate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Punt
    {
        public double A;
        public double B;
        public Punt(double a, double b)
        {
            A = a;
            B = b;

        }
    }
}
