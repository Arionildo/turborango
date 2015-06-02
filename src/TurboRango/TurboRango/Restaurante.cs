using ConsoleApplication1;

namespace TurboRango.Dominio
{
    public class Restaurante
    {
        /// <summary>
        /// CAPACIDADE(LOTAÇÃO MÁXIMA) DO RESTAURANTE
        /// </summary>
        public Categoria Categoria { get; set;}
        public Localizacao Localizacao { get; set;}
        public Contato Contato { get; set; }
        public int Capacidade { get; set; }
        public string Nome { get; set; }

        static void Main(string[] args)
        {

        }
    }
}
