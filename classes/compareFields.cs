using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
using System.Collections;



// esta clase nos permite ordenar los campos de una tabla por dos metodos distintos para ordenarlos 
// primero por la clave y luego alfabeticamente...
 
    class compareFields :IComparer
    {
        public enum  CompareByOptions
        {
            key=1,
            name=2
        }

        private CompareByOptions cmp;

        public compareFields(CompareByOptions comp)
		{
            cmp = comp;
			
		}


        // para poder ordenar...
        public int Compare(object obj, object obj2)
        {
            field campo1 = (field)obj;
            field campo2 = (field)obj2;

            switch (cmp)
            {
                case CompareByOptions.key:
                    if (campo1.isKey)
                        return -1;
                    else
                        return 0;
                    break;
                case CompareByOptions.name:
                    return string.Compare(campo1.Name, campo2.Name);
                    break;
                default:
                    return 0;
                    break;
            }


             return 0;
        }


        // para poder ordenar...
        public int CompareTo(object obj)
        {
             
            return 0;

        }



    }
 
