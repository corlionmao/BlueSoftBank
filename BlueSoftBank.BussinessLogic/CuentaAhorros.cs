using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSoftBank.BussinessLogic
{
    public class CuentaAhorros : Cuenta
    {
        public CuentaAhorros()
        {
        }

        public CuentaAhorros(string id, decimal saldo, List<Movimientos> movimientos, Cliente cliente, Sucursal sucursal) : base(id, saldo, movimientos, cliente, sucursal)
        {
        }
    }
}
