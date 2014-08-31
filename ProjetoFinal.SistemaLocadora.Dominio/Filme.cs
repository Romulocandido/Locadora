using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.Dominio
{
    public class Filme : Produto
    {
        public string Diretor { get; set; }
        public string Atores { get; set; }
    }
}
