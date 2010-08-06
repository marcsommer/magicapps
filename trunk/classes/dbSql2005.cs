using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

// http://msdn.microsoft.com/en-us/library/microsoft.web.management.databasemanager.indextype.aspx
    // http://tom-shelton.net/index.php/2009/02/21/exploring-sql-server-schema-information-with-adonet/
// http://www.dotnetbips.com/articles/bcd9065e-94af-4063-8360-f916571f9872.aspx
    
class dbSql2005
    {
        public  SqlConnection conexion;
        public  SqlCommand miComando;
        public  SqlDataReader miLector;
        //public string cadConexion;




        public string test(string cadconexion)
        {
            SqlConnection conexion = null;
            try
            {

            
                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand("");
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
            SqlConnection conexion = null;
            try
            {
                List<table> lista = new List<table>();

                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand("");
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                System.Data.DataTable dt=new System.Data.DataTable();
                dt=conexion.GetSchema( SqlClientMetaDataCollectionNames.Tables, new String[] {null, null, null, null});

                foreach (System.Data.DataRow rowDatabase in dt.Rows)
                {
                    string tableName = rowDatabase["table_name"].ToString();
                    if (tableName.Equals("dtproperties") || tableName.Equals("sysdiagrams"))
                    {
                        // system tables
                    }
                    else
                    {
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

            SqlConnection conexion = null;

            try
            {


                List<field> lista = new List<field>();


                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand("");
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.GetSchema(SqlClientMetaDataCollectionNames.Columns, new String[] { null, null, table, null });

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
                            fi.type = field.fieldType._double;
                            break;

                        case "float":
                            fi.type = field.fieldType._double;
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

                        case "uniqueidentifier":
                            fi.type = field.fieldType._uniqueidentifier;
                            break;
                        case "decimal":
                            fi.type = field.fieldType._decimal;
                            break;

                        default:
                            fi.type = field.fieldType._string;
                            break;
                    }

                    fi.targetType = fi.type;





                    fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);
                    fi.size = sf.entero(row["CHARACTER_MAXIMUM_LENGTH"]);
                    //     fi.comment = sf.Cadena(tbl.Rows(i)!COLUMN_COMMENT);
                    fi.defaultValue = sf.cadena(row["COLUMN_DEFAULT"]);

                    if (fi.defaultValue.Equals("-1"))
                        fi.defaultValue = "0";

                    //if (fi.defaultValue.Equals("(getdate())"))
                    //    fi.defaultValue = "0";

                    //if (sf.cadena(row["COLUMN_DEFAULT"]).IndexOf("getdate()") != -1)
                    //    fi.defaultValue = "0";

                    //fi.autoNumber = sf.boolean(row["COLUMN_KEY"]);
                    //   fi.isKey = sf.boolean(row["COLUMN_KEY"]);
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
                    //fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);//tbl.Rows(i)!IS_NULLABLE)
                    //     fi.defaultValue = sf.Cadena(tbl.Rows(i)!COLUMN_DEFAULT)
                    //     fi.autoNumber = sf.boolean(tbl.Rows(i)!COLUMN_KEY)
                    //     fi.decimals = sf.Entero(tbl.Rows(i)!NUMERIC_PRECISION)



                    // lets get the comment
                    fi.comment = getComments(cadconexion, table, fi.Name);
                    if (fi.comment.IndexOf("#image#") >= 1)
                    {
                        fi.targetType = field.fieldType._image;
                        fi.comment=fi.comment.Replace("#image#", "");
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



        public void getKeys(string cadconexion,   table table)
        {
            SqlConnection conexion = null;
            try
            {
                List<String> lista = new List<String>();
                String sql = null;
                sql = String.Format(@" SELECT INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME AS TABLE_NAME,
                        INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME AS COLUMN_NAME, 
                        REPLACE(INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE,' ', '_') AS CONSTRAINT_TYPE 
                        , INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME
                    FROM 
                        INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ON 
                        INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME = 
                        INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME 
                    WHERE 
                        INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME <> N'sysdiagrams'  and
	                    INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME = '{0}' 
                    ORDER BY 
                        INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME ASC", table.Name);


                // esta sql nos da los primary key y los foreign key...
               


                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand(sql);
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                 SqlDataReader dr = null;
                dr = miComando.ExecuteReader();

                while (dr.Read())
                {
                    String tipo = sf.cadena(dr["CONSTRAINT_TYPE"]);
                    String campo = sf.cadena(dr["COLUMN_NAME"]);
                    String comentario = getComments(cadconexion, table.Name, campo);

                    switch (tipo)
                    {
                        case "PRIMARY_KEY":
                            foreach (field fi in table.fields)
                            {
                                if (fi.Name.Equals(campo))
                                {
                                    fi.isKey = true;
                                    table.keyFields.Add(fi);
                                    if (table.GetKey == "")
                                        table.GetKey = campo;
                                }

                            }
                            break;
                        case "FOREIGN_KEY":
                            foreach (field fi in table.fields)
                            {
                                if (fi.Name.Equals(campo))
                                {
                                    fi.isForeignKey = true;
                                    table.notKeyFields.Add(fi);
                                }

                            }
                            break;
                        default:

                            foreach (field fix in table.fields)
                            {
                                if (fix.Name.Equals(campo))
                                {
                                    table.notKeyFields.Add(fix);
                                }
                            }
                            break;
                    }

                    foreach (field fi in table.fields)
                    {

                        if (fi.Name.Equals(campo))
                        {


                            fi.comment = comentario;
                            if (comentario.Contains("#img#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#img#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.targetType = field.fieldType._image;
                            }
                            if (comentario.Contains("#audio#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#audio#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.targetType = field.fieldType._audio;
                            }
                            if (comentario.Contains("#money#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#money#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.targetType = field.fieldType._money;
                            }
                            if (comentario.Contains("#video#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#video#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.targetType = field.fieldType._video;
                            }
                            if (comentario.Contains("#doc#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#doc#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.targetType = field.fieldType._document;
                            }
                            if (comentario.Contains("#desc#"))
                            {
                                comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#desc#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                fi.isDescriptionInCombo = true;
                                table.fieldDescription = fi.Name;
                            }

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
        public List<relation> getRelations(string cadconexion )
        {
            SqlConnection conexion = null;
            try
            {

                 List<relation> lista = new List<relation>();

                 String sql = @"SELECT tablesA.name AS ParentTable, columnsA.name AS ParentPK, tablesB.name AS ReferencedTable, columnsB.name AS ReferencedFK
                            FROM sys.foreign_key_columns
                            INNER JOIN sys.columns AS columnsA
                            ON sys.foreign_key_columns.parent_object_id = columnsA.object_id
                            AND sys.foreign_key_columns.parent_column_id = columnsA.column_id
                            INNER JOIN sys.columns AS columnsB
                            ON sys.foreign_key_columns.referenced_object_id = columnsB.object_id
                            AND sys.foreign_key_columns.referenced_column_id = columnsB.column_id
                            INNER JOIN sys.tables AS tablesA
                            ON sys.foreign_key_columns.parent_object_id = tablesA.object_id
                            INNER JOIN sys.tables AS tablesB
                            ON sys.foreign_key_columns.referenced_object_id = tablesB.object_id ";


                 conexion = new SqlConnection(cadconexion);
                 miComando = new SqlCommand(sql);
                 miComando.Connection = conexion;
                 conexion.ConnectionString = cadconexion;
                 conexion.Open();

                // System.Data.DataTable dt = new System.Data.DataTable();
                 miLector = miComando.ExecuteReader();
 
               while (miLector.Read() )
	{
	         relation rel = new relation();

                     rel.name = sf.cadena(miLector["ParentTable"]) + "_" +  sf.cadena(miLector["ReferencedTable"]) ;
                     rel.parentTable = sf.cadena(miLector["ParentTable"]);
                     rel.parentField = sf.cadena(miLector["ParentPK"]);

                     rel.childTable = sf.cadena(miLector["ReferencedTable"]);
                     rel.childField = sf.cadena(miLector["ReferencedFK"]); 

                   

                     //                descripcion = schemaTable.Rows(i)("PK_NAME").ToString

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

        public List<relation> getRelations(string cadconexion, string table)
        {
            SqlConnection conexion = null;
            try
            {

                 List<relation> lista = new List<relation>();

           
                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand("");
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.GetSchema(SqlClientMetaDataCollectionNames.ForeignKeys, new String[] { null, null, table, null });

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    relation rel = new relation();

              //      rel.name = sf.cadena(row["FK_NAME"]); 
//                descripcion = schemaTable.Rows(i)("PK_NAME").ToString

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

            SqlConnection conexion = null;
            try
            {

                List<String> lista = new List<String>();
                String sql = null;
                sql = String.Format("select value from ::fn_listextendedproperty ('MS_Description', 'user','dbo', 'table', '{0}', 'column', '{1}')", table, column);


                conexion = new SqlConnection(cadconexion);
                miComando = new SqlCommand(sql);
                miComando.Connection = conexion;
                conexion.ConnectionString = cadconexion;
                conexion.Open();

                SqlDataReader dr = null;
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

 
