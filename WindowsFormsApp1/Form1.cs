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
    public struct Punt
    {
        public int A;
        public int B;
        public Punt (int a, int b) 
        {
            A = a;
            B = b;

        }
    }

    public partial class Form1 : Form
    {
        //variable member declared outside of any specific function, in order to make it available throughout the class in all functions
        int mendelBrotGetal;
        int width = 1000;
        int height = 500; 
        public Form1()
        {
            InitializeComponent();
            this.Text = "Mendelbrot";
            this.Size = new Size(width, height);
            this.Paint += this.tekenscherm;

        }

        void tekenscherm(object o, PaintEventArgs pea)
        {
            //I created a bitmap because of its bitmap.setpixel() function to color each pixel
            Bitmap image = new Bitmap(width,height);

            //the next few lines deal with applying the mendelFunction to one pixel(x,y)
            
            //we  make a nested for loop here to let it run through every pixel
            for (int x = 0; x<width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    double afstand = 0;
                    mendelBrotGetal = 0;


                    Punt coordinaat = new Punt(x, y);
                    Punt varPunt = new Punt(0, 0);
                    //coordinaat is constant and refers to the position of the pixel
                    // varPunt is variable, a linear transformation or function is applied to it several times and it changes each time

                    //here we apply the function to varPunt until its distance to the origin is more than 2 OR the mendelbrotgetal gets above 100 (the collegedictaat suggested this to mean mendelbrotgetal = infinite)
                    while (afstand < 2 && mendelBrotGetal < 100)
                    {
                        // the new variable point varPunt(a,b) is the output of the mendelbrotfunction(a,b) using itself as input
                        varPunt = (mendelbrotfunctie(varPunt, coordinaat));

                        // using the Pythagorean Theorem to calculate the distant between (a,b) and (0,0)
                        afstand = System.Math.Sqrt(varPunt.A * varPunt.A + varPunt.B * varPunt.B);
                    }

                    //convert the MendelbrotGetal to a color
                    //even MendelbrotGetallen become white, uneven become black, infinite also become black
                    Color kleur;
                    if (mendelBrotGetal == 100)
                    {
                        kleur = Color.Black;
                    }
                    else if (mendelBrotGetal % 2 == 0)
                    {
                        kleur = Color.White;
                    }
                    else
                    {
                        kleur = Color.Black;
                    }

                    // TODO: now we have the mendelbrotgetal for any coordinaat(x,y) or pixel(x,y) on the window !
                    // TODO: here we should paint the given pixel black or white
                    image.SetPixel(x, y, kleur);
                    pea.Graphics.DrawImage(image, 0, 0, width, height);
                }
            }
        }

        Punt mendelbrotfunctie(Punt varPunt, Punt coordinaat)
        {
            Punt resultaat = new Punt(0,0);
            resultaat.A = varPunt.A * varPunt.A - varPunt.B * varPunt.B + coordinaat.A;
            resultaat.B = 2 * varPunt.A * varPunt.B + coordinaat.B;

            mendelBrotGetal++; 

            return resultaat;
        }
    }
}
