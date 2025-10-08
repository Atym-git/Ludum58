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

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            int index = _items.IndexOf(item);
            _items.Remove(item);
            _invoker.InvokeItemsRemap(_items);

        }
    }


}
