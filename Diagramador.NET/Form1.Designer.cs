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
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(950, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip2";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.nuevoToolStripMenuItem.Text = "Abrir";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.cargarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.guardarToolStripMenuItem.Text = "Nuevo";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer.Size = new System.Drawing.Size(950, 598);
            this.splitContainer.SplitterDistance = 166;
            this.splitContainer.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(34, 555);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.ChangeSize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tamaño de línea:";
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(29, 507);
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
            this.botones.Location = new System.Drawing.Point(13, 3);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(141, 464);
            this.botones.TabIndex = 1;
            // 
            // rect
            // 
            this.rect.Dock = System.Windows.Forms.DockStyle.Top;
            this.rect.Location = new System.Drawing.Point(3, 3);
            this.rect.Name = "rect";
            this.rect.Size = new System.Drawing.Size(134, 52);
            this.rect.TabIndex = 4;
            this.rect.Text = "Rectángulo";
            this.rect.UseVisualStyleBackColor = true;
            // 
            // rectFill
            // 
            this.rectFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.rectFill.Location = new System.Drawing.Point(3, 61);
            this.rectFill.Name = "rectFill";
            this.rectFill.Size = new System.Drawing.Size(134, 52);
            this.rectFill.TabIndex = 5;
            this.rectFill.Text = "Rectángulo relleno";
            this.rectFill.UseVisualStyleBackColor = true;
            // 
            // circle
            // 
            this.circle.Dock = System.Windows.Forms.DockStyle.Top;
            this.circle.Location = new System.Drawing.Point(3, 119);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(134, 52);
            this.circle.TabIndex = 6;
            this.circle.Text = "Elipse";
            this.circle.UseVisualStyleBackColor = true;
            // 
            // circFill
            // 
            this.circFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.circFill.Location = new System.Drawing.Point(3, 177);
            this.circFill.Name = "circFill";
            this.circFill.Size = new System.Drawing.Size(134, 52);
            this.circFill.TabIndex = 7;
            this.circFill.Text = "Elipse rellena";
            this.circFill.UseVisualStyleBackColor = true;
            // 
            // flechaLeft
            // 
            this.flechaLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.flechaLeft.Location = new System.Drawing.Point(3, 235);
            this.flechaLeft.Name = "flechaLeft";
            this.flechaLeft.Size = new System.Drawing.Size(134, 52);
            this.flechaLeft.TabIndex = 8;
            this.flechaLeft.Text = "<--";
            this.flechaLeft.UseVisualStyleBackColor = true;
            // 
            // flechaRight
            // 
            this.flechaRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.flechaRight.Location = new System.Drawing.Point(3, 293);
            this.flechaRight.Name = "flechaRight";
            this.flechaRight.Size = new System.Drawing.Size(134, 52);
            this.flechaRight.TabIndex = 9;
            this.flechaRight.Text = "-->";
            this.flechaRight.UseVisualStyleBackColor = true;
            // 
            // flechaBoth
            // 
            this.flechaBoth.Dock = System.Windows.Forms.DockStyle.Top;
            this.flechaBoth.Location = new System.Drawing.Point(3, 351);
            this.flechaBoth.Name = "flechaBoth";
            this.flechaBoth.Size = new System.Drawing.Size(134, 52);
            this.flechaBoth.TabIndex = 10;
            this.flechaBoth.Text = "<->";
            this.flechaBoth.UseVisualStyleBackColor = true;
            // 
            // flechaNone
            // 
            this.flechaNone.Dock = System.Windows.Forms.DockStyle.Top;
            this.flechaNone.Location = new System.Drawing.Point(3, 409);
            this.flechaNone.Name = "flechaNone";
            this.flechaNone.Size = new System.Drawing.Size(134, 52);
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
            this.pictureBox1.Size = new System.Drawing.Size(776, 598);
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
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(46, 473);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 31);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 626);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.botones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
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
    }
}

