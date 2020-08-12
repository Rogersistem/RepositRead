using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyLibreri;
using System.Data;

namespace FactuxD
{
    public partial class VentanaLogin : FormBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        //vARIABLES GLOBALES
        public static String Codigo="";

        private void button1_Click(object sender, EventArgs e)
        {
            /*recibe la consulta //debuelve los datos de la  fila entera de la tablatabla 
            Utilidades.Ejecutar("select * from Cliente where id_clientes = 1; ");*/
            try
            {//declaramos variables
                string CMD = string.Format("select * from Usuarios where Account='{0}'and Password='{1}'", txtAccount.Text.Trim(),txtPassword.Text.Trim());

                //SE GUARDA EN EL DATASET
                DataSet ds = Utilidades.Ejecutar(CMD);

                Codigo = ds.Tables[0].Rows[0]["Id_Usuario"].ToString().Trim();



                string cuenta = ds.Tables[0].Rows[0]["Account"].ToString().Trim();
                string contaseña = ds.Tables[0].Rows[0]["Password"].ToString().Trim();

                if (cuenta == txtAccount.Text.Trim() && contaseña ==txtPassword.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status_Admin"])== true)
                     {
                        VentanaAdmin venAd = new VentanaAdmin();
                        this.Hide();
                        venAd.Show();

                    }
                    else
                    {
                        VentanaUser ventUse = new VentanaUser();
                        this.Hide();
                        ventUse.Show();
                    }

                    /*MessageBox.Show("Se a iniciado sesion");*/
                }
                /*else
                    MessageBox.Show("Usuario y/o Contaseña incorrecta!...");*/
            }
            catch(Exception error)
            {
                MessageBox.Show("Usuario o contarselal incorrecta");
                /*MessageBox.Show("Error"+error.Message);*/
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //evento que va cerrar la ventana
            Application.Exit();
        }
    }
}
