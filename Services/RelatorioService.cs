using InclusaoDiversidadeEmpresas.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InclusaoDiversidadeEmpresas.Services
{
    public class RelatorioService : IRelatorioService
    {
        // 1. Injeção da interface IColaboradorService
        private readonly IColaboradorService _colaboradorService;

        public RelatorioService(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        public async Task<RelatorioDeDiversidadeModel> GerarRelatorioAsync()
        {
            // 2. Obtém a lista completa de colaboradores através do SERVICE injetado.
            var colaboradores = await _colaboradorService.GetAllColaboradores();
            var listaColaboradores = colaboradores.ToList();

            // 3. Contagem Total
            var totalColaborador = listaColaboradores.Count;

            // 4. Contagem de Mulheres (em memória)
            var contagemDeMulheres = listaColaboradores
                .Count(c => c.GeneroColaborador.Equals("Feminino", StringComparison.OrdinalIgnoreCase));

            // 5. Contagem de Pessoas Negras (em memória)
            var contagemDePessoasNegras = listaColaboradores
                .Count(c => c.EtniaColaborador.Equals("Preta", StringComparison.OrdinalIgnoreCase) ||
                            c.EtniaColaborador.Equals("Parda", StringComparison.OrdinalIgnoreCase));

            // 6. Contagem de Pessoas com Desabilidade (em memória)
            var contagemDePessoasComDesabilidade = listaColaboradores
                .Count(c => c.TemDisabilidade);


            // 7. Mapear para o Model de Relatório
            var relatorio = new RelatorioDeDiversidadeModel
            {
                DataGerada = DateTime.Now,
                TotalColaborador = totalColaborador,
                ContagemDeMulheres = contagemDeMulheres,
                ContagemDePessoasNegras = contagemDePessoasNegras,
                ContagemDePessoasComDesabilidade = contagemDePessoasComDesabilidade,
            };

            return relatorio;
        }
    }
}