using Microsoft.AspNetCore.Mvc;
using Questionario.Domain;
using Questionario.Data;
using Microsoft.EntityFrameworkCore;

namespace Questionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;
        private readonly ApplicationContext _context;

        public FormController(
            ILogger<FormController> logger, 
            ApplicationContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Form>>> Get()
        {
            var resposta = await _context.Forms.ToListAsync();
            if (resposta != null)
            {
                return Ok(resposta);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
