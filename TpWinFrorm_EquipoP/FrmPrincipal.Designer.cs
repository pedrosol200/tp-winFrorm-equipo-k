namespace TpWinFrorm_EquipoP
{
    partial class FrmPrincipal
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
            this.btArticulos = new System.Windows.Forms.Button();
            this.btMarcas = new System.Windows.Forms.Button();
            this.btCategorias = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btArticulos
            // 
            this.btArticulos.Location = new System.Drawing.Point(29, 100);
            this.btArticulos.Name = "btArticulos";
            this.btArticulos.Size = new System.Drawing.Size(93, 41);
            this.btArticulos.TabIndex = 0;
            this.btArticulos.Text = "Articulos";
            this.btArticulos.UseVisualStyleBackColor = true;
            this.btArticulos.Click += new System.EventHandler(this.btArticulos_Click);
            // 
            // btMarcas
            // 
            this.btMarcas.Location = new System.Drawing.Point(168, 100);
            this.btMarcas.Name = "btMarcas";
            this.btMarcas.Size = new System.Drawing.Size(88, 41);
            this.btMarcas.TabIndex = 1;
            this.btMarcas.Text = "Marcas";
            this.btMarcas.UseVisualStyleBackColor = true;
            this.btMarcas.Click += new System.EventHandler(this.btMarcas_Click);
            // 
            // btCategorias
            // 
            this.btCategorias.Location = new System.Drawing.Point(297, 100);
            this.btCategorias.Name = "btCategorias";
            this.btCategorias.Size = new System.Drawing.Size(93, 41);
            this.btCategorias.TabIndex = 2;
            this.btCategorias.Text = "Categorias";
            this.btCategorias.UseVisualStyleBackColor = true;
            this.btCategorias.Click += new System.EventHandler(this.btCategorias_Click);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(120, 159);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(178, 57);
            this.btSalir.TabIndex = 3;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ELIJA 1 OPCION:";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btCategorias);
            this.Controls.Add(this.btMarcas);
            this.Controls.Add(this.btArticulos);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Catálogo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btArticulos;
        private System.Windows.Forms.Button btMarcas;
        private System.Windows.Forms.Button btCategorias;
        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Label label1;
    }
}

