using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSoftBank.BussinessLogic
{
    public abstract class Cuenta
    {
        private string id;
        private Decimal saldo;
        private List<Movimientos> movimientos;
        private Cliente cliente;
        private Sucursal sucursal;

        public string Id { get => id; set => id = value; }
        public Decimal Saldo { get => saldo; set => saldo = value; }
        public List<Movimientos> Movimientos { get => movimientos; set => movimientos = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Sucursal Sucursal { get => sucursal; set => sucursal = value; }

        protected Cuenta(string id, decimal saldo, List<Movimientos> movimientos, Cliente cliente, Sucursal sucursal)
        {
            this.id = id;
            this.saldo = saldo;
            this.movimientos = movimientos;
            this.cliente = cliente;
            this.sucursal = sucursal;
        }

        public void Deposito(Decimal monto)
        {
            Saldo += monto;
            Movimientos.Add(new BussinessLogic.Movimientos());
        }

        public void Retiro(Decimal monto)
        {
            if (Saldo < monto)
            {
                throw new Exception("No hay fondos suficientes en su cuenta");
            }
            Saldo += monto;
            Movimientos.Add(new BussinessLogic.Movimientos());
        }

        public Decimal ConsultarSaldo()
        {
            return saldo;
        }


    }
}
