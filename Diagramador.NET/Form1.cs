using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Text.Json;
using System.IO;

namespace Diagramador.NET
{
    public partial class Form1 : Form
    {
        bool check = false, changed = false;
        int accionMouse = -1;
        string archivo = "";

        Save save = new Save();

        int[] figura;

        Bitmap bmp;
        private int opcion = 0;
        Point primerPunto, actualPunto, previous;

        public Form1()
        {
            InitializeComponent();
            SplitterPanel panel2 = splitContainer.Panel2;
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Size = new Size(panel2.ClientSize.Width, panel2.ClientSize.Height);
            pictureBox2.BackColor = colorDialog1.Color = Color.Black;

            saveFileDialog1.FileOk += Guardar;
            openFileDialog1.FileOk += Abrir;
            openFileDialog1.Filter = "dnsave files (*.dnsave)|*.dnsave";
            saveFileDialog1.Filter = "dnsave files (*.dnsave)|*.dnsave|JPG (.*jpg *jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";

            foreach (var b in botones.Controls) (b as Button).Click += ElegirFigura;
        }

        private void ElegirFigura(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            check = false;
            if (e.Button == MouseButtons.Left)
            {
                if(accionMouse > 1)
                {
                    primerPunto = new Point(figura[0], figura[1]);
                    if(accionMouse > 9)
                    {
                        actualPunto = new Point(figura[2], figura[3]);
                        pictureBox1.Cursor = Cursors.Cross;
                    }
                    else actualPunto = new Point(figura[0] + figura[2], figura[1] + figura[3]);
                    accionMouse += 10;
                    Debug.WriteLine(accionMouse);
                    return;
                }

                foreach (var r in save.figuras)
                {
                    if (InsideFigura(r, e.Location))
                    {
                        if(r[5]<4)
                        {
                            accionMouse = 1;
                            pictureBox1.Cursor = Cursors.Cross;
                            figura = new int[] {
                                r[0], //X
                                r[1], //Y
                                r[2], //width
                                r[3], //height
                                r[4], //grosor de linea de la figura (PenWidth)
                                r[5], //tipo de figura (rectangulo, elipse, etc)
                                save.figuras.IndexOf(r) //indice de la figura en la lista (para el color)
                            };
                            actualPunto = previous = e.Location;
                            return;
                        }
                    }
                }

                foreach(var r in save.figuras)
                {
                    if (InsideFigura(r, e.Location)) return;
                }
                accionMouse = 0;
                primerPunto = e.Location;
            }
        }

        private bool CheckCollisionB(Point primerPunto, Point actualPunto, Point mouse)
        {

            foreach (var r in save.figuras)
            {
                if(r[0] != figura[0])
                {
                    if (r[1] != figura[1] &&
                    (
                        figura[5] < 4 && r[5] < 4 &&
                        (
                            (r[1] - r[4] > primerPunto.Y &&
                                (
                                    actualPunto.Y > r[1] - r[4] &&
                                    (
                                        (r[0] - r[4] < actualPunto.X && primerPunto.X < r[0]) ||
                                        (r[0] + r[2] + r[4] > actualPunto.X && primerPunto.X > r[0] + r[2]) ||
                                        (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4])
                                    )
                                )
                            ) || //o...
                            (r[1] + r[3] + r[4] < actualPunto.Y &&
                                (
                                    primerPunto.Y < r[1] + r[3] + r[4] &&
                                    (
                                        (r[0] - r[4] < actualPunto.X && primerPunto.X < r[0]) ||
                                        (r[0] + r[2] + r[4] > actualPunto.X && primerPunto.X > r[0] + r[2]) ||
                                        (primerPunto.X > r[0] - r[4] && primerPunto.X < r[0] + r[2] + r[4])
                                    )
                                )
                            ) || //o...
                            primerPunto.Y > r[1] - r[4] && primerPunto.Y < r[1] + r[3] + r[4] &&
                            (
                                (primerPunto.X < r[0] - r[4] && actualPunto.X > r[0] - r[4]) ||
                                (actualPunto.X > r[0] + r[2] + r[4] && primerPunto.X < r[0] + r[2] + r[4])
                            )
                        )
                    )) return true;
                    if (InsideFigura(r, mouse)) return true;
                }
            }
            return false;
        }

