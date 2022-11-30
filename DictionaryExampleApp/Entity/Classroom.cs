using System;
using System.Collections.Generic;

namespace DictionaryExampleApp.Entity
{
    public sealed class Classroom
    {
        public string Id { get; }
        public List<Student> Students { get; }

        public Classroom(string id)
        {
            Id = id;
            Students = new List<Student>();
        }

        public Classroom(string id, List<Student> students)
        {
            Id = id;
            Students = students;
        }
    }
}