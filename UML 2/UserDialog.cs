using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML2;

namespace UML_2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza GetNewPizza()
        {
            
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("|   Creating Pizza    |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter pizza name: ");
            string inputname = Console.ReadLine();
            try
            {
                

               
                foreach (char c in inputname)
                {
                    if (char.IsDigit(c))
                    {
                        {
                            throw new FormatException("Pizza name cannot contain numbers. Please try again.");
                        }
                    }
                } 
                
               

                pizzaItem.Name = inputname;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
                throw; 
            }

            

            


            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' Please try again using numbers - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Id = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' Please try again using numbers - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("| BIG MAMA'S PIZZAMENU |");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new pizza",
                "2. Print menu",
                "3. Delete a pizza",
                "4. Search for a pizza",
                "5. Update a pizza"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        _menuCatalog.PrintMenu();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        DeletePizza();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        SearchPizza();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        UpdatePizza();
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void DeletePizza()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("|     Deleting Pizza   |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter pizza ID to delete: ");
            string input = Console.ReadLine();
            try
            {
                
                int id = Convert.ToInt32(input); 

                _menuCatalog.Delete(id);
                Console.WriteLine($"Pizza with ID {id} deleted.");
            }
            catch (FormatException)
            {
                
                Console.WriteLine("Invalid ID entered. Please try again using numbers.");
            }
            
           
        }

        void SearchPizza()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("|     Search Pizza    |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter the first letter or the full name of the pizza you want to search for: ");
            string criteria = Console.ReadLine();
            var foundPizzas = _menuCatalog.SearchPizza(criteria);
            if (foundPizzas.Any())
            {
                Console.WriteLine("Found pizzas:");
                foreach (var pizza in foundPizzas)
                {
                    Console.WriteLine(pizza);
                }
            }
            else
            {
                Console.WriteLine("No pizzas found.");
            }
            
        }

        void UpdatePizza()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("|    Updating Pizza   |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter the pizza ID which you want to update: ");
            string idInput = Console.ReadLine();

            
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID entered. Please try again using numbers.");
                return; 
            }

            Pizza pizzaToUpdate = _menuCatalog.Read(id);
            if (pizzaToUpdate == null)
            {
                Console.WriteLine("Pizza not found.");
                return; 
            }

            
            Console.Write("Enter the new name for the pizza: ");
            string newName = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(newName) || !newName.Any(char.IsLetter))
            {
                Console.WriteLine("Please try again using letters.");
                return; 
            }

            
            Console.Write("Enter the new price for the pizza: ");
            string priceInput = Console.ReadLine();

            
            if (!double.TryParse(priceInput, out double newPrice))
            {
                Console.WriteLine("Invalid price entered. Please try again using numbers.");
                return; 
            }

            
            try
            {
                pizzaToUpdate.Name = newName; 
                pizzaToUpdate.Price = newPrice; 
                _menuCatalog.Update(pizzaToUpdate); 
                Console.WriteLine("Pizza updated successfully!"); 
            }
            catch (Exception ex) 
            {
                
                Console.WriteLine($"An error occurred while updating the pizza: {ex.Message}");
            }






        }
            
        
    }
}
