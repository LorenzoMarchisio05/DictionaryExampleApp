using DictionaryExampleApp.Controllers;

namespace DictionaryExampleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // creazione app e dependency
            var classroomHandler = new ClassroomHandler();
            var app = new App(classroomHandler);
            
            // avvio app
            app.Run();
        }
    }
}
