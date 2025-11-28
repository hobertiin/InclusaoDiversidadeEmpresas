using InclusaoDiversidadeEmpresas.Models;
using System.Threading.Tasks;

namespace InclusaoDiversidadeEmpresas.Services
{
    // Define o método que o Controller irá chamar para obter o relatório.
    public interface IRelatorioService
    {
        // Retorna o RelatorioDeDiversidadeModel preenchido
        Task<RelatorioDeDiversidadeModel> GerarRelatorioAsync();
    }
}