using Microsoft.EntityFrameworkCore;

namespace CRUDMascote.Models
{
    public class Contexto : DbContext
    {
        public Contexto( DbContextOptions<Contexto> options) : base(options)
        {            
        }
        public DbSet<Mascote> Mascotes { get; set; }
    }
}
