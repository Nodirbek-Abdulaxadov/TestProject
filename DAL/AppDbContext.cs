using DAL.Entities;
using DAL.Entities.MTM;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext : IdentityDbContext<Admin>
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Student> Students { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<TeacherSubject> TeacherSubjects { get; set; }
	public DbSet<StudentSubject> StudentSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
		builder.Entity<TeacherSubject>()
			.HasKey(i => new { i.TeacherId, i.SubjectId });
		builder.Entity<TeacherSubject>()
			.HasOne(i => i.Teacher)
			.WithMany(t => t.TeacherSubjects)
			.HasForeignKey(j => j.TeacherId)
			.OnDelete(DeleteBehavior.ClientCascade);
		builder.Entity<TeacherSubject>()
			.HasOne(i => i.Subject)
			.WithMany(j => j.SubjectTeachers)
			.HasForeignKey(k => k.SubjectId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<StudentSubject>()
            .HasKey(i => new { i.StudentId, i.SubjectId });
        builder.Entity<StudentSubject>()
            .HasOne(i => i.Student)
            .WithMany(t => t.StudentSubjects)
            .HasForeignKey(j => j.StudentId)
            .OnDelete(DeleteBehavior.ClientCascade);
        builder.Entity<StudentSubject>()
            .HasOne(i => i.Subject)
            .WithMany(j => j.SubjectStudents)
            .HasForeignKey(k => k.SubjectId)
            .OnDelete(DeleteBehavior.ClientCascade);


        base.OnModelCreating(builder);
    }
}