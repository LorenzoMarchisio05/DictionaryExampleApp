using DictionaryExampleApp.Controllers;

namespace DictionaryExampleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var classroomHandler = new ClassroomHandler();
            var app = new App(classroomHandler);
            
            app.Run();
        }
    }
}
