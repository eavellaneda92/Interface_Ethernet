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
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;

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

        private void SendGETRequest(string url,int comando)
        {
            string control = "";
            string buffer = "";
            switch (comando)
            {
                case 1: control = "/LED1=ON";break;
                case 2: control = "/LED1=OFF"; break;
                case 3: control = "/LED2=ON"; break;
                case 4: control = "/LED2=OFF"; break;
            }
            WebClient wc = new WebClient();
            try
            {
               buffer  = wc.DownloadString("http://" + url + control);
            }
            catch
            {
                MessageBox.Show(url + " INACCESIBLE");
            }
            
        }

        private void btn1on_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip1.Text,1);
        }

        void consulta_estados() //Consulta de estados de salidas de puertos
        {
            string Buffer=""; 
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) { Buffer = wc.DownloadString("http://"+txt_ip1.Text); }
                if (Buffer.IndexOf("ON1") >= 0) p11.BackColor = Color.Green;
                else p11.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p21.BackColor = Color.Green;
                else p21.BackColor = Color.Red;
            }
            catch(Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip1.Text + " NO ACCESIBLE");
            }
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) Buffer = wc.DownloadString(txt_ip2.Text);
                if (Buffer.IndexOf("ON") >= 0) p12.BackColor = Color.Green;
                else p12.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p22.BackColor = Color.Green;
                else p22.BackColor = Color.Red;
            }
            catch (Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip2.Text + " NO ACCESIBLE");
            }
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) Buffer = wc.DownloadString(txt_ip3.Text);
                if (Buffer.IndexOf("ON") >= 0) p13.BackColor = Color.Green;
                else p13.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p23.BackColor = Color.Green;
                else p23.BackColor = Color.Red;
            }
            catch (Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip3.Text + " NO ACCESIBLE");
            }
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) Buffer = wc.DownloadString(txt_ip4.Text);
                if (Buffer.IndexOf("ON") >= 0) p14.BackColor = Color.Green;
                else p14.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p24.BackColor = Color.Green;
                else p24.BackColor = Color.Red;
            }
            catch (Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip4.Text + " NO ACCESIBLE");
            }
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) Buffer = wc.DownloadString(txt_ip5.Text);
                if (Buffer.IndexOf("ON") >= 0) p15.BackColor = Color.Green;
                else p15.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p25.BackColor = Color.Green;
                else p25.BackColor = Color.Red;
            }
            catch (Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip5.Text + " NO ACCESIBLE");
            }
            try
            {
                WebClient wc = new WebClient();
                for (int i = 0; i <= 10; i++) Buffer = wc.DownloadString(txt_ip6.Text);
                if (Buffer.IndexOf("ON") >= 0) p16.BackColor = Color.Green;
                else p16.BackColor = Color.Red;
                if (Buffer.IndexOf("ON2") >= 0) p26.BackColor = Color.Green;
                else p26.BackColor = Color.Red;
            }
            catch (Exception E)
            {
                string e = "";
                e = E.ToString();
                MessageBox.Show(txt_ip6.Text + " NO ACCESIBLE");
            }
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

        private void off11_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip1.Text, 2);
        }

        private void on12_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip2.Text, 1);
        }

        private void off12_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip2.Text, 2);
        }

        private void on13_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip3.Text, 1);
        }

        private void off13_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip3.Text, 2);
        }

        private void on14_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip4.Text, 1);
        }

        private void off14_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip4.Text, 2);
        }

        private void on15_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip5.Text, 1);
        }

        private void off15_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip5.Text, 2);
        }

        private void on16_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip6.Text, 1);
        }

        private void off16_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip6.Text, 2);
        }

        private void on21_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip1.Text, 3);
        }

        private void off21_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip1.Text, 4);
        }

        private void on22_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip2.Text, 3);
        }

        private void off22_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip2.Text, 4);
        }

        private void on23_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip3.Text, 3);
        }

        private void off23_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip3.Text, 4);
        }

        private void on24_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip4.Text, 3);
        }

        private void off24_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip4.Text, 4);
        }

        private void on25_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip5.Text, 3);
        }

        private void off25_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip5.Text, 4);
        }

        private void on26_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip6.Text, 3);
        }

        private void off26_Click(object sender, EventArgs e)
        {
            SendGETRequest(txt_ip6.Text, 4);
        }

        Computer mycomputer = new Computer();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);

        private void mueve(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
