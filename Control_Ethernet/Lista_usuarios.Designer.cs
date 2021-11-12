
namespace Control_Ethernet
{
    partial class Lista_usuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lista_usuarios));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.NOMBRE,
            this.EMPRESA,
            this.EMAIL,
            this.TIPO,
            this.PASSWORD});
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(925, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "APELLIDO Y NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 200;
            // 
            // EMPRESA
            // 
            this.EMPRESA.HeaderText = "EMPRESA";
            this.EMPRESA.Name = "EMPRESA";
            this.EMPRESA.Width = 150;
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Width = 150;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO INGRESO";
            this.TIPO.Name = "TIPO";
            this.TIPO.Width = 130;
            // 
            // PASSWORD
            // 
            this.PASSWORD.HeaderText = "PASSWORD";
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Width = 150;
            // 
            // Lista_usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(926, 426);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Lista_usuarios";
            this.Text = "Lista_usuarios";
            this.Load += new System.EventHandler(this.Lista_usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
    }
}