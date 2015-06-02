using ConsoleApplication1;

namespace TurboRango.Dominio
{
    class Restaurante
    {
        /// <summary>
        /// CAPACIDADE(LOTAÇÃO MÁXIMA) DO RESTAURANTE
        /// </summary>
        internal Categoria Categoria { get; set;}
        internal Localizacao Localizacao { get; set;}
        internal Contato Contato { get; set; }
        internal int Capacidade { get; set; }
        internal string Nome { get; set; }

        static void Main(string[] args)
        {

        }
    }
}
