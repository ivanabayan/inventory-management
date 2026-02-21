class InventoryView
{
    private InventoryService _service = new InventoryService();

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1) View Inventory");
            Console.WriteLine("2) Update Stock");
            Console.WriteLine("3) Reset Inventory");
            Console.WriteLine("4) Exit");
            Console.Write("\nChoose an option: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                ShowInventory();
            }
            else if (input == "2")
            {
                UpdateStock();
            }
            else if (input == "3")
            {
                _service.ResetToInitial();
                Console.WriteLine("All stock levels have been reset.");
            }
            else if (input == "4")
            {
                isRunning = false;
                Console.WriteLine("Program terminated.");
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }

    private void ShowInventory()
    {
        string[,] products = _service.GetProducts();
        Console.WriteLine("\nCurrent Inventory:");

        for (int i = 0; i < products.GetLength(1); i++)
        {
            Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
        }
    }

    private void UpdateStock()
    {
        ShowInventory();

        Console.Write("\nEnter the product number to update: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
        {
            string[,] products = _service.GetProducts();
            string name = products[0, choice - 1];

            Console.Write($"Enter new stock for {name}: ");
            string newQty = Console.ReadLine();

            _service.UpdateStock(choice - 1, newQty);
            Console.WriteLine($"{name} stock updated to {newQty}.");
        }
        else
        {
            Console.WriteLine("Invalid selection. Returning to menu.");
        }
    }
}
