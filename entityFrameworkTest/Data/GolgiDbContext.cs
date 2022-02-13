using Microsoft.EntityFrameworkCore;

namespace entityFrameworkTest.Data.Repositories
{
    public partial class GolgiDbContext : DbContext
    {
        public GolgiDbContext(DbContextOptions<GolgiDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<ComponentEntity> Components { get; set; }
        public virtual DbSet<AssemblingEntity> Synthesis { get; set; }
        public virtual DbSet<SubcomponentEntity> Subcomponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ComponentEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProteinType)
                    .IsRequired()

                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Chaperonine)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HSP80)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ubiquitination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnergyIncrease)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumComponents)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Temp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ph)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Synthesis)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.SynthesisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Components_Packages");
            });

            modelBuilder.Entity<AssemblingEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubcomponentEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Energy).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Subcomponents)
                    .HasForeignKey(d => d.ComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcomponents_Components");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
