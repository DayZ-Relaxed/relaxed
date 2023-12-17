using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Relaxed.LogParser.Settings;

namespace Relaxed.LogParser.Model;

public partial class DayzRelaxedContext : DbContext
{
    

    public DayzRelaxedContext()
    {
    }

    public DayzRelaxedContext(
        DbContextOptions<DayzRelaxedContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    public virtual DbSet<TerritoryMember> TerritoryMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile("appsettings.Development.json", true, true)
            .Build();

        optionsBuilder.UseSqlServer(builder.GetConnectionString("DayZRelaxed"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.BattleEyeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DayzId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SteamId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatisticsId);

            entity.Property(e => e.DateWritten).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.ToTable("Territory");

            entity.Property(e => e.LastFound).HasColumnType("datetime");
            entity.Property(e => e.OwnerDayzId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PosZ)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TerritoryMember>(entity =>
        {
            entity.ToTable("TerritoryMember");

            entity.Property(e => e.LastFound).HasColumnType("datetime");
            entity.Property(e => e.MemberDayzId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
