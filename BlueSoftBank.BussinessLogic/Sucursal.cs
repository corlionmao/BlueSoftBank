using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSoftBank.BussinessLogic
{
    public class Sucursal
    {
        private string nombre;
        private int codigo;
        private Ciudad ciudad;

        public Sucursal(string nombre, int codigo, Ciudad ciudad)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.ciudad = ciudad;
        }
    }
}
