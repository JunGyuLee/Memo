using KJMemo.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace KJMemo.Models.DAO
{
    public class KJContext : DbContext
    {
        public KJContext(DbContextOptions<KJContext> options)
       : base(options)
        { }

        public DbSet<Member> Members { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member")
                .HasKey(m => m.MemberID);

            modelBuilder.Entity<Note>().ToTable("Note")
                .HasKey(m => m.Id);

            modelBuilder.Entity<Note>()
                .Property(m => m.Category)
                .HasConversion(new EnumToStringConverter<ENoteCategory>())
                .HasMaxLength(1000);

        }
    }
}