using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Produto;
using Business.Validations;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;
        public ProdutoService(IMapper mapper, IProdutoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(ProdutoInput _produto)
        {

            ReturnView retorno = new ReturnView();
            ProdutoValidation validator = new ProdutoValidation();
            var valid = validator.Validate(_produto);
            if (!valid.IsValid)
            {
                retorno.Status = false;
                foreach (var item in valid.Errors)
                {
                    retorno.Message = string.IsNullOrEmpty(retorno.Message) ? item.ErrorMessage : retorno.Message + ", " + item.ErrorMessage;
                }
                return retorno;
            }
            var register = _mapper.Map<ProdutoInput, ProdutoEntity>(_produto);
            try
            {
                var result = _mapper.Map<ProdutoEntity, ProdutoOutput>(await _repository.Add(register));
                retorno = new ReturnView() { Object = result, Message = "Operação realizada com sucesso!", Status = true };
            }
            catch (Exception ex)
            {
                retorno = new ReturnView() { Object = null, Message = ex.Message, Status = false };
            }
            return retorno;
        }
        public async Task<ReturnView> Update(ProdutoInput _produto)
        {
            ReturnView retorno = new ReturnView();
            ProdutoValidation validator = new ProdutoValidation();
            var valid = validator.Validate(_produto);
            if (!valid.IsValid)
            {
                retorno.Status = false;
                foreach (var item in valid.Errors)
                {
                    retorno.Message = string.IsNullOrEmpty(retorno.Message) ? item.ErrorMessage : retorno.Message + ", " + item.ErrorMessage;
                }
                return retorno;
            }
            var register = _mapper.Map<ProdutoInput, ProdutoEntity>(_produto);
            try
            {
                var result = _mapper.Map<ProdutoEntity, ProdutoOutput>(await _repository.Update(register));
                retorno = new ReturnView() { Object = result, Message = "Operação realizada com sucesso!", Status = true };
            }
            catch (Exception ex)
            {
                retorno = new ReturnView() { Object = null, Message = ex.Message, Status = false };
            }
            return retorno;
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<ReturnView> GetId(int id)
        {
            ReturnView retorno = new ReturnView();
            ProdutoOutput produto = new ProdutoOutput();
            try
            {
                retorno = new ReturnView() { Object = _mapper.Map<ProdutoEntity, ProdutoOutput>(await _repository.Get(x => x.Id == id)), Message = "Operação realizada com sucesso!", Status = true };
            }
            catch (Exception ex)
            {
                retorno = new ReturnView() { Object = null, Message = ex.Message, Status = false };

            }
            return retorno;
        }
        public async Task<ReturnView> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);
                return new ReturnView() { Status = true, Message = "Operação realizada com sucesso!" };
            }
            catch (Exception ex)
            {
                return new ReturnView() { Status = false, Message = ex.Message };
            }
        }

        public async Task<ReturnView> GetFilter(ProdutoInput _filter)
        {
            var produtos =  await _repository.GetFilter(_filter);
            var result = _mapper.Map<IEnumerable<ProdutoEntity>, IEnumerable<ProdutoOutput>>(produtos);
            return new ReturnView() { Object = result, Message = "Operação realizada com sucesso!", Status = true };
        }
    }
}
