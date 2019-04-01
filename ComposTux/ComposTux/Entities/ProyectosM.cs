namespace ComposTux.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProyectosM : DbContext
    {
        public ProyectosM()
            : base("name=ProyectosM")
        {
        }

        public virtual DbSet<AssignUserCompany> AssignUserCompanies { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyLatitud)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyLongitud)
                .IsUnicode(false);

            modelBuilder.Entity<Token>()
                .Property(e => e.PlayerId)
                .IsUnicode(false);

            modelBuilder.Entity<Token>()
                .Property(e => e.PushToken)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.NameUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastNameUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Longitud)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Companies)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tokens)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
