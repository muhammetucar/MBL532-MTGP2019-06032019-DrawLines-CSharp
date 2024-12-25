using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLines
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Graphics g = null;
        static int startX, startY;
        static int endX, endY;
        static int myAngle = 0;
        static int myLength = 0;
        static int myDistance = 0;
        static int numberLines = 0;



        private void button1_Click(object sender, EventArgs e)
        {
            //convert text to integer
            myAngle = int.Parse(Angle.Text);
            myLength = int.Parse(Length.Text);
            myDistance = int.Parse(Distance.Text);
            numberLines = int.Parse(NumberofLines.Text);

            //locate patterns in the center of the form
            startX = panel2.Width / 2;
            startY = panel2.Height / 2;

            //refresh canvas
            panel2.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 1; //pen width
            g = panel2.CreateGraphics();
            for (int i = 0; i < int.Parse(NumberofLines.Text); i++)
                drawLine();
        }

        private void drawLine()
        {
            //choose random pen color
            Random randomGen = new Random();
            myPen.Color = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));

            myAngle = myAngle + int.Parse(Angle.Text); //add line to existing line
            myLength = myLength + int.Parse(Distance.Text); //add length to existing length

            //draw radiant lines:
            endX = (int)(startX + Math.Cos(Math.PI * myAngle / 180) * myLength);
            endY = (int)(startY + Math.Sin(Math.PI * myAngle / 180) * myLength);
            Point[] points = { new Point(startX, startY), new Point(endX, endY) };
            //end of a line is the starting point of the next line:
            startX = endX;
            startY = endY;
            g.DrawLines(myPen, points);

        }

        public Form1()
        {
            InitializeComponent();
        }

        
    }
}
