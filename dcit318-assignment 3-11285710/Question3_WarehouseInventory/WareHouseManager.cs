public class WareHouseManager
{
    private InventoryRepository<ElectronicItem> _electronics;
    private InventoryRepository<GroceryItem> _groceries;

    public WareHouseManager()
    {
        _electronics = new InventoryRepository<ElectronicItem>();
        _groceries = new InventoryRepository<GroceryItem>();
    }

    public void SeedData()
    {
        // Add 2–3 items of each type
        _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
        _electronics.AddItem(new ElectronicItem(2, "Phone", 25, "Samsung", 12));
        _electronics.AddItem(new ElectronicItem(3, "Tablet", 15, "Apple", 12));

        _groceries.AddItem(new GroceryItem(1, "Milk", 50, DateTime.Now.AddDays(7)));
        _groceries.AddItem(new GroceryItem(2, "Bread", 30, DateTime.Now.AddDays(3)));
        _groceries.AddItem(new GroceryItem(3, "Eggs", 40, DateTime.Now.AddDays(14)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        List<T> items = repo.GetAllItems();
        foreach (T item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            T item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public InventoryRepository<ElectronicItem> GetElectronicsRepo()
    {
        return _electronics;
    }

    public InventoryRepository<GroceryItem> GetGroceriesRepo()
    {
        return _groceries;
    }
}