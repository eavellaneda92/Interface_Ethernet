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
using System.Net;
using System.Net.Sockets;
using System.IO.Compression;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;

namespace Control_Ethernet
{
    public partial class Control : Form
    {
        int valor;
        string texto = "";
        public Control()
        {
            InitializeComponent();
        }

        void inicia_datos()
        {
            //Crear carpeta 
            string FolderPath = @"C:\\Control";
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                //IP's por defecto
                StreamWriter outfile = new StreamWriter("C:\\Control\\IP1.txt");
                outfile.WriteLine("192.168.1.21");
                outfile.Close();
                outfile = new StreamWriter("C:\\Control\\IP2.txt");
                outfile.WriteLine("192.168.1.22");
                outfile.Close();
                outfile = new StreamWriter("C:\\Control\\IP3.txt");
                outfile.WriteLine("192.168.1.23");
                outfile.Close();
                outfile = new StreamWriter("C:\\Control\\IP4.txt");
                outfile.WriteLine("192.168.1.24");
                outfile.Close();
                outfile = new StreamWriter("C:\\Control\\IP5.txt");
                outfile.WriteLine("192.168.1.25");
                outfile.Close();
                outfile = new StreamWriter("C:\\Control\\IP6.txt");
                outfile.WriteLine("192.168.1.26");
                outfile.Close();
                lbl_ip1.Text = "192.168.1.21";
                lbl_ip2.Text = "192.168.1.22";
                lbl_ip3.Text = "192.168.1.23";
                lbl_ip4.Text = "192.168.1.24";
                lbl_ip5.Text = "192.168.1.25";
                lbl_ip6.Text = "192.168.1.26";
            }
            else
            {
                //Leer la direccion
                TextReader leer = new StreamReader("C:\\Control\\IP1.txt");
                string IP1 = leer.ReadLine();
                leer.Close();
                leer = new StreamReader("C:\\Control\\IP2.txt");
                string IP2 = leer.ReadLine();
                leer.Close();
                leer = new StreamReader("C:\\Control\\IP3.txt");
                string IP3 = leer.ReadLine();
                leer.Close();
                leer = new StreamReader("C:\\Control\\IP4.txt");
                string IP4 = leer.ReadLine();
                leer.Close();
                leer = new StreamReader("C:\\Control\\IP5.txt");
                string IP5 = leer.ReadLine();
                leer.Close();
                leer = new StreamReader("C:\\Control\\IP6.txt");
                string IP6 = leer.ReadLine();
                leer.Close();
                lbl_ip1.Text = IP1;
                lbl_ip2.Text = IP2;
                lbl_ip3.Text = IP3;
                lbl_ip4.Text = IP4;
                lbl_ip5.Text = IP5;
                lbl_ip6.Text = IP6;
            }
        }

        private void Control_Load(object sender, EventArgs e)
        {
            //Lectura de IP
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                   lbl_ip.Text = ip.ToString();
                }
            }
            inicia_datos();
            txt_ip.Text = "";
        }

        private void EDIT1_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 1:";
            texto = "C:\\Control\\IP1.txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = texto;
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete(path);
                StreamWriter outfile = new StreamWriter(texto);
                outfile.WriteLine(txt_ip.Text);
                outfile.Close();
                txt_ip.Text = "";
                lbl_sms.Visible = false;
                txt_ip.Visible = false;
                btn_ok.Visible = false;
                inicia_datos();
                valor = 0;
            }
        }

        private void EDIT2_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 2:";
            texto = "C:\\Control\\IP2.txt";
        }

        private void EDIT3_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 3:";
            texto = "C:\\Control\\IP3.txt";
        }

        private void EDIT4_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 4:";
            texto = "C:\\Control\\IP4.txt";
        }

        private void EDIT5_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 5:";
            texto = "C:\\Control\\IP5.txt";
        }

        private void EDIT6_Click(object sender, EventArgs e)
        {
            lbl_sms.Visible = true;
            txt_ip.Visible = true;
            btn_ok.Visible = true;
            BTN_CERRAR.Visible = true;
            lbl_sms.Text = "Ingrese IP 6:";
            texto = "C:\\Control\\IP6.txt";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txt_ip.Text = "";
            lbl_sms.Visible = false;
            txt_ip.Visible = false;
            btn_ok.Visible = false;
            BTN_CERRAR.Visible = false;
            inicia_datos();
            valor = 0;
        }

        private void REGISTRO_Click(object sender, EventArgs e)
        {
            Registro ventana = new Registro();
            ventana.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string direccion = @"C:\Control";
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "tipo archivo (.zip)|*.zip";
            try
            {
                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    string txt = guardar.FileName;
                    ZipFile.CreateFromDirectory(direccion,txt);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR AL GUARDAR ARCHIVO");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operacion ventana = new Operacion();
            ventana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registro_Personal VENTANA = new Registro_Personal();
            VENTANA.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminar_user ventana = new Eliminar_user();
            ventana.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lista_usuarios ventana = new Lista_usuarios();
            ventana.Show();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
