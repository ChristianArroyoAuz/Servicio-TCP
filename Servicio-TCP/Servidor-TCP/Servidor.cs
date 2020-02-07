using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Servidor_TCP
{
    public partial class FrmServidorTcp : Form
    {
        private ArrayList clientes;
        private IPAddress[] informacionIP;
        private IPAddress ipReal;

        private delegate void ActualizarListBox(string texto);

        public FrmServidorTcp()
        {
            InitializeComponent();
        }

        private void FrmServidorTcp_Load(object sender, EventArgs e)
        {
            informacionIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in informacionIP)
            {
                if (ip.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                    if (!ip.Equals("127.0.0.1"))
                        ipReal = ip;
            }

            lblInfo.Text = "Mi dirección IP es: " + ipReal.ToString();

            clientes = new ArrayList();

            Thread hiloEscucha = new Thread(new ThreadStart(TareaEscucha));
            hiloEscucha.Start();
        }

        public void TareaEscucha()
        {
            TcpListener socketEscucha = new TcpListener(ipReal, 8080);
            socketEscucha.Start();

            while (true)
            {
                Socket socketCliente = socketEscucha.AcceptSocket();
                if (socketCliente.Connected)
                {
                    lsbClientes.Invoke(new ActualizarListBox(ActualizarInformacionEnListBox), new object[] { socketCliente.RemoteEndPoint.ToString() + " conectado..." });

                    lock (this)
                    {
                        clientes.Add(socketCliente);
                    }

                    ThreadStart iniciadorHiloCliente = new ThreadStart(TareaCliente);
                    Thread hiloCliente = new Thread(iniciadorHiloCliente);
                    hiloCliente.Start();
                }
            }
        }

        public void TareaCliente()
        {
            Socket cliente = (Socket)clientes[clientes.Count - 1];
            NetworkStream flujoRed = new NetworkStream(cliente);
            
            int indicadorLectura = 0;
            int tamanioBloque = 1024;
            Byte[] datosRx = new Byte[tamanioBloque];
            lock(this)
            {
                Stream flujoArchivo = File.OpenWrite(@"C:\Users\Programador\Desktop\Chat-TCP\archivo.txt");
                while(true)
                {
                    indicadorLectura = flujoRed.Read(datosRx, 0, tamanioBloque);
                    flujoArchivo.Write(datosRx, 0, indicadorLectura);
                    if (indicadorLectura == 0) 
                        break;
                }
                flujoArchivo.Close();
            }
            
            lsbClientes.Invoke(new ActualizarListBox(ActualizarInformacionEnListBox), new  object[] { "Archivo guardado exitosamente..." });

            cliente = null;
        }

        public void ActualizarInformacionEnListBox(string texto)
        {
            lsbClientes.Items.Add(texto);
        }
    }
}
