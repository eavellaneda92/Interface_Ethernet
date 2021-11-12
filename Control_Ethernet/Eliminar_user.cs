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
    public partial class Eliminar_user : Form
    {
        public Eliminar_user()
        {
            InitializeComponent();
        }

        private void Eliminar_user_Load(object sender, EventArgs e)
        {
            //Busqueda de usuarios
            DirectoryInfo di = new DirectoryInfo("C:\\Control\\USUARIOS\\");
            DirectoryInfo[] diArr = di.GetDirectories();
            foreach (DirectoryInfo dri in diArr)
                comboBox1.Items.Add(dri.Name.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\Control\\USUARIOS\\" + comboBox1.Text;
            if (Directory.Exists(path))
            {
                Directory.Delete(path,true);
                MessageBox.Show("USUARIO ELIMINADO");
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERROR AL ELIMINAR");
            }
        }
    }
}
