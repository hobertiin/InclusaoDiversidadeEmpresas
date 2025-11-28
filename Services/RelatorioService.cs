using InclusaoDiversidadeEmpresas.Data;
using InclusaoDiversidadeEmpresas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InclusaoDiversidadeEmpresas.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly DatabaseContext _context;

        public RelatorioService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RelatorioDeDiversidadeModel> GerarRelatorioAsync()
        {
            // 1. Contagem Total
            var totalColaborador = await _context.Colaboradores.CountAsync();

            // 2. Contagem de Mulheres
            var contagemDeMulheres = await _context.Colaboradores
                .CountAsync(c => c.GeneroColaborador.Equals("Feminino", StringComparison.OrdinalIgnoreCase));

            // 3. Contagem de Pessoas Negras
            var contagemDePessoasNegras = await _context.Colaboradores
                .CountAsync(c => c.EtniaColaborador.Equals("Preta", StringComparison.OrdinalIgnoreCase) ||
                                 c.EtniaColaborador.Equals("Parda", StringComparison.OrdinalIgnoreCase));

            // 4. Contagem de Pessoas com Desabilidade
            var contagemDePessoasComDesabilidade = await _context.Colaboradores
                .CountAsync(c => c.TemDisabilidade);

            // 5. Mapear para o Model de Relatório
            var relatorio = new RelatorioDeDiversidadeModel
            {
                DataGerada = DateTime.Now,
                TotalColaborador = totalColaborador,
                ContagemDeMulheres = contagemDeMulheres,
                ContagemDePessoasNegras = contagemDePessoasNegras,
                ContagemDePessoasComDesabilidade = contagemDePessoasComDesabilidade
            };

            return relatorio;
        }
    }
}