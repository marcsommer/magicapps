using System;
using System.Collections.Generic;
using System.Text;

using System.Data.OleDb;


class dbAccess
{
    public OleDbConnection conexion;
    public OleDbCommand miComando;
    public OleDbDataReader miLector;
    //public string cadConexion;


    public enum adoTypes
    {
        adEmpty = 0,
        adTinyInt = 16,
        adSmallInt = 2,
        adInteger = 3,
        adBigInt = 20,
        adUnsignedTinyInt = 17,
        adUnsignedSmallInt = 18,
        adUnsignedInt = 19,
        adUnsignedBigInt = 21,
        adSingle = 4,
        adDouble = 5,
        adCurrency = 6,
        adDecimal = 14,
        adNumeric = 131,
        adBoolean = 11,
        adError = 10,
        adUserDefined = 132,
        adVariant = 12,
        adIDispatch = 9,
        adIUnknown = 13,
        adGUID = 72,
        adDate = 7,
        adDBDate = 133,
        adDBTime = 134,
        adDBTimeStamp = 135,
        adBSTR = 8,
        adChar = 129,
        adVarChar = 200,
        adLongVarChar = 201,
        adWChar = 130,
        adVarWChar = 202,
        adLongVarWChar = 203,
        adBinary = 128,
        adVarBinary = 204,
        adLongVarBinary = 205,
        adChapter = 136,
        adFileTime = 64,
        adDBFileTime = 137,
        adPropVariant = 138,
        adVarNumeric = 139
    }

    public string test(string cadconexion)
    {
        OleDbConnection conexion = null;
        try
        {
            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();
            return "";
        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return ep.Message;
        }
        finally
        {
            conexion.Close();
        }
    }   // test


    public List<table> getTables(string cadconexion, string database)
    {
        OleDbConnection conexion = null;
        try
        {
            List<table> lista = new List<table>();

            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = conexion.GetSchema(OleDbMetaDataCollectionNames.Tables, new String[] { null, null, null, null });

            foreach (System.Data.DataRow rowDatabase in dt.Rows)
            {
                // exclude system tables...
                if (rowDatabase["table_name"].ToString().IndexOf("TMP") == -1 && rowDatabase["table_name"].ToString().IndexOf("MSys") == -1 && rowDatabase.ItemArray[3].Equals("TABLE"))
                {
                    string tableName = rowDatabase["table_name"].ToString();

                    table tab = new table();
                    tab.Name = tableName;
                    tab.TargetName = tab.Name;
                    lista.Add(tab);

                }




            }

            return lista;


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return null;
        }
        finally
        {
            conexion.Close();
        }
    }   // getTables



