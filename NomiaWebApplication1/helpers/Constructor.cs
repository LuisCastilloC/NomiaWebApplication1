using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomiaWebApplication1.helpers
{
    public class Constructor
    {
        private static Constructor instance;
        public Constructor()
        {

        }
        public static Constructor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Constructor();
                }

                return instance;
            }
        }

        public Registros.Empleados.registro empleado
        {
            get
            {
                return new Registros.Empleados.registro();
            }
        }
    }
}