using AutoMapper;
using Locadora.Dtos;
using Locadora.Model;

namespace Locadora.Profiles
{
    public class FilmeProfile :Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme,FilmeReadDto>();
            CreateMap<FilmeCreateAlterDto,Filme>();
            CreateMap<Filme,FilmeCreateAlterDto>();
        }
    }
}