    public List<field> getFields(string cadconexion, string table)
    {

        OleDbConnection conexion = null;

        try
        {


            List<field> lista = new List<field>();


            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = conexion.GetSchema(OleDbMetaDataCollectionNames.Columns, new String[] { null, null, table, null });


            //foreach (System.Data.DataColumn col in dt.Columns)
            //{

            //}
            foreach (System.Data.DataRow row in dt.Rows)
            {
                // Debug.WriteLine(row["TABLE_NAME"] + " " + row["COLUMN_NAME"] + " " + row["DATA_TYPE"]);

                field fi = new field();
                fi.Name = row[3].ToString();
                fi.targetName = row[3].ToString();

                adoTypes at = new adoTypes();
                at = (adoTypes)sf.entero(row[11].ToString());
                switch (at)
                {
                    case adoTypes.adInteger:
                        fi.type = field.fieldType._integer;
                        break;
                    case adoTypes.adDBDate:
                        fi.type = field.fieldType._date;
                        break;
                    case adoTypes.adDate:
                        fi.type = field.fieldType._date;
                        break;
                    case adoTypes.adDouble:
                        fi.type = field.fieldType._double;
                        break;
                    case adoTypes.adWChar:
                        fi.type = field.fieldType._string;
                        break;

                    case adoTypes.adBoolean:
                        fi.type = field.fieldType._boolean;
                        break;


                    default:
                        fi.type = field.fieldType._string;
                        break;
                }

                fi.targetType = fi.type;



                fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);
                fi.size = sf.entero(row["CHARACTER_MAXIMUM_LENGTH"]);
                fi.defaultValue = sf.cadena(row["COLUMN_DEFAULT"]);

                try
                {
                    fi.comment = sf.cadena(row[27].ToString());
                }
                catch (Exception)
                {

                    throw;
                }





                fi.decimals = sf.entero(row["NUMERIC_PRECISION"]);



                //fi.autoNumber = sf.boolean(row["COLUMN_KEY"]);
                //   fi.isKey = sf.boolean(row["COLUMN_KEY"]);

                // fi.autoNumber = sf.boolean(row["ISIDENTITY"]);

                // // Retrieve the column's default value.
                // fi.defaultValue = ((row["COLUMN_DEFAULT"] as DBNull)
                //     != null) ? "Null" : row["COLUMN_DEFAULT"].ToString();
                // // Retrieve the column's precision.
                // //column.Precision = ((row["NUMERIC_PRECISION"] as DBNull)
                // //    != null) ? 0 : Int32.Parse(row["NUMERIC_PRECISION"].ToString());
                // // Retrieve the column's scale.
                //// column.Scale = ((row["NUMERIC_SCALE"] as DBNull) != null) ? 0 : Int32.Parse(row["NUMERIC_SCALE"].ToString());
                // // Specify if the column is a primary key.
                // fi.isKey = primaryKeys.Contains(row["COLUMN_NAME"].ToString());
                // // Specify that the column is not an identity column.
                // //column.IsIdentity = false;
                // // Retrieve the column length.
                // fi.size = ((OleDbType)Int32.Parse(row["DATA_TYPE"].ToString()) != OleDbType.WChar) ? -1 : Int32.Parse(row["CHARACTER_MAXIMUM_LENGTH"].ToString());
                // // Append the column to the list.



                //fi.size = sf.Entero(tbl.Rows(i)!CHARACTER_MAXIMUM_LENGTH)
                //     fi.comment = sf.Cadena(tbl.Rows(i)!COLUMN_COMMENT)
                //fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);//tbl.Rows(i)!IS_NULLABLE)
                //     fi.defaultValue = sf.Cadena(tbl.Rows(i)!COLUMN_DEFAULT)
                //     fi.autoNumber = sf.boolean(tbl.Rows(i)!COLUMN_KEY)
                //     fi.decimals = sf.Entero(tbl.Rows(i)!NUMERIC_PRECISION)



                // lets get the comment
                // fi.comment = getComments(cadconexion, table, fi.Name);
                if (fi.comment.IndexOf("#image#") >= 1)
                {
                    fi.targetType = field.fieldType._image;
                    fi.comment = fi.comment.Replace("#image#", "");
                }
                if (fi.comment.IndexOf("#audio#") >= 1)
                {
                    fi.targetType = field.fieldType._audio;
                    fi.comment = fi.comment.Replace("#image#", "");
                }
                if (fi.comment.IndexOf("#doc#") >= 1)
                {
                    fi.targetType = field.fieldType._document;
                    fi.comment = fi.comment.Replace("#doc#", "");
                }
                if (!fi.comment.Equals(""))
                    fi.targetName = fi.comment;

                lista.Add(fi);

            }

            return lista;


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return null;
        }

