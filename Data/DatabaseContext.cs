using Microsoft.EntityFrameworkCore;
namespace InclusaoDiversidadeEmpresas.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
