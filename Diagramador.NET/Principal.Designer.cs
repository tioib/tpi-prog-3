namespace Diagramador.NET
{
    partial class Principal
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
            this.botonNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.botonAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botonGuardar = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(949, 28);
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
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // botonNuevo
            // 
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(187, 26);
            this.botonNuevo.Text = "Nuevo";
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // botonAbrir
            // 
            this.botonAbrir.Name = "botonAbrir";
            this.botonAbrir.Size = new System.Drawing.Size(187, 26);
            this.botonAbrir.Text = "Abrir";
            this.botonAbrir.Click += new System.EventHandler(this.botonAbrir_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(187, 26);
            this.botonGuardar.Text = "Guardar como";
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
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
            this.splitContainer.Size = new System.Drawing.Size(949, 598);
            this.splitContainer.SplitterDistance = 165;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(45, 473);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 31);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(35, 555);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tamaño de línea:";
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(29, 507);
            this.color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(108, 26);
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
            this.botones.Location = new System.Drawing.Point(13, 2);
            this.botones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(141, 464);
            this.botones.TabIndex = 1;
            // 
            // rect
            // 
            this.rect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rect.Location = new System.Drawing.Point(3, 2);
            this.rect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rect.Name = "rect";
            this.rect.Size = new System.Drawing.Size(133, 52);
            this.rect.TabIndex = 4;
            this.rect.Text = "Rectángulo";
            this.rect.UseVisualStyleBackColor = true;
            // 
            // rectFill
            // 
            this.rectFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectFill.Location = new System.Drawing.Point(3, 58);
            this.rectFill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rectFill.Name = "rectFill";
            this.rectFill.Size = new System.Drawing.Size(133, 52);
            this.rectFill.TabIndex = 5;
            this.rectFill.Text = "Rectángulo relleno";
            this.rectFill.UseVisualStyleBackColor = true;
            // 
            // circle
            // 
            this.circle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circle.Location = new System.Drawing.Point(3, 114);
            this.circle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(133, 52);
            this.circle.TabIndex = 6;
            this.circle.Text = "Elipse";
            this.circle.UseVisualStyleBackColor = true;
            // 
            // circFill
            // 
            this.circFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circFill.Location = new System.Drawing.Point(3, 170);
            this.circFill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circFill.Name = "circFill";
            this.circFill.Size = new System.Drawing.Size(133, 52);
            this.circFill.TabIndex = 7;
            this.circFill.Text = "Elipse rellena";
            this.circFill.UseVisualStyleBackColor = true;
            // 
            // flechaLeft
            // 
            this.flechaLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaLeft.Location = new System.Drawing.Point(3, 226);
            this.flechaLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaLeft.Name = "flechaLeft";
            this.flechaLeft.Size = new System.Drawing.Size(133, 52);
            this.flechaLeft.TabIndex = 8;
            this.flechaLeft.Text = "Texto";
            this.flechaLeft.UseVisualStyleBackColor = true;
            // 
            // flechaRight
            // 
            this.flechaRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaRight.Location = new System.Drawing.Point(3, 282);
            this.flechaRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaRight.Name = "flechaRight";
            this.flechaRight.Size = new System.Drawing.Size(133, 52);
            this.flechaRight.TabIndex = 9;
            this.flechaRight.Text = "-->";
            this.flechaRight.UseVisualStyleBackColor = true;
            // 
            // flechaBoth
            // 
            this.flechaBoth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaBoth.Location = new System.Drawing.Point(3, 338);
            this.flechaBoth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaBoth.Name = "flechaBoth";
            this.flechaBoth.Size = new System.Drawing.Size(133, 52);
            this.flechaBoth.TabIndex = 10;
            this.flechaBoth.Text = "<->";
            this.flechaBoth.UseVisualStyleBackColor = true;
            // 
            // flechaNone
            // 
            this.flechaNone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flechaNone.Location = new System.Drawing.Point(3, 394);
            this.flechaNone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaNone.Name = "flechaNone";
            this.flechaNone.Size = new System.Drawing.Size(133, 52);
            this.flechaNone.TabIndex = 11;
            this.flechaNone.Text = "---";
            this.flechaNone.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 598);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Change);
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
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 626);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
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

