namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=KnowledgeSystem")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SkillCategory> SkillCategories { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Profile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SkillCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SkillCategory>()
                .HasMany(e => e.Skills)
                .WithRequired(e => e.SkillCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillName)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.UserSkills)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSkills)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
