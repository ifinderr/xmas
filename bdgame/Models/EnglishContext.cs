using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bdgame.Models;

public partial class EnglishContext : DbContext
{
    public EnglishContext()
    {
    }

    public EnglishContext(DbContextOptions<EnglishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Param> Params { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dadds2.database.windows.net;Database=english;user id=sysadmin;password=7c419eae$;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1250_CI_AS");

        modelBuilder.Entity<Param>(entity =>
        {
            entity.ToTable("Param");

            entity.Property(e => e.ParamId)
                .ValueGeneratedNever()
                .HasColumnName("ParamID");
            entity.Property(e => e.RefreshDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.WordsId).HasName("PK_Words_1");

            entity.Property(e => e.WordsId)
                .ValueGeneratedNever()
                .HasColumnName("WordsID");
            entity.Property(e => e.En)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EN");
            entity.Property(e => e.Hu)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HU");
            entity.Property(e => e.LessionGroup)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SentenceEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SentenceEN");
            entity.Property(e => e.SentenceHu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SentenceHU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
