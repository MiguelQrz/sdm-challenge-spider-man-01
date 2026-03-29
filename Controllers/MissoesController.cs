using Microsoft.AspNetCore.Mvc;
using SpiderNetApi.Models;

namespace SpiderNetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissoesController : ControllerBase
{
    private static readonly List<MissaoAranha> _missoes = new();

    [HttpGet]
    public ActionResult<IEnumerable<MissaoAranha>> Get()
    {
        return Ok(_missoes);
    }

    [HttpPost]
    public ActionResult Post([FromBody] MissaoAranha novaMissao)
    {
        if (novaMissao.NivelPerigo < 1 || novaMissao.NivelPerigo > 10)
        {
            return BadRequest("Alerta! O nível de perigo deve estar entre 1 e 10. O sentido aranha detectou um erro nos dados.");
        }

        _missoes.Add(novaMissao);
        
        return CreatedAtAction(nameof(Get), new { id = novaMissao.Id }, novaMissao);
    }
}