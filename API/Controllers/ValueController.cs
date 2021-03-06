using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ValueController:ControllerBase
{
    // private readonly ILogger<ValueController> _logger;

    // public ValueController(ILogger<ValueController> logger){
    //     _logger=logger;
    // }
    private readonly DataContext _context;
    public ValueController(DataContext context){
        _context=context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Value>>> Get(){
       var values= await _context.Values.ToListAsync();
       return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Value>> Get(int id)
    {
        var value= await _context.Values.FindAsync(id);
        return Ok(value);
    }

}
