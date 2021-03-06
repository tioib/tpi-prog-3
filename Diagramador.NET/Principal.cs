using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.Json;
using System.IO;

namespace Diagramador.NET
{
    public partial class Principal : Form
    {
        bool check = false, changed = false, editText = false;
        int accionMouse = -1;
        string archivo = "";

        Save save = new Save();

        int[] figura;
     
        Bitmap bmp;
        private int opcion = -1;
        Point primerPunto, actualPunto, previous;
        Label aux = new Label();
        RichTextBox r = new RichTextBox();

        public Principal()
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
            saveFileDialog1.Filter = "dnsave files (*.dnsave)|*.dnsave|PNG (*.png)|*.png";

            pictureBox1.Controls.Add(r);
            r.Visible = false;
            r.KeyDown += R_KeyPress;
            r.KeyUp += DontEditText;

            HelpButtonClicked += ayudaToolStripMenuItem_Click;

            foreach (var b in botones.Controls) (b as Button).Click += ElegirFigura;
        }


        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (accionMouse == 30)
            {
                ctr.Left = e.X + ctr.Left - previous.X;
                ctr.Top = e.Y + ctr.Top - previous.Y;
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e)
        {
            accionMouse = -1;//para nada
            var l = sender as Label;
            int index = pictureBox1.Controls.IndexOf(l) - 1;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    save.labels.RemoveAt(index);
                    save.labelsTexto.RemoveAt(index);
                    pictureBox1.Controls.Remove(l);
                    l.Dispose();
                    changed = true;
                    break;

                case MouseButtons.Left:
                    var label = save.labels[index];
                    label[0] = l.Location.X;
                    label[1] = l.Location.Y;
                    changed = true;
                    break;
            }
        }
        private int[] CrearLabel(Point e, string txt, int size, int color)
        {
            Label texto = new Label();

            texto.Location = new Point(e.X, e.Y);
            texto.Text = txt;
            texto.ForeColor = Color.FromArgb(color);
            texto.Font = new Font(Font.FontFamily, size);
            texto.AutoSize = true;

            pictureBox1.Controls.Add(texto);

            texto.DoubleClick += Item_DoubleClick;
            texto.MouseDown += Ctr_MouseDown;
            texto.MouseUp += Ctr_MouseUp;
            texto.MouseMove += Ctr_MouseMove;

            return new int[] { e.X, e.Y, size, color };
        }
        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (!aux.Visible) aux.Visible = true;
            aux = sender as Label;
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    int index = pictureBox1.Controls.IndexOf(aux) - 1;
                    var label = save.labels[index];
                    aux.ForeColor = colorDialog1.Color;
                    aux.Font = new Font(Font.FontFamily, label[2] = (int)numericUpDown1.Value);
                    label[3] = colorDialog1.Color.ToArgb();
                    changed = true;
                    break;

                case MouseButtons.Left:
                    accionMouse = 30;//para mover el label
                    previous = e.Location;//primer posicion del mouse cuando haces click
                    break;
            }
        }

        private void Item_DoubleClick(object sender, EventArgs e)
        {
            r.Location = new Point(aux.Location.X, aux.Location.Y);
            r.Text = aux.Text;
            r.Width = aux.Width;
            r.Height = 20;
            aux.Visible = false;
            r.Visible = true;

            r.Focus();//automaticamente se pone para escribir en el richtextbox
        }



        private void DontEditText(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (int)Keys.ControlKey) editText = false;// cuando se suelta el control se vuelve falso
        }

        private void R_KeyPress(object sender, KeyEventArgs e)
        {
            if(!editText)editText = e.KeyValue == (int)Keys.ControlKey;

            if (e.KeyValue == (int)Keys.Enter)
            {
                int index = pictureBox1.Controls.IndexOf(aux) - 1;
                
                if (editText)
                {
                    var label = save.labels[index];
                    aux.ForeColor = colorDialog1.Color;
                    aux.Font = new Font(Font.FontFamily, label[2] = (int)numericUpDown1.Value);
                    label[3] = colorDialog1.Color.ToArgb();
                    editText = false;
                }
                aux.Visible = true;
                save.labelsTexto[index] = aux.Text = r.Text;
                r.Visible = false;
                return;
            }

            if (e.KeyValue == (int)Keys.Escape)
            {
                aux.Visible = true;
                //r.Text = "";
                r.Visible = false;
                return;
            }
        }

        private void ElegirFigura(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "Rectángulo": opcion = 0; break;
                case "Rectángulo relleno": opcion = 1; break;
                case "Elipse": opcion = 2; break;
                case "Elipse rellena": opcion = 3; break;
                case "Texto": opcion = 4; break;
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

        private void ChangeColor(object sender, MouseEventArgs e)
        {
            foreach(var r in save.figuras)
            {
                if(InsideFigura(r,e.Location))
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

                    primerPunto = new Point(r[0], r[1]);//Izquierda - arriba
                    actualPunto = r[5] < 4 ? new Point(r[0] + r[2], r[1] + r[3]) : new Point(r[2], r[3]);

                    DibujarFigura(figura[5], colorDialog1.Color);
                    BorrarFigura();
                    pictureBox1.Cursor = Cursors.Default;
                    changed = true;
                    return;
                }
            }
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            check = false;
            if (opcion != -1 && e.Button == MouseButtons.Left)
            {
                if (opcion == 4)
                {
                    save.labels.Add(CrearLabel(e.Location, "Escribir aquí...", (int)numericUpDown1.Value, colorDialog1.Color.ToArgb()));
                    save.labelsTexto.Add("Escribir aquí...");
                    changed = true;
                    return;
                }

                if (accionMouse > 1)// para la redimension 
                {
                    primerPunto = new Point(figura[0], figura[1]);
                    if(accionMouse > 9) // redimension de flecha 10 - 11
                    {
                        actualPunto = new Point(figura[2], figura[3]);
                        pictureBox1.Cursor = Cursors.Cross;
                    }
                    else actualPunto = new Point(figura[0] + figura[2], figura[1] + figura[3]);
                    accionMouse += 10;
                    return;
                }

                foreach (var r in save.figuras) 
                {
                    if (InsideFigura(r, e.Location)) // para mover la figura
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
                accionMouse = 0;// hiciste clic en un espacio vacio no hay ninguna figura 
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

                case 1:// se movia la figura 
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

                default:// para redimensionar figuras
                    primerPunto.X = primerPunto.X != this.primerPunto.X ? this.primerPunto.X : primerPunto.X;
                    primerPunto.Y = primerPunto.Y != this.primerPunto.Y ? this.primerPunto.Y : primerPunto.Y;
                    actualPunto.X = actualPunto.X != this.actualPunto.X ? this.actualPunto.X : actualPunto.X;
                    actualPunto.Y = actualPunto.Y != this.actualPunto.Y ? this.actualPunto.Y : actualPunto.Y;
                    switch (accionMouse) // depende de donde se agarro la figura ,
                    {
                        case 12: // cuando actionMouse es 2 y 12 es porq se redimensiona desde la izquierda un rectangulo o elipse
                            if (e.X >= actualPunto.X) return;
                            primerPunto.X = e.X; 
                            break;

                        case 13: // cuando actionMouse es 3 y 13 es porq se redimensiona desde la derecha un rectangulo o elipse
                            if (e.X <= primerPunto.X) return;
                            actualPunto.X = e.X;
                            break;

                        case 14:// cuando actionMouse es 4 y 14 es porq se redimensiona desde arriba de un rectangulo o elipse
                            if (e.Y >= actualPunto.Y) return;
                            primerPunto.Y = e.Y;
                            break;

                        case 15:// cuando actionMouse es 5 y 15 es porq se redimensiona desde abajo de un rectangulo o elipse
                            if (e.Y <= primerPunto.Y) return;
                            actualPunto.Y = e.Y;
                            break;

                        case 16: // redimensiona desde arriba a la izquierda
                            if (e.X >= actualPunto.X) return;
                            if (e.Y >= actualPunto.Y) return;
                            primerPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;

                        case 17:// redimensiona desde arriba a la derecha
                            if (e.X <= primerPunto.X) return;
                            if (e.Y >= actualPunto.Y) return;
                            actualPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;

                        case 18:// redimensiona desde abajo a la izquierda
                            if (e.X >= actualPunto.X) return;
                            if (e.Y <= primerPunto.Y) return;
                            primerPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                        case 19:// redimensiona desde abajo a la derecha
                            if (e.X <= primerPunto.X) return;
                            if (e.Y <= primerPunto.Y) return;
                            actualPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                        case 20:// redimesiona la flecha , si agarras el primer punto
                            primerPunto.X = e.X;
                            primerPunto.Y = e.Y;
                            break;
                        case 21:// redimesiona la flecha , si agarras el segundo punto
                            actualPunto.X = e.X;
                            actualPunto.Y = e.Y;
                            break;

                    }
                    if (CheckCollisionB(primerPunto, actualPunto,e.Location)) return;
                    this.primerPunto = primerPunto; this.actualPunto = actualPunto;
                    DrawPreview(figura[5], Color.FromArgb(save.colores[figura[6]]), figura[4]);
                    return;
            }

            foreach (var r in save.figuras)// es para ver si apoyas en el borde
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
                            accionMouse = 2;// si apoyas a la figura a la izquierda
                            return;
                        }

                        if (e.X <= r[0] + r[2] + r[4] && e.X > r[0] + r[2])
                        {
                            pictureBox1.Cursor = Cursors.SizeWE;
                            accionMouse = 3;// si apoyas a la figura a la derecha
                            return;
                        }
                    }

                    if(e.X > r[0] && e.X < r[0] + r[2])
                    {
                        if(e.Y >= r[1] - r[4] && e.Y < r[1])
                        {
                            pictureBox1.Cursor = Cursors.SizeNS;
                            accionMouse = 4;// si apoyas a la figura arriba
                            return;
                        }

                        if (e.Y <= r[1] + r[3] + r[4] && e.Y > r[1] + r[3])
                        {
                            pictureBox1.Cursor = Cursors.SizeNS;
                            accionMouse = 5;// si apoyas a la figura abajo
                            return;
                        }
                    }

                    if(e.X >= r[0] - r[4] && e.X <= r[0] && e.Y >= r[1] - r[4] && e.Y <= r[1])
                    {
                        pictureBox1.Cursor = Cursors.SizeNWSE;// si apoyas a la figura en diagonal arriba a la izquierda
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
                }//tipo de figura mayor a 4
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
            switch(e.Button)
            {
                case MouseButtons.Right:
                    foreach (var r in save.figuras)
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
                    break;

                case MouseButtons.Left:
                    if (check)
                    {
                        if (accionMouse == 0)
                        {
                            DibujarFigura(opcion, colorDialog1.Color);
                            pictureBox1.Refresh();
                        }
                        else if (accionMouse != -1)
                        {
                            DibujarFigura(figura[5], Color.FromArgb(save.colores[figura[6]]));
                            BorrarFigura();
                            pictureBox1.Cursor = Cursors.Default;
                        }
                        changed = true;
                    }
                    break;

                case MouseButtons.Middle:
                    ChangeColor(sender, e);
                    break;
            }
            accionMouse = -1;
        }


        private void BorrarFigura()
        {
            save.figuras.RemoveAt(figura[6]);
            save.colores.RemoveAt(figura[6]);
            bmp = new Bitmap(splitContainer.Panel2.ClientSize.Width, splitContainer.Panel2.ClientSize.Height);
            pictureBox1.Image = bmp;
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
                using(var pen = new Pen(Color.Transparent, r[4]))
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

                    pen.Dispose();
                    brush.Dispose();
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = splitContainer.Panel2.ClientSize;
            if (bmp != null)
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
        private bool CheckChange(object sender, EventArgs e)
        {
            if (changed && save.figuras.Count == 0 && save.labels.Count == 0) changed = false;

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
        private void Abrir(object sebder, EventArgs e)
        {
            var save = JsonSerializer.Deserialize<Save>(File.ReadAllText(openFileDialog1.FileName));
            if (save != null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
                archivo = openFileDialog1.FileName;
                this.save = save;
                RedrawFiguras();
                pictureBox1.Controls.Clear();
                pictureBox1.Controls.Add(r);

                foreach(var l in save.labels)
                    CrearLabel(new Point(l[0],l[1]),save.labelsTexto[save.labels.IndexOf(l)], l[2], l[3]);
                
                changed = false;
            }
        }

        private void ExportarImagen()
        {
            var bmp = new Bitmap(this.bmp);
            using(Graphics g = Graphics.FromImage(this.bmp))
            {
                foreach(var c in pictureBox1.Controls)
                {
                    if(c is Label)
                    {
                        var l = c as Label;
                        
                        g.DrawString(l.Text, l.Font, new SolidBrush(l.ForeColor), l.Location);
                    }
                }
                pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            this.bmp = bmp;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new Ayuda();
            a.ShowDialog();
            a.Dispose();
        }

        private void Guardar(object sender, EventArgs e)
        {
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
                pictureBox1.Controls.Clear();
                pictureBox1.Controls.Add(r);
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
                changed = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e) =>
            CheckChange(this, e);
        
    }
}
