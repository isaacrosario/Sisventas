using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;



        public int Idcategoria
        {
            get { return _Idcategoria; } //Cuando me pidan por ejemplo el Idcategoria, llamo al metodo "get" para retornar(return) el Idcategoria
            set { _Idcategoria = value; } //Cuando me envien un valor para almacenarlo en mi objeto(Idcategoria), llamo al metodo "set" para guardar ese valor enviado en el objeto Idcategoria
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; } //Todos estos son metodo set and get
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Declaramos un constructor vacio
        public DCategoria()
        {

        }
        //Declaramos un constructor con todos los parametros
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar) //Los parametros que vamos a recibir son aquellos que estan dento de los parentesis del constructor
        {
            this.Idcategoria = idcategoria;  //Idcategoria hace referencia al Metodo set and get mientras que idcategoria con misnuscula es del construstor             
            this.Nombre = nombre;            //Los parametros despues del punto hacen referencia al metodo set and get los cuales dependen de las variables declaradas con "_"  
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;



        }

        //Metodo Insertar

        public string Insertar(DCategoria Categoria)
        {
            string rpta = ""; //rpta significa repuesta y recibe un valor en blanco
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open(); //Para abrir conexion
                //Establecer el comando para ejecutar sentencias sin sql server
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuetro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
                finally  //este finally se ejecutara si o si y sirve para cerrar la conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta; //Para devolver la variable rpta
        }






        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = ""; //rpta significa repuesta y recibe un valor en blanco
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open(); //Para abrir conexion
                //Establecer el comando para ejecutar sentencias sin sql server
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuetro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
                finally  //este finally se ejecutara si o si y sirve para cerrar la conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta; //Para devolver la variable rpta

        }
        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {

            string rpta = ""; //rpta significa repuesta y recibe un valor en blanco
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open(); //Para abrir conexion
                //Establecer el comando para ejecutar sentencias sin sql server
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);



                //Ejecutamos nuetro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }
                finally  //este finally se ejecutara si o si y sirve para cerrar la conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta; //Para devolver la variable rpta



        }

        public DataTable Mostrar()
        {

            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);





            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        // Metodo BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter PartextoBuscar = new SqlParameter();
                PartextoBuscar.ParameterName = "@textobuscar";
                PartextoBuscar.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar.Size = 50;
                PartextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(PartextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);





            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;



        }


    }
}



//ESTE ES EL SEGUNDO PROYECTO