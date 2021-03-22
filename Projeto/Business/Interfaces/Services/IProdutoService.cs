using Business.IO;
using Business.IO.Produto;
using Business.IO.Users;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ReturnView> Save(ProdutoInput _produto);
        Task<ReturnView> Update(ProdutoInput _produto);
        Task<ProdutoOutput> GetId(int id);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> GetFilter(ProdutoInput _filtro);
    }
}
