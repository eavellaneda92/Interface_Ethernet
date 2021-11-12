using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;
using System.IO.Compression;
using System.IO;

namespace Control_Ethernet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_name.Size = new Size(261, 35);
            txt_pass.Size = new Size(261, 35);
        }

        Computer mycomputer = new Computer();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void mueve(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chekeo();
        }

        void registra_sesion()
        {
            string path = "C:\\Control\\Login.txt";
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete(path);
                StreamWriter outfile = new StreamWriter(path);
                outfile.WriteLine(txt_name.Text);
                outfile.WriteLine(DateTime.Now.ToString());
                outfile.Close();
            }
            else
            {
                StreamWriter outfile = new StreamWriter(path);
                outfile.WriteLine(txt_name.Text);
                outfile.WriteLine(DateTime.Now.ToString());
                outfile.Close();
            }
        }

        void chekeo()
        {
            //Si es usuario general
            if (txt_name.Text == "ADMIN")
            {
                if (txt_pass.Text == "Log2021")
                {
                    Control apertura = new Control();
                    apertura.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password incorrecto");
                }
            }
            else
            {
                //Lectura de usuarios
                //Busqueda de usuarios
                DirectoryInfo di = new DirectoryInfo("C:\\Control\\USUARIOS\\");
                DirectoryInfo[] diArr = di.GetDirectories();
                bool correcto = false;
                foreach (DirectoryInfo dri in diArr) { 
                    string user = dri.Name.ToString();
                    TextReader leer = new StreamReader("C:\\Control\\USUARIOS\\" + user + "\\Datos.txt");
                    string name = leer.ReadLine();
                    string pass = leer.ReadLine();
                    string empresa = leer.ReadLine();
                    string email = leer.ReadLine();
                    string modo = leer.ReadLine();
                    leer.Close();
                    if(txt_name.Text == user)
                    {
                        if(txt_pass.Text == pass)
                        {
                            if (modo == "ADMINISTRADOR")
                            {
                                Control apertura = new Control();
                                apertura.Show();
                                this.Hide();
                                correcto = true;
                            }
                            else
                            {
                                Operacion apertura = new Operacion();
                                apertura.Show();
                                this.Hide();
                                correcto = true;
                            }
                            registra_sesion();
                        }
                    }
                }
                if(correcto == false) MessageBox.Show("Usuario no encontrado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.Filter = "Text Files (.zip)|*.zip";
            try
            {
                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    /*Busca destino*/
                    string FolderPath = @"C:\\Control";
                    if (!Directory.Exists(FolderPath))
                    {
                        Directory.CreateDirectory(FolderPath);
                    }

                    /*Borrar carpeta*/
                    DirectoryInfo di = new DirectoryInfo(@"C:\Control");
                    FileInfo[] files = di.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }

                    /*mover zip*/
                    String directorio = buscar.FileName;
                    String raiz = "C:\\Control\\update.zip";
                    mycomputer.FileSystem.MoveFile(directorio, raiz);

                    /*Descomprimir zip y borrar*/
                    ZipFile.ExtractToDirectory(raiz,"C:\\Control");
                    string path = "C:\\Control\\update.zip";
                    bool result = File.Exists(path);
                    if (result == true)
                    {
                        File.Delete(path);
                        MessageBox.Show("Cargado correctamente");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR AL ABRIR ARCHIVO");
            }
        }
    }
}
