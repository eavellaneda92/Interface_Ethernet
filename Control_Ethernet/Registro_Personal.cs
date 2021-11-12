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
    public partial class Registro_Personal : Form
    {
        public Registro_Personal()
        {
            InitializeComponent();
        }

        private void Registro_Personal_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ADMINISTRADOR");
            comboBox1.Items.Add("USUARIO");
            comboBox1.Text = "ADMINISTRADOR";
            button1.BackColor = Color.Green;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.Green;
            button4.BackColor = Color.Green;
            button5.BackColor = Color.Green;
            button6.BackColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Green)
            {
                button1.BackColor = Color.Red;
            }
            else
            {
                button1.BackColor = Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Green)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Green;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Green)
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.BackColor = Color.Green;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Green)
            {
                button4.BackColor = Color.Red;
            }
            else
            {
                button4.BackColor = Color.Green;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Green)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Green;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Green)
            {
                button6.BackColor = Color.Red;
            }
            else
            {
                button6.BackColor = Color.Green;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //CREA CARPETA 
            string FolderPath = @"C:\\Control\\USUARIOS\\" + txt_dni.Text;
            if (!Directory.Exists(FolderPath))
            {
                //DATOS DE USUARIO
                Directory.CreateDirectory(FolderPath);
                StreamWriter outfile = new StreamWriter("C:\\Control\\USUARIOS\\" + txt_dni.Text + "\\" + "Datos.txt");
                outfile.WriteLine(txt_nombre.Text);
                outfile.WriteLine(txt_password.Text);
                outfile.WriteLine(txt_empresa.Text);
                outfile.WriteLine(txt_email.Text);
                outfile.WriteLine(comboBox1.Text);
                outfile.Close();
                //REGIONES PERMITIDAS
                outfile = new StreamWriter("C:\\Control\\USUARIOS\\" + txt_dni.Text + "\\" + "Areas.txt");
                if (button1.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                if (button2.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                if (button3.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                if (button4.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                if (button5.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                if (button6.BackColor == Color.Green) outfile.WriteLine("ON");
                else outfile.WriteLine("OFF");
                outfile.Close();
                //REGISTRO
                

                //COMENTARIO
                outfile = new StreamWriter("C:\\Control\\USUARIOS\\" + txt_dni.Text + "\\" + "Comentario.txt");
                outfile.WriteLine(textBox1.Text);
                outfile.Close();
                MessageBox.Show("USUARIO CREADO");
                this.Hide();
            }
            else
            {
                MessageBox.Show("USUARIO YA EXISTE");
            }
        }
    }
}
