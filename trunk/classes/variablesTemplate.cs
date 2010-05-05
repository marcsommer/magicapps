using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class variablesTemplate
{

    #region["Variables"]



    private string _namefile;


    private string _extensionFile;


    private string _languageGenerated;


    private string _description;


    private string _targetDirectory;


    private string _appliesToAllTables;


    private string _apliesToModel;


    private string _apliesToView;


    private string _apliesToController;


    #endregion


    #region["Propiedades"]


    public string namefile
    {
        get { return _namefile; }
        set { _namefile = value; }
    }

    public string extensionFile
    {
        get { return _extensionFile; }
        set { _extensionFile = value; }
    }

    public string languageGenerated
    {
        get { return _languageGenerated; }
        set { _languageGenerated = value; }
    }

    public string description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string targetDirectory
    {
        get { return _targetDirectory; }
        set { _targetDirectory = value; }
    }

    public string appliesToAllTables
    {
        get { return _appliesToAllTables; }
        set { _appliesToAllTables = value; }
    }

    public string apliesToModel
    {
        get { return _apliesToModel; }
        set { _apliesToModel = value; }
    }

    public string apliesToView
    {
        get { return _apliesToView; }
        set { _apliesToView = value; }
    }

    public string apliesToController
    {
        get { return _apliesToController; }
        set { _apliesToController = value; }
    }


    #endregion


    public variablesTemplate()
    {
    }


}
 
