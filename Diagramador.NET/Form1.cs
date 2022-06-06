using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Diagramador.NET
{
    public partial class Form1 : Form
    {
        bool dibujar = false;
        
        public Form1()
        {
            InitializeComponent();
            panel2 = splitContainer.Panel2;
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
        }


        Bitmap bmp;
        SplitterPanel panel2;
        private Rectangle RcDraw;
        private float PenWidth = 5;
        Point actual, anterior;

        
        private void Draw(object sender, MouseEventArgs e)
        {
            if(dibujar)
            {
                anterior = e.Location;
                panel2.Refresh();


                panel2.CreateGraphics().DrawRectangle(
                        preDibujo(),
                        Math.Min(actual.X,anterior.X),
                        Math.Min(actual.Y,anterior.Y),
                        Math.Abs(anterior.X - actual.X),
                        Math.Abs(anterior.Y - actual.Y)
                    );
                
                
                // Force a repaint of the region occupied by the RcDrawangle...

                
                

            }
        }

        private Pen preDibujo()
        {
            Pen pen = new Pen(Color.Black, PenWidth);
            pen.DashStyle = DashStyle.DashDotDot;
            return pen;
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dibujar = true;

            // Determine the initial RcDrawangle coordinates...
            
            actual = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dibujar = false;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(Color.Black, PenWidth);

                g.DrawRectangle(
                    pen,
                    Math.Min(actual.X, anterior.X),
                    Math.Min(actual.Y, anterior.Y),
                    Math.Abs(anterior.X - actual.X),
                    Math.Abs(anterior.Y - actual.Y)
                    );

                pen.Dispose();
                g.Dispose();
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                  // Draw the RcDrawangle...
                    
        }

       
    }
}
