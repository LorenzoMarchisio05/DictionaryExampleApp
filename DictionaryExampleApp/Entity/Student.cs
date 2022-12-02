using System;
using DictionaryExampleApp.Validators;

namespace DictionaryExampleApp.Entity
{
    public sealed class Student
    {
        private string _name;
        private string _surname;

        public string Name
        {
            get => _name;
            set
            {
                if (!NameValidator.Validate(value))
                {
                    throw new Exception("invalid name");
                }
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (!NameValidator.Validate(value))
                {
                    throw new Exception("invalid name");
                }
                _surname = value;
            }
        }

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