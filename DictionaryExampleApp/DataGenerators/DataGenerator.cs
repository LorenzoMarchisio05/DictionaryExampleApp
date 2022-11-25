using System;
using System.Collections.Generic;
using Bogus;
using DictionaryExampleApp.Entity;

namespace DictionaryExampleApp.DataGenerators
{
    public static class DataGenerator
    {
        private static readonly string[] _classId =
        {
            "1A", "2A", "3A", "4A", "5A",
            "1B", "2B", "3B", "4B", "5B"
        };

        public static List<Classroom> Generate()
        {
            List<Classroom> classrooms = new List<Classroom>();
            
            foreach (var id in _classId)
            {
                List<Student> students = new Faker<Student>()
                    .RuleFor(s => s.Name, f => f.Person.FirstName)
                    .RuleFor(s => s.Surname, f => f.Person.LastName)
                    .RuleFor(s => s.Age, f => ushort.Parse((DateTime.Now.Year - f.Person.DateOfBirth.Year).ToString()))
                    .Generate(20);

                classrooms.Add(new Classroom(id, students));
            }

            return classrooms;
        }
    }
}