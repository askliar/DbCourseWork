using System.Data.Entity;
using DBCourseWork.Entities;

namespace DBCourseWork
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public ApplicationDbContext(string connectionString)
        {
            this.Database.Connection.ConnectionString = connectionString;
        }

        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<AbsenceType> AbsenceTypes { get; set; }
        public virtual DbSet<NecessarySkill> NecessarySkills { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonalSkill> PersonalSkills { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<Timeshift> Timeshifts { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Documentation> Documentations { get; set; }
        public virtual DbSet<EntityContr> EntityContrs { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodsMove> GoodsMoves { get; set; }
        public virtual DbSet<IndividContr> IndividContrs { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<GoodInfo> GoodInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AbsenceType>()
                .Property(e => e.AbsName)
                .IsUnicode(false);

            modelBuilder.Entity<AbsenceType>()
                .HasMany(e => e.Absences)
                .WithRequired(e => e.AbsenceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PerName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PerSurname)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Education)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonalSkills)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Stuffs)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.VacName)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.NecessarySkills)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Vacancies)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillName)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.NecessarySkills)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.PersonalSkills)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stuff>()
                .HasMany(e => e.Timeshifts)
                .WithRequired(e => e.Stuff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Timeshift>()
                .Property(e => e.TypeShift)
                .IsUnicode(false);

            modelBuilder.Entity<Vacancy>()
                .HasMany(e => e.Stuffs)
                .WithRequired(e => e.Vacancy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Contractor>()
                .Property(e => e.ContrName)
                .IsUnicode(false);

            modelBuilder.Entity<Contractor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contractor>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.EntityContrs)
                .WithRequired(e => e.Contractor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.IndividContrs)
                .WithRequired(e => e.Contractor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocType>()
                .Property(e => e.Doctype1)
                .IsUnicode(false);

            modelBuilder.Entity<DocType>()
                .HasMany(e => e.Documentations)
                .WithRequired(e => e.DocType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Documentation>()
                .HasMany(e => e.GoodsMoves)
                .WithRequired(e => e.Documentation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntityContr>()
                .Property(e => e.StateNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.GoodName)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.GoodsMoves)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoodsMove>()
                .Property(e => e.MoveType)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Role)
                .IsUnicode(false);
        }
    }
}