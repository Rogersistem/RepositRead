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
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }
        //UTILIZAMOS EL POLIMORFISMO

        public override Boolean Guardar()
        {
            if (Utilidades.ValidarFormulario(this, errorProvider1) == false)
            {
                //ingresar datos 
                try
                {
                    string cmd = String.Format("exec ActualizarArticulos '{0}','{1}','{2}'", txtIDProducto.Text.Trim(), txtNomProducto.Text.Trim(), txtPrecio.Text.Trim());
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("se ha guardado los datos");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error" + error.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public override void Eliminar()
        {
            try
            {
                string cmd = String.Format("exec EliminaArticulos '{0}'", txtIDProducto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se a eliminado");

            }catch(Exception error)
            {
                MessageBox.Show("ha ocurrido un error"+ error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtIDProducto_TextChanged(object sender, EventArgs e)
        {
            //Al momento de salir error esto quita el mensaje 
            errorProvider1.Clear();
        }
    }
}
