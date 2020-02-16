using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Registro
{
    public class SeguridadBL
    {

        public bool Autenticar(string usuario, string contrasena)
        {
            if(usuario == "admin" && contrasena == "1234")
            {
                return true;
            }else
            {
                if(usuario == "admin2" && contrasena == "5678")
                {
                    return true;
                }
            }
            return false;
        }

        /*public class Usuario
        {
            public string Nombre { get; set; }
            public string Contrasena { get; set; }

        }
        */
    }
}
