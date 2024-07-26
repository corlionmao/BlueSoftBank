using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSoftBank.BussinessLogic
{
    public class Consultas
    {
        public List<Movimientos> ObtenerExtractoMensual(Cliente cliente, int mes, int año)
        {
            var cuenta = Cuenta.FirstOrDefault(c => c.Cliente.Id == cliente.Id);
            if (cuenta == null) return new List<Movimientos>();

            return cuenta.Movimientos
                         .Where(mov => mov.Fecha.Month == mes && mov.Fecha.Year == año)
                         .OrderBy(mov => mov.Fecha)
                         .ToList();
        }

        // Método para obtener los últimos movimientos
        public List<Movimientos> ObtenerUltimosMovimientos(Cliente cliente, int numeroMovimientos)
        {
            var cuenta = Cuenta.FirstOrDefault(c => c.Cliente.Id == cliente.Id);
            if (cuenta == null) return new List<Movimientos>();

            return cuenta.Movimientos
                         .OrderByDescending(mov => mov.Fecha)
                         .Take(numeroMovimientos)
                         .ToList();
        }
    }
}
