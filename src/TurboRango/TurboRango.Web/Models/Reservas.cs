using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TurboRango.Dominio;

namespace TurboRango.Web.Models
{
    public class Reservas : Entidade
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public String Usuario { get; set; }
        public String Restaurante { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public IEnumerable<SelectListItem> ListaRestaurantes { get; set; }

        public Reservas()
        {
            this.Dia = DateTime.Now.Date;
            this.Inicio = DateTime.Now.TimeOfDay;
        }
    }
}