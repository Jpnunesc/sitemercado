using AutoMapper;
using Business.IO.Produto;
using Business.IO.Users;
using Domain.Entity;
using Domain.Entitys;
using System.Collections.Generic;

namespace Business.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProdutoOutput,ProdutoEntity>(MemberList.None);
            CreateMap<ProdutoEntity, ProdutoOutput>(MemberList.None);
            CreateMap<ProdutoInput, ProdutoEntity>(MemberList.None);
        }
    }

}