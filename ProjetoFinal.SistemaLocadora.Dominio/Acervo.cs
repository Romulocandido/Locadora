using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.SistemaLocadora.Dominio
{
    public class Acervo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Dano { get; set; }
        public string MotivoDano { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
