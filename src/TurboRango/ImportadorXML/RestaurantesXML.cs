using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            localizacao = restaurantes.Descendants("localizacao");
            contato = restaurantes.Descendants("contato");
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

        public object AgruparPorCategoria()
        {
            return restaurantes
                .GroupBy(r => new
                {
                    Categorias = r.Attribute("categoria"),
                    Restaurantes = restaurantes
                })
                .Select(r => r);
        }

        public IList<Categoria> CategoriaComUmRestaurante()
        {
            return (IList<Categoria>) restaurantes
                .GroupBy(x => x.Attribute("categoria").Value)
                .Where(g => g.Count() == 1)
                .Select(g => Enum.Parse(typeof(Categoria),g.Key)/*.ToEnum<Categoria>()*/)
                .ToList();
        }
    }
}


/* ESTUDAR CÓDIGO
public IList<Categoria> ApenasComUmRestaurante()
        {
            return restaurantes.GroupBy(x => x.Attribute("categoria").Value).Where(g => g.Count() == 1).Select(g => g.Key.ToEnum<Categoria>() ).ToList();
        }

        public IList<Categoria> ApenasMaisPopulares()
        {
            //return restaurantes.GroupBy(n => n.Attribute("categoria").Value).Where(g => g.Count() > 2).OrderByDescending(g => g.Count()).Take(2).Select(g => g.Key.ToEnum<Categoria>() ).ToList();
            return (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                let groupLength = g.Count()
                where groupLength > 2
                orderby groupLength descending
                select g.Key.ToEnum<Categoria>()
            ).Take(2).ToList();
        }

        public IList<string> BairrosComMenosPizzarias()
        {
            //return restaurantes
            //    .Where(n => n.Attribute("categoria").Value.ToEnum<Categoria>() == Categoria.Pizzaria)
            //    .GroupBy(n => n.Element("localizacao").Element("bairro").Value)
            //    .OrderBy(g => g.Count())
            //    .Take(8)
            //    .Select(g => g.Key)
            //    .ToList();
            return (
                from n in restaurantes
                let cat = n.Attribute("categoria").Value.ToEnum<Categoria>()
                where cat == Categoria.Pizzaria
                group n by n.Element("localizacao").Element("bairro").Value into g
                orderby g.Count()
                select g.Key
            ).Take(8).ToList();
        }

        public object AgrupadosPorBairroPercentual()
        {
            //return restaurantes.GroupBy(n => n.Element("localizacao").Element("bairro").Value).Select(g => new { Bairro = g.Key, Percentual = Math.Round(Convert.ToDouble(g.Count() * 100) / restaurantes.Count(), 2) }).OrderByDescending(g => g.Percentual);
            return (
                from n in restaurantes
                group n by n.Element("localizacao").Element("bairro").Value into g
                let totalRestaurantes = restaurantes.Count()
                select new { Bairro = g.Key, Percentual = Math.Round(Convert.ToDouble(g.Count() * 100) / totalRestaurantes, 2) }
            ).OrderByDescending(g => g.Percentual);
        }

        public IEnumerable<Restaurante> TodosRestaurantes()
        {
            return (
                from n in restaurantes
                let contato = n.Element("contato")
                let site = contato != null && contato.Element("site") != null ? contato.Element("site").Value : null
                let telefone = contato != null && contato.Element("telefone") != null ? contato.Element("telefone").Value : null
                let localizacao = n.Element("localizacao")
                select new Restaurante
                {
                     Nome = n.Attribute("nome").Value,
                     Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value),
                     Categoria = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true),
                     Contato = new Contato
                     {
                          Site = site,
                          Telefone = telefone
                     },
                     Localizacao = new Localizacao
                     {
                          Bairro = localizacao.Element("bairro").Value,
                          Logradouro = localizacao.Element("logradouro").Value,
                          Latitude = Convert.ToDouble(localizacao.Element("latitude").Value),
                          Longitude = Convert.ToDouble(localizacao.Element("longitude").Value)
                     }
                }
            );
        }
*/