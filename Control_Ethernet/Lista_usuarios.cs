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
    public partial class Lista_usuarios : Form
    {
        public Lista_usuarios()
        {
            InitializeComponent();
        }

        private void Lista_usuarios_Load(object sender, EventArgs e)
        {
            //Busqueda de usuarios
            DirectoryInfo di = new DirectoryInfo("C:\\Control\\USUARIOS\\");
            DirectoryInfo[] diArr = di.GetDirectories();
            dataGridView1.Rows.Add(1);
            int contador = 0;
            foreach (DirectoryInfo dri in diArr)
            {
                string user = dri.Name.ToString();
                TextReader leer = new StreamReader("C:\\Control\\USUARIOS\\" + user + "\\Datos.txt");
                string name = leer.ReadLine();
                string pass = leer.ReadLine();
                string empresa = leer.ReadLine();
                string email = leer.ReadLine();
                string modo = leer.ReadLine();
                leer.Close();
                dataGridView1.Rows[contador].Cells[0].Value = user;
                dataGridView1.Rows[contador].Cells[1].Value = name;
                dataGridView1.Rows[contador].Cells[2].Value = empresa;
                dataGridView1.Rows[contador].Cells[3].Value = email;
                dataGridView1.Rows[contador].Cells[4].Value = modo;
                dataGridView1.Rows[contador].Cells[5].Value = pass;
                dataGridView1.Rows.Add(1);
                contador++;
            }
        }
    }
}
