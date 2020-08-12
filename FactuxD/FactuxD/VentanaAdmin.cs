using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibreri;


namespace FactuxD
{
    public partial class VentanaAdmin : FormBase
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaAdmin_Load(object sender, EventArgs e)
        {

            string cmd = "select * from Usuarios where id_usuario=" + VentanaLogin.Codigo;

            DataSet DS = Utilidades.Ejecutar(cmd);
            //rellenar a cada campo
            lblNombAdmin.Text = DS.Tables[0].Rows[0]["Nom_usu"].ToString().Trim();
            lblUsuAdmin.Text = DS.Tables[0].Rows[0]["Account"].ToString().Trim();
            lblCodigoAdmin.Text = DS.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

            string url= DS.Tables[0].Rows[0]["Foto"].ToString();
            pictureBox1.Image = Image.FromFile(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contPrincipal = new ContenedorPrincipal();
            this.Hide();
            contPrincipal.Show();

        }
    }
}
