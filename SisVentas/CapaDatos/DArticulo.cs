﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo
    {

        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;



        //Metodos Set and get

        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }
        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores

        public DArticulo()
        { }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;



        }


        //Metodos

        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Codigo

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer comandos
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);



                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }



            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {//Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";



            }



            catch (Exception ex)
            { rpta = ex.Message; }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
            return rpta;

        }

        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            { // conectar con la base de datos
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Comando para tener acceso al procedimiento
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Comando para navegar

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)

            { DtResultado = null; }
            return DtResultado;
        }
//Metodo Buscar Nombre

        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "spbuscar_buscar_nombre";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 256;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
                sqlCmd.Parameters.Add(ParTextoBuscar);
            
            }
            
            
            catch(Exception ex)
            { DtResultado = null; }
            return DtResultado;
        }

        //Metodo Stock_Articulos
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();


            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Comando para navegar

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)

            { DtResultado = null; }
            return DtResultado;
        }
    }
    
}
