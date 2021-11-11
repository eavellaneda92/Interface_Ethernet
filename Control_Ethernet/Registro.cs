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

namespace Control_Ethernet
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            //Leer la direcciones IP
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
            cmb_ip.Items.Add(IP1);
            cmb_ip.Items.Add(IP2);
            cmb_ip.Items.Add(IP3);
            cmb_ip.Items.Add(IP4);
            cmb_ip.Items.Add(IP5);
            cmb_ip.Items.Add(IP6);
        }
    }
}
