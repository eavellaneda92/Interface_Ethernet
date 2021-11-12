using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Control_Ethernet
{
    public partial class Operacion : Form
    {
        public Operacion()
        {
            InitializeComponent();
        }

        private void Operacion_Load(object sender, EventArgs e)
        {
            TextReader leer = new StreamReader("C:\\Control\\IP1.txt");
            txt_ip1.Text = leer.ReadLine();
            leer.Close();
            leer = new StreamReader("C:\\Control\\IP2.txt");
            txt_ip2.Text = leer.ReadLine();
            leer.Close();
            leer = new StreamReader("C:\\Control\\IP3.txt");
            txt_ip3.Text = leer.ReadLine();
            leer.Close();
            leer = new StreamReader("C:\\Control\\IP4.txt");
            txt_ip4.Text = leer.ReadLine();
            leer.Close();
            leer = new StreamReader("C:\\Control\\IP5.txt");
            txt_ip5.Text = leer.ReadLine();
            leer.Close();
            leer = new StreamReader("C:\\Control\\IP6.txt");
            txt_ip6.Text = leer.ReadLine();
            leer.Close();
            consulta_estados();

            
        }

        private void SendGETRequest(string url)
        {
            WebClient wc = new WebClient();
            textBox1.Text = wc.DownloadString(url);
        }

        private void btn1on_Click(object sender, EventArgs e)
        {
            
        }

        void consulta_estados() //Consulta de estados de salidas de puertos
        {

        }

        private void txt_ip2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Regitra el login
            string path = "C:\\Control\\Registro_log.txt";

            TextReader leer = new StreamReader("C:\\Control\\Login.txt");
            string user = leer.ReadLine();
            string fecha_in = leer.ReadLine();
            string fecha_out = DateTime.Now.ToString();
            leer.Close();
            string ipx = "";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipx = ip.ToString();
                }
            }

            StreamWriter outfile = new StreamWriter(path, append: true);
            outfile.WriteLineAsync(user);
            outfile.WriteLineAsync(ipx);
            outfile.WriteLineAsync(fecha_in);
            outfile.WriteLineAsync(fecha_out);
            outfile.Close();

            //y cierra sesion
            Application.Exit();
        }
    }
}
