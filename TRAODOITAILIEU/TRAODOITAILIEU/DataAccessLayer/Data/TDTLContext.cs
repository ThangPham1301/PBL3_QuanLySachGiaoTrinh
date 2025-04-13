using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.DataAccessLayer.Data;

public partial class TDTLContext : DbContext
{
    public TDTLContext()
    {
    }

    public TDTLContext(DbContextOptions<TDTLContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderDocument> OrderDocuments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MINHKHAI;Initial Catalog=TDTL;Persist Security Info=True;User ID=sa;Password=123456;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__account__F267251ECD6D2779");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__content__0BDC871922564E68");

            entity.HasOne(d => d.Document).WithMany(p => p.Contents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__content__documen__3C69FB99");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__document__EFAAAD85ECFE6FC3");

            entity.HasOne(d => d.Account).WithMany(p => p.Documents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__document__accoun__398D8EEE");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__order__0809335D86B22016");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__orderDet__E4FEDE4A6AC478C2");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orderDeta__order__47DBAE45");
        });

        modelBuilder.Entity<OrderDocument>(entity =>
        {
            entity.HasKey(e => e.OrderDocumentId).HasName("PK__order_do__E10D561436DCCE21");

            entity.HasOne(d => d.Document).WithMany(p => p.OrderDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_doc__docum__440B1D61");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_doc__order__44FF419A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payment__A0D9EFC62A8FBE49");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payment__orderId__4AB81AF0");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasOne(d => d.Account).WithMany(p => p.UserProfiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_prof__accou__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
