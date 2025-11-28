namespace InclusaoDiversidadeEmpresas.Models
{
    public class Colaborador
    {
        public long Id { get; set; }

        public required string NomeColaborador { get; set; }

        public required string GeneroColaborador { get; set; }

        public required string EtniaColaborador { get; set; }

        public bool TemDisabilidade { get; set; }

        public required string Departamento { get; set; }

        public required string Email { get; set; }

        public required string Senha { get; set; }

        public bool TreinamentoCompleto { get; set; } = false;

        // Relacionamentos
        public required ICollection<ParticipacaoEmTreinamentoModel> Participacao { get; set; }
    }
}

