using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend_Blog_API.Models;

public partial class BlogElNucleoContext : DbContext
{
    public BlogElNucleoContext()
    {
    }

    public BlogElNucleoContext(DbContextOptions<BlogElNucleoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Testimonio> Testimonios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07118AB77A");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC07425CE041");

            entity.Property(e => e.Comentar).HasColumnName("Comentar");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime");
            entity.Property(e => e.EditadoEn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PostId).HasColumnName("PostId");

            entity.HasOne(d => d.Post).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Comentari__Post___3C69FB99");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC072DFA5429");

            entity.ToTable("Post");

            entity.Property(e => e.Autor)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CantComentarios).HasColumnName("Cant_Comentarios");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaId");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime");
            entity.Property(e => e.EditadoEn).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Post__Categoria___398D8EEE");
        });

        modelBuilder.Entity<Testimonio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testimon__3214EC07CFD34C2E");

            entity.ToTable("testimonios");

            entity.Property(e => e.Cargo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
