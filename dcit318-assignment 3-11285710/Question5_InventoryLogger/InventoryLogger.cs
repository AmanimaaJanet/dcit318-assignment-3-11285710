using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private readonly string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            using FileStream fs = new FileStream(_filePath, FileMode.Create);
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            JsonSerializer.Serialize(fs, _log, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("File not found. Starting with empty log.");
                _log = new List<T>();
                return;
            }

            using FileStream fs = new FileStream(_filePath, FileMode.Open);
            _log = JsonSerializer.Deserialize<List<T>>(fs) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
            _log = new List<T>();
        }
    }
}
