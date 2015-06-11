using System;
using TurboRango.Dominio;

namespace TurboRango.Web.Models
{
    public class Reservas : Entidade
    {
        public String Usuario { get; set; }
        public String Restaurante { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
    }
}