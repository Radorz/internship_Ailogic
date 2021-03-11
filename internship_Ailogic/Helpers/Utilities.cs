using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internship_Ailogic.Helpers
{
    public class Utilities
    {

       public string CreatePassword(string name, string lastname, string cedula ,DateTime date)
       {
            string password = name.Substring(0, 3)
                + lastname.Substring(0, 3)
                + cedula.Substring(4, 3)
                + Convert.ToString(date).Substring(0, 6);
            return password;
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
