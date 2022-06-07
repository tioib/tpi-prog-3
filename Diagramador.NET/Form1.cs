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
        bool dibujar = false, mover = false;
        
        public Form1()
        {
            InitializeComponent();
            panel2 = splitContainer.Panel2;
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Size = new Size(panel2.ClientSize.Width, panel2.ClientSize.Height);
        }

        List<Graphics> rects = new List<Graphics>();
        List<int[]> rectLocations = new List<int[]>();

        Bitmap bmp;
        SplitterPanel panel2;
        private Rectangle RcDraw;
        private int PenWidth = 5;
        Point primerPunto, actualPunto;

        
        private void Draw(object sender, MouseEventArgs e)
        {
            if(dibujar)
            {
                foreach (var r in rectLocations)
                {
                    if (
                        (r[1] - r[4] > primerPunto.Y &&
                            (
                                e.Y > r[1] - r[4] &&
                                (
                                    (r[0] - r[4] < e.X && primerPunto.X < r[0]) ||
                                    (r[0] + r[2] + r[4] > e.X && primerPunto.X > r[0] + r[2]) ||
                                    (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4])
                                )
                            )
                        ) ||
                        (r[1] + r[3] + r[4] < primerPunto.Y &&
                            (
                                e.Y < r[1] + r[3] + r[4] &&
                                (
                                    (r[0] - r[4] < e.X && primerPunto.X < r[0]) ||
                                    (r[0] + r[2] + r[4] > e.X && primerPunto.X > r[0] + r[2]) ||
                                    (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4])
                                )
                            )
                        ) ||
                        (r[0] - r[4] > primerPunto.X &&
                            (
                                e.X > r[0] - r[4] &&
                                (
                                    (r[1] - r[4] < e.Y && primerPunto.Y < r[1]) ||
                                    (r[1] + r[3] + r[4] > e.Y && primerPunto.Y > r[1] + r[3]) ||
                                    (primerPunto.Y > r[1] - r[3] && primerPunto.Y < r[1] + r[3] + r[4])
                                )
                            )
                        ) ||
                        (r[0] + r[2] + r[4] < primerPunto.X &&
                            (
                                e.X < r[0] + r[2] + r[4] &&
                                (
                                    (r[1] - r[4] < e.Y && primerPunto.Y < r[1]) ||
                                    (r[1] + r[3] + r[4] > e.Y && primerPunto.Y > r[1] + r[3]) ||
                                    (primerPunto.Y > r[1] - r[3] && primerPunto.Y < r[1] + r[3] + r[4])
                                )
                            )
                        )
                    )
                        return;


                    
                    
                }
                        
                actualPunto = e.Location;
                pictureBox1.Refresh();


                pictureBox1.CreateGraphics().DrawRectangle(
                        preDibujo(),
                        Math.Min(primerPunto.X,actualPunto.X),
                        Math.Min(primerPunto.Y,actualPunto.Y),
                        Math.Abs(actualPunto.X - primerPunto.X),
                        Math.Abs(actualPunto.Y - primerPunto.Y)
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
        
        private bool InsideRectangle(int[] r, Point e)
        {
            return r[0] <= e.X && r[1] <= e.Y && (r[0] + r[2]) >= e.X && (r[1] + r[3]) >= e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                foreach (var r in rectLocations)
                {
                    if (InsideRectangle(r, e.Location))
                    {
                        primerPunto = e.Location;
                        return;
                    }
                }
                dibujar = true;
                primerPunto = e.Location;
            }
            // Determine the initial RcDrawangle coordinates...
            
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                int index = -1;
                foreach (var r in rectLocations)
                {
                    if (InsideRectangle(r,e.Location))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawRectangle(
                                new Pen(pictureBox1.BackColor, r[4]),
                                r[0],
                                r[1],
                                r[2],
                                r[3]
                                );
                            pictureBox1.Refresh();
                            g.Dispose();
                        }
                        rects[index = rectLocations.IndexOf(r)].Dispose();
                        rects.RemoveAt(index);


                    }
                }
                if (index != -1)
                {
                    rectLocations.RemoveAt(index);
                    pictureBox1.Refresh();
                }
                return;
            }
            
            if(dibujar)
            {
                dibujar = false;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    Pen pen = new Pen(Color.Black, PenWidth);

                    var rect = new int[]
                    {
                    Math.Min(primerPunto.X, actualPunto.X),
                    Math.Min(primerPunto.Y, actualPunto.Y),
                    Math.Abs(actualPunto.X - primerPunto.X),
                    Math.Abs(actualPunto.Y - primerPunto.Y),
                    PenWidth
                    };

                    g.DrawRectangle(
                        pen,
                        rect[0],
                        rect[1],
                        rect[2],
                        rect[3]
                        );

                    pen.Dispose();
                    rects.Add(g);
                    rectLocations.Add(rect);

                }
                pictureBox1.Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                  // Draw the RcDrawangle...
                    
        }

       
    }
}
