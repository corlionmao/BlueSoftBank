using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSoftBank.BussinessLogic
{
    public class Servicios
    {
        public Servicios() { }

        public List<Cliente> ClientesConMayorNumeroDeMovimientosEnMes(int mes, int año)
        {
            var movimientosPorCliente = Cuentas
                .SelectMany(cuenta => cuenta.Movimientos)
                .Where(movimiento => movimiento.Fecha.Month == mes && movimiento.Fecha.Year == año)
                .GroupBy(movimiento => movimiento.Cliente)
                .Select(grupo => new
                {
                    Cliente = grupo.Key,
                    NumeroDeMovimientos = grupo.Count()
                })
                .OrderByDescending(grupo => grupo.NumeroDeMovimientos)
                .ToList();

            if (movimientosPorCliente.Count == 0)
                return new List<Cliente>();

            int maxMovimientos = movimientosPorCliente.First().NumeroDeMovimientos;

            return movimientosPorCliente
                .Where(grupo => grupo.NumeroDeMovimientos == maxMovimientos)
                .Select(grupo => grupo.Cliente)
                .ToList();
        }

        public List<Cliente> ClientesConRetirosFueraDeCiudadYValorMayorA(decimal montoMinimo)
        {
            var retirosFueraDeCiudad = Cuentas
                .SelectMany(cuenta => cuenta.Movimientos)
                .Where(movimiento =>
                    movimiento.TipoMovimiento == "Retiro" &&
                    movimiento.Monto > montoMinimo &&
                    movimiento.Cliente != null &&
                    movimiento.Sucursal != null &&
                    movimiento.Cliente != null &&
                    movimiento.Sucursal.Ciudad != cuenta.Sucursal.Ciudad)
                .GroupBy(movimiento => movimiento.Cliente)
                .Select(grupo => new
                {
                    Cliente = grupo.Key,
                    TotalRetiros = grupo.Sum(movimiento => movimiento.Monto)
                })
                .Where(grupo => grupo.TotalRetiros > montoMinimo)
                .Select(grupo => grupo.Cliente)
                .Distinct()
                .ToList();

            return retirosFueraDeCiudad;
        }
    }
}
