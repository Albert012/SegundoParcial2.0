namespace SegundoParcial.UI.Registros
{
    partial class rArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ArticuloId_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Costo_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Precio_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Ganancia_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Inventario_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Descripcion_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.ValidarErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloId_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Costo_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Precio_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ganancia_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inventario_numericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidarErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Articulo Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inventario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "% Ganacia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Costo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Descripcion:";
            // 
            // ArticuloId_numericUpDown
            // 
            this.ArticuloId_numericUpDown.Location = new System.Drawing.Point(115, 26);
            this.ArticuloId_numericUpDown.Name = "ArticuloId_numericUpDown";
            this.ArticuloId_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ArticuloId_numericUpDown.TabIndex = 6;
            // 
            // Costo_numericUpDown
            // 
            this.Costo_numericUpDown.Location = new System.Drawing.Point(115, 92);
            this.Costo_numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Costo_numericUpDown.Name = "Costo_numericUpDown";
            this.Costo_numericUpDown.Size = new System.Drawing.Size(106, 20);
            this.Costo_numericUpDown.TabIndex = 1;
            this.Costo_numericUpDown.ValueChanged += new System.EventHandler(this.Costo_numericUpDown_ValueChanged);
            // 
            // Precio_numericUpDown
            // 
            this.Precio_numericUpDown.Location = new System.Drawing.Point(115, 131);
            this.Precio_numericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Precio_numericUpDown.Name = "Precio_numericUpDown";
            this.Precio_numericUpDown.Size = new System.Drawing.Size(106, 20);
            this.Precio_numericUpDown.TabIndex = 2;
            this.Precio_numericUpDown.ValueChanged += new System.EventHandler(this.Precio_numericUpDown_ValueChanged);
            // 
            // Ganancia_numericUpDown
            // 
            this.Ganancia_numericUpDown.Location = new System.Drawing.Point(326, 89);
            this.Ganancia_numericUpDown.Name = "Ganancia_numericUpDown";
            this.Ganancia_numericUpDown.Size = new System.Drawing.Size(96, 20);
            this.Ganancia_numericUpDown.TabIndex = 3;
            this.Ganancia_numericUpDown.ValueChanged += new System.EventHandler(this.Ganancia_numericUpDown_ValueChanged);
            // 
            // Inventario_numericUpDown
            // 
            this.Inventario_numericUpDown.Enabled = false;
            this.Inventario_numericUpDown.Location = new System.Drawing.Point(326, 131);
            this.Inventario_numericUpDown.Name = "Inventario_numericUpDown";
            this.Inventario_numericUpDown.Size = new System.Drawing.Size(96, 20);
            this.Inventario_numericUpDown.TabIndex = 10;
            // 
            // Descripcion_textBox
            // 
            this.Descripcion_textBox.Location = new System.Drawing.Point(115, 58);
            this.Descripcion_textBox.Name = "Descripcion_textBox";
            this.Descripcion_textBox.Size = new System.Drawing.Size(307, 20);
            this.Descripcion_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EliminarButton);
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.NuevoButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(116, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 87);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // EliminarButton
            // 
            this.EliminarButton.Image = global::SegundoParcial.Properties.Resources.Delete;
            this.EliminarButton.Location = new System.Drawing.Point(136, 21);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(53, 48);
            this.EliminarButton.TabIndex = 2;
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Image = global::SegundoParcial.Properties.Resources.Save;
            this.GuardarButton.Location = new System.Drawing.Point(70, 21);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(56, 48);
            this.GuardarButton.TabIndex = 0;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Image = global::SegundoParcial.Properties.Resources.new2;
            this.NuevoButton.Location = new System.Drawing.Point(13, 21);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(49, 48);
            this.NuevoButton.TabIndex = 1;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // ValidarErrorProvider
            // 
            this.ValidarErrorProvider.ContainerControl = this;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SegundoParcial.Properties.Resources.buscar;
            this.BuscarButton.Location = new System.Drawing.Point(244, 17);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(39, 31);
            this.BuscarButton.TabIndex = 13;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // rArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 322);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Descripcion_textBox);
            this.Controls.Add(this.Inventario_numericUpDown);
            this.Controls.Add(this.Ganancia_numericUpDown);
            this.Controls.Add(this.Precio_numericUpDown);
            this.Controls.Add(this.Costo_numericUpDown);
            this.Controls.Add(this.ArticuloId_numericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "rArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.ArticuloId_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Costo_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Precio_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ganancia_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inventario_numericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValidarErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ArticuloId_numericUpDown;
        private System.Windows.Forms.NumericUpDown Costo_numericUpDown;
        private System.Windows.Forms.NumericUpDown Precio_numericUpDown;
        private System.Windows.Forms.NumericUpDown Ganancia_numericUpDown;
        private System.Windows.Forms.NumericUpDown Inventario_numericUpDown;
        private System.Windows.Forms.TextBox Descripcion_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.ErrorProvider ValidarErrorProvider;
    }
}