using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entitys
{
    public class ProdutoEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }
        public string Imagem { get; set; }

 
    }
}
