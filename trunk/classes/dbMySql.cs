using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

// http://msdn.microsoft.com/en-us/library/microsoft.web.management.databasemanager.indextype.aspx
    // http://tom-shelton.net/index.php/2009/02/21/exploring-sql-server-schema-information-with-adonet/
// http://www.dotnetbips.com/articles/bcd9065e-94af-4063-8360-f916571f9872.aspx
    
class dbMySql
    {
        public MySql.Data.MySqlClient.MySqlConnection conexion;
        public MySql.Data.MySqlClient.MySqlCommand miComando;
        public MySql.Data.MySqlClient.MySqlDataReader  miLector;
      


        public string test(string cadconexion)
        {
            MySqlConnection conexion = null;
            try
            {
                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand("");
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
            MySqlConnection conexion = null;
            try
            {
                List<table> lista = new List<table>();

                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand("");
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                System.Data.DataTable dt=new System.Data.DataTable();
                dt = conexion.GetSchema("Tables", new String[] { null, database, null, null });
               

                foreach (System.Data.DataRow rowDatabase in dt.Rows)
                {
                    table tab=new table();
                    tab.Name = rowDatabase["table_name"].ToString();
                    tab.TargetName = tab.Name;
                    lista.Add(tab);

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



        public List<field> getFields(string cadconexion, string database, string table)
        {
            MySqlConnection conexion = null;
            try
            {

                //   ' ESTO SERIA PARA LA TABLA COMMENTS
                //' PARA SACARLO CON SQL...
                // SELECT *, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS  where table_name = 'cars'

                List<field> lista = new List<field>();

                // Retrieve a list of primary keys for a table.
                //List<String> primaryKeys = getKeys(cadconexion, table);

                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand("");
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.GetSchema("Columns", new String[] { null, database, table, null });

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    field fi = new field();
                    fi.Name = row[3].ToString();
                    fi.targetName = row[3].ToString();

                    string tipo = null;
                    tipo = row[7].ToString();
                    switch (tipo)
                    {
                        case "text":
                            fi.type = field.fieldType._string;
                            break;

                        case "char":
                            fi.type = field.fieldType._string;
                            break;

                        case "nchar":
                            fi.type = field.fieldType._string;
                            break;

                        case "varchar":
                            fi.type = field.fieldType._string;
                            break;

                        case "nvarchar":
                            fi.type = field.fieldType._string;
                            break;
                        case "binary":
                            fi.type = field.fieldType._string;
                            break;

                        case "varbinary":
                            fi.type = field.fieldType._string;
                            break;


                        case "mediumint":
                            fi.type = field.fieldType._integer;
                            break;

                        case "smallint":
                            fi.type = field.fieldType._integer;
                            break;

                        case "int":
                            fi.type = field.fieldType._integer;
                            break;

                        case "numeric":
                            fi.type = field.fieldType._integer;
                            break;

                        case "tinyint":
                            fi.type = field.fieldType._boolean;
                            break;

                        case "bit":
                            fi.type = field.fieldType._boolean;
                            break;

                        case "bigint":
                            fi.type = field.fieldType._doble;
                            break;

                        case "float":
                            fi.type = field.fieldType._doble;
                            break;

                        case "smalldatetime":
                            fi.type = field.fieldType._date;
                            break;

                        case "datetime":
                            fi.type = field.fieldType._date;
                            break;

                        case "date":
                            fi.type = field.fieldType._date;
                            break;

                        case "timestamp":
                            fi.type = field.fieldType._date;
                            break;

                        default:
                            fi.type = field.fieldType._string;
                            break;
                    }

                    fi.targetType = fi.type;





                    fi.allowNulls = sf.Bool(row["IS_NULLABLE"]);
                    fi.size = sf.entero(row["CHARACTER_MAXIMUM_LENGTH"]);
                    //     fi.comment = sf.Cadena(tbl.Rows(i)!COLUMN_COMMENT);
                    fi.defaultValue = sf.cadena(row["COLUMN_DEFAULT"]);


                    //try
                    //{
                    //    if (primaryKeys.Contains(fi.Name))
                    //    {
                    //        fi.isKey = true;
                    //        // fi.autoNumber = true;
                    //    }
                    //}
                    //catch (Exception)
                    //{


                    //}

                    //fi.autoNumber = sf.Bool(row["COLUMN_KEY"]);
                    //   fi.isKey = sf.Bool(row["COLUMN_KEY"]);
                    fi.decimals = sf.entero(row["NUMERIC_PRECISION"]);

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
                    //fi.allowNulls = sf.Bool(row["IS_NULLABLE"]);//tbl.Rows(i)!IS_NULLABLE)
                    //     fi.defaultValue = sf.Cadena(tbl.Rows(i)!COLUMN_DEFAULT)
                    //     fi.autoNumber = sf.Bool(tbl.Rows(i)!COLUMN_KEY)
                    //     fi.decimals = sf.Entero(tbl.Rows(i)!NUMERIC_PRECISION)


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
        }  // getFields


    // we get extra information for the fields...
        public void getKeys(string cadconexion, table table, String database)
        {
            MySqlConnection conexion = null;
            try
            {
                List<String> lista = new List<String>();
                String sql = null;
               //sql = String.Format("SELECT  table_name, column_name, constraint_name, referenced_table_name, referenced_column_name FROM information_schema.key_column_usage WHERE TABLE_NAME = '{0}' ", table);
                sql = String.Format("SELECT  * FROM information_schema.columns WHERE TABLE_NAME = '{0}' and TABLE_SCHEMA= '{1}'", table.Name, database);

                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand(sql);
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                MySql.Data.MySqlClient.MySqlDataReader dr = null;
                dr = miComando.ExecuteReader();

                while (dr.Read())
                {
                    String tipo = sf.cadena(dr["COLUMN_KEY"]);
                    String campo = sf.cadena(dr["COLUMN_NAME"]);
                    String comentario = sf.cadena(dr["COLUMN_COMMENT"]);
                    String defecto = sf.cadena(dr["COLUMN_DEFAULT"]);
                    bool isNullable = sf.Bool(dr["is_nullable"]);
                    int  maximumLength= sf.entero(dr["character_maximum_length"]);

                    switch (tipo)
                    {
                        case "PRI":
                            foreach (field fi in table.fields)
                            {
                                if (fi.Name.Equals(campo))
                                {
                                    fi.isKey = true;
                                    if (table.GetKey==null)
                                        table.GetKey = campo;
                                }
                                    
                            }
                            break;
                        case "MUL":
                            foreach (field fi in table.fields)
                            {
                                if (fi.Name.Equals(campo))
                                    fi.isForeignKey = true;
                            }
                            break;
                        default:
                            break;
                    }

                    // ahora rellenamos los valores extra
                    foreach (field fi in table.fields)
                    {
                        if (fi.Name.Equals(campo))
                        {
                            fi.comment = comentario;
                            fi.defaultValue = defecto;
                            fi.allowNulls = isNullable;
                            fi.size = maximumLength;
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




        public List<relation> getRelations(string cadconexion, string database)
        {
            MySqlConnection conexion = null;
            try
            {

                List<relation> lista = new List<relation>();


                string sql = @"SELECT * FROM information_schema.key_column_usage
 where constraint_schema = '{0}'
 and referenced_table_name <> ''";

                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand(string.Format(sql,database));
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                // System.Data.DataTable dt = new System.Data.DataTable();
                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                {
                    relation rel = new relation();

                    rel.name = sf.cadena(miLector["constraint_name"]) ;
                  
                    rel.parentTable = sf.cadena(miLector["referenced_table_name"]);
                    rel.parentField = sf.cadena(miLector["referenced_column_name"]);

                    rel.childTable = sf.cadena(miLector["table_name"]);
                    rel.childField = sf.cadena(miLector["column_name"]);                
                

                    lista.Add(rel);
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
        }   // getRelations



        // get the description for a column
        public String getComments(string cadconexion, string table, string column)
        {
            MySqlConnection conexion = null;
            try
            {

                List<String> lista = new List<String>();
                String sql = null;
                sql = String.Format("select value from ::fn_listextendedproperty ('MS_Description', 'user','dbo', 'table', '{0}', 'column', '{1}')", table, column);


                conexion = new MySqlConnection(cadconexion);
                miComando = new MySqlCommand(sql);
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                MySqlDataReader dr = null;
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
                conexion.Close();
            }
        }  // getComments



    // -----------------------------------------------------------------------
    // code to copy




    // Public Function getkeys(ByRef conexion As MySql.Data.MySqlClient.SqlConnection, ByVal database As String, ByVal mostrarLog As Boolean)
 
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
    //            Dim cmd As New SqlClient.SqlCommand()
    //            Dim myReader As SqlClient.SqlDataReader
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

 
