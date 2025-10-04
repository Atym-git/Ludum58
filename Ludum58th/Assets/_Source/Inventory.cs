using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class Inventory
{
    private static List<Item> _items = new();

    private static InventoryVisualizer _inventoryVisualizer;

    public Inventory(InventoryVisualizer inventoryVisualizer)
    {
        _inventoryVisualizer = inventoryVisualizer;
    }

    public static void AddItem(Item item)
    {
        _items.Add(item);
        int lastIndex = _items.Count - 1;
        _inventoryVisualizer.ShowInventoryItems(item.ItemSprite, lastIndex);
    }

    public void RemoveAtItem(int index)
    {
        if (_items[index] != null)
        {
            _items.RemoveAt(index);
        }
    }
    
}
