using Business.IO.Produto;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<ProdutoEntity>
    {
        Task<IEnumerable<ProdutoEntity>> GetFilter(ProdutoInput filter);
    }
}
