namespace Diagramador.NET
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botonAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.botonGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.botonNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.Button();
            this.botones = new System.Windows.Forms.FlowLayoutPanel();
            this.rect = new System.Windows.Forms.Button();
            this.rectFill = new System.Windows.Forms.Button();
            this.circle = new System.Windows.Forms.Button();
            this.circFill = new System.Windows.Forms.Button();
            this.flechaLeft = new System.Windows.Forms.Button();
            this.flechaRight = new System.Windows.Forms.Button();
            this.flechaBoth = new System.Windows.Forms.Button();
            this.flechaNone = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
<<<<<<< HEAD
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(950, 30);
=======
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(712, 24);
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip2";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonNuevo,
            this.botonAbrir,
            this.guardarToolStripMenuItem,
            this.botonGuardar});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // botonAbrir
            // 
<<<<<<< HEAD
            this.botonAbrir.Name = "botonAbrir";
            this.botonAbrir.Size = new System.Drawing.Size(224, 26);
            this.botonAbrir.Text = "Abrir";
            this.botonAbrir.Click += new System.EventHandler(this.botonAbrir_Click);
=======
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoToolStripMenuItem.Text = "Abrir";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            // 
            // botonGuardar
            // 
<<<<<<< HEAD
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(224, 26);
            this.botonGuardar.Text = "Guardar como";
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
=======
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarToolStripMenuItem.Text = "Guardar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            // 
            // botonNuevo
            // 
<<<<<<< HEAD
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(224, 26);
            this.botonNuevo.Text = "Nuevo";
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
=======
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Nuevo";
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< HEAD
            this.splitContainer.Location = new System.Drawing.Point(0, 30);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.color);
            this.splitContainer.Panel1.Controls.Add(this.botones);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.splitContainer.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Draw);
            this.splitContainer.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
<<<<<<< HEAD
            this.splitContainer.Size = new System.Drawing.Size(950, 596);
            this.splitContainer.SplitterDistance = 166;
=======
            this.splitContainer.Size = new System.Drawing.Size(712, 485);
            this.splitContainer.SplitterDistance = 124;
            this.splitContainer.SplitterWidth = 3;
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            this.splitContainer.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(34, 384);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(26, 451);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 436);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tamaño de línea:";
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(22, 412);
            this.color.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(81, 21);
            this.color.TabIndex = 1;
            this.color.Text = "Elegir color";
            this.color.UseVisualStyleBackColor = true;
            this.color.Click += new System.EventHandler(this.ElegirColor);
            // 
            // botones
            // 
            this.botones.Controls.Add(this.rect);
            this.botones.Controls.Add(this.rectFill);
            this.botones.Controls.Add(this.circle);
            this.botones.Controls.Add(this.circFill);
            this.botones.Controls.Add(this.flechaLeft);
            this.botones.Controls.Add(this.flechaRight);
            this.botones.Controls.Add(this.flechaBoth);
            this.botones.Controls.Add(this.flechaNone);
            this.botones.Location = new System.Drawing.Point(10, 2);
            this.botones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(106, 377);
            this.botones.TabIndex = 1;
            // 
            // rect
            // 
            this.rect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rect.Location = new System.Drawing.Point(2, 2);
            this.rect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rect.Name = "rect";
            this.rect.Size = new System.Drawing.Size(100, 42);
            this.rect.TabIndex = 4;
            this.rect.Text = "Rectángulo";
            this.rect.UseVisualStyleBackColor = true;
            // 
            // rectFill
            // 
            this.rectFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectFill.Location = new System.Drawing.Point(2, 48);
            this.rectFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rectFill.Name = "rectFill";
            this.rectFill.Size = new System.Drawing.Size(100, 42);
            this.rectFill.TabIndex = 5;
            this.rectFill.Text = "Rectángulo relleno";
            this.rectFill.UseVisualStyleBackColor = true;
            // 
            // circle
            // 
            this.circle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circle.Location = new System.Drawing.Point(2, 94);
            this.circle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(100, 42);
            this.circle.TabIndex = 6;
            this.circle.Text = "Elipse";
            this.circle.UseVisualStyleBackColor = true;
            // 
            // circFill
            // 
            this.circFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circFill.Location = new System.Drawing.Point(2, 140);
            this.circFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.circFill.Name = "circFill";
            this.circFill.Size = new System.Drawing.Size(100, 42);
            this.circFill.TabIndex = 7;
            this.circFill.Text = "Elipse rellena";
            this.circFill.UseVisualStyleBackColor = true;
            // 
            // flechaLeft
            // 
            this.flechaLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaLeft.Location = new System.Drawing.Point(2, 186);
            this.flechaLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flechaLeft.Name = "flechaLeft";
            this.flechaLeft.Size = new System.Drawing.Size(100, 42);
            this.flechaLeft.TabIndex = 8;
            this.flechaLeft.Text = "<--";
            this.flechaLeft.UseVisualStyleBackColor = true;
            // 
            // flechaRight
            // 
            this.flechaRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaRight.Location = new System.Drawing.Point(2, 232);
            this.flechaRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flechaRight.Name = "flechaRight";
            this.flechaRight.Size = new System.Drawing.Size(100, 42);
            this.flechaRight.TabIndex = 9;
            this.flechaRight.Text = "-->";
            this.flechaRight.UseVisualStyleBackColor = true;
            // 
            // flechaBoth
            // 
            this.flechaBoth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaBoth.Location = new System.Drawing.Point(2, 278);
            this.flechaBoth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flechaBoth.Name = "flechaBoth";
            this.flechaBoth.Size = new System.Drawing.Size(100, 42);
            this.flechaBoth.TabIndex = 10;
            this.flechaBoth.Text = "<->";
            this.flechaBoth.UseVisualStyleBackColor = true;
            // 
            // flechaNone
            // 
            this.flechaNone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaNone.Location = new System.Drawing.Point(2, 324);
            this.flechaNone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flechaNone.Name = "flechaNone";
            this.flechaNone.Size = new System.Drawing.Size(100, 42);
            this.flechaNone.TabIndex = 11;
            this.flechaNone.Text = "---";
            this.flechaNone.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
<<<<<<< HEAD
            this.pictureBox1.Size = new System.Drawing.Size(776, 596);
=======
            this.pictureBox1.Size = new System.Drawing.Size(582, 485);
>>>>>>> 9ab394dc3d74c1e46b97654e728f6f6c5f54246c
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Draw);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 509);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Diagramador.NET";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.botones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botonAbrir;
        private System.Windows.Forms.ToolStripMenuItem botonGuardar;
        private System.Windows.Forms.ToolStripMenuItem botonNuevo;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel botones;
        private System.Windows.Forms.Button rect;
        private System.Windows.Forms.Button rectFill;
        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Button circFill;
        private System.Windows.Forms.Button flechaLeft;
        private System.Windows.Forms.Button flechaRight;
        private System.Windows.Forms.Button flechaBoth;
        private System.Windows.Forms.Button flechaNone;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button color;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

