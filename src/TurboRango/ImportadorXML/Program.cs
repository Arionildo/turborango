using ConsoleApplication1;
using System;
using System.Collections;
using System.Collections.Generic;
using TurboRango.Dominio;

namespace ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            const string nomeArquivo = "restaurantes.xml";

            var rxml = new RestaurantesXML(nomeArquivo);

            var nomes = rxml.ObterNomes();
            var capacidadeMedia = rxml.CapacidadeMedia();
            var capacidadeMaxima = rxml.CapacidadeMaxima();
            var ordenarNomesAsc = rxml.OrdenarPorNomeAsc();
            var obterSites = rxml.ObterSites();
            var agruparPorCategoria = rxml.AgruparPorCategoria();
            */

            #region ADO.NET

            var connString = @"Data Source=.;Initial Catalog=TurboRango_Dev;UID=sa;PWD=feevale;";  //Integrated Security=True; PARA WINDOWS AUTHENTICATION

            var acessoAoBanco = new CarinhaQueManipulaOBanco(connString);

            acessoAoBanco.Inserir(new Contato
            {
                Site = "www.dogao.gif",
                Telefone = "33333333"
            });

            IEnumerable<Contato> contains = acessoAoBanco.GetContatos();

            #endregion

        }
    }
}


/* ESTUDAR CÓDIGO

var ex1e = restaurantesXML.ApenasComUmRestaurante();
            var ex1f = restaurantesXML.ApenasMaisPopulares();
            var ex1g = restaurantesXML.BairrosComMenosPizzarias();
            var ex1h = restaurantesXML.AgrupadosPorBairroPercentual();

            var todos = restaurantesXML.TodosRestaurantes();

            #endregion

            #region ADO.NET

            var connString = @"Data Source=.;Initial Catalog=TurboRango_dev;Integrated Security=True;";

            var acessoAoBanco = new CarinhaQueManipulaOBanco(connString);

            acessoAoBanco.Inserir(new Contato
            {
                 Site = "www.dogao.gif",
                 Telefone = "5555555"
            });

            IEnumerable<Contato> contatos = acessoAoBanco.GetContatos();

            var restaurantes = new Restaurantes(connString);

            var tiririca = new Restaurante
            {
                Nome = "Tiririca",
                Capacidade = 50,
                Categoria = Categoria.Fastfood,
                Contato = new Contato
                {
                    Site = "http://github.com/tiririca",
                    Telefone = "5555 5555"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Vila Nova",
                    Logradouro = "ERS 239, 2755",
                    Latitude = -29.6646122,
                    Longitude = -51.1188255
                }
            };

            restaurantes.Inserir(tiririca);

            foreach (var r in todos)
            {
                restaurantes.Inserir(r);
            }

            var todosBD = restaurantes.Todos();

            // Atualizar dados do restaurante...

            tiririca.Capacidade = 100;
            tiririca.Nome = "Novo Tiririca Grill";
            tiririca.Categoria = Categoria.Churrascaria;
            tiririca.Contato.Site = "http://www.tiriricagrill.com.br";
            tiririca.Contato.Telefone = "5544445555";
            tiririca.Localizacao.Bairro = "Centro";
            tiririca.Localizacao.Logradouro = "Avenida central";
            tiririca.Localizacao.Latitude = -29.6646122;
            tiririca.Localizacao.Longitude = -51.1188255;

            restaurantes.Atualizar(375, tiririca);

            #endregion
*/