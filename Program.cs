// See https://aka.ms/new-console-template for more information


using project1.Presentation;

namespace project1
{
    public class Program
    { 
        public static async Task Main(string[] args)
        {
            Display display = new Display();
            await display.ShowMenu();
        }
    }

}



