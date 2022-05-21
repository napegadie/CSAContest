using Microsoft.EntityFrameworkCore;

namespace CSAContestWeb.Models
{
    public class DocSearchDbContext : DbContext
    {
        public DocSearchDbContext(DbContextOptions<DocSearchDbContext> opt) : base(opt)
        {

        }

        public DbSet<DocumentModel>? DocSearch { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DocumentModel>().HasData(
                new DocumentModel() { DocSearchId = 1, StoragePath = "kljghdgfsgfjhjh", DateInvoice = "05/09/2022", ReceiverBy = "nape", BirdFindLocation = "Dallas", DonorName = "Kone" }
                );
        }
    }
}
