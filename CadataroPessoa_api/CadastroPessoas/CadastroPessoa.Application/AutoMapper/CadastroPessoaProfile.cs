using AutoMapper;
using CadastroPessoa.Application.DTO;
using CadastroPessoa.Domain.Entities;

namespace CadastroPessoa.Domain.Mappings
{
    public class CadastroPessoaProfile : Profile
    {
        public CadastroPessoaProfile()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<FileImport, FileDTO>().ReverseMap();
        }
    }
}
