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
    public partial class FrmVentas : Form
    {

        private bool IsNuevo=false;
        public int idtrabajador;
        private DataTable dtDetalle;

        private decimal totaPagado = 0;

       private static FrmVentas _Instancia;
        public static FrmVentas GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVentas();
            
            }
            return _Instancia;
        
        }

        public void setCliente(string idcliente, string nombre)
        {

            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;

        }

        public void setArticulo(string iddetalle_ingreso, string nombre, decimal precio_compra,
            decimal precio_venta, int stock, DateTime fecha_vencimiento) 
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecio_Compra.Text = Convert.ToString(precio_compra);
            this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);
            this.txtStock_Actual.Text = Convert.ToString(stock);
            this.dtFecha_Vencimiento.Value = fecha_vencimiento;

        
        }

        public FrmVentas()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(this.txtCliente, "Seleccione un cliente");
            ttMensaje.SetToolTip(this.txtSerie, "Seleccione una serie de comprobante");
            ttMensaje.SetToolTip(this.txtCorrelativo, "Seleccione un numero de comprobante  ");
            ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Articulo");

            this.txtIdcliente.Visible = false;
            this.txtIdcliente.Visible = false;
            this.txtArticulo.ReadOnly = true;
            this.txtCliente.ReadOnly = true;
            this.dtFecha_Vencimiento.Enabled = false;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtStock_Actual.ReadOnly = true;
        }

        //Mostrar mensaje de confirmacion

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Mostrar Mensaje de error 
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
            this.txtIgv.Text = "18";
            this.CrearTabla();
        }

        private void limpiardetalles()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtStock_Actual.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }






        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;            
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;
            this.txtStock_Actual.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.dtFecha_Vencimiento.Enabled = valor;

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }


        //Habilitar los botones

        private void Botones()
        {

            if (this.IsNuevo) //alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;

            }

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
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarFecha

        private void BuscarFecha()
        {
            //Recuerda las 3 yyy
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyy"));


            this.OcultarColumnas();
            lblTotal.Text = "Total de registro:" + Convert.ToString(dataListado.Rows.Count);
        }
        private void MostraDetalle()
        {
            //Recuerda las 3 yyy
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle              
                (this.txtIdventa.Text);




        }


        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            //this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));    
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));    
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));        
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListadoDetalle.DataSource = dtDetalle;    
            
        }



        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Venta vista = new FrmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Venta vista = new FrmVistaArticulo_Venta();
            vista.ShowDialog();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult Opction;
                Opction = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opction == DialogResult.OK)
                {

                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));



                            if (Rpta.Equals("OK"))
                            {

                                this.MensajeOk("Se eliminó correctamente el ingreso");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }

                        this.Mostrar();




                    }

                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);

            }

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
           this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
                this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
                this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fecha"].Value);
                this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);                
                this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
                this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
                this.MostraDetalle();
                this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
            {
            this.dataListado.Columns[0].Visible = true;
            }
        else
            {
            this.dataListado.Columns[0].Visible = false;
            
            }
        
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiardetalles();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiardetalles();
            this.Habilitar(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty ||
                    this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");
                }

                else
                {


                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(idtrabajador, Convert.ToInt32(this.txtIdcliente.Text), dtFecha.Value, cbTipo_Comprobante.Text,
                            txtSerie.Text, txtCorrelativo.Text, Convert.ToDecimal(this.txtIgv.Text), dtDetalle);



                    }


                    if (rpta.Equals("OK"))
                    {

                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");

                        }

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiardetalles();
                    this.Mostrar();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtArticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                    this.txtDescuento.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                }

                else
                {

                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    { 
                    if(Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                    {
                        registrar = false;
                    this.MensajeError("Ya se encuentra el articulo en el detalle");
                    }  
                    
                }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock_Actual.Text))
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio_Venta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totaPagado = totaPagado + subtotal;
                        this.lblTotal_Pagado.Text = totaPagado.ToString("#0.00#");
                        //agregar ese detalle  al datalistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                      // row["articulo"] = this.txtArticulo.Text;
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiardetalles();
                    }
                    else 
                    {

                        MensajeError("No hay Stock Suficiente");
                    }
                }

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
}

        private void btnQuitar_Click(object sender, EventArgs e)
        {
              try 
            {
            
            int IndiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[IndiceFila];

                //Disminuir el TotalPagado
                this.totaPagado = this.totaPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = totaPagado.ToString("#0.00#");

                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            
            }
            
            
            catch {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            FrmReporteFactura frm = new FrmReporteFactura();
            frm.Idventa=Convert.ToInt32(this.dataListado.CurrentRow .Cells["idventa"].Value);
            frm.ShowDialog();
        }
        }   
        }
        
        
    
