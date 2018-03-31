using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
  public class DPresentacion
    {


        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;


        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
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

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
      
        public DPresentacion()
        {

        }

        public DPresentacion(int idpresentacion, string descripcion, string Nombre, string TextoBuscar)
        {

            this.Idpresentacion = idpresentacion;
            this.Nombre = Nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = TextoBuscar;

            // despues del this.por ejemplo Idpresentacion es la propiedad del metodo set and get
        }
        //Insertar

        public string Insertar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "spinsertar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion  .Nombre;
                SqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
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
        public string Editar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "speditar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
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
        public string Eliminar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);



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

                DataTable DtResultado = new DataTable("presentacion");
                SqlConnection SqlCon = new SqlConnection();
                try {
                    
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                   SqlCmd.CommandText = "spmostrar_presentacion";
                   SqlCmd.CommandType = CommandType.StoredProcedure;

                   SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                   SqlDat.Fill(DtResultado);

                            


                
                }
                catch  (Exception ex)
                {
                    DtResultado = null;
                }
                return DtResultado;
            }
        // Metodo BuscarNombre
  public DataTable BuscarNombre(DPresentacion Presentacion)
  {
      DataTable DtResultado = new DataTable("presentacion");
      SqlConnection SqlCon = new SqlConnection();
      try
      {

          SqlCon.ConnectionString = Conexion.Cn;
          SqlCommand SqlCmd = new SqlCommand();
          SqlCmd.Connection = SqlCon;
          SqlCmd.CommandText = "spbuscar_presentacion_nombre";
          SqlCmd.CommandType = CommandType.StoredProcedure;

          SqlParameter PartextoBuscar = new SqlParameter();
          PartextoBuscar.ParameterName = "@textobuscar";
          PartextoBuscar.SqlDbType = SqlDbType.VarChar;
          PartextoBuscar.Size = 50;
          PartextoBuscar.Value = Presentacion.TextoBuscar;
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