using Autofac;
using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Students.Commands;
using University.Application.Domain.Students.Commands.CreateStudent;
using University.Application.Domain.Students.Commands.RemoveStudent;
using University.Application.Domain.Students.Commands.UpdateStudent;
using University.Application.Domain.Subject.Commands.CreateSubject;
using University.Application.Domain.Subject.Commands.RemoveSubject;
using University.Application.Domain.Subject.Commands.UpdateSubject;
using University.Application.Domain.Teachers.Commands;
using University.Application.Domain.Teachers.Commands.CreateTeacher;
using University.Core.Common;
using University.Core.Domain.RecordBooks.Common;
using University.Core.Domain.StudentGroups.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Subjects.Common;
using University.Core.Domain.Subjects.Models;
using University.Core.Domain.Teachers.Common;
using University.Infrastructure.Core.Common;
using University.Infrastructure.Core.Domain.RecordBooks.Common;
using University.Infrastructure.Core.Domain.Student.Common;
using University.Infrastructure.Core.Domain.StudentGroups.Common;
using University.Infrastructure.Core.Domain.Subject.Common;
using University.Infrastructure.Core.Domain.Teacher.Common;
using University.Infrastructure.Core.Domain.Teacher.Queries;
using University.Persistence.UniversityDb;

using var dbContext = new UniversityDbContext();

var builder = new ContainerBuilder();
builder.RegisterType<UniversityDbContext>().AsSelf().As<DbContext>().SingleInstance();
builder.RegisterType<UnitOfWork>().AsSelf().As<IUnitOfWork>().SingleInstance();
builder.RegisterType<StudentsRepository>().AsSelf().As<IStudentsRepository>().SingleInstance();
builder.RegisterType<SubjectsRepository>().AsSelf().As<ISubjectsRepository>().SingleInstance();
builder.RegisterType<TeachersRepository>().AsSelf().As<ITeachersRepository>().SingleInstance();
builder.RegisterType<RecordBookRepository>().AsSelf().As<IRecordBookRepository>().SingleInstance();
builder.RegisterType<StudentGroupRepository>().AsSelf().As<IStudentGroupRepository>().SingleInstance();

var unitOfWork = new UnitOfWork(dbContext);

var teachersRepository = new TeachersRepository(dbContext);
var createTeacherCommand = new CreateTeacherCommand(teachersRepository, unitOfWork);
createTeacherCommand.CreateTeacher("Bob", "Bob", "Bob");
unitOfWork.SaveChanges();

//var studentsRepository = new StudentsRepository(dbContext);
//var createStudentCommand = new CreateStudentCommand(studentsRepository, unitOfWork);
//createStudentCommand.CreateStudent("Kovalov", "Yaroslav", "Igorovych");
//unitOfWork.SaveChanges();

var subjectsRepository = new SubjectsRepository(dbContext);
var createSubjectCommand = new CreateSubjectCommand(subjectsRepository, unitOfWork);
createSubjectCommand.CreateSubject("Physic", 2);
unitOfWork.SaveChanges();

var getSubjectsQuery = new GetTeacherQuery(dbContext);
var result = getSubjectsQuery.GetTeachers();
Console.WriteLine();

async Task Update(Subject subject)
 {
     var original = dbContext.Subjects.SingleOrDefault(s => s.Id == subject.Id);

     original.Update(subject);
     dbContext.Subjects.Update(original);
     await dbContext.SaveChangesAsync();
 }