        finally
        {
            conexion.Close();
        }
    }   // getFields



    public void getKeys(string cadconexion, table table)
    {
        OleDbConnection conexion = null;
        try
        {
            List<String> lista = new List<String>();

            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            // dt = conexion.GetSchema(OleDbMetaDataCollectionNames.Indexes, new String[] { null, null, table.ToString(), null });
            dt = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, new String[] { null, null, table.Name });

            foreach (System.Data.DataRow row in dt.Rows)
            {
                foreach (field item in table.fields)
                {
                    if (item.Name.Equals(row[3].ToString()))
                    {
                        item.isKey = true;
                        table.keyFields.Add(item);
                        if (table.GetKey == "")
                            table.GetKey = item.Name;
                    }
                    else
                    {
                        table.notKeyFields.Add(item);
                    }

                }
            }


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");

        }
        finally
        {
            conexion.Close();
        }
    }  // getKeys


    // get all relations for project
    public List<relation> getRelations(string cadconexion)
    {
        List<relation> lista = null;

        OleDbConnection conexion = null;
        try
        {

            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new String[] { null, null, null });

            foreach (System.Data.DataRow row in dt.Rows)
            {

                //       Dim nombre As New String("")
                //Dim descripcion As New String("")

                //Dim tablaPadre As New String("")
                //Dim campoPadre As New String("")

                //Dim tablaHijo As New String("")
                //Dim campoHijo As New String("")

                //Dim update As Boolean = False
                //Dim delete As Boolean = False

                //nombre = schemaTable.Rows(i)("FK_NAME").ToString
                //descripcion = schemaTable.Rows(i)("PK_NAME").ToString

                //tablaPadre = schemaTable.Rows(i)("PK_TABLE_NAME").ToString
                //campoPadre = schemaTable.Rows(i)("PK_COLUMN_NAME").ToString

                //tablaHijo = schemaTable.Rows(i)("FK_TABLE_NAME").ToString
                //campoHijo = schemaTable.Rows(i)("FK_COLUMN_NAME").ToString


                //If schemaTable.Rows(i)("UPDATE_RULE").ToString.IndexOf("CASCADE") <> -1 Then
                //    update = True
                //End If


                //If schemaTable.Rows(i)("DELETE_RULE").ToString.IndexOf("CASCADE") <> -1 Then
                //    delete = True
                //End If
            }



        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");

        }
        finally
        {
            conexion.Close();
        }

        return lista;


    }   // getRelations

    public List<relation> getRelations(string cadconexion, string table)
    {
        // not implemented still
        return null;



    }   // getRelations



    // get the description for a column
    public String getComments(string cadconexion, string table, string column)
    {

        OleDbConnection conexion = null;
        try
        {

            List<String> lista = new List<String>();
            String sql = null;
            sql = String.Format("select value from ::fn_listextendedproperty ('MS_Description', 'user','dbo', 'table', '{0}', 'column', '{1}')", table, column);


            conexion = new OleDbConnection(cadconexion);
            miComando = new OleDbCommand(sql);
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            OleDbDataReader dr = null;
            dr = miComando.ExecuteReader();

            while (dr.Read())
            {
                return (dr["value"].ToString());
            }

            return "";


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return "";
        }
        finally
        {
            miComando = null;
            conexion.Close();
            conexion = null;
        }
    }  // getComments





    // -----------------------------------------------------------------------
    // code to copy




    // Public Function getkeys(ByRef conexion As MySql.Data.MySqlClient.OleDbConnection, ByVal database As String, ByVal mostrarLog As Boolean)

    //    'Dim db As New SqlServer.WrSqlServerDatabase("192.168.0.135\SQL2005", "svNursingAdmin")
    //    'db.GetTables(New WrCredentials("sa", "xx"), WrVendor.ELEM_OWNER.USER)
    //    'Dim cols As WrColumn()
    //    'cols = db.GetColumns("AllTypes", New WrCredentials("sa", "xx"))


    //    Dim sql As String

    //    For Each tabla As lb.tabla In proyectoActual.tablas

    //        sql = String.Format("SELECT column_name FROM information_schema.key_column_usage WHERE TABLE_NAME = '{0}' AND CHARINDEX('PK', CONSTRAINT_NAME) <> 0", tabla.nombre)
    //        '            sql = String.Format("select s.name as TABLE_SCHEMA, t.name as TABLE_NAME, k.name as CONSTRAINT_NAME, c.name as COLUMN_NAME, ic.key_ordinal AS ORDINAL_POSITION " & _
    //        '"  from sys.key_constraints as k " & _
    //        '"  join sys.tables as t " & _
    //        '"    on t.object_id = k.parent_object_id " & _
    //        '"  join sys.schemas as s " & _
    //        '"    on s.schema_id = t.schema_id " & _
    //        '"  join sys.index_columns as ic " & _
    //        '"    on ic.object_id = t.object_id " & _
    //        '"   and ic.index_id = k.unique_index_id " & _
    //        '"  join sys.columns as c " & _
    //        '"    on c.object_id = t.object_id " & _
    //        '"   and c.column_id = ic.column_id " & _
    //        '" where k.type = 'PK' " & _
    //        '" and t.name like '{0}'", tabla.nombre)

    //        Try
    //            Dim cmd As New SqlClient.OleDbCommand()
    //            Dim myReader As SqlClient.OleDbDataReader
    //            cmd.Connection = conexion
    //            cmd.CommandType = CommandType.Text



    //            cmd.CommandText = sql
    //            myReader = cmd.ExecuteReader()
    //            Do While myReader.Read()
    //                'MsgBox(myReader.GetString(3))
    //                For Each campo As lb.campo In tabla.campos
    //                    If campo.nombre = myReader.GetString(0) Then
    //                        campo.isKey = True
    //                    End If
    //                Next
    //            Loop


    //            cmd = Nothing
    //            myReader.Close()
    //            myReader = Nothing
    //        Catch ex As Exception

    //        End Try






    //    Next


    //End Function







    //// Retrieve the list of a table's indices.
    //private void GetIndexes(OleDbConnection connection, string tableName, IList<Index> indices)
    //{
    //    String[] restrictions = new string[] { null, null, null, null, tableName };
    //    DataTable schema;
    //    // Open the schema information for the indices.
    //    schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Indexes, restrictions);
    //    // Enumerate the table's indices.
    //    foreach (DataRow row in schema.Rows)
    //    {
    //        // Create a new index.
    //        Index dbIndex = new Index();
    //        // Append the index name.
    //        dbIndex.Name = row["INDEX_NAME"].ToString();
    //        dbIndex.OriginalName = row["INDEX_NAME"].ToString();
    //        // Append the index's uniqueness.
    //        dbIndex.Unique = (bool)row["UNIQUE"];
    //        // Specify the index type. 
    //        dbIndex.IndexType = (bool)row["PRIMARY_KEY"] == true ? IndexType.PrimaryKey : IndexType.Index;
    //        // Create an index column object.
    //        IndexColumn column = new IndexColumn();
    //        column.Name = row["COLUMN_NAME"].ToString();
    //        // Specify whether the index is descending.
    //        column.Descending = (Int32.Parse(row["COLLATION"].ToString()) == 2) ? true : false;
    //        dbIndex.Columns.Add(column);
    //        // Append the index to the list.
    //        indices.Add(dbIndex);
    //    }
    //}

    //// Retrieve the list of a table's foreign keys.
    //private void GetForeignKeys(OleDbConnection connection, string tableName, IList<ForeignKey> foreignKeys)
    //{
    //    String[] restrictions = new string[] { null };
    //    DataTable schema;
    //    // Open the schema information for the foreign keys.
    //    schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions);
    //    // Enumerate the table's foreign keys.
    //    foreach (DataRow row in schema.Rows)
    //    {
    //        ForeignKey dbForeignKey = new ForeignKey();
    //        dbForeignKey.Name = row["FK_NAME"].ToString();
    //        dbForeignKey.OriginalName = row["FK_NAME"].ToString();

    //        dbForeignKey.FKTableName = row["FK_TABLE_NAME"].ToString();
    //        ForeignKeyColumn fkc = new ForeignKeyColumn();
    //        fkc.Name = row["FK_COLUMN_NAME"].ToString();
    //        dbForeignKey.FKColumns.Add(fkc);
    //        dbForeignKey.FKTableSchema = schema.ToString();

    //        dbForeignKey.PKTableName = row["PK_TABLE_NAME"].ToString();
    //        ForeignKeyColumn pkc = new ForeignKeyColumn();
    //        pkc.Name = row["PK_COLUMN_NAME"].ToString();
    //        dbForeignKey.PKColumns.Add(pkc);
    //        dbForeignKey.PKTableSchema = schema.ToString();

    //        foreignKeys.Add(dbForeignKey);
    //    }
    //}






}


