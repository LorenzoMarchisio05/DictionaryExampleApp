namespace DictionaryExampleApp.Entity
{
    public sealed class Student
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string Fullname => $"{Surname} {Name}";

        public ushort Age { get; set;  }

        public Student()
        {
            // used by bogus to create students
            // dont remove setters for name and surname ( Used by Bogus for data generator )
        }

        public Student(string name, string surname, ushort age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}