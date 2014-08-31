using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.Dominio
{
    public class ProdutoExibir
    {
        public int id { get; set; }
        public int Codigo { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public string Motivo { get; set; }
    }
}
