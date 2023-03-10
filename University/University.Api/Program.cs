using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using University.Application.Domain.Students.Queries.GetStudent;
using University.Application.Domain.Subject.Commands.CreateSubject;
using University.Application.Domain.Subject.Queries.GetSubjects;
using University.Core.Common;
using University.Core.Domain.Subjects.Common;
using University.Infrastructure.Core.Common;
using University.Infrastructure.Core.Domain.Subject.Common;
using University.Infrastructure.Core.Domain.Subject.Queries;
using University.Persistence.UniversityDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetSubjectsQuery, GetSubjectsQuery>();
builder.Services.AddSingleton<UniversityDbContext>();
builder.Services.AddSingleton<ISubjectsRepository, SubjectsRepository>();
builder.Services.AddSingleton<ICreateSubjectCommand, CreateSubjectCommand>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
