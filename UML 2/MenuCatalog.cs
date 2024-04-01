using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML2;

namespace UML_2
{
    public class MenuCatalog
    {
        private List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public Pizza Read(int id)
        {
            foreach (var pizza in _pizzas)
            {
                if (pizza.Id == id)
                {
                    return pizza;
                }
            }
            return null;
        }

        public void Update(Pizza updatedpizza)
        {
            for (int i = 0; i < _pizzas.Count; i++)
            {
                if (_pizzas[i].Id == updatedpizza.Id)
                {
                    _pizzas[i] = updatedpizza;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            _pizzas.RemoveAll(p => p.Id == id);
        }

        public List<Pizza> SearchPizza(string criteria)
        {
            List<Pizza> foundPizzas = new List<Pizza>();

            
                foreach (var pizza in _pizzas)
                {
                    if (pizza.Name.StartsWith(criteria, StringComparison.OrdinalIgnoreCase))
                    {
                        foundPizzas.Add(pizza);
                    }
                }
                return foundPizzas;
            
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas)
            {
                Console.WriteLine(p);
            }
        }
    }
}
    