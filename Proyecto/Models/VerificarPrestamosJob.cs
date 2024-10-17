using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Proyecto.Interfaces;

namespace Proyecto.Models
{
    public class VerificarPrestamosJob : IJob
    {   
        private readonly IRepoPrestamo _repoPrestamo;

        public VerificarPrestamosJob(IRepoPrestamo repoPrestamo)
        {
            _repoPrestamo = repoPrestamo;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var prestamosVencidos = _repoPrestamo.SelectWhere(p => !p.Recibido && !p.Cancelado && p.Salida.Value.AddDays(30) < DateTime.Now).ToList();

            foreach (var prestamo in prestamosVencidos)
            {
                prestamo.Cancelado = true;
                _repoPrestamo.Update(prestamo);
            }

            return Task.CompletedTask;
        }
    }
}
