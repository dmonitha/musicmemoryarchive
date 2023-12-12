using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MMADatabase;

public partial class MusicMemoryArchiveContext : IdentityDbContext<UserClass>
{
    public MusicMemoryArchiveContext()
    {
    }

    public MusicMemoryArchiveContext(DbContextOptions<MusicMemoryArchiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Album>(entity =>
        {
         
            entity.ToTable("Album");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Artist)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberOfSongs).HasColumnName("Number of Songs");
            entity.Property(e => e.YearOfRelease).HasColumnName("Year of Release");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.ToTable("Song");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlbumId).HasColumnName("Album ID");
            entity.Property(e => e.FeaturingArtist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Featuring Artist");
            entity.Property(e => e.SongName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Song Name");

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Song_Album");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
