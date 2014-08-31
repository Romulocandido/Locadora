using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.Dominio
{
    public class Jogo : Produto
    {
        public string Desenvolvedora { get; set; }
        public virtual Plataforma Console { get; set; }
    }
}
