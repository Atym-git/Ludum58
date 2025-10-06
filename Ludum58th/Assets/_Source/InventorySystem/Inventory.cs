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
            Debug.Log("Before removing Items Count: " + _items.Count);
            int index = _items.IndexOf(item);
            Debug.Log("Items Index of: " + index);
            _invoker.InvokeStopShowingInv(index);
            _items.Remove(item);
            Debug.Log("After removing Items Count: " + _items.Count);
            //for (int i = 0; i < _items.Count; i++)
            //{
            //    Debug.Log("Is Inside Cycle" + i);
            //    if (_items[i].ItemSprite == item.ItemSprite)
            //    {
                    
                    
            //        //Debug.Log("Item after removing: " + _items[i]);
            //        _invoker.InvokeStopShowingInv(i);
            //    }
            //    Debug.Log("_items[i].ItemSprite: " + _items[i].ItemSprite);
            //    Debug.Log("item.ItemSprite " + item.ItemSprite);
            //}

        }
    }
    
}
