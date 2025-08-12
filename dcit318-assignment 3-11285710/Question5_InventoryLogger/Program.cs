using System;

class Program
{
    static void Main()
    {
        string filePath = "InventoryData.json";
        InventoryApp app = new InventoryApp(filePath);

        // Seed data and save it
        app.SeedSampleData();
        app.SaveData();

        // Simulate clearing memory (new instance)
        app = new InventoryApp(filePath);

        // Load data from file and print
        app.LoadData();
        app.PrintAllItems();
    }
}
