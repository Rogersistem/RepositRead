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
    public partial class MantenimientoCliente : Mantenimiento
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }
        //UTILIZAMOS EL POLIMORFISMO

        public override Boolean Guardar()
        {
            //ingresar datos 
            try
            {
                string cmd = String.Format("exec ActualizarClientes '{0}','{1}','{2}'", txtIdCliente.Text.Trim(), txtNombCliente.Text.Trim(),txtApeCliente.Text.Trim());
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
        public override void Eliminar()
        {
            try
            {
                string cmd = String.Format("exec EliminaClientes '{0}'", txtIdCliente.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Se a eliminado");

            }
            catch (Exception error)
            {
                MessageBox.Show("ha ocurrido un error" + error.Message);
            }
        }

    }
}