        private void Draw(object sender, MouseEventArgs e)
        {
            check = true;
            Point primerPunto = new Point(), actualPunto = new Point();
            switch (accionMouse)
            {
                case -1: case 2: case 3: case 4: case 5: case 6: case 7: case 8: case 9: case 10: case 11: break;
                case 0:
                    foreach (var r in save.figuras)
                    {
                        if (r[5] < 4 &&
                            (
                                (r[1] - r[4] > this.primerPunto.Y && //se hizo clic arriba del recangulo colisionado y
                                    (
                                        e.Y > r[1] - r[4] && //mouse apoyado debajo del lado superior del recangulo colisionado y
                                        (
                                            (r[0] - r[4] < e.X && this.primerPunto.X < r[0]) || //mouse apoyado a la derecha del lado izquierdo del rectangulo y se hizo clic a su izquierda o
                                            (r[0] + r[2] + r[4] > e.X && this.primerPunto.X > r[0] + r[2]) || //mouse apoyado a la izquierda del lado derecho del rectangulo y se hizo clic a su derecha o
                                            (this.primerPunto.X > r[0] - r[4] && this.primerPunto.X < r[0] + r[2] + r[4]) //se hizo clic directamente arriba o abajo del rectangulo
                                        )
                                    )
                                ) || //o...
                                (r[1] + r[3] + r[4] < this.primerPunto.Y && //se hizo clic abajo del recangulo colisionado y
                                    (
                                        e.Y < r[1] + r[3] + r[4] && //mouse apoyado encima del lado inferior del recangulo colisionado y
                                        (
                                            (r[0] - r[4] < e.X && this.primerPunto.X < r[0]) || //mouse apoyado a la derecha del lado izquierdo del rectangulo y se hizo clic a su izquierda o
                                            (r[0] + r[2] + r[4] > e.X && this.primerPunto.X > r[0] + r[2]) || //mouse apoyado a la izquierda del lado derecho del rectangulo y se hizo clic a su derecha o
                                            (this.primerPunto.X > r[0] - r[4] && this.primerPunto.X < r[0] + r[2] + r[4]) //se hizo clic directamente arriba o abajo del rectangulo
                                        )
                                    )
                                ) || //o...
                                this.primerPunto.Y > r[1] - r[4] && this.primerPunto.Y < r[1] + r[3] + r[4] && //se hizo clic directamente a un costado del tectangulo y
                                (
                                    (this.primerPunto.X < r[0] - r[4] && e.X > r[0] - r[4]) || //se hizo clic a la izquierda del rectangulo y mouse apoyado a la derecha del lado izquierda o
                                    (this.primerPunto.X > r[0] + r[2] + r[4] && e.X < r[0] + r[2] + r[4]) //se hizo clic a la derecha del rectangulo y mouse apoyado a la izquierda del lado derecho 
                                )
                            )
                        ) return;
                        if(InsideFigura(r,e.Location)) return;
                    }

                    this.actualPunto = e.Location;
                    DrawPreview(opcion, colorDialog1.Color, (int)numericUpDown1.Value);
                    return;

                case 1:
                    if(figura[5] < 4)
                    {
                        primerPunto.X = e.X < previous.X ? figura[0] - Math.Abs(e.X - previous.X) : figura[0] + Math.Abs(e.X - previous.X);
                        primerPunto.Y = e.Y < previous.Y ? figura[1] - Math.Abs(e.Y - previous.Y) : figura[1] + Math.Abs(e.Y - previous.Y);

                        actualPunto.X = primerPunto.X + figura[2]; actualPunto.Y = primerPunto.Y + figura[3];

                        if (CheckCollisionB(primerPunto, actualPunto, e.Location)) return;

                        this.primerPunto = primerPunto;
                        this.actualPunto = actualPunto;
                    

                        DrawPreview(figura[5], Color.FromArgb(save.colores[figura[6]]), figura[4]);
                    }
                    return;

                default:
                    primerPunto.X = primerPunto.X != this.primerPunto.X ? this.primerPunto.X : primerPunto.X;
                    primerPunto.Y = primerPunto.Y != this.primerPunto.Y ? this.primerPunto.Y : primerPunto.Y;
                    actualPunto.X = actualPunto.X != this.actualPunto.X ? this.actualPunto.X : actualPunto.X;
                    actualPunto.Y = actualPunto.Y != this.actualPunto.Y ? this.actualPunto.Y : actualPunto.Y;
                    switch (accionMouse)
                    {
                        case 12:
                            if (e.X >= actualPunto.X) return;
                            primerPunto.X = e.X;
                            break;

                        case 13:
                            if (e.X <= primerPunto.X) return;
                            actualPunto.X = e.X;
                            break;

                        case 14:
                            if (e.Y >= actualPunto.Y) return;
                            primerPunto.Y = e.Y;
                            break;

                        case 15:
                            if (e.Y <= primerPunto.Y) return;
                            actualPunto.Y = e.Y;
                            break;

                        case 16: 
                            if (e.X >= actualPunto.X) return;
                            if (e.Y >= actualPunto.Y) return;
                            primerPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;

                        case 17:
                            if (e.X <= primerPunto.X) return;
                            if (e.Y >= actualPunto.Y) return;
                            actualPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;

                        case 18:
                            if (e.X >= actualPunto.X) return;
                            if (e.Y <= primerPunto.Y) return;
                            primerPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                        case 19:
                            if (e.X <= primerPunto.X) return;
                            if (e.Y <= primerPunto.Y) return;
                            actualPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                        case 20:
                            primerPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;
                        case 21:
                            actualPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                    }
                    if (CheckCollisionB(primerPunto, actualPunto,e.Location)) return;
                    this.primerPunto = primerPunto; this.actualPunto = actualPunto;
                    DrawPreview(figura[5], Color.FromArgb(save.colores[figura[6]]), figura[4]);
                    return;
            }

            foreach (var r in save.figuras)
            {
                figura = new int[] {
                            r[0],
                            r[1],
                            r[2],
                            r[3],
                            r[4],
                            r[5],
                            save.figuras.IndexOf(r)
                        };
                if (r[5] < 4)
                {
                    if (e.Y > r[1] && e.Y < r[1] + r[3])
                    {
                        if (e.X >= r[0] - r[4] && e.X < r[0])
                        {
                            pictureBox1.Cursor = Cursors.SizeWE;
                            accionMouse = 2;
                            return;
                        }

                        if (e.X <= r[0] + r[2] + r[4] && e.X > r[0] + r[2])
                        {
                            pictureBox1.Cursor = Cursors.SizeWE;
                            accionMouse = 3;
                            return;
                        }
                    }

                    if(e.X > r[0] && e.X < r[0] + r[2])
                    {
                        if(e.Y >= r[1] - r[4] && e.Y < r[1])
                        {
                            pictureBox1.Cursor = Cursors.SizeNS;
                            accionMouse = 4;
                            return;
                        }

                        if (e.Y <= r[1] + r[3] + r[4] && e.Y > r[1] + r[3])
                        {
                            pictureBox1.Cursor = Cursors.SizeNS;
                            accionMouse = 5;
                            return;
                        }
                    }

                    if(e.X >= r[0] - r[4] && e.X <= r[0] && e.Y >= r[1] - r[4] && e.Y <= r[1])
                    {
                        pictureBox1.Cursor = Cursors.SizeNWSE;
                        accionMouse = 6;
                        return;
                    }

                    if (e.X >= r[0] + r[2] && e.X <= r[0] + r[2] + r[4] && e.Y >= r[1] - r[4] && e.Y <= r[1])
                    {
                        pictureBox1.Cursor = Cursors.SizeNESW;
                        accionMouse = 7;
                        return;
                    }

                    if (e.X >= r[0] - r[4] && e.X <= r[0] && e.Y >= r[1] + r[3] && e.Y <= r[1] + r[3] + r[4])
                    {
                        pictureBox1.Cursor = Cursors.SizeNESW;
                        accionMouse = 8;
                        return;
                    }

                    if (e.X >= r[0] + r[2] && e.X <= r[0] + r[2] + r[4] && e.Y >= r[1] + r[3] && e.Y <= r[1] + r[3] + r[4])
                    {
                        pictureBox1.Cursor = Cursors.SizeNWSE;
                        accionMouse = 9;
                        return;
                    }
                }
                else if(e.X >= r[0] - r[4] && e.X <= r[0] + r[4] && e.Y >= r[1] - r[4] && e.Y <= r[1] + r[4]) 
                {
                    pictureBox1.Cursor = Cursors.Hand;
                    accionMouse = 10;
                    return;
                }
                else if(e.X >= r[2] - r[4] && e.X <= r[2] + r[4] && e.Y >= r[3] - r[4] && e.Y <= r[3] + r[4])
                {
                    pictureBox1.Cursor = Cursors.Hand;
                    accionMouse = 11;
                    return;
                }
            }
            pictureBox1.Cursor = Cursors.Default;
            accionMouse = -1;
        }

