using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private static List<Item> _items = new();

    private static Invoker _invoker;

    public Inventory(Invoker invoker)
    {
        _invoker = invoker;
    }

    public static void AddItem(Item item)
    {
        _items.Add(item);
        int itemIndex = _items.Count - 1;
        _invoker.InvokeShowInv(item, itemIndex);
    }

    public void RemoveAtItem(int index)
    {
        if (_items[index] != null)
        {
            _items.RemoveAt(index);
        }
    }
    
}
