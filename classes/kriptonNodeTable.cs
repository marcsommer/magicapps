using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace myWay.classes
{
    class kriptonNodeTable : ComponentFactory.Krypton.Toolkit.IContentValues
    {

        // funciones generales...


        public string GetLongText()
        {
            return "";
        }

        public string GetShortText()
        {
            return "";
        }

        public Image GetImage(PaletteState state)
        {
            return null;
        }

        public Color GetImageTransparentColor(PaletteState state)
        {
            return Color.AliceBlue;
        }


        //Image GetImage(PaletteState state);
        //Color GetImageTransparentColor(PaletteState state);
        //string GetLongText();
        //string GetShortText();

    }                       




        
    
}