        private Pen preDibujo(int linea, Color color, int PenWidth)
        {
            Pen pen = new Pen(color, PenWidth);
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

        private void DrawPreview(int opcion, Color color, int PenWidth)
        {
            pictureBox1.Refresh();

            switch (opcion)
            {
                case 0:
                case 1:
                    pictureBox1.CreateGraphics().DrawRectangle(
                    preDibujo(0, color, PenWidth),
                        Math.Min(primerPunto.X, actualPunto.X),
                        Math.Min(primerPunto.Y, actualPunto.Y),
                        Math.Abs(actualPunto.X - primerPunto.X),
                        Math.Abs(actualPunto.Y - primerPunto.Y)
                    );
                    break;

                case 2:
                case 3:
                    pictureBox1.CreateGraphics().DrawEllipse(
                    preDibujo(0, color, PenWidth),
                        Math.Min(primerPunto.X, actualPunto.X),
                        Math.Min(primerPunto.Y, actualPunto.Y),
                        Math.Abs(actualPunto.X - primerPunto.X),
                        Math.Abs(actualPunto.Y - primerPunto.Y)
                    );
                    break;

                default:
                    pictureBox1.CreateGraphics().DrawLine(
                        preDibujo(opcion,color,PenWidth),
                        primerPunto,
                        actualPunto
                    );
                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                foreach(var r in save.figuras)
                {
                    if (InsideFigura(r, e.Location))
                    {
                        figura = new int[] {
                            r[0], //X
                            r[1], //Y
                            r[2], //width
                            r[3], //height
                            r[4], //grosor de linea de la figura (PenWidth)
                            r[5], //tipo de figura (rectangulo, elipse, etc)
                            save.figuras.IndexOf(r) //indice de la figura en la lista (para el color)
                        };
                        BorrarFigura();
                        changed = true;
                        return;
                    }
                }
            }

            if(check)
            {
                if (accionMouse == 0)
                {
                    DibujarFigura(opcion, colorDialog1.Color);
                    pictureBox1.Refresh();
                }
                else if(accionMouse != -1)
                {
                    DibujarFigura(figura[5], Color.FromArgb(save.colores[figura[6]]));
                    BorrarFigura();
                    pictureBox1.Cursor = Cursors.Default;
                }
                changed = true;
            }
            accionMouse = -1;
        }


        private void BorrarFigura()
        {
            Pen pen = new Pen(pictureBox1.BackColor);
            SolidBrush brush = new SolidBrush(pictureBox1.BackColor);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                switch (figura[5])
                {
                    case 0:
                        pen.Width = figura[4];
                        g.DrawRectangle(
                            pen,
                            figura[0],
                            figura[1],
                            figura[2],
                            figura[3]
                        );
                        break;

                    case 1:
                        g.FillRectangle(
                            brush,
                            figura[0],
                            figura[1],
                            figura[2],
                            figura[3]
                        );
                        break;

                    case 2:
                        pen.Width = figura[4];
                        g.DrawEllipse(
                            pen,
                            figura[0],
                            figura[1],
                            figura[2],
                            figura[3]
                        );
                        break;

                    case 3:
                        g.FillEllipse(
                            brush,
                            figura[0],
                            figura[1],
                            figura[2],
                            figura[3]
                        );
                        break;

                    default:
                        pen.Width = figura[4];
                        switch (figura[5])
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
                            new Point(figura[0], figura[1]),
                            new Point(figura[2], figura[3])
                        );
                        break;
                }
                g.Dispose();

            }

