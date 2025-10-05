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
        for (int i = 0; i < _items.Count; i++)
        {
            Debug.Log("Item: " + i + _items[i]);
        }
        int itemIndex = _items.Count - 1;
        _invoker.InvokeShowInv(item, itemIndex);
    }

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Debug.Log("Is Inside Cycle" + i);
                if (_items[i].ItemSprite == item.ItemSprite)
                {
                    Debug.Log("Removing Item from inventory with index" + i);
                    _items.Remove(item);
                    _invoker.InvokeStopShowingInv(i);
                }
            }

        }
    }
    
}
