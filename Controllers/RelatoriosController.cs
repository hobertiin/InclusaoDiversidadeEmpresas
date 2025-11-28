using InclusaoDiversidadeEmpresas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InclusaoDiversidadeEmpresas.Controllers
{
    [Route("api/[controller]")] // Define a rota base como /api/Relatorios
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        // Injeção de Dependência do Serviço de Relatório
        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        // Endpoint: GET /api/Relatorios/diversidade
        [HttpGet("diversidade")]
        public async Task<IActionResult> GetRelatorioDiversidade()
        {
            var relatorio = await _relatorioService.GerarRelatorioAsync();

            if (relatorio == null)
            {
                return NotFound("Não foi possível gerar o relatório.");
            }

            // Retorna o objeto RelatorioDeDiversidadeModel no formato JSON
            return Ok(relatorio);
        }
    }
}