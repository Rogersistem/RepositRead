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
    public partial class Facturación :Procesos
    {
        public Facturación()
        {
            InitializeComponent();
        }

        private void Facturación_Load(object sender, EventArgs e)
        {
            //este código mostrara al usuario que atiende al cliente
            string cmd = "select * from Usuarios where id_usuario=" + VentanaLogin.Codigo;
            DataSet ds;
            ds = Utilidades.Ejecutar(cmd);

            lblLe_Atiende.Text = ds.Tables[0].Rows[0]["Nom_usu"].ToString().Trim();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo_cli.Text.Trim()) == false)
            {
                try
                {

                string cmd = string.Format("select Nom_cli from Cliente where id_clientes='{0}'", txtCodigo_cli.Text.Trim());


                DataSet ds = Utilidades.Ejecutar(cmd);
                TxtCliente.Text = ds.Tables[0].Rows[0]["Nom_cli"].ToString().Trim();
                    txtCodigo_producto.Focus();


                }
                catch(Exception Error)
                {
                    MessageBox.Show("Ha ocurrido un Error"+ Error.Message);
                }
                 
            }
        }//variables publicas 
        public static int Contador_fila = 0;
        public static double total;
        private void btnColocar_Click(object sender, EventArgs e)
        {
            if (Utilidades.ValidarFormulario(this,errorProvider1) == false)
            {
                bool existe = false;
                int num_fila = 0;

                if (Contador_fila == 0)
                {
                    //calcula el importe
                    dataGridView1.Rows.Add(txtCodigo_producto.Text, txtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);
                    double importe = Convert.ToDouble(dataGridView1.Rows[Contador_fila].Cells[2].Value)* Convert.ToDouble(dataGridView1.Rows[Contador_fila].Cells[3].Value);
                    dataGridView1.Rows[Contador_fila].Cells[4].Value = importe;
                   
                    Contador_fila++;
                }
                else
                {
                    foreach(DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (fila.Cells[0].Value.ToString() == txtCodigo_producto.Text)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if(existe== true)
                    {
                        dataGridView1.Rows[num_fila].Cells[3].Value =( Convert.ToDouble(TxtCantidad.Text)+ Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();
                        double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value);
                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;

                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;

                    }
                    else
                    {
                        dataGridView1.Rows.Add(txtCodigo_producto.Text, txtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);
                        double importe = Convert.ToDouble(dataGridView1.Rows[Contador_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[Contador_fila].Cells[3].Value);
                        dataGridView1.Rows[Contador_fila].Cells[4].Value = importe;

                        Contador_fila++;
                    }
                    }
                    ///se inici el total en cero y con esto obtenemos el total
                total = 0;
                      foreach (DataGridViewRow fila in dataGridView1.Rows)
                       {
                    total += Convert.ToDouble(fila.Cells[4].Value);
                      
                    }
                lblTotal.Text = "S/." + total.ToString();
                }
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Contador_fila > 0)
            {
                total = total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
                lblTotal.Text = "S/." + total.ToString();

                //luego de Selecionarlo lo remueve
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                //tambiens se resta una fila
                Contador_fila--;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConsultarClientes conCli = new ConsultarClientes();
            conCli.ShowDialog();

            if (conCli.DialogResult == DialogResult.OK)
            {
                txtCodigo_cli.Text=conCli.dataGridView1.Rows[conCli.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCliente.Text = conCli.dataGridView1.Rows[conCli.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

                txtCodigo_producto.Focus();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

            ConsultarProducto conpro = new ConsultarProducto();
            conpro.ShowDialog();
            if (conpro.DialogResult == DialogResult.OK)
            {
                txtCodigo_producto.Text = conpro.dataGridView1.Rows[conpro.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtDescripcion.Text= conpro.dataGridView1.Rows[conpro.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtPrecio.Text= conpro.dataGridView1.Rows[conpro.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCantidad.Focus();

            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        public override void Nuevo()
        {
            txtCodigo_cli.Text = "";
            TxtCliente.Text = "";
            txtCodigo_producto.Text = "";
            txtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            lblTotal.Text = "S/. 0";
            dataGridView1.Rows.Clear();
            Contador_fila = 0;
            total = 0;
            txtCodigo_cli.Focus();
            
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            if(Contador_fila != 0)
            {
                try
                {
                    string cmd = string.Format("Exec ActualizarFacturas '{0}'", txtCodigo_cli.Text.Trim());
                    DataSet ds = Utilidades.Ejecutar(cmd);

                    string Numfac = ds.Tables[0].Rows[0]["NumFact"].ToString().Trim();
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        cmd = string.Format("Exec ActualizarDetalles '{0},'{1}','{2}','3'", Numfac, fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString(),fila.Cells[3].Value.ToString());
                        ds = Utilidades.Ejecutar(cmd);
                    }
                    cmd = "Exec DatosFactura" + Numfac;
                    ds = Utilidades.Ejecutar(cmd);
                    //ventana reporte
                    Reporte rp = new Reporte();
                    //rp.Reportviewer1.LocalReport.Datasources[0].value = ds.Tables[0];
                    rp.ShowDialog();

                    Nuevo();
                    
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error:" + error.Message);
                }
            }
        }
    }
    }

