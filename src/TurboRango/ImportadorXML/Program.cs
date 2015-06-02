using System;
using TurboRango.Dominio;

namespace ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            const string nomeArquivo = "restaurantes.xml";

            var rxml = new RestaurantesXML(nomeArquivo);

            var nomes = rxml.ObterNomes();
            var capacidadeMedia = rxml.CapacidadeMedia();
            var capacidadeMaxima = rxml.CapacidadeMaxima();
        }
    }
}
