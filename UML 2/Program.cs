using UML_2;

namespace UML2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting PizzaStore app");
            Console.WriteLine();
            Store store = new Store();
            store.Test();
            Console.WriteLine();
            Console.Write("Hit any key to continue with user dialog");
            Console.ReadKey();
            store.Run();
        }
    }
}
