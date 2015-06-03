using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TurboRango.Dominio;

namespace ImportadorXML
{
    public class RestaurantesXML
    {
        public string NomeArquivo { get; private set; }
        IEnumerable<XElement> restaurantes;
        IEnumerable<XElement> localizacao;
        IEnumerable<XElement> contato;

        /// <summary>
        /// CONSTRÓI RestaurantesXML
        /// </summary>
        /// <param name="nomeArquivo"></param>
        public RestaurantesXML(string nomeArquivo)
        {
            this.NomeArquivo = nomeArquivo;
            restaurantes = XDocument.Load(NomeArquivo).Descendants("restaurante");
            localizacao = XDocument.Load(NomeArquivo).Descendants("restaurante").Descendants("localizacao");
            contato = XDocument.Load(NomeArquivo).Descendants("restaurante").Descendants("contato");
        }

        public IList<string> ObterNomes()
        {
            /*
            var resultado = new List<string>();
            
            foreach (var item in nodos)
            {
                resultado.Add(item.Attribute("nome").Value);
            }

            return resultado;
            */
            
            return XDocument
                .Load(NomeArquivo)
                .Descendants("restaurante")
                .Select(n => n.Attribute("nome").Value)
                .ToList();
        }

        public double CapacidadeMedia()
        {
            return (
                from n in restaurantes
                select Convert.ToInt32(n.Attribute("capacidade").Value)).Average();
        }

        public double CapacidadeMaxima()
        {
            return (
                from n in restaurantes
                select Convert.ToInt32(n.Attribute("capacidade").Value)).Max();
        }

        public IList<Restaurante> AgruparPorCategorias()
        {
            var res = from n in restaurantes
                      group n by n.Attribute("categoria").Value into g
                      select new { Categoria = g.Key, Restaurantes = g.ToList()};

            throw new NotImplementedException();
        }

        public IList<string> OrdenarPorNomeAsc()
        {
            return (from n in ObterNomes()
                   orderby n
                   select n).ToList();
        }

        public IList<string> ObterSites()
        {
            return contato
                .Descendants("site")
                .Select(x => x.Value)
                .ToList();
        }
    }
}
