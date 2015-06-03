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
