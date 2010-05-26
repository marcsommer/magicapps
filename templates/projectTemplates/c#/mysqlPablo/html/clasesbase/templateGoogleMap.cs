
using System.Web.UI; // ITemplate
using System.Web.UI.HtmlControls;
using Artem.Web.UI;
using System.Collections.Generic; // List


internal class templateGoogleMap : ITemplate
{



    private portales _port;
    public portales port
    {
        get { return _port; }
        set { _port = value; }
    }

    private string _idportal;
    public string idportal
    {
        get { return _idportal; }
        set { _idportal = value; }
    }


    public void InstantiateIn(System.Web.UI.Control container)
    {

        HtmlGenericControl h2 = new HtmlGenericControl("h2");
        string datoextra = "";
        string fechas = "";
 
        
        //if (eventox.fecha > System.DateTime.Now)
                    //torneo futuro
        h2.InnerHtml = port.nombre;

        container.Controls.Add(h2);

        HtmlGenericControl p = new HtmlGenericControl("p");

     //   fechas = "Del " + eventox.fecha.ToLongDateString() + " al " + eventox.fechafin.ToLongDateString();
            
        string cadenaHtml = @"
            {0} <br/>
            {1}({2})<br/>
            <br/>
            ";

 
        string cadenaHtmlFinal = string.Format(cadenaHtml,  port.direccion,sf.cadena(port.localidad), sf.cadena(provincias.getprovincias(port.idProvincias).nombre) );
        p.InnerHtml = cadenaHtmlFinal;
        container.Controls.Add(p);


        //HtmlGenericControl detalleFichas = new HtmlGenericControl("p");
        //detalleFichas.InnerHtml = "<h3>Fichas disponibles para este recurso:</h3></br>";
        //container.Controls.Add(detalleFichas);
        //List<fichas> listaFichas = fichas.getListByIdCuestionarios(sf.cadena(cuestionario.idCuestionarios));
        //foreach (fichas tix in listaFichas)
        //{
        //    //HtmlGenericControl ficha = new HtmlGenericControl("p");
        //    detalleFichas.InnerHtml += "" + tix.nombre + "</br>";
        //    //container.Controls.Add(ficha);
        //}
    }

}
