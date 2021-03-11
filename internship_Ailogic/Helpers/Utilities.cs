using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internship_Ailogic.Helpers
{
    public class Utilities
    {

       public string CreatePassword()
       {
            return "Password12345*";
       }


       public string FormatCedula(string cedula)
       {
            if (cedula.Length == 13)
            {
                return cedula;
            }
            else
            {
                cedula.Insert(2, "-");
                cedula.Insert(11, "-");
                return cedula;
            }
       } 
        




    }
}
