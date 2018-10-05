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
        string kleurschema;

        // Grootte van de interface & panel
        int width = 500;
        int height = 500;
        int widthForm = 600;
        int heightForm = 700;
  
        public Mandelbrot()
        {
            // De interface wordt gemaakt en de textboxen ingevuld
            InitializeComponent();
            Tmaxgetal.Text = maxgetal.ToString();
            Tscale.Text = scale.ToString();
            TmidX.Text = midX.ToString();
            TmidY.Text = midY.ToString();
            listBox1.SelectedIndex = 0;
            kleurschema = listBox1.Items[0].ToString();
            this.Text = "Mandelbrot";
            this.Size = new Size(widthForm, heightForm);

            // Panel tekening 
            panel2.Paint += this.tekenscherm;
            this.button1.Click += this.button1_Click;
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

                    // Convert the mandelbrotGetal to a color
                    // De verschillende kleurcombinaties van de standaardplaatjes worden hier gecreëerd. 

                    Color kleur;

                    if (kleurschema == "Standaard")
                    {
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
                    }

                    else if (kleurschema == "Kekke kleur")
                    {
                        if (mandelBrotGetal == maxgetal)
                        {
                            kleur = Color.Honeydew;
                        }
                        else if (mandelBrotGetal % 2 == 0)
                        {
                            kleur = Color.White;
                        }
                        else if (mandelBrotGetal % 3 == 0)
                        {
                            kleur = Color.Coral;
                        }
                        else
                        {
                            kleur = Color.Honeydew;
                        }
                    }

                    else if (kleurschema == "Nederlandse Vlag")
                    {
                        if (mandelBrotGetal == maxgetal)
                        {
                            kleur = Color.Orange;
                        }
                        else if (mandelBrotGetal % 7 == 0)
                        {
                            kleur = Color.DarkOrange;
                        }

                        else if (mandelBrotGetal % 2 == 0)
                        {
                            kleur = Color.White;
                        }
                        else if (mandelBrotGetal % 3 == 0)
                        {
                            kleur = Color.Red;
                        }
                        else
                        {
                            kleur = Color.Blue;
                        }
                    }

                    else if (kleurschema == "Regenboog")
                    {              
                        if (mandelBrotGetal == maxgetal)
                        {
                            kleur = Color.Purple;
                        }
                        else if (mandelBrotGetal % 11 == 0)
                        {
                            kleur = Color.Blue;
                        }                       
                        else if (mandelBrotGetal % 4 == 0)
                        {
                            kleur = Color.Green;
                        }
                        else if (mandelBrotGetal % 7 == 0)
                        {
                            kleur = Color.Yellow;
                        }
                        else if (mandelBrotGetal % 3 == 0)
                        {
                            kleur = Color.Orange;
                        }
                        else
                        {
                            kleur = Color.Red;
                        }
                    }

                    // Voor als er geen standaardplaatje geselecteerd is
                    else
                    {
                        kleur = Color.Black;
                    }                    
                  
                    // now we have the mandelbrotgetal for any coordinaat(x,y) or pixel(x,y) on the window !
                    // Here we should paint the given pixel with the color determined above
                    image.SetPixel(x, y, kleur);
                }               
            }

            // Draw image (should be outside for-loops)
            pea.Graphics.DrawImage(image, 0, 0, width, height);
        }

        // Hier wordt het mandelbrotgetal berekend dmv de functie die ons was gegeven
        Punt mandelbrotfunctie(Punt varPunt, Punt coordinaat)
        {
            Punt resultaat = new Punt(0,0);
            resultaat.A = varPunt.A * varPunt.A - varPunt.B * varPunt.B + coordinaat.A;
            resultaat.B = 2 * varPunt.A * varPunt.B + coordinaat.B;

            mandelBrotGetal++; 

            return resultaat;
        }

        // Als er op OK wordt geklikt worden de parameters bijgesteld
        private void button1_Click(object sender, EventArgs e)
        {
            // Poging tot parsen user input
            try
            {
                // User Interface veranderingen aangegeven in de textboxen
                scale = Double.Parse(Tscale.Text);
                maxgetal = int.Parse(Tmaxgetal.Text);
                midX = Double.Parse(TmidX.Text); // moeten we scalen
                midY = Double.Parse(TmidY.Text);
                panel2.Invalidate();
            }
            
            // Als de user input invalid is, wordt een foutmelding gegeven. 
            catch (Exception notnumber)
            {            
                Form popup;
                popup = new Form();
                popup.Size = new Size (500,200);
                popup.Text = "Error";

                Label error = new Label();
                error.Text = "Invalid input. Please only use numbers and the character \",\". ";
                error.Location = new Point(20, 20);
                error.Height = 30;
                error.Width = 450;

                popup.Controls.Add(error);
                popup.ShowDialog(); 
            }
      
        }

        // Als er geklikt wordt, wordt de kliklocatie het nieuwe middelpunt en worden de midX, midY en scale aangepast
        private void mouse_click(object sender, MouseEventArgs mea)
        {
            
            midX += (mea.X - width / 2)  * scale;
            midY += (mea.Y - height / 2) * scale;
            scale = scale / 2;

            Tscale.Text = scale.ToString();
            TmidX.Text = midX.ToString();
            TmidY.Text = midY.ToString();

            panel2.Invalidate();
        }

        // Het lukt ons niet om de onderstaande delen eruit te halen zonder foutmeldingen, we weten niet precies waarom.
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

        // Zodra een item uit de list wordt aangeklikt wordt de schaal van het plaatje aangepast 
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            // Schaal, midx en midy per plaatje instellen
            // Als je een nieuw plaatje aanklikt, gaat deze terug naar de onderstaande standaard instellingen
            kleurschema = listBox1.Items[listBox1.SelectedIndex].ToString();
            if (kleurschema == "Standaard")
            {
                scale = 0.01;
                midX = 0;
                midY = 0;
                Tscale.Text = scale.ToString();
                TmidX.Text = midX.ToString();
                TmidY.Text = midY.ToString();
            }

            else if (kleurschema == "Kekke kleur")
            {
                midX = -0.21185546875;
                midY = 0.68431640625;
                scale = 1.953125E-05;

                Tscale.Text = scale.ToString();
                TmidX.Text = midX.ToString();
                TmidY.Text = midY.ToString();
            }

            else if (kleurschema == "Nederlandse Vlag")
            {
                midX = 0.03924560546875;
                midY = 0.660491943359375;
                scale = 3.0517578125E-05;

                Tscale.Text = scale.ToString();
                TmidX.Text = midX.ToString();
                TmidY.Text = midY.ToString();
            }

            else if (kleurschema == "Regenboog")
            { 
                midX = 0.347546997070313;
                midY = 0.579248657226563;
                scale = 6.103515625E-07;

                Tscale.Text = scale.ToString();
                TmidX.Text = midX.ToString();
                TmidY.Text = midY.ToString();
            }

            panel2.Invalidate();
        }
    }

    // Hier wordt een minimalistische Punt klasse gedefineert, om de coordinaten te representeren
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
