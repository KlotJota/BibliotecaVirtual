using AutoMapper;
using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;

namespace BibliotecaVirtual.Api.Helpers
{
    public class BibliotecaVirtualProfile: Profile
    {
        public BibliotecaVirtualProfile()
        {
            CreateMap<Livro, LivroDto>()
                .ForMember(d => d.CategoriaNome, opt => opt.MapFrom(src => src.Categorias.Nome));

            CreateMap<AdicionaLivroDto, Livro>();

            CreateMap<LivroDto, Livro>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LivroAtualizaDto, Livro>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
