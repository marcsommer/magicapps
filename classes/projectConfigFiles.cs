
using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using MySql.Data.MySqlClient;   
using System.ComponentModel;


[System.ComponentModel.DataObject]
public partial class projectconfigfiles
{
    #region["Variables"]


    private string _Name;
    private string _Directory;
    private string _Description;
    private string _Image;
    private string _Url;

    #endregion


    #region["Propiedades"]

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Directory
    {
        get { return _Directory; }
        set { _Directory = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }

    public string Url
    {
        get { return _Url; }
        set { _Url = value; }
    }


    #endregion

    public projectconfigfiles()
    {
    }

    public string toString()
    {
        return _Name;
    }

}