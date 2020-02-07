using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Cliente_TCP
{
    public partial class FrmClienteTcp : Form
    {
        public FrmClienteTcp()
        {
            InitializeComponent();
        }

        private void FrmClienteTcp_Load(object sender, EventArgs e)
        {

        }

        private void btnExplorar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                txtNombreArchivo.Text = dialogo.FileName;
                btnEnviar.Enabled = true;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Stream flujoArchivo = File.OpenRead(txtNombreArchivo.Text);

            byte[] bufferEnvio = new byte[flujoArchivo.Length];
            flujoArchivo.Read(bufferEnvio, 0, (int)flujoArchivo.Length);

            TcpClient cliente = new TcpClient(txtServidor.Text, 8080);
            NetworkStream flujoRed = cliente.GetStream();
            flujoRed.Write(bufferEnvio, 0, bufferEnvio.GetLength(0));
            flujoRed.Close();
        }
    }
}
