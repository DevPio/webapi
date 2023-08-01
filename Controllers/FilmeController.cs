using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{

    private DataContext _context;

    private IMapper _mapper;

    public FilmeController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateFilmeDto filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto);

        var result = _context.Filmes.Add(filme);

        _context.SaveChanges();


        return CreatedAtAction(nameof(Get), new { id = filme.ID });
    }



    [HttpGet]
    public IActionResult Get([FromQuery] int page = 0, [FromQuery] int size = 250)
    {
        return Ok(_context.Filmes.Skip(page).Take(size));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }


    [HttpPut("{id}")]

    public IActionResult Update(int id, [FromBody] CreateFilmeDto filmeUpdate)
    {

        Filme? findFilme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);

        if(findFilme == null) return NotFound();


        Filme filme = _mapper.Map(filmeUpdate,findFilme);

        _context.SaveChanges();

        return NoContent();

    }



}