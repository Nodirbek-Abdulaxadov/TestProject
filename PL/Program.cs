using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration
                    .GetConnectionString("LocalDB")));

//Add Identity
builder.Services.AddIdentity<Admin, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

//Add DI Services
builder.Services.AddTransient<ITeacher, TeacherRepository>();
builder.Services.AddTransient<IStudent, StudentRepository>();
builder.Services.AddTransient<ISubject, SubjectRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();