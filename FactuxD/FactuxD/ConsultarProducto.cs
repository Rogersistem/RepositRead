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
    //HERREDA LAS CARACTERISTICAS DEL FORM CONSULTAS
    public partial class ConsultarProducto : Consultas
    {
        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            {
                try
                {
                    DataSet ds;
                    string cmd = "select * from Articulo where Nom_pro like ('%" + textBox1.Text.Trim() + "%' )";

                    ds = Utilidades.Ejecutar(cmd);

                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error" + error.Message);
                }
            }
        }

        private void ConsultarProducto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LLenarDataGriView("Articulo").Tables[0];
        }
    }
}
