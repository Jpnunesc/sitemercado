using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business.IO.Produto
{
    public class ProdutoInput
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }

        [Column(TypeName = "CLOB")]
        public string Imagem { get; set; }

    }

}
