namespace WindowsFormsApp1
{
    partial class Mandelbrot
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.TmidX = new System.Windows.Forms.TextBox();
            this.Tscale = new System.Windows.Forms.TextBox();
            this.Tmaxgetal = new System.Windows.Forms.TextBox();
            this.TmidY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TmidX
            // 
            this.TmidX.Location = new System.Drawing.Point(106, 29);
            this.TmidX.Name = "TmidX";
            this.TmidX.Size = new System.Drawing.Size(113, 22);
            this.TmidX.TabIndex = 1;
            this.TmidX.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Tscale
            // 
            this.Tscale.Location = new System.Drawing.Point(297, 29);
            this.Tscale.Name = "Tscale";
            this.Tscale.Size = new System.Drawing.Size(135, 22);
            this.Tscale.TabIndex = 2;
            this.Tscale.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Tmaxgetal
            // 
            this.Tmaxgetal.Location = new System.Drawing.Point(297, 71);
            this.Tmaxgetal.Name = "Tmaxgetal";
            this.Tmaxgetal.Size = new System.Drawing.Size(52, 22);
            this.Tmaxgetal.TabIndex = 3;
            // 
            // TmidY
            // 
            this.TmidY.Location = new System.Drawing.Point(106, 71);
            this.TmidY.Name = "TmidY";
            this.TmidY.Size = new System.Drawing.Size(113, 22);
            this.TmidY.TabIndex = 4;
            this.TmidY.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Midden X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Midden Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Schaal:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(36, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 500);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Standaard",
            "Kekke kleur",
            "Nederlandse Vlag",
            "Regenboog"});
            this.listBox1.Location = new System.Drawing.Point(450, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 68);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 647);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TmidY);
            this.Controls.Add(this.Tmaxgetal);
            this.Controls.Add(this.Tscale);
            this.Controls.Add(this.TmidX);
            this.Controls.Add(this.button1);
            this.Name = "Mandelbrot";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TmidX;
        private System.Windows.Forms.TextBox Tscale;
        private System.Windows.Forms.TextBox Tmaxgetal;
        private System.Windows.Forms.TextBox TmidY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

