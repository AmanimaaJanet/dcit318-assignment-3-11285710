class Program
{
    static void Main(string[] args)
    {
        // i. Instantiate WareHouseManager
        WareHouseManager manager = new WareHouseManager();

        // ii. Call SeedData()
        manager.SeedData();

        // iii. Print all grocery items
        Console.WriteLine("Grocery Items:");
        manager.PrintAllItems(manager.GetGroceriesRepo());

        // iv. Print all electronic items
        Console.WriteLine("Electronic Items:");
        manager.PrintAllItems(manager.GetElectronicsRepo());

        // v. Try error scenarios
        try
        {
            manager.GetElectronicsRepo().AddItem(new ElectronicItem(1, "Duplicate", 5, "Test", 6));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        manager.RemoveItemById(manager.GetGroceriesRepo(), 999);

        try
        {
            manager.GetElectronicsRepo().UpdateQuantity(1, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}