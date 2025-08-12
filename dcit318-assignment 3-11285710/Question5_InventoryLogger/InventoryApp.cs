using System;

public class InventoryApp
{
    private readonly InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-10)));
        _logger.Add(new InventoryItem(2, "Mouse", 25, DateTime.Now.AddDays(-5)));
        _logger.Add(new InventoryItem(3, "Keyboard", 15, DateTime.Now.AddDays(-2)));
        _logger.Add(new InventoryItem(4, "Monitor", 7, DateTime.Now.AddDays(-20)));
        _logger.Add(new InventoryItem(5, "Printer", 3, DateTime.Now.AddDays(-15)));
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        var items = _logger.GetAll();
        if (items.Count == 0)
        {
            Console.WriteLine("No inventory items found.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded:d}");
        }
    }
}
