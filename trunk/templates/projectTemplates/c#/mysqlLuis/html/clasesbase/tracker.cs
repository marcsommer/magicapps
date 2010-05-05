using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Collections.Generic;

 
	 
    // vamos a implementar una lifo en la session
    public class tracker
    {
         public static Stack getLifo()
         {
             if (HttpContext.Current.Session["lifo"] != null)
             {
                 return (Stack)HttpContext.Current.Session["lifo"];
             }
             else
             {
                 return null;
             }
         }



        public static Boolean push(track traki)
        {
            if (HttpContext.Current.Session["lifo"] != null)
            { 
                ((Stack)HttpContext.Current.Session["lifo"]).Push(traki);
                 return true;
            }
            else
            {
                // creamos la stack
                Stack sta = new Stack();
                HttpContext.Current.Session["lifo"] = sta;
                ((Stack)HttpContext.Current.Session["lifo"]).Push(traki);
               
                return false;
            }
        }


        public static track pop()
        {
             
            if (HttpContext.Current.Session["lifo"] != null)
            {
                if (((Stack)HttpContext.Current.Session["lifo"]).Count > 0)
                {
                    return (track)((Stack)HttpContext.Current.Session["lifo"]).Pop();
                }
                else
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }

        }

	
        public tracker()
    {

    }
        

    }


    public class track
    {
        private String _url;

        public String url
        {
            get { return _url; }
            set { _url = value; }
        }

        private String _campo;

        public String campo
        {
            get { return _campo; }
            set { _campo = value; }
        }


        private String _valor;

        public String valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public track()
        {
        }

        public track(String url, String campo, String valor)
        {
            this._url = url;
            this._campo = campo;
            this._valor = valor;
        }
    }
 