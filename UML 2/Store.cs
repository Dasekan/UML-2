using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML2;

namespace UML_2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            Pizza p1 = new Pizza() { Id = 1, Name = "Margherita", Price = 50 };
            menuCatalog.Create(p1);
            Pizza p2 = new Pizza() { Id = 2, Name = "Mexicano", Price = 55 };
            menuCatalog.Create(p2);
            Pizza p3 = new Pizza() { Id = 3, Name = "Hawaii", Price = 65 };
            menuCatalog.Create(p3);

            menuCatalog.PrintMenu();

            Console.WriteLine();
            int pizzaToBeFound = 1;
            Console.WriteLine($"Finding Pizza# {pizzaToBeFound}");
            Pizza foundPizza = menuCatalog.Read(pizzaToBeFound);
            Console.WriteLine(foundPizza);

            Console.WriteLine();
            string searchCriteria = "H";
            Console.WriteLine($"Finding Pizza starting with: {searchCriteria}");
            List<Pizza> foundPizzas = menuCatalog.SearchPizza(searchCriteria);
            foreach (var pizza in foundPizzas)
            {
                Console.WriteLine(pizza);
            }

            Console.WriteLine();
            Console.WriteLine($"Updating Pizza #{foundPizza.Id}");
            foundPizza.Name += " (Updated)";
            menuCatalog.Update(foundPizza);

            Console.WriteLine();
            menuCatalog.PrintMenu();

            Console.WriteLine();
            int pizzaToBeDeleted = 2;
            Console.WriteLine($"Deleting pizza#: {pizzaToBeDeleted}");
            menuCatalog.Delete(pizzaToBeDeleted);
            Console.WriteLine();
            menuCatalog.PrintMenu();

        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();
        }
    }
}
