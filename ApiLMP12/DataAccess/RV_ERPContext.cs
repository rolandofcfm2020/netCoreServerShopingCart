using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiLMP12.DataAccess
{
    public partial class RV_ERPContext : DbContext
    {
        public RV_ERPContext()
        {
        }

        public RV_ERPContext(DbContextOptions<RV_ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<InvoiceProductItems> InvoiceProductItems { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HNFHQ6K\\SQLEXPRESS;Database=RV_ERP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(800);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<InvoiceProductItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceProductItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InvoicePr__Invoi__48CFD27E");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceProductItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InvoicePr__Produ__49C3F6B7");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Emisor).IsRequired();

                entity.Property(e => e.Series).HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Client__45F365D3");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CurrencyCode).HasMaxLength(10);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
