using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace Util
{
    public class JQueryUtils
    {
        public static void RegisterTextBoxForDatePicker(Page page, params TextBox[] textBoxes)
        {
            RegisterTextBoxForDatePicker(page, "dd-mm-yy", textBoxes);
        }

        public static void RegisterTextBoxForDatePicker(Page page, string format, params TextBox[] textBoxes)
        {
            bool allTextBoxNull = true;
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox != null) allTextBoxNull = false;
            }

            if (allTextBoxNull) return;

            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery", "../../JQuery/jquery-1.4.2.js");
            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery.ui.all", "../../JQuery/ui/jquery.ui.core.js");
            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery.ui.widget", "../../JQuery/ui/jquery.ui.widget.js");
            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery.ui.datepicker", "../../JQuery/ui/jquery.ui.datepicker.js");
            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery.ui.datepicker-es", "../../JQuery/jquery.ui.datepicker-es.js");
          
            // style ..
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "datepickerCss", "<link  rel=\"stylesheet\" href=\"../../JQuery/themes/start/jquery.ui.all.css\" />");
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "datepickerCss", "<link  rel=\"stylesheet\" href=\"../../JQuery/themes/start/jquery.ui.datepicker.css\" />");
            
            StringBuilder sb = new StringBuilder();

            sb.Append("$(document).ready(function() {");

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox != null)
                {
                    // ejemplos en
                    // http://www.esasp.net/2009/09/jquery-ui-datepicker-o-selector-de.html
                   
                    // to show month and year
                      sb.Append("$('#" + textBox.ClientID + "').datepicker({showButtonPanel: true,changeMonth: true,changeYear: true});");
                  
                    // para poner la fecha en formato 22-22-2222
                   // sb.Append("$('#" + textBox.ClientID + "').datepicker({dateFormat: \"" + format + "\"});");

                   

                }
            }

            sb.Append("});");

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "jQueryScript", sb.ToString(), true);
        }


        // uso: Util.JQueryUtils.jGrowl(this, "perico");
        public static void jGrowl (Page page, string cadena)
        {

            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery13", "/JQuery/jGrowl/jquery-1.3.2.js");
            page.ClientScript.RegisterClientScriptInclude(page.GetType(), "jquery.jgrowl.js", "/JQuery/jGrowl/jquery.jgrowl.js");
           
            // style ..
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "jquery.jgrowl.css", "<link  rel=\"stylesheet\" href=\"/JQuery/jGrowl/jquery.jgrowl.css\" />");
                        
            StringBuilder sb = new StringBuilder();

            sb.Append("$(document).ready(function() {");
            sb.Append("$.jGrowl('" + cadena + "');");
            sb.Append("});");

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "jQueryScript", sb.ToString(), true);
        }

    }

}
