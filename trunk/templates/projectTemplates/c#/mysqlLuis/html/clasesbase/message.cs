using System;
using System.Collections.Generic;
using System.Web;

namespace juleweb
{
    public class message
    {
        private string _text;
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }


        public enum typeOfMessage
        {
            info = 1,
            error = 2,
            success = 3
        }

        private typeOfMessage _type;
        public typeOfMessage type
        {
            get { return _type; }
            set { _type = value; }
        }


        public message(string textx, typeOfMessage typex)
        {
            this.text = textx;
            this.type = typex;
        }

    }
}
