﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{ //ESTE ES LA AUNTENTICO
   public class DDetalle_Ingreso
    {

        private int _Iddetalle_ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;
      

       public int Iddetalle_ingreso
       {
           get { return _Iddetalle_ingreso; }
           set { _Iddetalle_ingreso = value; }
       }

       public int Idingreso
       {
           get { return _Idingreso; }
           set { _Idingreso = value; }
       }

       public int Idarticulo
       {
           get { return _Idarticulo; }
           set { _Idarticulo = value; }
       }

       public decimal Precio_Compra
       {
           get { return _Precio_Compra; }
           set { _Precio_Compra = value; }
       }

       public decimal Precio_Venta
       {
           get { return _Precio_Venta; }
           set { _Precio_Venta = value; }
       }

       public int Stock_Inicial
       {
           get { return _Stock_Inicial; }
           set { _Stock_Inicial = value; }
       }

       public int Stock_Actual
       {
           get { return _Stock_Actual; }
           set { _Stock_Actual = value; }
       }

       public DateTime Fecha_Produccion
       {
           get { return _Fecha_Produccion; }
           set { _Fecha_Produccion = value; }
       }

       public DateTime Fecha_Vencimiento
       {
           get { return _Fecha_Vencimiento; }
           set { _Fecha_Vencimiento = value; }
       }

   //Constructores



       public DDetalle_Ingreso()
       {
         

       }

       public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso,  int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion,DateTime fecha_vencimiento)
       {

           this._Iddetalle_ingreso = iddetalle_ingreso;
           this.Idingreso = idingreso;
           this.Idarticulo = idarticulo;
           this.Precio_Compra = precio_compra;
           this.Precio_Venta = precio_venta;
           this.Stock_Inicial = stock_inicial;
           this.Stock_Actual = stock_actual;
           this.Fecha_Produccion = fecha_produccion;
           this.Fecha_Vencimiento = fecha_vencimiento;

       }
  //Metodo insertar
       public string Insertar(DDetalle_Ingreso DDetalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
       {
           string rpta = ""; //rpta significa repuesta y recibe un valor en blanco
         
           try
           {
             
               //Establecer el comando para ejecutar sentencias sin sql server
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.Transaction = SqlTra;
               SqlCmd.CommandText = "spinsertar_detalle_ingreso";
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlParameter ParIddetalle_Ingreso = new SqlParameter();
               ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
               ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
               ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
               SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

               SqlParameter ParIdingreso = new SqlParameter();
               ParIdingreso.ParameterName = "@idingreso";
               ParIdingreso.SqlDbType = SqlDbType.Int;               
               ParIdingreso.Value = DDetalle_Ingreso.Idingreso;
               SqlCmd.Parameters.Add(ParIdingreso);

               SqlParameter ParIdarticulo = new SqlParameter();
               ParIdarticulo.ParameterName = "@idarticulo";
               ParIdarticulo.SqlDbType = SqlDbType.Int;
               ParIdarticulo.Value = DDetalle_Ingreso.Idarticulo;
               SqlCmd.Parameters.Add(ParIdarticulo);


               SqlParameter ParPrecio_Compra = new SqlParameter();
               ParPrecio_Compra.ParameterName = "@precio_compra";
               ParPrecio_Compra.SqlDbType = SqlDbType.Money;
               ParPrecio_Compra.Size = 256;
               ParPrecio_Compra.Value = DDetalle_Ingreso.Precio_Compra;
               SqlCmd.Parameters.Add(ParPrecio_Compra);


               SqlParameter ParPrecio_Venta = new SqlParameter();
               ParPrecio_Venta.ParameterName = "@precio_venta";
               ParPrecio_Venta.SqlDbType = SqlDbType.Money;              
               ParPrecio_Venta.Value = DDetalle_Ingreso.Precio_Venta;
               SqlCmd.Parameters.Add(ParPrecio_Venta);

               SqlParameter ParStock_Actual = new SqlParameter();
               ParStock_Actual.ParameterName = "@stock_actual";
               ParStock_Actual.SqlDbType = SqlDbType.Money;
               ParStock_Actual.Value = DDetalle_Ingreso.Stock_Actual;
               SqlCmd.Parameters.Add(ParStock_Actual);

               SqlParameter ParStock_Inicial = new SqlParameter();
               ParStock_Inicial.ParameterName = "@stock_inicial";
               ParStock_Inicial.SqlDbType = SqlDbType.Money;
               ParStock_Inicial.Value = DDetalle_Ingreso.Stock_Inicial;
               SqlCmd.Parameters.Add(ParStock_Inicial);

               SqlParameter ParFecha_Produccion = new SqlParameter();
               ParFecha_Produccion.ParameterName = "@fecha_produccion";
               ParFecha_Produccion.SqlDbType = SqlDbType.Date;
               ParFecha_Produccion.Value = DDetalle_Ingreso.Fecha_Produccion;
               SqlCmd.Parameters.Add(ParFecha_Produccion);


               SqlParameter ParFecha_Vencimiento = new SqlParameter();
               ParFecha_Vencimiento.ParameterName = "@fecha_vencimiento";
               ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
               ParFecha_Vencimiento.Value = DDetalle_Ingreso.Fecha_Vencimiento;
               SqlCmd.Parameters.Add(ParFecha_Vencimiento);
               
               //Ejecutamos nuetro comando
               rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

           }

           catch (Exception ex)
           {
               rpta = ex.Message;
           }
              
           return rpta; //Para devolver la variable rpta
       }    

   }

}
 //ESTE ES LA AUNTENTICO