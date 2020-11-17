using edital.Model;
using Microsoft.EntityFrameworkCore;

namespace edital.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //liga tabelas do BD com as classes
        public DbSet<Cidade> cidade { get; set; }
        public DbSet<Estado> estado { get; set; }
        public DbSet<Contato> contato { get; set; }
        public DbSet<Edital> edital { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<Inscricao> inscricao { get; set; }
        public DbSet<PessoaJuridica> pessoajuridica { get; set; }
        public DbSet<Representante> representante { get; set; }
        public DbSet<Segmento> segmento { get; set; }
        public DbSet<Anexo> anexo { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);

             builder.Entity<Inscricao>()
             .HasKey(i => new { i.pessoajuridica_id, i.segmento_id});
            
        }        
    }

}