            pen.Dispose();
            brush.Dispose();

            save.figuras.RemoveAt(figura[6]);
            save.colores.RemoveAt(figura[6]);

            RedrawFiguras();
            pictureBox1.Refresh();
        }

        private void DibujarFigura(int opcion, Color color)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                var rect = new int[]
                {
                        Math.Min(primerPunto.X, actualPunto.X),
                        Math.Min(primerPunto.Y, actualPunto.Y),
                        Math.Abs(actualPunto.X - primerPunto.X),
                        Math.Abs(actualPunto.Y - primerPunto.Y),
                        (int)numericUpDown1.Value,
                        opcion
                };

                Pen pen = new Pen(color, (int)numericUpDown1.Value);
                SolidBrush brush = new SolidBrush(color);
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
                        save.figuras.Add(rect);
                        break;

                    case 1:
                        g.FillRectangle(
                            brush,
                            rect[0],
                            rect[1],
                            rect[2],
                            rect[3]
                        );
                        save.figuras.Add(rect);
                        break;

                    case 2:
                        g.DrawEllipse(
                            pen,
                            rect[0],
                            rect[1],
                            rect[2],
                            rect[3]
                        );
                        save.figuras.Add(rect);
                        break;

                    case 3:
                        g.FillEllipse(
                            brush,
                            rect[0],
                            rect[1],
                            rect[2],
                            rect[3]
                        );
                        save.figuras.Add(rect);
                        break;

                    default:
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
                        save.figuras.Add(new int[] { primerPunto.X, primerPunto.Y, actualPunto.X, actualPunto.Y, (int)numericUpDown1.Value, opcion });
                        break;
                }
                pen.Dispose();
                brush.Dispose();
                g.Dispose();
                save.colores.Add(color.ToArgb());
            }
        }

        private bool InsideFigura(int[] r, Point e)
        {
            if (r[5] < 4) return r[0] < e.X && r[1] < e.Y && (r[0] + r[2]) > e.X && (r[1] + r[3]) > e.Y;

            using(var path = new GraphicsPath())
            {
                using(var pen = new Pen(Color.Transparent, r[5]))
                {
                    path.AddLine(new Point(r[0],r[1]),new Point(r[2],r[3]));
                    return path.IsOutlineVisible(e, pen);
                }
            }
        }


        
        

        private void RedrawFiguras()
        {
            for (int i = 0; i < save.figuras.Count; i++)
            {
                var r = save.figuras[i];
                Pen pen = new Pen(Color.FromArgb(save.colores[i]));
                SolidBrush brush = new SolidBrush(Color.FromArgb(save.colores[i]));

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
                            break;

                        case 1:
                            g.FillRectangle(
                                brush,
                                r[0],
                                r[1],
                                r[2],
                                r[3]
                            );
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
                            break;

                        case 3:
                            g.FillEllipse(
                                brush,
                                r[0],
                                r[1],
                                r[2],
                                r[3]
                            );
                            break;

                        default:
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
                            break;
                    }

                    g.Dispose();
                    pen.Dispose();
                    brush.Dispose();
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = splitContainer.Panel2.ClientSize;
            if(bmp != null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;

                RedrawFiguras();
            }
            
        }


        private void botonAbrir_Click(object sender, EventArgs e)
        {
            if(CheckChange(sender, e)) openFileDialog1.ShowDialog();
        }

        private void Abrir(object sebder, EventArgs e)
        {
            var save = JsonSerializer.Deserialize<Save>(File.ReadAllText(openFileDialog1.FileName));
            if (save != null)
            {
                Debug.WriteLine("");
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
                archivo = openFileDialog1.FileName;
                this.save = save;
                RedrawFiguras();
                changed = false;

            }
        }

        private void ExportarImagen()
        {
            using(FileStream fs = File.Open(saveFileDialog1.FileName, FileMode.OpenOrCreate))
            if (saveFileDialog1.FilterIndex == 2)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = bmp;
                pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
                pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void Guardar(object sender, EventArgs e)
        {
            Debug.WriteLine(saveFileDialog1.FilterIndex);
            if (saveFileDialog1.FilterIndex > 1) ExportarImagen();
            else
            {
                File.WriteAllText(archivo = saveFileDialog1.FileName, JsonSerializer.Serialize(save));
                changed = false;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(archivo == "")
                saveFileDialog1.ShowDialog();
            else
            {
                File.WriteAllText(archivo, JsonSerializer.Serialize(save));
                MessageBox.Show("Diagrama guardado en:\n"+archivo);
            }
            changed = false;
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            if(CheckChange(sender,e))
            {
                save.Clear();
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
                changed = false;
            }
        }

        private bool CheckChange(object sender, EventArgs e)
        {
            if (changed)
            {
                switch (MessageBox.Show("Cambios realizados, ¿desea guardar el diagrama?", "Alerta", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        botonGuardar_Click(sender, e);
                        break;

                    case DialogResult.Cancel:
                        return false;

                }
                return true;
            }
            else return true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            CheckChange(this, e);
            base.OnClosing(e);
        }
    }
}
