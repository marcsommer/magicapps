//using System.Data.Odbc;

using System.Data;
using System.Data.SqlClient;
using System.Text;
using System;


// clase para acceso a bd

public class dbClassSql
{
    public System.Data.SqlClient.SqlConnection conexion;
    public System.Data.SqlClient.SqlCommand miComando;
    public System.Data.SqlClient.SqlDataReader miLector;
    public string cadConexion;

    public SqlDataReader sql(string texto)
    {
        try
        {
            miComando.CommandText = texto;
            miLector = miComando.ExecuteReader();
            return miLector;
        }
        catch (Exception em)
        {
            //lo.tratarError(em, "Error en dbclass.sql", texto);
        }



        //Error en la ejecucion
        return null;

    }

    // devuelve un dataset
    public System.Data.DataSet sqlDataset(string texto)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlConnection conn = new SqlConnection(ctes.conStringAdoGeneral);
            IDbDataAdapter myAdapter = new SqlDataAdapter(texto, conn);
            myAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            lo.tratarError(ex, "Error en dbclass.sqlDataset", texto);
        }
        return ds;
    }



    public void ejecutar(string texto)
    {

        // comento el try para capturar el error en su sitio
        try
        {
            miComando.CommandText = texto;
            miComando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // mandamos un mensaje mas detallado
            lo.tratarError(ex, "Error en dbclass.ejecutar", texto);
        }
    }

    public dbClassSql(string cadconexion)
    {
        try
        {
            conexion = new SqlConnection(cadconexion);
            miComando = new SqlCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();
        }
        catch (Exception ep)
        {
            lo.tratarError(ep, "Error en dbClass.new", "");
        }
    }

    public void Dispose()
    {
        try
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            miComando = null;
            miLector = null;
        }
        catch (Exception ep)
        {
            //MsgBox(ep.Message)
        }
    }

    protected void Destroy()
    {
        try
        {
            conexion.Dispose();
            conexion = null;
            miComando = null;
            miLector = null;

            //conexion.Close()
        }
        catch (Exception em)
        {
        }
    }

}

