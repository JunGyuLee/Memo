using Microsoft.EntityFrameworkCore;

namespace KJMemo.Models.DAO
{
    public class KJContext : DbContext
    {
        public KJContext(DbContextOptions<KJContext> options)
       : base(options)
        { }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member")
                .HasKey(m => m.MemberID);
        }
    }
}