using AutoMapper;

namespace webapi.Controllers;


public class FilmeProfile : Profile {
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto,Filme>();
    }
}