using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FrmVistaCliente_Venta : Form
    {
        public FrmVistaCliente_Venta()
        {
            InitializeComponent();
        }
        private void FrmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        //Metodo para ocultar columnas

        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;


        }
        //Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarApellidos

        private void BuscarApellidos()
        {

            this.dataListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarNum_Documento

        private void BuscarNum_Documento()
        {

            this.dataListado.DataSource = NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();

            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();

            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVentas form = FrmVentas.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value)+" "+
            Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(par1,par2);
            this.Hide();

                
        }

        



    }
}
