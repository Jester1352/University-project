namespace University.Core.Domain.Faculties.Models
{
    public class Faculty
    {
        private Faculty()
        {

        }

        private Faculty(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public IReadOnlyCollection<FacultyDepartment> Departments { get; private set; }

        public static Faculty Create(string name)
        {
            return new Faculty(new Guid(), name);
        }
    }
}
