using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
   public List<Filme> filmes = new List<Filme>();
   private DataContext _context;

   public FilmeController(DataContext context)
   {
        _context = context;
   }

    [HttpPost]
    public IActionResult Post([FromBody] Filme filme)
    {
        
       var result =  _context.Filmes.Add(filme);

       _context.SaveChanges();


        return CreatedAtAction(nameof(Get), new {id = filme.ID});
    }

   

    [HttpGet]
    public IActionResult Get([FromQuery] int page = 0,[FromQuery] int size = 250)
    {
        return Ok(_context.Filmes.Skip(page).Take(size));
    }

    [HttpGet("{id}")]
    public IActionResult Get( int id)
    {
        Filme ?filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);

        if(filme == null) return NotFound();
        return Ok(filme);
    }

    

}