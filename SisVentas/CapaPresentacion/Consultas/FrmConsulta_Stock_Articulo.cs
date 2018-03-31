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

namespace CapaPresentacion.Consultas
{
    public partial class FrmConsulta_Stock_Articulo : Form
    {
        public FrmConsulta_Stock_Articulo()
        {
            InitializeComponent();
        }
            
            //Metodo para ocultar columnas
             private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            


        }
        //Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmConsulta_Stock_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        }
    }

