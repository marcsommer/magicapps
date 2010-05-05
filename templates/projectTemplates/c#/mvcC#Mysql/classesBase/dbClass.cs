using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Mail;
using System.Text;
using System;

// clase para acceso a bd

public class dbClass
{
    public MySql.Data.MySqlClient.MySqlConnection conexion;
    public MySql.Data.MySqlClient.MySqlCommand miComando;
    public MySql.Data.MySqlClient.MySqlDataReader miLector;
    public string cadConexion;

    public MySqlDataReader sql(string texto)
    {
        try
        {
            miComando.CommandText = texto;
            miLector = miComando.ExecuteReader();
            return miLector;
        }
        catch (Exception em)
        {
            lo.tratarError(em, "Error en dbclass.sql", texto);
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
            MySqlConnection conn = new MySqlConnection(ctes.conStringAdoGeneral);
            IDbDataAdapter myAdapter = new MySqlDataAdapter(texto, conn);
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


        // para mysql
        //myOdbcCommand.ExecuteNonQuery()

    }

    public dbClass(string cadconexion)
    {

        try
        {
            conexion = new MySqlConnection(cadconexion);
            miComando = new MySqlCommand("");
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
            lo.tratarError(ep, "Error en dbClass.Dispose", "");
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

