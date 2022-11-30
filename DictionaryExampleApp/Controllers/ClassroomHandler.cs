using System;
using System.Collections.Generic;
using System.Linq;
using DictionaryExampleApp.Entity;
using DictionaryExampleApp.Validators;

namespace DictionaryExampleApp.Controllers
{
    public class ClassroomHandler
    {
        /// <summary>
        /// Dictionary privato, readonly perche instanziato dal costruttore
        /// </summary>
        private readonly Dictionary<string, Classroom> _classrooms;

        public ClassroomHandler()
        {
            _classrooms = new Dictionary<string, Classroom>();
        }

        /// <summary>
        /// Funzione per l'aggiunta di una classe, accetta un tipo classroom vedi classe Classroom
        /// </summary>
        /// <param name="classroom">classe da aggiungere all'interno della nostra lista di classi</param>
        /// <returns>Ritorna true se l'aggiunta della classe avviene correttamente</returns>
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
        
        /// <summary>
        /// Funzione per l'aggiunta di un elenco di classi, accetta un tipo IEnumerable<Classroom> vedi classe Classroom
        /// </summary>
        /// <param name="classroom">Elenco di classi da aggiungere all'interno della nostra lista di classi</param>
        /// <returns>Ritorna true se l'aggiunta delle classi avviene correttamente</returns>
        public bool TryAddClassrooms(IEnumerable<Classroom> classrooms)
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

        /// <summary>
        /// Ritorna una copia del dictionary della classe, il tipo di retorno è un IReadOlyDictionary
        /// </summary>
        /// <returns>Ritorna un IReadOnlyDictionary per impedire la modifica dei valori</returns>
        public IReadOnlyDictionary<string, Classroom> GetAllClassrooms()
        {
            return _classrooms;
        }

        /// <summary>
        /// ottiene una classe dato un id
        /// </summary>
        /// <param name="id">id della classe da trovare</param>
        /// <returns>Ritorna la classe ricercata</returns>
        public Classroom GetClassroomById(string id)
        {
            
            return _classrooms[id];
        }

        /// <summary>
        /// Ritorna un IReadOnlyDictionay contenente un insieme di coppie chiave valore dove
        /// la chiave rappresenta la classe di appertenenza mentre il valore è una lista di studenti
        /// </summary>
        /// <returns>Ritorna un IReadOnlyDictionay<string, List<Students>> contentene un elenco di classi e studenti</returns>
        public IReadOnlyDictionary<string, List<Student>> GetStudentsPerClass()
        {
            Dictionary<string, List<Student>> studentsPerClass = new Dictionary<string, List<Student>>();
            
            foreach (string key in _classrooms.Keys)
            {
                List<Student> students = _classrooms[key].Students;
                studentsPerClass.Add(key , students);
            }

            return studentsPerClass;
        }

        /// <summary>
        /// Rimuove una clasee dal dictionary
        /// </summary>
        /// <param name="id">l'id della classe, rappresenta la chiave nel Dictionary</param>
        /// <returns>Ritorna l'esito della rimozione (true in caso di successo)</returns>
        public bool RemoveClassroomFromId(string id)
        {
            return _classrooms.Remove(id);
        }

        /// <summary>
        /// Funzione per la creazione di una nuova classe
        /// </summary>
        /// <returns>Ritorna l'esito della creazione</returns>
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

        /// <summary>
        /// Aggiunge uno studente ad una classe
        /// </summary>
        public void AddStudentToClass()
        {
            HandleClassIdSelection(out string classId);
            _classrooms[classId].Students.Add(HandleStudentsCreation());
        }

        /// <summary>
        /// Rimuove tutte le classi presenti nel dictionary
        /// </summary>
        /// <returns>Ritorna l'esito della rimozione</returns>
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
        
        #region Class creation backend

        

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

        #endregion
        
    }
}
