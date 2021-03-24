using Business.IO;
using Business.IO.Produto;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ReturnView> Save(ProdutoInput _produto);
        Task<ReturnView> Update(ProdutoInput _produto);
        Task<ReturnView> GetId(int id);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> GetFilter(ProdutoInput _filtro);
    }
}
