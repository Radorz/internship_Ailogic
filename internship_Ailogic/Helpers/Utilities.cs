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
            if (cedula.Contains("-") && cedula.Length == 13)
            {
                return cedula;
            }
             else if(cedula.Length == 11 && !cedula.Contains("-"))
            {
                cedula.Insert(2, "-");
                cedula.Insert(11, "-");
                return cedula;
            }
            else
            {
                return "Invalid Cedula";
            }
       }

        public string FormatPhone(string phone)
        {
            if (phone.Contains("-") && phone.Length == 12)
            {
                return phone;
            }
            else if (phone.Length == 10 && !phone.Contains("-"))
            {
                phone.Insert(3, "-");
                phone.Insert(7, "-");
                return phone;
            }
            else
            {
                return "Invalid Phone";
            }
        }





    }
}
