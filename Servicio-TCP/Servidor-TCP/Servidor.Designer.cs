namespace Servidor_TCP
{
    partial class FrmServidorTcp
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.lsbClientes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(21, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(94, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Mi dirección IP es:";
            // 
            // lsbClientes
            // 
            this.lsbClientes.FormattingEnabled = true;
            this.lsbClientes.Location = new System.Drawing.Point(24, 35);
            this.lsbClientes.Name = "lsbClientes";
            this.lsbClientes.Size = new System.Drawing.Size(204, 108);
            this.lsbClientes.TabIndex = 1;
            // 
            // FrmServidorTcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 157);
            this.Controls.Add(this.lsbClientes);
            this.Controls.Add(this.lblInfo);
            this.Name = "FrmServidorTcp";
            this.Text = "Servidor - TCP";
            this.Load += new System.EventHandler(this.FrmServidorTcp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lsbClientes;
    }
}

