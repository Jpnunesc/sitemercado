using Business.Interfaces.Repositories;
using Business.IO.Produto;
using Domain.Entitys;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<TestContext, ProdutoEntity>, IProdutoRepository
    {
        public ProdutoRepository(TestContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProdutoEntity>> GetFilter(ProdutoInput filter)
        {
            var query = DbSet as IQueryable<ProdutoEntity>;
            if (!string.IsNullOrEmpty(filter.Nome)) query.Where(x => x.Nome.Contains(filter.Nome));
            if (filter.Valor != null) query.Where(x => x.Valor >= filter.Valor);
            return await Task.Run(() => query.ToList());
        }
    }
}
