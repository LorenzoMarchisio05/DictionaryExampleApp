using System;
using System.Collections.Generic;
using System.Linq;
using DictionaryExampleApp.Entity;
using DictionaryExampleApp.Validators;

namespace DictionaryExampleApp.Controllers
{
    public class ClassroomHandler
    {
        private readonly Dictionary<string, Classroom> _classrooms;

        public ClassroomHandler()
        {
            _classrooms = new Dictionary<string, Classroom>();
        }

        private bool TryAddClassroom(Classroom classroom)
        {
            try
            {
                _classrooms.Add(classroom.Id, classroom);
            
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool TryAddClassrooms(List<Classroom> classrooms)
        {
            try
            {
                foreach (Classroom classroom in classrooms)
                {
                    _classrooms.Add(classroom.Id, classroom);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Dictionary<string, Classroom> GetAllClassrooms()
        {
            return _classrooms.ToDictionary(
                    entry => entry.Key, 
                    entry => entry.Value );
        }

        public Classroom GetClassroomById(string id)
        {
            return _classrooms[id];
        }

        public Dictionary<string, List<Student>> GetStudentsPerClass()
        {
            Dictionary<string, List<Student>> studentsPerClass = new Dictionary<string, List<Student>>();
            
            foreach (string key in _classrooms.Keys)
            {
                List<Student> students = _classrooms[key].Students;
                studentsPerClass.Add(key , students);
            }

            return studentsPerClass;
        }

        public bool RemoveClassroomFromId(string id)
        {
            return _classrooms.Remove(id);
        }

        public bool CreateClass()
        {
            List<Student> students = new List<Student>();

            try
            {
                HandleClassIdInsertion(out string classId);
                
                HandleStudentsListCreation(students);
                
                Classroom classroom = new Classroom(classId, students);
                
                return TryAddClassroom(classroom);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void HandleStudentsListCreation(List<Student> students)
        {
            do
            {
                Console.Clear();

                students.Add(HandleStudentsCreation());
                
                Console.WriteLine(@"Digita ""esc"" per uscire dalla modalita di inserimento");
            } while (Console.ReadLine()?.Trim().ToLower() != "esc");
        }

        private Student HandleStudentsCreation()
        {
            HandleNameInsertion(out string name);
            HandleSurnameInsertion(out string surname);
            HandleAgeInsertion(out ushort age);
            return new Student(
                name,
                surname,
                age);
        }

        private void HandleClassIdInsertion(out string classId)
        {
            do
            {
                Console.Clear();
                Console.Write("Insersci l'id della nuova classe: ");
                classId = Console.ReadLine()?.Trim().ToUpper() ?? "";
            } while (_classrooms.ContainsKey(classId));
        }
        
        private void HandleClassIdSelection(out string classId)
        {
            do
            {
                Console.Clear();
                Console.Write("Insersci l'id della classe: ");
                classId = Console.ReadLine()?.Trim() ?? "";
            } while (!_classrooms.ContainsKey(classId));
        }

        private void HandleAgeInsertion(out ushort age)
        {
            do
            {
                Console.Write("Inserisci età: ");
            } while (!ushort.TryParse(Console.ReadLine()?.Trim(), out age));
        }

        private void HandleNameInsertion(out string name)
        {
            do
            {
                Console.Write("Inserisci nome: ");
                name = Console.ReadLine()?.Trim();
            } while (!NameValidator.Validate(name));
        }
        
        private void HandleSurnameInsertion(out string surname)
        {
            do
            {
                Console.Write("Inserisci cognome: ");
                surname = Console.ReadLine()?.Trim();
            } while (!NameValidator.Validate(surname));
        }

        public void AddStudentToClass()
        {
            HandleClassIdSelection(out string classId);
            _classrooms[classId].Students.Add(HandleStudentsCreation());
        }

        public bool RemoveAllClassrooms()
        {
            try
            {
                _classrooms.Clear();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }   
    }
}
