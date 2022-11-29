using System.Collections.Generic;
using System.Linq;
using api.Models;
using API_Copa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly Context _context;
        public JogoController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Jogo jogo)
        {

            _context.Jogos.Add(jogo);
            _context.SaveChanges();

            return Ok(jogo);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List<Jogo> jogos = _context.Jogos.Include(x => x.SelecaoA).Include(x => x.SelecaoB).ToList();
            return jogos.Count != 0 ? Ok(jogos) : NotFound();
        }

        [HttpPatch]
        [Route("palpitar")]
        public IActionResult Palpitar([FromBody] Jogo jogo)
        {
            try
            {
                _context.Jogos.Update(jogo);
                _context.SaveChanges();
                return Ok(jogo);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}