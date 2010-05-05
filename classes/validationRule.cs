using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class validationRule
{

    public enum typeOfValidation
    {
        Alphanumeric,
        Between,
        Blank,
        Comparison,
        CreditCard,
        Custom,
        Date,
        Decimal,
        Email,
        ExactlyEqual,
        Extension,
        File,
        IP,
        MaxLength,
        MinLength,
        Money,
        Multiple,
        Numeric,
        Phone,
        Postal,
        SSN,
        Url,
        UserDefined
    }


    #region["Variables"]


    private string _name;
    private string _check;
    private string _regex;
    private string _pattern;
    private string _country;
    private string _deep;
    private string _type;
    private string _errors;

    private bool _Required;

    private bool _Allow_Blank;

    private bool _On;
    private string _Message;
    private int _validationType;

    #endregion


    #region["Propiedades"]

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string check
    {
        get { return _check; }
        set { _check = value; }
    }
    public string regex
    {
        get { return _regex; }
        set { _regex = value; }
    }
    public string pattern
    {
        get { return _pattern; }
        set { _pattern = value; }
    }
    public string country
    {
        get { return _country; }
        set { _country = value; }
    }
    public string deep
    {
        get { return _deep; }
        set { _deep = value; }
    }
    public string type
    {
        get { return _type; }
        set { _type = value; }
    }
    public string errors
    {
        get { return _errors; }
        set { _errors = value; }
    }

    public bool Required
    {
        get { return _Required; }
        set { _Required = value; }
    }

    public bool Allow_Blank
    {
        get { return _Allow_Blank; }
        set { _Allow_Blank = value; }
    }

    public bool On
    {
        get { return _On; }
        set { _On = value; }
    }
    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }
    public int validationType
    {
        get { return _validationType; }
        set { _validationType = value; }
    }
    


    #endregion


}
 
