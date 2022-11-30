using System;
using System.Collections.Generic;
using DictionaryExampleApp.Entity;
using DictionaryExampleApp.Validators;
using DictionaryExampleApp.DataGenerators;

namespace DictionaryExampleApp.Controllers
{
    
    public sealed class App
    {
        private readonly ClassroomHandler _classroomHandler;
        public App(ClassroomHandler classroomHandler)
        {
            _classroomHandler = classroomHandler;

            // init 
            _classroomHandler.TryAddClassrooms(DataGenerator.Generate());
        }
        

        public void Run()
        {
            int scelta;
            do
            {
                Menu(out scelta);
                
                HandleScelta(scelta);

                if (scelta != 0) Console.ReadKey();
            } while (scelta != 0);
        }
        
        private static void Menu(out int scelta)
        {
            string[] options =
            {
                "0. Esci",
                "1. Aggiungi una classe",
                "2. Aggiungi uno studente ad una classe",
                "3. Mostra tutte le classi",
                "4. Mostra gli studenti di ogni classe",
                "5. Elimina una classe",
                "6. Elimina tutte le classi"
            };
            
            do
            {
                Console.Clear();
                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }   
                Console.Write("> ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > options.Length-1);
        }

        private void HandleScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    _classroomHandler.CreateClass();
                    break;
                case 2:
                    _classroomHandler.AddStudentToClass();
                    break;
                case 3:
                    var classrooms = _classroomHandler.GetAllClassrooms();
                    Console.WriteLine("Classrooms: ");
                    foreach (string classroomsId in classrooms.Keys)
                    {
                        Console.WriteLine(classroomsId);
                    }
                    break;
                case 4:
                    IReadOnlyDictionary<string, List<Student>> studentsPerClass = _classroomHandler.GetStudentsPerClass();

                    foreach (string key in studentsPerClass.Keys)
                    {
                        List<Student> students = studentsPerClass[key];
                        Console.WriteLine($"Class: {key}");
                        foreach (Student student in students)
                        {
                            Console.WriteLine($"\t{student.Fullname} {student.Age}");
                        }
                    }
                    break;
                case 5:
                    string id;
                    do
                    {
                        Console.Clear();
                        Console.Write("Inserisci id classe: ");
                        id = Console.ReadLine()?.Trim().ToUpper();
                    } while (!IdValidator.Validate(id));

                    Console.WriteLine(_classroomHandler.RemoveClassroomFromId(id)
                        ? "Classe rimossa con successo"
                        : "Errore nella rimozione della classe");

                    break;
                case 6:
                    Console.WriteLine(_classroomHandler.RemoveAllClassrooms()
                        ? "Successo rimozione tutte le classi"
                        : "Errore rimozioni classi");
                    break;
            }
        }
       
    }
}