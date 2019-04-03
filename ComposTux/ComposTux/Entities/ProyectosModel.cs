namespace ComposTux.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProyectosModel : DbContext
    {
        public ProyectosModel()
            : base("name=ProyectosModel")
        {
        }

        public virtual DbSet<AssigmentColony> AssigmentColonies { get; set; }
        public virtual DbSet<Colony> Colonies { get; set; }
        public virtual DbSet<InformationCartel> InformationCartels { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colony>()
                .Property(e => e.ColonyName)
                .IsUnicode(false);

            modelBuilder.Entity<Colony>()
                .Property(e => e.ColonyAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Colony>()
                .HasMany(e => e.AssigmentColonies)
                .WithRequired(e => e.Colony)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InformationCartel>()
                .Property(e => e.UrlImage)
                .IsUnicode(false);

            modelBuilder.Entity<InformationCartel>()
                .Property(e => e.CartelDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.UserResponsable)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Colonies)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.AssigmentColonies)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.InformationCartels)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tokens)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
