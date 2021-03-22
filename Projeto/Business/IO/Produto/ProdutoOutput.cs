using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Produto
{
    public class ProdutoOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }
        public string Imagem { get; set; }
    }
}
