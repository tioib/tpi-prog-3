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
            pictureBox1.Image = bmp;
            pictureBox1.Size = new Size(panel2.ClientSize.Width, panel2.ClientSize.Height);
            pictureBox2.BackColor = colorDialog1.Color = Color.Black;

            foreach (var b in botones.Controls) (b as Button).Click += ElegirFigura;
        }

        private void ElegirFigura(object sender, EventArgs e)
        {
            switch((sender as Button).Text)
            {
                case "Rectángulo": opcion = 0; break;
                case "Rectángulo relleno": opcion = 1; break;
                case "Elipse": opcion = 2; break;
                case "Elipse rellena": opcion = 3; break;
                case "<--": opcion = 4; break;
                case "-->": opcion = 5; break;
                case "<->": opcion = 6; break;
                case "---": opcion = 7; break;
            }
        }

        

        private void ElegirColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox2.BackColor = colorDialog1.Color;
        }

        List<int[]> rects = new List<int[]>(), circles = new List<int[]>(), lines = new List<int[]>();

        Bitmap bmp;
        SplitterPanel panel2;
        private int PenWidth = 5, opcion = 0;
        Point primerPunto, actualPunto;

        private void ChangeSize(object sender, EventArgs e)
        {
            PenWidth = (int)numericUpDown1.Value;
        }
        
        private void Draw(object sender, MouseEventArgs e)
        {
            if(dibujar)
            {
                var listas = GetListas();
                for(int i = 0; i < listas.Length; i++)
                {
                    foreach (var r in listas[i])
                    {
                        if ( r[5] < 4 &&
                            (
                                (r[1] - r[4] > primerPunto.Y && //se hizo clic arriba del recangulo colisionado y
                                    (
                                        e.Y > r[1] - r[4] && //mouse apoyado debajo del lado superior del recangulo colisionado y
                                        (
                                            (r[0] - r[4] < e.X && primerPunto.X < r[0]) || //mouse apoyado a la derecha del lado izquierdo del rectangulo y se hizo clic a su izquierda o
                                            (r[0] + r[2] + r[4] > e.X && primerPunto.X > r[0] + r[2]) || //mouse apoyado a la izquierda del lado derecho del rectangulo y se hizo clic a su derecha o
                                            (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4]) //se hizo clic directamente arriba o abajo del rectangulo
                                        )
                                    )
                                ) || //o...
                                (r[1] + r[3] + r[4] < primerPunto.Y && //se hizo clic abajo del recangulo colisionado y
                                    (
                                        e.Y < r[1] + r[3] + r[4] && //mouse apoyado encima del lado inferior del recangulo colisionado y
                                        (
                                            (r[0] - r[4] < e.X && primerPunto.X < r[0]) || //mouse apoyado a la derecha del lado izquierdo del rectangulo y se hizo clic a su izquierda o
                                            (r[0] + r[2] + r[4] > e.X && primerPunto.X > r[0] + r[2]) || //mouse apoyado a la izquierda del lado derecho del rectangulo y se hizo clic a su derecha o
                                            (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4]) //se hizo clic directamente arriba o abajo del rectangulo
                                        )
                                    )
                                ) || //o...
                                primerPunto.Y > r[1] - r[4] && primerPunto.Y < r[1] + r[3] + r[4] && //se hizo clic directamente a un costado del tectangulo y
                                (
                                    (primerPunto.X < r[0] - r[4] && e.X > r[0] - r[4]) || //se hizo clic a la izquierda del rectangulo y mouse apoyado a la derecha del lado izquierda o
                                    (primerPunto.X > r[0] + r[2] + r[4] && e.X < r[0] + r[2] + r[4]) //se hizo clic a la derecha del rectangulo y mouse apoyado a la izquierda del lado derecho 
                                )
                            )
                        ) return;
                    }
                }    
                        
                actualPunto = e.Location;
                pictureBox1.Refresh();

                switch (opcion)
                {
                    case 0:
                    case 1:
                        pictureBox1.CreateGraphics().DrawRectangle(
                        preDibujo(0),
                            Math.Min(primerPunto.X, actualPunto.X),
                            Math.Min(primerPunto.Y, actualPunto.Y),
                            Math.Abs(actualPunto.X - primerPunto.X),
                            Math.Abs(actualPunto.Y - primerPunto.Y)
                        );
                        break;

                    case 2:
                    case 3:
                        pictureBox1.CreateGraphics().DrawEllipse(
                        preDibujo(0),
                            Math.Min(primerPunto.X, actualPunto.X),
                            Math.Min(primerPunto.Y, actualPunto.Y),
                            Math.Abs(actualPunto.X - primerPunto.X),
                            Math.Abs(actualPunto.Y - primerPunto.Y)
                        );
                        break;
                        
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        pictureBox1.CreateGraphics().DrawLine(
                            preDibujo(opcion),
                            primerPunto,
                            actualPunto
                        );
                        break;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                int index = -1, opcion = -1;
                Pen pen = new Pen(pictureBox1.BackColor);
                SolidBrush brush = new SolidBrush(pictureBox1.BackColor);
                var listas = GetListas();
                for(int i = 0; i < listas.Length; i++)
                {
                    foreach (var r in listas[i])
                    {
                        if (InsideFigura(r, e.Location))
                        {
                            opcion = r[5];
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                switch (r[5])
                                {
                                    case 0:
                                        pen.Width = r[4];
                                        g.DrawRectangle(
                                            pen,
                                            r[0],
                                            r[1],
                                            r[2],
                                            r[3]
                                        );
                                        index = rects.IndexOf(r);
                                        break;

                                    case 1:
                                        g.FillRectangle(
                                            brush,
                                            r[0],
                                            r[1],
                                            r[2],
                                            r[3]
                                        );
                                        index = rects.IndexOf(r);
                                        break;

                                    case 2:
                                        pen.Width = r[4];
                                        g.DrawEllipse(
                                            pen,
                                            r[0],
                                            r[1],
                                            r[2],
                                            r[3]
                                        );
                                        index = circles.IndexOf(r);
                                        break;

                                    case 3:
                                        g.FillEllipse(
                                            brush,
                                            r[0],
                                            r[1],
                                            r[2],
                                            r[3]
                                        );
                                        index = circles.IndexOf(r);
                                        break;

                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                        pen.Width = r[4];
                                        switch (r[5])
                                        {
                                            case 4:
                                                pen.StartCap = LineCap.ArrowAnchor;
                                                break;
                                            case 5:
                                                pen.EndCap = LineCap.ArrowAnchor;
                                                break;
                                            case 6:
                                                pen.StartCap = pen.EndCap = LineCap.ArrowAnchor;
                                                break;
                                        }
                                        g.DrawLine(
                                            pen,
                                            new Point(r[0], r[1]),
                                            new Point(r[2], r[3])
                                        );
                                        index = lines.IndexOf(r);
                                        break;
                                }
                                g.Dispose();

                            }
                        }
                    }
                }    
                pen.Dispose();
                brush.Dispose();

                if (index != -1)
                {
                    switch(opcion)
                    {
                        case 0: case 1: rects.RemoveAt(index); break;
                        case 2: case 3: circles.RemoveAt(index); break;
                        case 4: case 5: case 6: case 7: lines.RemoveAt(index); break;
                    }
                    
                    pictureBox1.Refresh();
                }

                return;
            }

            if (dibujar)
            {
                dibujar = false;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    var rect = new int[]
                    {
                        Math.Min(primerPunto.X, actualPunto.X),
                        Math.Min(primerPunto.Y, actualPunto.Y),
                        Math.Abs(actualPunto.X - primerPunto.X),
                        Math.Abs(actualPunto.Y - primerPunto.Y),
                        PenWidth,
                        opcion
                    };

                    Pen pen = new Pen(colorDialog1.Color, PenWidth);
                    SolidBrush brush = new SolidBrush(colorDialog1.Color);
                    switch (opcion)
                    {
                        case 0:
                            g.DrawRectangle(
                                pen,
                                rect[0],
                                rect[1],
                                rect[2],
                                rect[3]
                            );
                            rects.Add(rect);
                            break;

                        case 1:
                            g.FillRectangle(
                                brush,
                                rect[0],
                                rect[1],
                                rect[2],
                                rect[3]
                            );
                            rects.Add(rect);
                            break;

                        case 2:
                            g.DrawEllipse(
                                pen,
                                rect[0],
                                rect[1],
                                rect[2],
                                rect[3]
                            );
                            circles.Add(rect);
                            break;

                        case 3:
                            g.FillEllipse(
                                brush,
                                rect[0],
                                rect[1],
                                rect[2],
                                rect[3]
                            );
                            circles.Add(rect);
                            break;

                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            switch (opcion)
                            {
                                case 4:
                                    pen.StartCap = LineCap.ArrowAnchor;
                                    break;
                                case 5:
                                    pen.EndCap = LineCap.ArrowAnchor;
                                    break;
                                case 6:
                                    pen.StartCap = pen.EndCap = LineCap.ArrowAnchor;
                                    break;
                            }
                            g.DrawLine(
                                pen,
                                primerPunto,
                                actualPunto
                            );
                            lines.Add(new int[] { primerPunto.X, primerPunto.Y, actualPunto.X, actualPunto.Y, PenWidth, opcion });
                            break;
                    }
                    pen.Dispose();
                    brush.Dispose();
                    g.Dispose();
                    

                }
                pictureBox1.Refresh();
            }
        }

        private void CrearFigura(Graphics g)
        {
            
        }

        private Pen preDibujo(int linea)
        {
            Pen pen = new Pen(colorDialog1.Color, PenWidth);
            pen.DashStyle = DashStyle.DashDotDot;
            switch (linea)
            {
                case 4:
                    pen.StartCap = LineCap.ArrowAnchor;
                    break;
                case 5:
                    pen.EndCap = LineCap.ArrowAnchor;
                    break;
                case 6:
                    pen.StartCap = pen.EndCap = LineCap.ArrowAnchor;
                    break;
            }
            return pen;
        }
        
        private bool InsideFigura(int[] r, Point e)
        {
            if(r[5] < 4) return r[0] <= e.X && r[1] <= e.Y && (r[0] + r[2]) >= e.X && (r[1] + r[3]) >= e.Y;

            return false; //acá debería verificarse si se toca una flecha
        }

        private List<int[]>[] GetListas()
        {
            return new List<int[]>[] { rects, circles, lines };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                var listas = GetListas();
                for(int i = 0; i < listas.Length; i++)
                {
                    foreach (var r in listas[i])
                    {
                        if (InsideFigura(r, e.Location))
                        {
                            primerPunto = e.Location;
                            return;
                        }
                    }
                }
                dibujar = true;
                primerPunto = e.Location;
            }  
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = splitContainer.Panel2.ClientSize;
            if(bmp != null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;

                foreach(var r in rects)
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangle(
                            new Pen(colorDialog1.Color, r[4]),
                            r[0],
                            r[1],
                            r[2],
                            r[3]
                            );

                        g.Dispose();

                        pictureBox1.Refresh();
                    }
                }
            }
            
        }


        

       
    }
}
