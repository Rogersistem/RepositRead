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
    public partial class Consultas : FormBase
    {
        public Consultas()
        {
            InitializeComponent();
        }
        //creamos un tipo de metodo de tipo dataset
        public DataSet LLenarDataGriView(string tabla)
        {
            DataSet Ds;
            string cmd = string.Format("select * from " + tabla);
            Ds = Utilidades.Ejecutar(cmd);

            return Ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
