using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public virtual Categoria Categoria { get; set; }
        public decimal Valor { get; set; }
    }
}
